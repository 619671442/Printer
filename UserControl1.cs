using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using PrintShipmentOrder;
using System.Data.OleDb;
using Yb.StmsWeight.App;

namespace Printer
{
    public partial class UserControl1 : UserControl
    {
       
        private PrintDocument printDocument1;

        private PrintDialog printDialog1;

        private PrintPreviewDialog printPreviewDialog1;

        public string send_id;

        public string id;
        public string shipmentorderId;

        public string take_unit;

        public string proj_name;

        public string strong_lv;

        public string prod_addr;

        public string proj_area;

        public string tanluo_lv;

        public string jiaozhu_type;

        public string all_weight;

        public string car_weight;

        public string send_weight;

        public string send_count;

        public string car_num;

        public string driver_name;

        public string handle_man;

        public string time;

        public string add_count;

        public string add_car;

        public string weight_title;

        public string zf_ratio;

        public string constr;

        public string ht_num;

        public string pinzhong;

        public string station;

        private int sub = 0;

        private string excelDataType = "1";//文件数据类型  1：发货单(默认)  2 收货单

        private string excelFileName;//文件路径

        private string printName;//操作人

        private int showindex = 0;//当前展示数据的下标
        private List<Shipmentorder> orderList = new List<Shipmentorder>();//所有单据信息
        private Shipmentorder order = new Shipmentorder();//当前单据信息
        private PrintForm w1;//子窗体
                             //private ImageList imageList1 = new ImageList();

        public UserControl1()
        {
            InitializeComponent();
        }
        public void Show(string excelDataType)
        {
            this.radioButton1.Checked = true;
            this.excelDataType = excelDataType;
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            int num = 60;
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                printDocument1.DocumentName = "单据:" + order.DispatchCode;
                printDocument1.Print();

            }
            catch (Exception ex)
            {

                MessageBox.Show(string.Format("打印异常:{0}", ex));
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void PrintShipmentorderForm_Load(object sender, EventArgs e)
        {
            //设置列表表头 
            this.listView1.Columns.Add("行号", 50, HorizontalAlignment.Left); //一步添加
            this.listView1.Columns.Add("状态", 50, HorizontalAlignment.Left); //一步添加
            this.listView1.Columns.Add("时间", 120, HorizontalAlignment.Left); //一步添加
            this.listView1.Columns.Add("编号", 120, HorizontalAlignment.Left); //一步添加
            this.listView1.Columns.Add("收货单位", 120, HorizontalAlignment.Left); //一步添加
            this.listView1.Columns.Add("工程名称", 120, HorizontalAlignment.Left); //一步添加
            this.listView1.BeginUpdate(); //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
            this.listView1.Items.Clear();//先清空数据

            this.listView1.EndUpdate();
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

            textBox1.Text = order.DispatchCode;
            textBox2.Text = order.SalesOrderCode;
            textBox3.Text = order.WeighTime.ToString();
            textBox4.Text = order.CustomerName;
            textBox5.Text = order.ProjectName;
            textBox6.Text = order.StrengthLevelName;
            txt_tspz.Text = order.SpecTypeName;
            textBox7.Text = order.BuildAddress;
            textBox8.Text = order.BuildPartName;
            textBox9.Text = order.SlumpDegree;
            textBox10.Text = order.BuildMethod;
            textBox11.Text = order.GrossWeight + "";
            textBox12.Text = order.BeforeTareWeight + "";
            textBox13.Text = order.NetWeight + "";
            textBox14.Text = order.Volume + "";
            textBox15.Text = order.CarNo;
            textBox16.Text = order.Driver;
            textBox19.Text = order.WeighUserName;
            textBox17.Text = order.GrandTotalNum + "";
            textBox18.Text = order.GrandTotalVolume + "";
            textBox22.Text = order.PoundTitle + "";
            textBox_add_info.Text = order.Note;


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
                        lvi.SubItems.Add(orderList[i].WeighTime.ToString());//时间
                        lvi.SubItems.Add(orderList[i].DispatchCode);//编号
                        lvi.SubItems.Add(orderList[i].CustomerName);//收货单位
                        lvi.SubItems.Add(orderList[i].ProjectName);//工程名称
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
            String Configure = "发货单";

            StringBuilder sql = new StringBuilder("select ");
            ReadIni readini = new ReadIni();
            String[] strs = new string[] { "磅单抬头", "编号", "序号", "时间", "收货单位", "工程名称", "强度等级", "特殊品种", "交货地点", "浇筑部位", "坍落度", "浇筑方式", "毛重", "皮重", "净重", "数量", "车号", "司机", "车次", "累计数量", "操作员", "备注" };
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

                    Shipmentorder order = new Shipmentorder();
                    order.PoundTitle = reader.GetString(0) + Configure; //磅单抬头 
                    order.DispatchCode = reader.GetString(1); //    编号  
                    order.SalesOrderCode = reader.GetString(2); //序号 
                    order.WeighTime = reader.GetDateTime(3);  //时间  
                    order.CustomerName = reader.GetString(4); //收货单位 
                    order.ProjectName = reader.GetString(5); //工程名称    
                    order.StrengthLevelName = reader.GetString(6); //强度等级 
                    order.SpecTypeName = reader.GetString(7); //tspz
                    order.BuildAddress = reader.GetString(8); //交货地点    
                    order.BuildPartName = reader.GetString(9); //浇筑部位 
                    order.SlumpDegree = reader.GetString(10); //坍落度 
                    order.BuildMethod = reader.GetString(11); //浇筑方式 
                    order.GrossWeight = Convert.ToDecimal(reader.GetDouble(12)); //毛重  
                    order.BeforeTareWeight = Convert.ToDecimal(reader.GetDouble(13)); //皮重 
                    order.NetWeight = Convert.ToDecimal(reader.GetDouble(14)); //净重  
                    order.Volume = Convert.ToDecimal(reader.GetDouble(15)); //数量 
                    order.CarNo = reader.GetString(16); //车号
                    order.Driver = reader.GetString(17); //    司机 
                    order.GrandTotalNum = Convert.ToDecimal(reader.GetDouble(18)); //车次  
                    order.GrandTotalVolume = Convert.ToDecimal(reader.GetDouble(19)); //累计数量 
                    order.WeighUserName = reader.GetString(20); //操作员
                    if (!String.IsNullOrEmpty(reader.GetString(21)))
                    {
                        order.Note = "车编号(" + reader.GetString(21) + ")"; //备注  
                    }
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

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {


        }
    }
}
