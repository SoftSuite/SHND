using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace SHND.Data.Common.Utilities
{
    public class Constant
    {
        public const string CultureSessionID = "SHNDCulture";
        public const string ApplicationErrorSessionID = "ErrorMessage";
        public const string IntFormat = "#,##0";
        public const string DoubleFormat = "#,##0.00";
        public const string DateFormat = "dd/MM/yyyy";

        public static string HomeFolder
        {
            get { return System.Web.HttpContext.Current.Request.ApplicationPath + "/"; }
        }

        public static string ImageFolder
        {
            get { return HomeFolder + "Images/"; }
        }

        public static string AttachWebURL
        {
            get { return ConfigurationManager.AppSettings["AttachWebURL"].ToString(); }
        }

        public static string AttachPhysical
        {
            get { return ConfigurationManager.AppSettings["AttachPhysical"].ToString(); }
        }

        public static string ReportWebUrl
        {
            get { return ConfigurationManager.AppSettings["WEB_REPORTS"].ToString(); }
        }

        public partial class StatusColor
        {
            public static System.Drawing.Color Information
            {
                get { return System.Drawing.Color.Green; }
            }
            public static System.Drawing.Color Error
            {
                get { return System.Drawing.Color.Red; }
            }
        }

        public partial class CultureName
        {
            public const string Default = "th-TH";
            public const string English = "en-US";
            public const string Thai = "th-TH";
        }

        public partial class Selected
        {
            public const string Yes = "1";
            public const string No = "0";
        }

        public partial class Active
        {
            public const string Yes = "1";
            public const string No = "0";
        }

        public partial class MessageType
        {
            public const string Error = "E";
            public const string Information = "I";
        }

        public partial class QueryString
        {
            public const string ReportName = "reportname";
            public const string ReportKey = "reportkey";
            public const string Loid = "loid";
        }

        public partial class Reports
        {
            public const string BillingReport = "BillingReport";
            public const string ChangeVegetable = "ChangeVegetable";
            public const string ContainerUseQtyDate = "ContainerUseQtyDate";
            public const string ContainerUseQtyMonth = "ContainerUseQtyMonth";
            public const string ContainerUseQtyYear = "ContainerUseQtyYear";
            public const string CompareInterest = "CompareInterest";
            public const string CutOrderReport = "CutOrderReport";
            public const string FormularFeedBDReport = "FormularFeedBDReport";
            public const string FormulaFeedMDReport = "FormulaFeedMDReport";
            public const string FormulaMilkReport = "FormulaMilkReport";
            public const string FormulaSetReport = "FormulaSetReport";
            public const string MaterialBD = "MaterialBD";
            public const string MaterialCM = "MaterialCM";
            public const string MaterialFeedReport = "MaterialFeedReport";
            public const string MaterialFoodReport = "MaterialFoodReport";
            public const string MaterialMilk = "MaterialMilk";
            public const string MaterialOrderDivision = "MaterialOrderDivision";
            public const string MaterialOrderSum = "MaterialOrderSum";
            public const string MaterialOrderRemainDivision = "MaterialOrderRemainDivision";
            public const string MaterialOrderRemainSum = "MaterialOrderRemainSum";
            public const string MaterialRemain = "MaterialRemain";
            public const string MaterialToolReport = "MaterialToolReport";
            public const string MaterialSeason = "MaterialSeason";
            public const string MaterialUseQtyClass = "MaterialUseQtyClass";
            public const string MaterialUseQtyMonth = "MaterialUseQtyMonth";
            public const string MaterialUseQtyDate = "MaterialUseQtyDate";
            public const string MaterialUseQtyYear = "MaterialUseQtyYear";
            public const string MaterialWelfareReport = "MaterialWelfareReport";
            public const string MedChargeDate = "MedChargeDate";
            public const string MedChargeMonth = "MedChargeMonth";
            public const string MedChargeYear = "MedChargeYear";
            public const string MedChargeTotalDate = "MedChargeTotalDate";
            public const string MedChargeTotalMonth = "MedChargeTotalMonth";
            public const string MedChargeTotalYear = "MedChargeTotalYear";
            public const string MedFeedChargeReport = "MedFeedChargeReport";
            public const string MenuFormulaReport = "MenuFormulaReport";
            public const string MenuPortionReport = "MenuPortionReport";
            public const string MenuPrepare = "MenuPrepare";
            public const string MenuReport_1 = "MenuReport_1";
            public const string MenuReport_2 = "MenuReport_2";
            public const string MenuWelfareReport = "MenuWelfareReport";
            public const string OrderMilkListReport = "OrderMilkListReport";
            public const string OrderFeedListReport = "OrderFeedListReport";
            public const string OrderFeedSlipReport = "OrderFeedSlipReport";
            public const string OrderFoodReport = "OrderFoodReport";
            public const string OrderSetListReport = "OrderSetListReport";
            public const string OrderSetSlipReport = "OrderSetSlipReport";
            public const string PatientNutrientReport = "PatientNutrientReport";
            public const string PatientQtyFeedDate = "PatientQtyFeedDate";
            public const string PatientQtyFeedMonth = "PatientQtyFeedMonth";
            public const string PatientQtyFeedYear = "PatientQtyFeedYear";
            public const string PatientQtyMilkDate = "PatientQtyMilkDate";
            public const string PatientQtyMilkMonth = "PatientQtyMilkMonth";
            public const string PatientQtyMilkYear = "PatientQtyMilkYear";
            public const string PatientSetQtyDate = "PatientSetQtyDate";
            public const string PatientSetQtyMonth = "PatientSetQtyMonth";
            public const string PatientSetQtyYear = "PatientSetQtyYear";
            public const string PatientQtyTypeFeedDate = "PatientQtyTypeFeedDate";
            public const string PatientQtyTypeFeedMonth = "PatientQtyTypeFeedMonth";
            public const string PatientQtyTypeFeedYear = "PatientQtyTypeFeedYear";
            public const string PlanOrderReport = "PlanOrderReport";
            public const string PlanOrderToolsReport = "PlanOrderToolsReport";
            public const string PreparePartyReport = "PreparePartyReport";
            public const string PrepareReturnReport = "PrepareReturnReport";
            public const string PrepareSet = "PrepareSet";
            public const string PrepareWeightAfterReport = "PrepareWeightAfterReport";
            public const string QuotationReport = "QuotationReport";
            public const string QuotationFormReport = "QuotationFormReport";
            public const string QuotationToolsReport = "QuotationToolsReport";
            public const string RepairFrequency = "RepairFrequency";
            public const string RepairList = "RepairList";
            public const string RepPO = "RepPO";
            public const string RepPrePO = "RepPrePO";
            public const string RepReceive = "RepReceive";
            public const string RepRepairRequest = "RepRepairRequest";
            public const string RepStockinReturn = "RepStockinReturn";
            public const string RepStockOut = "RepStockOutReport";
            public const string RequisitionMaterialDayReport = "RequisitionMaterialDayReport";
            public const string RequisitionMaterialMonthReport = "RequisitionMaterialMonthReport";
            public const string RequisitionMaterialYearReport = "RequisitionMaterialYearReport";
            public const string RequisitionMaterialList = "RequisitionMaterialList";
            public const string RequisitionToolDate = "RequisitionToolDate";
            public const string RequisitionToolMonth = "RequisitionToolMonth";
            public const string RequisitionToolYear = "RequisitionToolYear";
            public const string RequisitionToolList = "RequisitionToolList";
            public const string SendSupplierReport = "SendSupplierReport";
            public const string StdMenuReport_1 = "StdMenuReport_1";
            public const string StdMenuReport_2 = "StdMenuReport_2";
            public const string StockCheckAuditReport = "StockCheckAuditReport";
            public const string StockCheckCountReport = "StockCheckCountReport";
            public const string StockinMaterialDayReport = "StockinMaterialDayReport";
            public const string StockInMaterialList = "StockinMaterialList";
            public const string StockinMaterialMonthReport = "StockinMaterialMonthReport";
            public const string StockinMaterialYearReport = "StockinMaterialYearReport";
            public const string StockInReport = "StockIn";
            public const string StockInReturnMaterialDate = "StockInReturnMaterialDate";
            public const string StockInReturnMaterialList = "StockInReturnMaterialList";
            public const string StockInReturnMaterialMonth = "StockInReturnMaterialMonth";
            public const string StockInReturnMaterialYear = "StockInReturnMaterialYear";
            public const string StockInReturnToolsDay = "StockInReturnToolsDay";
            public const string StockInReturnToolsList = "StockInReturnToolsList";
            public const string StockInReturnToolsMonth = "StockInReturnToolsMonth";
            public const string StockInReturnToolsYear = "StockInReturnToolsYear";
            public const string StockInToolList = "StockInToolList";
            public const string StockInToolsDate = "StockInToolsDate";
            public const string StockInToolsMonth = "StockInToolsMonth";
            public const string StockInToolsYear = "StockInToolsYear";
            public const string StockOutHosList = "StockOutHosList";
            public const string StockOutHosToolsDay = "StockOutHosToolsDay";
            public const string StockOutHosToolsMonth = "StockOutHosToolsMonth";
            public const string StockOutHosToolsYear = "StockOutHosToolsYear";
            public const string StockOutLoseList = "StockOutLoseList";
            public const string StockOutLoseMaterialDate = "StockOutLoseMaterialDate";
            public const string StockOutLoseMaterialMonth = "StockOutLoseMaterialMonth";
            public const string StockOutLoseMaterialYear = "StockOutLoseMaterialYear";
            public const string StockOutMaterialDayReport = "StockOutMaterialDayReport";
            public const string StockOutMaterialList = "StockOutMaterialList";
            public const string StockOutMaterialMonthReport = "StockOutMaterialMonthReport";
            public const string StockoutMaterialYearReport = "StockoutMaterialYearReport";
            public const string StockOutSupplist = "StockOutSupplist";
            public const string StockOutSuppMaterialDate = "StockOutSuppMaterialDate";
            public const string StockOutSuppMaterialMonth = "StockOutSuppMaterialMonth";
            public const string StockOutSuppMaterialYear = "StockOutSuppMaterialYear";
            public const string StockoutToolList = "StockoutToolList";
            public const string StockOutToolsDay = "StockOutToolsDay";
            public const string StockOutToolsMonth = "StockOutToolsMonth";
            public const string StockOutToolsYear = "StockOutToolsYear";
            public const string StockoutWasteReport = "StockoutWaste";
            public const string ToolsUseQtyDate = "ToolsUseQtyDate";
            public const string ToolsUseQtyMonth = "ToolsUseQtyMonth";
            public const string ToolsUseQtyYear = "ToolsUseQtyYear";
            public const string TransferOrderFeedListReport = "TransferOrderFeedListReport";
            public const string TransferOrderMilkListReport = "TransferOrderMilkListReport";
            public const string TransferOrderSetListReport = "TransferOrderSetListReport";
            public const string WelfareCompareDayReport = "WelfareCompareDayReport";
            public const string WelfareCompareMonthReport = "WelfareCompareMonthReport";
            public const string WelfareCompareYearReport = "WelfareCompareYearReport";
            public const string WelfareQtyDayReport = "WelfareQtyDayReport";
            public const string WelfareQtyMonthReport = "WelfareQtyMonthReport";
            public const string WelfareQtyYearReport = "WelfareQtyYearReport";
            public const string WelfareRightQtyDayReport = "WelfareRightQtyDayReport";
            public const string WelfareRightQtyMonthReport = "WelfareRightQtyMonthReport";
            public const string WelfareRightQtyYearReport = "WelfareRightQtyYearReport";

        }

        public partial class DocType
        {
            public partial class StockOutWaste 
            {
                public const string Loid = "1";
                public const string Name = "ใบจำหน่ายของเสีย";
            }
            public partial class StockInPO
            {
                public const string Loid = "2";
                public const string Name = "รับจากสั่งซื้อ";
            }
            public partial class StockInHospital
            {
                public const string Loid = "3";
                public const string Name = "รับจากคลังโรงพยาบาล";
            }
            public partial class StockInPoSAP
            {
                public const string Loid = "4";
                public const string Name = "รับจาก PO ใน SAP";
            }
            public partial class StockInOther
            {
                public const string Loid = "5";
                public const string Name = "รับเข้ากรณีอื่นๆ";
            }
            public partial class StockOutFood
            {
                public const string Loid = "6";
                public const string Name = "เบิกจ่ายวัสดุอาหาร";
            }
            public partial class StockOutFeed
            {
                public const string Loid = "7";
                public const string Name = "เบิกอาหารทางสาย/นม/ยา";
            }
            public partial class StockOutToolsOffice
            {
                public const string Loid = "8";
                public const string Name = "เบิกวัสดุสำนักงาน";
            }
            public partial class StockOutToolsKitchen
            {
                public const string Loid = "9";
                public const string Name = "เบิกวัสดุงานบ้านงานครัว";
            }
            public partial class StockOutToolsRepair
            {
                public const string Loid = "10";
                public const string Name = "เบิกวัสดุงานช่าง";
            }
            public partial class StockOutPrinted
            {
                public const string Loid = "12";
                public const string Name = "เบิกวัสดุสิ่งพิมพ์";
            }
            public partial class StockOutReturnSupp
            {
                public const string Loid = "13";
                public const string Name = "ใบส่งคืนร้านค้า";
            }
            public partial class StockOutReturnHos
            {
                public const string Loid = "14";
                public const string Name = "ใบส่งคืนคลังโรงพยาบาล";
                public const string SupplierLOID = "1";
            }
            public partial class StockInReturn
            {
                public const string Loid = "15";
                public const string Name = "ใบรับคืน";
            }
            public partial class StockOutRepair
            {
                public const string Loid = "16";
                public const string Name = "ใบส่งซ่อม";
            }
        }

        public partial class Warehouse
        {
            public partial class WarehouseFood
            {
                public const string Loid = "1";
                public const string Name = "คลังวัสดุอาหาร";
            }
            public partial class WarehousePreOrder
            {
                public const string Loid = "15";
                public const string Name = "คลังสั่งซื้อล่วงหน้า";
            }
            public partial class WarehouseLose
            {
                public const string Loid = "16";
                public const string Name = "คลังสูญเสีย";
            }
        }
        public partial class CookType
        {
            public partial class CookTypeBO
            {
                public const string Loid = "1";
                public const string Name = "อาหารต้มหรือแกง";
            }
            public partial class CookTypeFR
            {
                public const string Loid = "2";
                public const string Name = "อาหารทอด";
            }
            public partial class CookTypeRO
            {
                public const string Loid = "3";
                public const string Name = "อาหารย่าง";
            }
            public partial class CookTypeFY
            {
                public const string Loid = "4";
                public const string Name = "อาหารผัด";
            }
            public partial class CookTypeST
            {
                public const string Loid = "5";
                public const string Name = "อาหารตุ๋น";
            }
            public partial class CookTypeNN
            {
                public const string Loid = "6";
                public const string Name = "อาหารนึ่ง";
            }
            public partial class CookTypePE
            {
                public const string Loid = "7";
                public const string Name = "อาหารอบ";
            }
        }

    }
}
