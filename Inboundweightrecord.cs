using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrintShipmentOrder
{
    /// <summary>
    /// 入库过磅记录，数据实体对象
    /// </summary>
    [Table("yb_inboundweightrecord")]
    [Serializable]
    public class Inboundweightrecord
    {
        /// <summary>
        /// 打印状态(未打印,已打印)
        /// </summary>
        public string printStatus { get; set; }
        /// <summary>
        /// 设置或获取进货编号
        /// </summary>
        public string EnCode { get; set; }

        /// <summary>
        /// 设置或获取合同编号
        /// </summary>
        public string ContractCode { get; set; }

        /// <summary>
        /// 设置或获取入库通知单ID
        /// </summary>
        public string InboundNoticeOrderId { get; set; }

        /// <summary>
        /// 设置或获取入库通知明细ID
        /// </summary>
        public string DetailId { get; set; }

        /// <summary>
        /// 设置或获取车牌号
        /// </summary>
        public string CarNo { get; set; }

        /// <summary>
        /// 设置或获取司机
        /// </summary>
        public string Driver { get; set; }

        /// <summary>
        /// 设置或获取司机电话
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// 设置或获取供应商ID
        /// </summary>
        public string SupplierId { get; set; }

        /// <summary>
        /// 设置或获取供应商Code
        /// </summary>
        public string SupplierCode { get; set; }

        /// <summary>
        /// 设置或获取供应商名称
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// 设置或获取部门
        /// </summary>
        public string DeptId { get; set; }

        /// <summary>
        /// 设置或获取部门编码
        /// </summary>
        public string DeptCode { get; set; }

        /// <summary>
        /// 设置或获取部门名称
        /// </summary>
        public string DeptName { get; set; }

        /// <summary>
        /// 设置或获取收货单位
        /// </summary>
        public string ReceiptUnit { get; set; }

        /// <summary>
        /// 设置或获取商品类别ID
        /// </summary>
        public string ProductCategoryId { get; set; }

        /// <summary>
        /// 设置或获取商品类别名称
        /// </summary>
        public string ProductCategoryName { get; set; }

        /// <summary>
        /// 设置或获取物料ID
        /// </summary>
        public string ProductSkuId { get; set; }

        /// <summary>
        /// 设置或获取物料编码
        /// </summary>
        public string ProductSkuCode { get; set; }

        /// <summary>
        /// 设置或获取物料名称
        /// </summary>
        public string ProductSkuName { get; set; }

        /// <summary>
        /// 设置或获取规格型号
        /// </summary>
        public string SpecDescription { get; set; }

        /// <summary>
        /// 设置或获取基本单位
        /// </summary>
        public string BasicUnit { get; set; }

        /// <summary>
        /// 设置或获取搅拌站ID
        /// </summary>
        public string MixingStationId { get; set; }

        /// <summary>
        /// 设置或获取搅拌站名称
        /// </summary>
        public string MixingStationName { get; set; }

        /// <summary>
        /// 设置或获取毛重
        /// </summary>
        public decimal? GrossWeight { get; set; }

        /// <summary>
        /// 设置或获取净重
        /// </summary>
        public decimal? NetWeight { get; set; }

        /// <summary>
        /// 设置或获取皮重
        /// </summary>
        public decimal? TareWeight { get; set; }

        /// <summary>
        /// 设置或获取扣杂重量
        /// </summary>
        public decimal? DeductWeight { get; set; }

        /// <summary>
        /// 设置或获取方量
        /// </summary>
        public decimal? Volume { get; set; }

        /// <summary>
        /// 设置或获取折方系数
        /// </summary>
        public decimal? ConvertRate { get; set; }

        /// <summary>
        /// 设置或获取扣减方量
        /// </summary>
        public decimal? DeductVolume { get; set; }

        /// <summary>
        /// 设置或获取货品单价
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// 设置或获取货品金额
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// 设置或获取供应商净重
        /// </summary>
        public decimal? SupplierNetWeight { get; set; }

        /// <summary>
        /// 设置或获取仓库ID
        /// </summary>
        public string WarehouseId { get; set; }

        /// <summary>
        /// 设置或获取仓库Code
        /// </summary>
        public string WarehouseCode { get; set; }

        /// <summary>
        /// 设置或获取仓库名称
        /// </summary>
        public string WarehouseName { get; set; }

        /// <summary>
        /// 设置或获取货位ID
        /// </summary>
        public string LocationId { get; set; }

        /// <summary>
        /// 设置或获取货位编码
        /// </summary>
        public string LocationCode { get; set; }

        /// <summary>
        /// 设置或获取货位名称
        /// </summary>
        public string LocationName { get; set; }

        /// <summary>
        /// 设置或获取结算方式
        /// </summary>
        public string SettleMethod { get; set; }

        /// <summary>
        /// 设置或获取里程
        /// </summary>
        public decimal Mileage { get; set; }

        /// <summary>
        /// 设置或获取进站时间
        /// </summary>
        public DateTime? InStation { get; set; }

        /// <summary>
        /// 设置或获取出站时间
        /// </summary>
        public DateTime? OutStation { get; set; }

        /// <summary>
        /// 设置或获取打印时间
        /// </summary>
        public DateTime? PrintTime { get; set; }

        /// <summary>
        /// 设置或获取备注
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 设置或获取是否去除皮重
        /// </summary>
        public bool? IsTare { get; set; }

        /// <summary>
        /// 设置或获取状态 0-未入库，1-已入库
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// 设置或获取打印状态，0-未打印；1-已打印
        /// </summary>
        public int? PrintStatus { get; set; }

        /// <summary>
        /// 设置或获取外部系统传输状态
        /// </summary>
        public string ExTransStatus { get; set; }

        /// <summary>
        /// 设置或获取外部系统传输返回报文
        /// </summary>
        public string ExTransResponse { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public int? SortCode { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public bool? DeleteMark { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public bool? EnabledMark { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public string CreatorUserId { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public string CreatorUserName { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public string LastModifyUserId { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public string DeleteUserId { get; set; }

    }
}
