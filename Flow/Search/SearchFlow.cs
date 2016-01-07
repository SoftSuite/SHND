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
///    Flow �Ѵ��á�÷ӧҹ Search Popup
/// Changes:
///    1.0 - ���ҧ
/// -------------------------------------------------------------------------
/// =========================================================================
/// </summary>
/// 
namespace SHND.Flow.Search
{
    public class SearchFlow
    {
        /// <summary>
        /// ���Ң����Ū�Դ�ͧ��������੾���ä (Disease Category)
        /// </summary>
        /// <param name="abbName">�������</param>
        /// <param name="description">��������´</param>
        /// <param name="exceptKeyList">DISEASECATEGORY.LOID ���¡���</param>
        /// <param name="orderBy">��Ŵ��������§�ӴѺ</param>
        /// <returns>DataTable</returns>
        public DataTable GetDiseaseCategoryList(string abbName, string description, string isSpecial, string isLimit, string isCalculate, string isIncrease, string isNeed, string isAbstain, string isRequest ,string cDiseaseCategory, string excepKeyList, string otherCondition, string orderBy)
        {
            VDiseaseCategoryDAL VDiseaseCategory = new VDiseaseCategoryDAL();
            return VDiseaseCategory.GetDataListByCondition(abbName, description, "1", isSpecial, isLimit, isCalculate, isIncrease, isAbstain, isNeed, isRequest, cDiseaseCategory, excepKeyList, otherCondition, orderBy, null);
        }

        /// <summary>
        /// ���Ң����Ū�Դ�ͧ��������੾���ä (Disease Category)
        /// </summary>
        /// <param name="abbName">�������</param>
        /// <param name="description">��������´</param>
        /// <param name="exceptKeyList">DISEASECATEGORY.LOID ���¡���</param>
        /// <param name="orderBy">��Ŵ��������§�ӴѺ</param>
        /// <returns>DataTable</returns>
        public DataTable GetDiseaseCategoryList(string abbName, string description, string isAbstain, string isNeed, string isRequest, string cDiseaseCategory,  string excepKeyList, string otherCondition, string orderBy)
        {
            VDiseaseCategoryDAL VDiseaseCategory = new VDiseaseCategoryDAL();
            return VDiseaseCategory.GetDataListByCondition(abbName, description, "1", "", "", "", "", isAbstain, isNeed, isRequest,cDiseaseCategory, excepKeyList, otherCondition, orderBy, null);
        }

        /// <summary>
        /// ���Ң�������ʴ�
        /// </summary>
        /// <param name="condition">���͹�㹡�ä���</param>
        /// <param name="masterListType">������ͧ ��������ʴ� �� 'TL', 'FO'</param>
        /// <param name="exceptKeyList">MATERIALMASTER.LOID ���¡���</param>
        /// <param name="orderBy">��Ŵ��������§�ӴѺ</param>
        /// <returns>DataTable</returns>
        public DataTable GetMaterialMasterList(MaterialMasterPopupData condition, string masterListType, string exceptKeyList, string orderBy)
        {
            V_MaterialMasterDAL VMaterialMaster = new V_MaterialMasterDAL();
            condition.Active = "1";
            return VMaterialMaster.GetDataListByCondition(condition, masterListType, exceptKeyList, orderBy, null);
        }

        /// <summary>
        /// ���Ң�������ʴبҡ˹������
        /// </summary>
        /// <param name="docType">����������Ѻ���/�ԡ����</param>
        /// <param name="materialClass">��Ǵ��ʴ�</param>
        /// <param name="materialName">������ʴ�</param>
        /// <param name="isStockIn">����Ѻ�Ѻ���</param>
        /// <param name="exceptMaterialMasterList">MATERIALMASTER.LOID ���¡���</param>
        /// <param name="exceptCodeList">V_MATERIALMASTER_UNIT.CODE ���¡���</param>
        /// <param name="otherCoditions">���͹�����</param>
        /// <param name="orderBy">��Ŵ��������§�ӴѺ</param>
        /// <returns>DataTable</returns>
        public DataTable GetMaterialUnitList(double docType, double materialClass, string materialName, string isStockIn, string exceptMaterialMasterList, string exceptCodeList, string otherCoditions, string orderBy)
        {
            VMaterialMasterUnitDAL VMaterialList = new VMaterialMasterUnitDAL();
            return VMaterialList.GetDataListByConditions(docType, materialClass, materialName, isStockIn, exceptMaterialMasterList, exceptCodeList, otherCoditions, orderBy, null);
        }

        /// <summary>
        /// �����ٵ���������Ѻ
        /// </summary>
        /// <param name="cREFFORMULASET">FORMULASET.LOID �ͧ�ٵ�����÷����ҧ�ԧ ������º�������÷��Ǻ���</param>
        /// <param name="cFOODTYPE">����������</param>
        /// <param name="cFOODCATEGORY">��Դ�����</param>
        /// <param name="cNAME">�����ٵ�</param>
        /// <param name="cISELEMENT">������ǹ�����ٵ�����</param>
        /// <param name="exceptKeyList">FORMULASET.LOID ���¡���</param>
        /// <param name="orderBy">��Ŵ��������§�ӴѺ</param>
        /// <returns>DataTable</returns>
        public DataTable GetFormulaSetList(double cREFFORMULASET, double cFOODTYPE, double cFOODCATEGORY, string cNAME, bool cISELEMENT, string exceptKeyList, string orderBy)
        {
            VFormulaSetSearchDAL VFormulaSetSearch = new VFormulaSetSearchDAL();
            return VFormulaSetSearch.GetDataListByCondition(cREFFORMULASET, cFOODTYPE, cFOODCATEGORY, cNAME, (cISELEMENT ? "Y" : "N"), "AP", exceptKeyList, orderBy, null);
        }

        /// <summary>
        /// ��������èѴ����§
        /// </summary>
        /// <param name="cFOODTYPE">����������ҹ</param>
        /// <param name="cFOODCOOKTYPE">��������û�ا</param>
        /// <param name="cNAME">���������</param>
        /// <param name="exceptKeyList">LOID ���¡���</param>
        /// <param name="orderBy">��Ŵ��������§�ӴѺ</param>
        /// <returns>DataTable</returns>
        public DataTable GetOrderPartyList(double cFOODTYPE, double cFOODCOOKTYPE, string cNAME, string isElement, DateTime partyDate, string exceptKeyList, string orderBy)
        {
            VFormulaOrderDAL VFormulaSetSearch = new VFormulaOrderDAL();
            return VFormulaSetSearch.GetDataListByCondition(cFOODTYPE, cFOODCOOKTYPE, cNAME, exceptKeyList, isElement, partyDate, orderBy, null);
        }

        /// <summary>
        /// ���Ң��������˹�ҷ��
        /// </summary>
        /// <param name="officerName">�������˹�ҷ��</param>
        /// <param name="division">˹��§ҹ</param>
        /// <param name="exceptKeyList">OFFICER.LOID ���¡���</param>
        /// <param name="orderBy">��Ŵ��������§�ӴѺ</param>
        /// <returns>DataTable</returns>
        public DataTable GetOfficerList(string officerName, double division, string exceptKeyList, string orderBy)
        {
            VOfficerDAL VOfficer = new VOfficerDAL();
            return VOfficer.GetDataListByConditions(officerName, division, exceptKeyList, orderBy, null);
        }

        /// <summary>
        /// ���Ң�������ʴؤ���ѧ
        /// </summary>
        /// <param name="warehouse">��ѧ�Թ���</param>
        /// <param name="MaterialName">������ʴ�</param>
        /// <param name="Meterailgroup">������</param>
        /// <param name="exceptKeyList">LOID ���¡���</param>
        /// <param name="orderBy">��Ŵ��������§�ӴѺ</param>
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
        /// ���Ң�������ʴ������(��觫���)
        /// </summary>
        /// <param name="materialClass">��Ǵ��ʴ�</param>
        /// <param name="materialName">������ʴ�</param>
        /// <param name="exceptKeyList">LOID ���¡���</param>
        /// <param name="orderBy">��Ŵ��������§�ӴѺ</param>
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
        /// ���Ң�������ʴ�����õ��Ἱ����ҳ���
        /// </summary>
        /// <param name="materialClass">��Ǵ��ʴ�</param>
        /// <param name="materialName">������ʴ�</param>
        /// <param name="exceptKeyList">LOID ���¡���</param>
        /// <param name="orderBy">��Ŵ��������§�ӴѺ</param>
        /// <returns>DataTable</returns>       
        public DataTable GetMaterialFoodStockinList(double PlanOrder, double materialClass, string materialName, string exceptCodeList, string orderBy)
        {
            VStockinFoodPopupDAL VStockinFoodPopup = new VStockinFoodPopupDAL();
            return VStockinFoodPopup.GetDataListByConditions(PlanOrder, materialClass, materialName, exceptCodeList, orderBy, null);
        }

        /// <summary>
        /// ���Ң�������ʴ��ػ�ó���Ἱ����ҳ���
        /// </summary>
        /// <param name="materialClass">��Ǵ��ʴ�</param>
        /// <param name="materialName">������ʴ�</param>
        /// <param name="exceptKeyList">LOID ���¡���</param>
        /// <param name="orderBy">��Ŵ��������§�ӴѺ</param>
        /// <returns>DataTable</returns>       
        public DataTable GetMaterialStockinList(double PlanOrder, double materialClass, string materialName, string exceptKeyList, string orderBy)
        {
            VStockinToolsPopupDAL VStockinToolsPopup = new VStockinToolsPopupDAL();
            return VStockinToolsPopup.GetDataListByConditions(PlanOrder, materialClass, materialName, exceptKeyList, orderBy, null);
        }

        /// <summary>
        /// ������¡�÷���觤׹��ҹ���
        /// </summary>
        /// <param name="condition">���͹�㹡�ä���</param>
        /// <param name="masterListType">������ͧ ��������ʴ� �� 'TL', 'FO'</param>
        /// <param name="exceptKeyList">MATERIALMASTER.LOID ���¡���</param>
        /// <param name="orderBy">��Ŵ��������§�ӴѺ</param>
        /// <returns>DataTable</returns>
        public DataTable GetSendSupplierList(VStockoutReturenPopUpData condition, string masterListType, string exceptKeyList, string orderBy)
        {
            VStockoutReturenPopUpDAL VStockoutReturn = new VStockoutReturenPopUpDAL();
            return VStockoutReturn.GetDataListByCondition(condition, masterListType, exceptKeyList, orderBy, null);
        }

        /// <summary>
        /// ���Ң�������ʴؤ�����ͤ׹��ѧ
        /// </summary>
        /// <param name="materialClass">��Ǵ��ʴ�</param>
        /// <param name="materialName">������ʴ�</param>
        /// <param name="exceptKeyList">LOID ���¡���</param>
        /// <param name="orderBy">��Ŵ��������§�ӴѺ</param>
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
