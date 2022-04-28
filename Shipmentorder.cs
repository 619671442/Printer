
using System;
using System.Collections.Generic;
using System.Text;
namespace PrintShipmentOrder
{

    public class Shipmentorder
    {
        /// <summary>
        /// 打印状态(未打印,已打印)
        /// </summary>
        public string printStatus { get; set; }
        /// <summary>
        /// 设置或获取调度ID
        /// </summary>
        public string DispatchId { get; set; }

        /// <summary>
        /// 设置或获取调度序号(车次)
        /// </summary>
        public int DispatchNo { get; set; }

        /// <summary>
        /// 设置或获取外部票据单号
        /// </summary>
        public string ExCode { get; set; }

        /// <summary>
        /// 设置或获取调度编号(出库编号)
        /// </summary>
        public string DispatchCode { get; set; }

        /// <summary>
        /// 设置或获取订单ID
        /// </summary>
        public string SalesOrderId { get; set; }

        /// <summary>
        /// 设置或获取订单编号
        /// </summary>
        public string SalesOrderCode { get; set; }

        /// <summary>
        /// 设置或获取客户ID
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// 设置或获取客户编码
        /// </summary>
        public string CustomerCode { get; set; }

        /// <summary>
        /// 设置或获取客户名称
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 设置或获取工程ID
        /// </summary>
        public string ProjectId { get; set; }

        /// <summary>
        /// 设置或获取工程编码
        /// </summary>
        public string ProjectCode { get; set; }

        /// <summary>
        /// 设置或获取工程名称
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// 设置或获取强度等级ID
        /// </summary>
        public string StrengthLevelId { get; set; }

        /// <summary>
        /// 设置或获取强度编码
        /// </summary>
        public string StrengthLevelCode { get; set; }

        /// <summary>
        /// 设置或获取强度名称
        /// </summary>
        public string StrengthLevelName { get; set; }

        /// <summary>
        /// 设置或获取特殊品种ID
        /// </summary>
        public string SpecTypeId { get; set; }

        /// <summary>
        /// 设置或获取特殊品种编码
        /// </summary>
        public string SpecTypeCode { get; set; }

        /// <summary>
        /// 设置或获取特殊品种CODE
        /// </summary>
        public string SpecTypeName { get; set; }

        /// <summary>
        /// 设置或获取施工部位名称
        /// </summary>
        public string BuildPartName { get; set; }

        /// <summary>
        /// 设置或获取塌落度
        /// </summary>
        public string SlumpDegree { get; set; }

        /// <summary>
        /// 设置或获取施工地址
        /// </summary>
        public string BuildAddress { get; set; }

        /// <summary>
        /// 设置或获取工地电话
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// 设置或获取施工方式
        /// </summary>
        public string BuildMethod { get; set; }

        /// <summary>
        /// 设置或获取运输距离
        /// </summary>
        public decimal? Distance { get; set; }

        /// <summary>
        /// 设置或获取搅拌站ID
        /// </summary>
        public string MixingStationId { get; set; }

        /// <summary>
        /// 设置或获取搅拌站编码
        /// </summary>
        public string MixingStationCode { get; set; }

        /// <summary>
        /// 设置或获取搅拌站名称
        /// </summary>
        public string MixingStationName { get; set; }

        /// <summary>
        /// 设置或获取磅单标题
        /// </summary>
        public string PoundTitle { get; set; }

        /// <summary>
        /// 设置或获取是否已打印
        /// </summary>
        public bool? IsPrint { get; set; }

        /// <summary>
        /// 设置或获取现场签收人
        /// </summary>
        public string Signer { get; set; }

        /// <summary>
        /// 设置或获取签收时间
        /// </summary>
        public DateTime? SignTime { get; set; }

        /// <summary>
        /// 设置或获取备注
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 设置或获取车号
        /// </summary>
        public string CarCode { get; set; }

        /// <summary>
        /// 设置或获取车牌号
        /// </summary>
        public string CarNo { get; set; }

        /// <summary>
        /// 设置或获取司机
        /// </summary>
        public string Driver { get; set; }

        /// <summary>
        /// 设置或获取发货时间
        /// </summary>
        public DateTime? ShipTime { get; set; }

        /// <summary>
        /// 设置或获取发货数量
        /// </summary>
        public decimal? ShipQty { get; set; }

        /// <summary>
        /// 设置或获取毛重
        /// </summary>
        public decimal? GrossWeight { get; set; }

        /// <summary>
        /// 设置或获取净重
        /// </summary>
        public decimal? NetWeight { get; set; }

        /// <summary>
        /// 设置或获取方量
        /// </summary>
        public decimal? Volume { get; set; }

        /// <summary>
        /// 设置或获取累计方量
        /// </summary>
        public decimal? GrandTotalVolume { get; set; }

        /// <summary>
        /// 设置或获取累计车次
        /// </summary>
        public decimal? GrandTotalNum { get; set; }

        /// <summary>
        /// 设置或获取过磅时间
        /// </summary>
        public DateTime? WeighTime { get; set; }

        /// <summary>
        /// 设置或获取司磅员ID
        /// </summary>
        public string WeighUserId { get; set; }

        /// <summary>
        /// 设置或获取司磅员姓名
        /// </summary>
        public string WeighUserName { get; set; }

        /// <summary>
        /// 设置或获取送货前皮重
        /// </summary>
        public decimal? BeforeTareWeight { get; set; }

        /// <summary>
        /// 设置或获取皮重时间
        /// </summary>
        public DateTime? BeforeTareTime { get; set; }

        /// <summary>
        /// 设置或获取司磅员ID
        /// </summary>
        public string BeforeWeighUserId { get; set; }

        /// <summary>
        /// 设置或获取司磅员名称(皮重)
        /// </summary>
        public string BeforeWeighUserName { get; set; }

        /// <summary>
        /// 设置或获取送货后皮重
        /// </summary>
        public decimal? AfterTareWeight { get; set; }

        /// <summary>
        /// 设置或获取皮重时间
        /// </summary>
        public DateTime? AfterTareTime { get; set; }

        /// <summary>
        /// 设置或获取司磅员ID
        /// </summary>
        public string AfterWeighUserId { get; set; }

        /// <summary>
        /// 设置或获取司磅员姓名
        /// </summary>
        public string AfterWeighUserName { get; set; }

        /// <summary>
        /// 设置或获取代理ID
        /// </summary>
        public string AgentId { get; set; }

        /// <summary>
        /// 设置或获取代理名称
        /// </summary>
        public string AgentName { get; set; }

        /// <summary>
        /// 设置或获取状态;0-等待中;1-送货中；2-已完成
        /// </summary>
        public int Status { get; set; }

        public int WeightStatus { get; set; }

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
        public DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public string LastModifyUserId { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public bool? DeleteMark { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public string DeleteUserId { get; set; }

        public string StatusText { get; set; }

        public decimal? ChangeRate { get; set; }//折方系数

        public bool IsFreight { get; set; }

        public decimal? MortarVolume { get; set; }

    }
}
