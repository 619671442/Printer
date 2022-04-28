using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrintShipmentOrder;
using Printer;
using System.Data.OleDb;
namespace Yb.StmsWeight.App
{
    public partial class PrintForm : Form
    {
        public string cz_time;

        public string in_num;

        public string send_goods;

        public string goods_name;

        public string goods_spec;

        public string fangliang;

        public string zhijian;

        public string beizhu;

        public string all_weight;

        public string car_weight;

        public string send_weight;

        public string car_num;

        public string driver_name;

        public string handle_man;

        public string zf;

        public string title;

        public string constr;

        public string kouzhong;

        public string encode;

        private int sub = 0;

        private PrintDocument printDocument1;

        private PrintDialog printDialog1;

        private PrintPreviewDialog printPreviewDialog1;

        private string excelDataType = "2";//文件数据类型  1：发货单  2 收货单(默认)

        private string excelFileName;//文件路径

        private string printName;//操作人

        private int showindex = 0;//当前展示数据的下标
        private List<Inboundweightrecord> orderList = new List<Inboundweightrecord>();//所有单据信息
        private Inboundweightrecord order = new Inboundweightrecord();//当前单据信息

        private PrintShipmentOrderForm mainwindow;
        private RadioButton radioButton;
        public PrintForm()
        {

            InitializeComponent();
            foreach (var item in PrinterSettings.InstalledPrinters)
            {
                this.comboBox1.Items.Add(item);
            }
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            int num = 80;
            int num2 = 20;
            graphics.DrawImage(panel1.BackgroundImage, 30, 10);
            foreach (Control control3 in panel1.Controls)
            {
                if (control3 is TextBox)
                {
                    Control control2 = control3;
                    graphics.DrawString(control2.Text, control2.Font, Brushes.Black, control2.Left + num, control2.Top + num2);
                }
            }
        }
        private void printText(string text, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            int left = e.PageSettings.Margins.Left;
            int right = e.PageSettings.Margins.Right;
            int num = e.PageSettings.PaperSize.Width - e.PageSettings.Margins.Left - e.PageSettings.Margins.Right;
            int num2 = e.PageSettings.PaperSize.Height - e.PageSettings.Margins.Top - e.PageSettings.Margins.Bottom;
            Font font = new Font("宋体", 15f);
            graphics.MeasureString(text.Substring(sub), font, new SizeF(num, num2 - 10), new StringFormat(), out var charactersFitted, out var _);
            graphics.DrawString(text.Substring(sub), font, Brushes.Black, new RectangleF(left, right, num, num2), new StringFormat());
            sub += charactersFitted;
            if (sub < textBox1.Text.Length)
            {
                e.HasMorePages = true;
                return;
            }
            e.HasMorePages = false;
            sub = 0;
        }
        private void PrintShipmentorderForm_Load(object sender, EventArgs e)
        {
            //设置列表表头 
            this.listView1.Columns.Add("行号", 50, HorizontalAlignment.Left); //一步添加
            this.listView1.Columns.Add("状态", 50, HorizontalAlignment.Left); //一步添加
            this.listView1.Columns.Add("时间", 120, HorizontalAlignment.Left); //一步添加
            this.listView1.Columns.Add("编号", 120, HorizontalAlignment.Left); //一步添加
            this.listView1.Columns.Add("供应商", 120, HorizontalAlignment.Left); //一步添加
            this.listView1.Columns.Add("收货单位", 120, HorizontalAlignment.Left); //一步添加
            this.listView1.BeginUpdate(); //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
            this.listView1.Items.Clear();//先清空数据

            this.listView1.EndUpdate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(comboBox1.SelectedItem + ""))
                {
                    MessageBox.Show("请先选择打印机");
                    this.timer1.Stop();
                    return;
                }
                if (string.IsNullOrEmpty(order.SupplierName))
                {
                    MessageBox.Show("请先选择文件");
                    this.timer1.Stop();
                    return;
                }
                printDocument1.PrinterSettings.PrinterName = comboBox1.SelectedItem.ToString();
                printDocument1.DocumentName = "单据:" + order.EnCode;
                printDocument1.Print();

            }
            catch (Exception ex)
            {

                MessageBox.Show(string.Format("打印异常:{0}", ex));
            }
        }
        //加载当前单据信息
        private void loadDataToForm(int index)
        {
            if (orderList.Count > index)
            {
                order = orderList[index];
            }
            this.loadOrderDataToForm();
            this.loadListDataToForm(index);


        }
        //加载当前单据信息
        private void loadOrderDataToForm()
        {

            textBox1.Text = order.InStation.ToString();
            textBox3.Text = order.EnCode;
            textBox4.Text = order.SupplierName;
            textBox5.Text = order.CarNo;
            textBox6.Text = order.ProductSkuName;
            textBox7.Text = order.SpecDescription;
            fangliang = String.IsNullOrEmpty(order.Volume.ToString()) ? "0" : order.Volume.ToString();

            textBox8.Text = fangliang + " 方";

            textBox9.Text = order.GrossWeight.ToString();
            textBox10.Text = order.TareWeight.ToString();
            textBox11.Text = order.NetWeight.ToString();
            textBox12.Text = order.CreatorUserName;
            textBox14.Text = order.Driver;
            textBox15.Text = order.Note;

            String mixingStationName = order.MixingStationName;
            switch (mixingStationName)
            {
                case "太龙站":
                    title = "1";
                    break;
                case "山立站":
                    title = "2";
                    break;
                case "伟治站":
                    title = "3";
                    break;
                case "松大站":
                    title = "5";
                    break;
            }
            textBox16.Text = "备注" + title;
            //kouzhong = order.DeductWeight;
            if (kouzhong != "")
            {
                textBox18.Text = "扣杂: " + kouzhong + " Kg";
            }



        } //加载当前单据信息
        private void loadListDataToForm(int index)
        {


            this.listView1.BeginUpdate(); //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
            this.listView1.Items.Clear();//先清空数据
            try
            {


                if (orderList.Count > 0)
                {

                    for (int i = 0; i < orderList.Count; i++)
                    {
                        ListViewItem lvi = new ListViewItem();

                        //lvi.ImageIndex = i;     //通过与imageList绑定，显示imageList中第i项图标
                        lvi.Text = (i).ToString();
                        lvi.SubItems.Add(orderList[i].printStatus);//状态
                        lvi.SubItems.Add(orderList[i].InStation.ToString());//时间
                        lvi.SubItems.Add(orderList[i].EnCode);//编号
                        lvi.SubItems.Add(orderList[i].SupplierName);//供应商
                        lvi.SubItems.Add(orderList[i].ReceiptUnit);//收货单位
                        this.listView1.Items.Add(lvi);//添加数据
                    }


                    //this.listView1.SmallImageList = this.imageList1;  //将listView的图标集与imageList1绑定

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("加载异常:{0}", ex.Message));
            }

            this.listView1.EndUpdate();


        }
        private void button3_Click(object sender, EventArgs e)
        {



            OpenFileDialog importOpenFileDialog = new OpenFileDialog();
            importOpenFileDialog.Filter = "excel文件(*.xlsx)|*.xlsx";
            DialogResult importDialogResult = importOpenFileDialog.ShowDialog();
            if (importDialogResult == DialogResult.OK)
            {
                excelFileName = importOpenFileDialog.FileName;
                this.textBox21.Text = excelFileName;

                BackgroundWorker worker = new BackgroundWorker();
                worker.WorkerSupportsCancellation = true;

                //CheckUpdate为窗体显示过程中需要处理算法的方法
                worker.DoWork += new DoWorkEventHandler(readExcel);
                worker.RunWorkerAsync();

                //显示进度窗体
                Form_Progress f = new Form_Progress(worker);
                f.Text = "正在加载。。。。。。";
                f.ShowDialog(this);
                this.loadDataToForm(0);//加载数据到窗体

            }
        }
        private void appendSql(StringBuilder sql, String str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                sql.Append(str + ",");
            }
            else
            {
                sql.Append(" '',");
            }
        }
        private void readExcel(object sender, DoWorkEventArgs e)
        {


            string inifile = System.AppDomain.CurrentDomain.BaseDirectory + "config.ini";
            String Configure = "收货单";
            StringBuilder sql = new StringBuilder("select ");
            ReadIni readini = new ReadIni();
            //String[] strs = new string[] { "磅单抬头",  "序号", "时间", "编号", "供货单位", "车号", "品名", "等级", "方量",  "毛重", "皮重", "净重", "计量员", "质检员", "司机", "备注", "扣杂" };
            String[] strs = new string[] { "时间", "编号", "供货单位", "车号", "品名", "等级", "方量", "毛重", "皮重", "净重", "计量员", "质检员", "司机", "备注", "扣杂", "收货单位","站名" };
            foreach (String str in strs)
            {
                this.appendSql(sql, readini.ReadIniData(Configure, str, null, "" + inifile + ""));

            }
            sql.Remove(sql.Length - 1, 1);
            String sheetname = readini.ReadIniData(Configure, "sheetname", null, "" + inifile + "");
            sql.Append("  from " + sheetname);


            orderList.Clear();
            String sqlstr = sql.ToString();

            string fileType = System.IO.Path.GetExtension(excelFileName);

            string strCon = string.Format("Provider=Microsoft.ACE.OLEDB.{0}.0;" +
                        "Extended Properties=\"Excel {1}.0;IMEX=1;\";" +
                        "data source={2};",
                        (fileType == ".xls" ? 4 : 12), (fileType == ".xls" ? 8 : 12), excelFileName);
            OleDbConnection conn = null;
            try
            {

                conn = new OleDbConnection(strCon);
                conn.Open();
                OleDbCommand command = conn.CreateCommand();

                command.CommandText = sqlstr;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Inboundweightrecord order = new Inboundweightrecord();
                    order.InStation = reader.GetDateTime(0);//时间
                    order.EnCode = reader.GetString(1);//编号
                    order.SupplierName = reader.GetString(2);//供货单位
                    order.CarNo = reader.GetString(3);//车号
                    order.ProductSkuName = reader.GetString(4);//品名
                    order.SpecDescription = reader.GetString(5); //等级
                    order.Volume = Convert.ToDecimal(reader.GetDouble(6)); //方量
                    order.GrossWeight = Convert.ToDecimal(reader.GetDouble(7)); //毛重
                    order.TareWeight = Convert.ToDecimal(reader.GetDouble(8)); //皮重
                    order.NetWeight = Convert.ToDecimal(reader.GetDouble(9));//净重
                    String dataTypeNam = reader.GetDataTypeName(10);
                    if (dataTypeNam == "DBTYPE_R8")
                    {
                        order.CreatorUserName = reader.GetDouble(10).ToString();//计量员
                        order.CreatorUserName = reader.GetDouble(11).ToString();//质检员
                    }
                    else
                    {

                        order.CreatorUserName = reader.GetString(10);//计量员
                        order.CreatorUserName = reader.GetString(11);//质检员
                    }
                    order.Driver = reader.GetString(12);//司机
                    order.Note = reader.GetString(13); //备注
                    String dataTypeNam2 = reader.GetDataTypeName(14);
                    if (dataTypeNam == "DBTYPE_R8")
                    {
                        try {
                            order.DeductWeight = Convert.ToDecimal(reader.GetDouble(14)); //扣杂
                        } catch(Exception) {
                        }

                           
                      
                    }
                    else if (dataTypeNam == "DBTYPE _ WSTR")
                    {
                        order.DeductWeight = Convert.ToDecimal(reader.GetString(14)); //扣杂
                    }
                    else
                    {
                        order.DeductWeight = null;
                    }
                    order.ReceiptUnit = reader.GetString(15); //收货单位
                    order.MixingStationName = reader.GetString(16); //站名


                    order.printStatus = "未打印";
                    orderList.Add(order);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("解析文件异常:{0}", ex.Message));
            }
            finally
            {
                if (null != conn)
                {

                    conn.Close();
                }
            }

        }
        //从x行开始连续打印
        private void button4_Click(object sender, EventArgs e)
        {
            int inputnum = 0;
            int inputs = 0;//间隔秒
            try
            {
                inputnum = int.Parse(this.textBox23.Text);
                inputs = int.Parse(this.textBox24.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("请输入整数");
                return;
            }
            if (inputnum < 0)
            {
                MessageBox.Show("请输入>=0的整数");
                return;
            }
            if (orderList.Count <= inputnum)
            {
                MessageBox.Show(String.Format("只有{0}行数据", orderList.Count.ToString()));
                return;
            }

            showindex = inputnum;



            timer1.Tick += new EventHandler(CallBack);
            timer1.Enabled = true;
            timer1.Interval = inputs * 1000;
            this.timer1.Start();


        }
        private void CallBack(object sender, EventArgs e)
        {
            try
            {
                this.listView1.Items[showindex - 1].SubItems[1].Text = "已打印";
            }
            catch (Exception)
            {

                this.timer1.Stop();
            }
        }
        private void timer1do(object sender, EventArgs e)
        {
            for (int i = 0; i < orderList.Count; i++)
            {
                if (i == showindex)
                {

                    this.listView1.Items[i].Selected = true;//选中行
                    this.listView1.EnsureVisible(i);//滚动到指定的行位置
                }
                else
                {
                    this.listView1.Items[i].Selected = false;//选中行
                }
            }

            listView1.Focus();
            showindex = showindex + 1;
            int current = showindex;
            if (current > orderList.Count)
            {
                this.timer1.Stop();
                MessageBox.Show("打印结束");
                return;
            }
            this.order = orderList[current - 1];
            this.loadOrderDataToForm();
            button1_Click(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {


            String text = this.listView1.FocusedItem.Text;
            order = orderList[int.Parse(text)];
            this.loadOrderDataToForm();
            this.textBox23.Text = text;

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            radioButton.Checked = true;
            mainwindow.Show();//显示主窗口
            this.Close();
        }

        private void PrintForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
