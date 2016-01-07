using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SHND.DAL.Inventory;
using SHND.DAL.Views;
using SHND.Data.Search;
using SHND.Data.Views;
using SHND.DAL.Tables;

/// <summary>
/// SearchFlow Class
/// Version 1.0
/// =========================================================================
/// Create by: Teang
/// Create Date: 8 Jan 2009
/// -------------------------------------------------------------------------
/// Modify By: -
/// Modify From: -
/// Modify Date: -
/// -------------------------------------------------------------------------
/// Remark: -
/// Description:
///    Flow จัดการการทำงาน Search Popup
/// Changes:
///    1.0 - สร้าง
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Flow.Search
{
    public class SearchFlow
    {
        /// <summary>
        /// ค้นหาข้อมูลชนิดของสารอาหารเฉพาะโรค (Disease Category)
        /// </summary>
        /// <param name="abbName">ชื่อย่อ</param>
        /// <param name="description">รายละเอียด</param>
        /// <param name="exceptKeyList">DISEASECATEGORY.LOID ที่ยกเว้น</param>
        /// <param name="orderBy">ฟิลด์ที่ใช้เรียงลำดับ</param>
        /// <returns>DataTable</returns>
        public DataTable GetDiseaseCategoryList(string abbName, string description, string isSpecial, string isLimit, string isCalculate, string isIncrease, string isNeed, string isAbstain, string isRequest ,string cDiseaseCategory, string excepKeyList, string otherCondition, string orderBy)
        {
            VDiseaseCategoryDAL VDiseaseCategory = new VDiseaseCategoryDAL();
            return VDiseaseCategory.GetDataListByCondition(abbName, description, "1", isSpecial, isLimit, isCalculate, isIncrease, isAbstain, isNeed, isRequest, cDiseaseCategory, excepKeyList, otherCondition, orderBy, null);
        }

        /// <summary>
        /// ค้นหาข้อมูลชนิดของสารอาหารเฉพาะโรค (Disease Category)
        /// </summary>
        /// <param name="abbName">ชื่อย่อ</param>
        /// <param name="description">รายละเอียด</param>
        /// <param name="exceptKeyList">DISEASECATEGORY.LOID ที่ยกเว้น</param>
        /// <param name="orderBy">ฟิลด์ที่ใช้เรียงลำดับ</param>
        /// <returns>DataTable</returns>
        public DataTable GetDiseaseCategoryList(string abbName, string description, string isAbstain, string isNeed, string isRequest, string cDiseaseCategory,  string excepKeyList, string otherCondition, string orderBy)
        {
            VDiseaseCategoryDAL VDiseaseCategory = new VDiseaseCategoryDAL();
            return VDiseaseCategory.GetDataListByCondition(abbName, description, "1", "", "", "", "", isAbstain, isNeed, isRequest,cDiseaseCategory, excepKeyList, otherCondition, orderBy, null);
        }

        /// <summary>
        /// ค้นหาข้อมูลวัสดุ
        /// </summary>
        /// <param name="condition">เงื่อนไขในการค้นหา</param>
        /// <param name="masterListType">กลุ่มของ ประเภทวัสดุ เช่น 'TL', 'FO'</param>
        /// <param name="exceptKeyList">MATERIALMASTER.LOID ที่ยกเว้น</param>
        /// <param name="orderBy">ฟิลด์ที่ใช้เรียงลำดับ</param>
        /// <returns>DataTable</returns>
        public DataTable GetMaterialMasterList(MaterialMasterPopupData condition, string masterListType, string exceptKeyList, string orderBy)
        {
            V_MaterialMasterDAL VMaterialMaster = new V_MaterialMasterDAL();
            condition.Active = "1";
            return VMaterialMaster.GetDataListByCondition(condition, masterListType, exceptKeyList, orderBy, null);
        }

        /// <summary>
        /// ค้นหาข้อมูลวัสดุจากหน่วยอื่น
        /// </summary>
        /// <param name="docType">ประเภทการรับเข้า/เบิกจ่าย</param>
        /// <param name="materialClass">หมวดวัสดุ</param>
        /// <param name="materialName">ชื่อวัสดุ</param>
        /// <param name="isStockIn">สำหรับรับเข้า</param>
        /// <param name="exceptMaterialMasterList">MATERIALMASTER.LOID ที่ยกเว้น</param>
        /// <param name="exceptCodeList">V_MATERIALMASTER_UNIT.CODE ที่ยกเว้น</param>
        /// <param name="otherCoditions">เงื่อนไขอื่นๆ</param>
        /// <param name="orderBy">ฟิลด์ที่ใช้เรียงลำดับ</param>
        /// <returns>DataTable</returns>
        public DataTable GetMaterialUnitList(double docType, double materialClass, string materialName, string isStockIn, string exceptMaterialMasterList, string exceptCodeList, string otherCoditions, string orderBy)
        {
            VMaterialMasterUnitDAL VMaterialList = new VMaterialMasterUnitDAL();
            return VMaterialList.GetDataListByConditions(docType, materialClass, materialName, isStockIn, exceptMaterialMasterList, exceptCodeList, otherCoditions, orderBy, null);
        }

        /// <summary>
        /// ค้นหาสูตรอาหารสำรับ
        /// </summary>
        /// <param name="cREFFORMULASET">FORMULASET.LOID ของสูตรอาหารที่อ้างอิง เพื่อเทียบสารอาหารที่ควบคุม</param>
        /// <param name="cFOODTYPE">ประภทอาหาร</param>
        /// <param name="cFOODCATEGORY">ชนิดอาหาร</param>
        /// <param name="cNAME">ชื่อสูตร</param>
        /// <param name="cISELEMENT">ใช้เป็นส่วนผสมในสูตรอื่นๆ</param>
        /// <param name="exceptKeyList">FORMULASET.LOID ที่ยกเว้น</param>
        /// <param name="orderBy">ฟิลด์ที่ใช้เรียงลำดับ</param>
        /// <returns>DataTable</returns>
        public DataTable GetFormulaSetList(double cREFFORMULASET, double cFOODTYPE, double cFOODCATEGORY, string cNAME, bool cISELEMENT, string exceptKeyList, string orderBy)
        {
            VFormulaSetSearchDAL VFormulaSetSearch = new VFormulaSetSearchDAL();
            return VFormulaSetSearch.GetDataListByCondition(cREFFORMULASET, cFOODTYPE, cFOODCATEGORY, cNAME, (cISELEMENT ? "Y" : "N"), "AP", exceptKeyList, orderBy, null);
        }

        /// <summary>
        /// ค้นหาอาหารจัดเลี้ยง
        /// </summary>
        /// <param name="cFOODTYPE">ประภทคาวหวาน</param>
        /// <param name="cFOODCOOKTYPE">ประเภทการปรุง</param>
        /// <param name="cNAME">ชื่ออาหาร</param>
        /// <param name="exceptKeyList">LOID ที่ยกเว้น</param>
        /// <param name="orderBy">ฟิลด์ที่ใช้เรียงลำดับ</param>
        /// <returns>DataTable</returns>
        public DataTable GetOrderPartyList(double cFOODTYPE, double cFOODCOOKTYPE, string cNAME, string isElement, DateTime partyDate, string exceptKeyList, string orderBy)
        {
            VFormulaOrderDAL VFormulaSetSearch = new VFormulaOrderDAL();
            return VFormulaSetSearch.GetDataListByCondition(cFOODTYPE, cFOODCOOKTYPE, cNAME, exceptKeyList, isElement, partyDate, orderBy, null);
        }

        /// <summary>
        /// ค้นหาข้อมูลเจ้าหน้าที่
        /// </summary>
        /// <param name="officerName">ชื่อเจ้าหน้าที่</param>
        /// <param name="division">หน่วยงาน</param>
        /// <param name="exceptKeyList">OFFICER.LOID ที่ยกเว้น</param>
        /// <param name="orderBy">ฟิลด์ที่ใช้เรียงลำดับ</param>
        /// <returns>DataTable</returns>
        public DataTable GetOfficerList(string officerName, double division, string exceptKeyList, string orderBy)
        {
            VOfficerDAL VOfficer = new VOfficerDAL();
            return VOfficer.GetDataListByConditions(officerName, division, exceptKeyList, orderBy, null);
        }

        /// <summary>
        /// ค้นหาข้อมูลวัสดุคงคลัง
        /// </summary>
        /// <param name="warehouse">คลังสินค้า</param>
        /// <param name="MaterialName">ชื่อวัสดุ</param>
        /// <param name="Meterailgroup">ประเภท</param>
        /// <param name="exceptKeyList">LOID ที่ยกเว้น</param>
        /// <param name="orderBy">ฟิลด์ที่ใช้เรียงลำดับ</param>
        /// <returns>DataTable</returns>
        public DataTable GetStockRemainList(double warehouse, string materialName, double meterailGroup, string exceptKeyList, string orderBy)
        {
            VStockRemainDAL VRepair = new VStockRemainDAL();
            return VRepair.GetDataListByConditions(warehouse, meterailGroup, materialName, exceptKeyList, orderBy, null);
        }

        public DataTable GetPOPopupList(string codeFrom, string codeTo, DateTime dateFrom, DateTime dateTo, DateTime UsedateFrom, DateTime usedateTo,double materialclass, string orderBy)
        {
            VPrePOPopupDAL VPOPopup = new VPrePOPopupDAL();
            return VPOPopup.GetDataListByConditions(codeFrom,codeTo,dateFrom,dateTo,UsedateFrom,usedateTo,materialclass, orderBy, null);
        }

        /// <summary>
        /// ค้นหาข้อมูลวัสดุอาหาร(สั่งซื้อ)
        /// </summary>
        /// <param name="materialClass">หมวดวัสดุ</param>
        /// <param name="materialName">ชื่อวัสดุ</param>
        /// <param name="exceptKeyList">LOID ที่ยกเว้น</param>
        /// <param name="orderBy">ฟิลด์ที่ใช้เรียงลำดับ</param>
        /// <returns>DataTable</returns>
        public DataTable GetPrePOMaterialList(double PlanOrder, double materialClass, string materialName, string exceptKeyList, string orderBy)
        {
            VPrePOMaterialClassDAL VMaterialList = new VPrePOMaterialClassDAL();
            return VMaterialList.GetDataListByConditions(PlanOrder, materialClass, materialName, exceptKeyList, orderBy, null);
        }

        public DataTable GetReceiveMaterialList(DateTime duedate, double materialClass, string materialName, string exceptKeyList, string orderBy)
        {
            VReceiveMaterialDAL VMaterialList = new VReceiveMaterialDAL();
            return VMaterialList.GetDataListByConditions(duedate, materialClass, materialName, exceptKeyList, orderBy, null);
        }

        public DataTable GetMenuItemStockOut(double docType, double division, DateTime menuDate, double materialClass, string materialName, bool isBreakfast, bool isLunch, bool isDinner, string exceptCodeList, string orderBy)
        {
            VMenuStockOutDAL vDAL = new VMenuStockOutDAL();
            return vDAL.GetDataListByConditions(docType, division, menuDate, materialClass, materialName, isBreakfast, isLunch, isDinner, exceptCodeList, orderBy, null);
        }

        /// <summary>
        /// ค้นหาข้อมูลวัสดุอาหารตามแผนประมาณการ
        /// </summary>
        /// <param name="materialClass">หมวดวัสดุ</param>
        /// <param name="materialName">ชื่อวัสดุ</param>
        /// <param name="exceptKeyList">LOID ที่ยกเว้น</param>
        /// <param name="orderBy">ฟิลด์ที่ใช้เรียงลำดับ</param>
        /// <returns>DataTable</returns>       
        public DataTable GetMaterialFoodStockinList(double PlanOrder, double materialClass, string materialName, string exceptCodeList, string orderBy)
        {
            VStockinFoodPopupDAL VStockinFoodPopup = new VStockinFoodPopupDAL();
            return VStockinFoodPopup.GetDataListByConditions(PlanOrder, materialClass, materialName, exceptCodeList, orderBy, null);
        }

        /// <summary>
        /// ค้นหาข้อมูลวัสดุอุปกรณ์ตามแผนประมาณการ
        /// </summary>
        /// <param name="materialClass">หมวดวัสดุ</param>
        /// <param name="materialName">ชื่อวัสดุ</param>
        /// <param name="exceptKeyList">LOID ที่ยกเว้น</param>
        /// <param name="orderBy">ฟิลด์ที่ใช้เรียงลำดับ</param>
        /// <returns>DataTable</returns>       
        public DataTable GetMaterialStockinList(double PlanOrder, double materialClass, string materialName, string exceptKeyList, string orderBy)
        {
            VStockinToolsPopupDAL VStockinToolsPopup = new VStockinToolsPopupDAL();
            return VStockinToolsPopup.GetDataListByConditions(PlanOrder, materialClass, materialName, exceptKeyList, orderBy, null);
        }

        /// <summary>
        /// ค้นหารายการที่ส่งคืนร้านค้า
        /// </summary>
        /// <param name="condition">เงื่อนไขในการค้นหา</param>
        /// <param name="masterListType">กลุ่มของ ประเภทวัสดุ เช่น 'TL', 'FO'</param>
        /// <param name="exceptKeyList">MATERIALMASTER.LOID ที่ยกเว้น</param>
        /// <param name="orderBy">ฟิลด์ที่ใช้เรียงลำดับ</param>
        /// <returns>DataTable</returns>
        public DataTable GetSendSupplierList(VStockoutReturenPopUpData condition, string masterListType, string exceptKeyList, string orderBy)
        {
            VStockoutReturenPopUpDAL VStockoutReturn = new VStockoutReturenPopUpDAL();
            return VStockoutReturn.GetDataListByCondition(condition, masterListType, exceptKeyList, orderBy, null);
        }

        /// <summary>
        /// ค้นหาข้อมูลวัสดุคงเหลือคืนคลัง
        /// </summary>
        /// <param name="materialClass">หมวดวัสดุ</param>
        /// <param name="materialName">ชื่อวัสดุ</param>
        /// <param name="exceptKeyList">LOID ที่ยกเว้น</param>
        /// <param name="orderBy">ฟิลด์ที่ใช้เรียงลำดับ</param>
        /// <returns>DataTable</returns>
        public DataTable GetMaterialReturnRequestList(double division,double warehouse, string materialName, string exceptKeyList, string orderBy)
        {
            VRetrunRequestPopupDAL VRetrunRequestPopup = new VRetrunRequestPopupDAL();
            return VRetrunRequestPopup.GetDataListByConditions(division, warehouse, materialName, exceptKeyList, orderBy, null);
        }

        public DataTable GetAdmitPatientList(string pname, string hn, string an, string admitdatefrom, string admitdateto, double ward, string exceptKeyList, string orderBy)
        {
            VAdmitPatientDAL VAdmitPatientDAL = new VAdmitPatientDAL();
            return VAdmitPatientDAL.GetDataListByConditions(pname, hn, an, admitdatefrom, admitdateto, ward, exceptKeyList, orderBy, null);
        }

        public DataTable GetMedChargeList(string pname, string hn, string an, string admitdatefrom, string admitdateto, double ward, string exceptKeyList, string orderBy)
        {
            VMedFeedChargePopup VAdmitPatientDAL = new VMedFeedChargePopup();
            return VAdmitPatientDAL.GetDataListByConditions(pname, hn, an, admitdatefrom, admitdateto, ward, exceptKeyList, orderBy, null);
        }

        public DataTable GetMedFedMaterialUnitList(string mmname, string exceptMaterialMasterList, string orderBy)
        {
            VMaterialMasterUnitDAL VMaterialList = new VMaterialMasterUnitDAL();
            return VMaterialList.GetMedFeedListByCondition(mmname,exceptMaterialMasterList, orderBy, null);
        }

        public DataTable GetMaterialStockOutWasteList(string mmName, double materialclass, double materialgroup, double warehouse ,string exceptMaterialList, string orderBy)
        { 
            VMaterialStockoutWasteDAL VMaterialList= new VMaterialStockoutWasteDAL();
            return VMaterialList.GetDataByConditions(mmName,materialclass,materialgroup,warehouse,exceptMaterialList,orderBy,null);
        }

        public DataTable GetSendPreOrderSupplierList(VSendPreOrderSupplierPopupData pData, string orderBy)
        {
            VSendPreOrderSupplierPopupDAL VMaterialList = new VSendPreOrderSupplierPopupDAL();
            return VMaterialList.GetDataByCondition(pData, orderBy, null);
        }

        public DataTable GetWardList(string exceptWardList, string orderBy)
        {
            VWardSearchDAL VWard = new VWardSearchDAL();
            return VWard.GetDataByConditions(exceptWardList, orderBy, null);
        }

        public DataTable GetDivisionList(string exceptWardList, string orderBy)
        {
            VDivisionSeacrhDAL VDivision = new VDivisionSeacrhDAL();
            return VDivision.GetDataByConditions(exceptWardList, orderBy, null);
        }

    }
}
