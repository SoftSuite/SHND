using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SHND.Data.Common.Utilities;
using SHND.DAL.Views;
using SHND.Data.Views;
using SHND.DAL.Prepare;
using System.IO;


public partial class _Default : System.Web.UI.Page
{
    CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

    private void BindNormalReport(string reportName)
    {
        //CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        string reportPath = Server.MapPath(Constant.HomeFolder + "Reports/" + reportName + ".rpt");
        rpt.Load(reportPath);
        CrystalDecisions.Shared.TableLogOnInfo logonInfo = new CrystalDecisions.Shared.TableLogOnInfo();
        logonInfo.ConnectionInfo.ServerName = ConfigurationManager.AppSettings["DB_SERVER"].ToString().Trim();
        logonInfo.ConnectionInfo.UserID = ConfigurationManager.AppSettings["DB_USER"].ToString().Trim();
        logonInfo.ConnectionInfo.Password = ConfigurationManager.AppSettings["DB_PASSWORD"].ToString();
        this.ctlReportViewer.LogOnInfo.Add(logonInfo);

        CrystalDecisions.Shared.ParameterValues curValue = new CrystalDecisions.Shared.ParameterValues();
        CrystalDecisions.Shared.ParameterDiscreteValue paraValue = new CrystalDecisions.Shared.ParameterDiscreteValue();
        for (int i = 0; i < Request.QueryString.Count; ++i)
        {
            string field = Request["paramfield" + (i + 1).ToString()];
            string value = Request["paramvalue" + (i + 1).ToString()];
            if (field != null && value != null)
            {
                paraValue.Value = value;
                curValue = rpt.ParameterFields[field].CurrentValues;
                curValue.Add(paraValue);
                rpt.ParameterFields[field].CurrentValues = curValue;
            }
            else
                break;
        }
        rpt.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
        rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;

        if (Request["landscape"] != null)
        {
            if (Request["landscape"] == "1") rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
        }
        Page.Cache["rpt"] = rpt;
        ctlReportViewer.ReportSource = Page.Cache["rpt"];
        
    }

    private void BindNormalReport(string reportName, string tableName, DataTable dt)
    {
        //CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        string reportPath = Server.MapPath(Constant.HomeFolder + "Reports/" + reportName + ".rpt");
        rpt.Load(reportPath);
        CrystalDecisions.Shared.TableLogOnInfo logonInfo = new CrystalDecisions.Shared.TableLogOnInfo();
        logonInfo.ConnectionInfo.ServerName = ConfigurationManager.AppSettings["DB_SERVER"].ToString().Trim();
        logonInfo.ConnectionInfo.UserID = ConfigurationManager.AppSettings["DB_USER"].ToString().Trim();
        logonInfo.ConnectionInfo.Password = ConfigurationManager.AppSettings["DB_PASSWORD"].ToString();
        this.ctlReportViewer.LogOnInfo.Add(logonInfo);

        DataSet ds = new DataSet();
        ds.Tables.Add(dt);
        ds.Tables[0].TableName = tableName;
        rpt.SetDataSource(ds.Tables[tableName]);

        Page.Cache["rpt"] = rpt;
        ctlReportViewer.ReportSource = Page.Cache["rpt"];
    }

    private void BindOrderSetSlipReport(string reportName)
    {
        DataTable dttmp = new DataTable();
        DataTable tempTable = new DataTable();

        VOrderSetSlipDAL vDAL = new VOrderSetSlipDAL();
        string str = "";

        #region Initial table data

        for (int i = 0; i < Request.QueryString.Count; ++i)
        {
            string field = Request["paramfield" + (i + 1).ToString()];
            string value = Request["paramvalue" + (i + 1).ToString()];

            if (field == "DIVISION")
                str = str + (str == "" ? "" : " AND ") + " DIVISION = " + value + "";

            else if (field != null && value != null & value != "" && field != "" && value != "0" && field != "0")
            {
                if (field == "REGISTERTIMEFROM")
                    str = str + (str == "" ? "" : " AND ") + " TO_CHAR(REGISTERDATE,'HH24MI') > '" + value + "'";

                else if (field == "REGISTERTIMETO")
                    str = str + (str == "" ? "" : " AND ") + " TO_CHAR(REGISTERDATE,'HH24MI') < '" + value + "'";

                else if (field == "ORDERTIMEFROM")
                    str = str + (str == "" ? "" : " AND ") + " TO_CHAR(ORDERDATE,'HH24MI') >= '" + value + "'";

                else if (field == "ORDERTIMETO")
                    str = str + (str == "" ? "" : " AND ") + " TO_CHAR(ORDERDATE,'HH24MI') <= '" + value + "'";

                else 
                    str = str + (str == "" ? "" : " AND ") + field + " = '" + value + "'";
            }
          //  else
          //      break;
        }

        dttmp = vDAL.GetDataList(str, "", null);

        if (dttmp.Rows.Count > 0)
        {
            #region CreatTempTable

            DataColumn dcRank = new DataColumn("RANK", typeof(double));
            DataColumn dcWardChar = new DataColumn("WardChar");
            DataColumn dcRoomNoChar = new DataColumn("RoomNoChar");
            DataColumn dcBedNoChar = new DataColumn("BedNoChar");
            DataColumn dcMealNameChar = new DataColumn("MealNameChar");
            DataColumn dcAnChar = new DataColumn("AnChar");
            DataColumn dcAgeChar = new DataColumn("AgeChar");
            DataColumn dcBmiChar = new DataColumn("BmiChar");
            DataColumn dcPNameChar = new DataColumn("PNameChar");
            DataColumn dcFoodTypeNameChar = new DataColumn("FoodTypeNameChar");
            DataColumn dcFoodCategoryNameChar = new DataColumn("FoodCategoryNameChar");
            DataColumn dcControlChar = new DataColumn("ControlChar");
            DataColumn dcAbstainChar = new DataColumn("AbstainChar");
            DataColumn dcIncreaseChar = new DataColumn("IncreaseChar");
            DataColumn dcRemarksChar = new DataColumn("RemarksChar");
            DataColumn dcLimitChar = new DataColumn("LimitChar");
            DataColumn dcNeedChar = new DataColumn("NeedChar");
            DataColumn dcImgUrlChar = new DataColumn("ImgUrlChar");
            DataColumn dcOrderDateChar = new DataColumn("OrderDateChar");
            DataColumn dcRegisterDateChar = new DataColumn("RegisterDateChar");
            DataColumn dcPhoto = new DataColumn("Photo", typeof(System.Byte[]));
            DataColumn dcPhoto1 = new DataColumn("Photo1", typeof(System.Byte[]));
            DataColumn dcPhoto2 = new DataColumn("Photo2", typeof(System.Byte[]));
            DataColumn dcPhoto3 = new DataColumn("Photo3", typeof(System.Byte[]));
            DataColumn dcPhoto4 = new DataColumn("Photo4", typeof(System.Byte[]));
            DataColumn dcLink1 = new DataColumn("Link1");
            DataColumn dcLink2 = new DataColumn("Link2");
            DataColumn dcLink3 = new DataColumn("Link3");
            DataColumn dcLink4 = new DataColumn("Link4");

            tempTable.Columns.Add(dcRank);
            tempTable.Columns.Add(dcWardChar);
            tempTable.Columns.Add(dcRoomNoChar);
            tempTable.Columns.Add(dcBedNoChar);
            tempTable.Columns.Add(dcMealNameChar);
            tempTable.Columns.Add(dcAnChar);
            tempTable.Columns.Add(dcAgeChar);
            tempTable.Columns.Add(dcBmiChar);
            tempTable.Columns.Add(dcPNameChar);
            tempTable.Columns.Add(dcFoodTypeNameChar);
            tempTable.Columns.Add(dcFoodCategoryNameChar);
            tempTable.Columns.Add(dcControlChar);
            tempTable.Columns.Add(dcAbstainChar);
            tempTable.Columns.Add(dcIncreaseChar);
            tempTable.Columns.Add(dcRemarksChar);
            tempTable.Columns.Add(dcLimitChar);
            tempTable.Columns.Add(dcNeedChar);
            tempTable.Columns.Add(dcImgUrlChar);
            tempTable.Columns.Add(dcOrderDateChar);
            tempTable.Columns.Add(dcRegisterDateChar);
            tempTable.Columns.Add(dcPhoto1);
            tempTable.Columns.Add(dcPhoto2);
            tempTable.Columns.Add(dcPhoto3);
            tempTable.Columns.Add(dcPhoto4);
            tempTable.Columns.Add(dcLink1);
            tempTable.Columns.Add(dcLink2);
            tempTable.Columns.Add(dcLink3);
            tempTable.Columns.Add(dcLink4);

            #endregion

            tempTable.Rows.Clear();

            for (int i = 0; i < dttmp.Rows.Count; i++)
            {
                DataRow dr = tempTable.Rows.Add();
                dr["RANK"] = i + 1;
                dr["WardChar"] = dttmp.Rows[i]["WARDNAME"].ToString();
                dr["RoomNoChar"] = dttmp.Rows[i]["ROOMNO"].ToString();
                dr["BedNoChar"] = dttmp.Rows[i]["BEDNO"].ToString();
                dr["MealNameChar"] = dttmp.Rows[i]["MEALNAME"].ToString();
                dr["AnChar"] = dttmp.Rows[i]["AN"].ToString();
                dr["AgeChar"] = dttmp.Rows[i]["AGE"].ToString();
                dr["BmiChar"] = dttmp.Rows[i]["BMI"].ToString();
                dr["PNameChar"] = dttmp.Rows[i]["PATIENTNAME"].ToString();
                dr["FoodTypeNameChar"] = dttmp.Rows[i]["FOODTYPENAME"].ToString();
                dr["FoodCategoryNameChar"] = dttmp.Rows[i]["FOODCATEGORYNAME"].ToString();
                dr["ControlChar"] = dttmp.Rows[i]["CONTROL"].ToString();
                dr["AbstainChar"] = dttmp.Rows[i]["ABSTAIN"].ToString();
                dr["IncreaseChar"] = dttmp.Rows[i]["INCREASE"].ToString();
                dr["RemarksChar"] = dttmp.Rows[i]["REMARKS"].ToString(); ;
                dr["LimitChar"] = dttmp.Rows[i]["LIMIT"].ToString();
                dr["NeedChar"] = dttmp.Rows[i]["NEED"].ToString();

                dr["OrderDateChar"] = dttmp.Rows[i]["ORDERDATE"];
                if (!Convert.IsDBNull(dttmp.Rows[i]["REGISTERDATE"]))
                    dr["RegisterDateChar"] = dttmp.Rows[i]["REGISTERDATE"];
                dr["Link1"] = "-";
                dr["Link2"] = "-";
                dr["Link3"] = "-";
                dr["Link4"] = "-";

                if (!Convert.IsDBNull(dttmp.Rows[i]["IMGURL"]))
                {
                    string[] temp = dttmp.Rows[i]["IMGURL"].ToString().Split(Convert.ToChar(","));

                    for (int j = 0; j < temp.Length && j < 3; j++)
                    {
                        string path = temp[j];
                        if (File.Exists(path))
                        {
                            FileStream FilStr = new FileStream(path, FileMode.Open, FileAccess.Read);
                            BinaryReader BinRed = new BinaryReader(FilStr);

                            dr["Link" + (j + 1).ToString()] = path;
                            dr["Photo" + (j + 1).ToString()] = BinRed.ReadBytes((int)BinRed.BaseStream.Length);

                            FilStr.Close(); //»Ô´ FileStream
                            BinRed.Close(); //»Ô´ BinaryReader
                        }
                    }
                }

            }
        }
        
        #endregion

        BindNormalReport(reportName, "OrderSetSlip", tempTable);
    }

    private void BindOrderFeedSlipReport(string reportName)
    {
        DataTable dttmp = new DataTable();
        DataTable tempTable = new DataTable();

        VOrderFeedSlipDAL vDAL = new VOrderFeedSlipDAL();
        double strWard = 0;
        double strFoodType = 0;
        double strFoodCategory = 0;
        string strPName = "";
        DateTime strODateFrom = new DateTime();
        DateTime strODateTo = new DateTime();
        DateTime strRDateFrom = new DateTime();
        DateTime strRDateTo = new DateTime();
        string strHN = "";
        string strAN = "";
        string strVN = "";

        #region Initial table data

        for (int i = 0; i < Request.QueryString.Count; ++i)
        {
            string field = Request["paramfield" + (i + 1).ToString()];
            string value = Request["paramvalue" + (i + 1).ToString()];
            if (field != null && value != null)
            {
                if (field == "WARDID")
                    strWard = Convert.ToDouble("0" + value);

                else if (field == "FOODTYPE")
                    strFoodType = Convert.ToDouble("0" + value);

                else if (field == "FOODCATEGORY")
                    strFoodCategory = Convert.ToDouble("0" + value);

                else if (field == "PATIENTNAME")
                    strPName = value;

                else if (field == "ORDERDATEFROM" && value != "")
                    strODateFrom = Convert.ToDateTime(value);

                else if (field == "ORDERDATETO" && value != "")
                    strODateTo = Convert.ToDateTime(value);

                else if (field == "REGISTERDATEFROM" && value != "")
                    strRDateFrom = Convert.ToDateTime(value);

                else if (field == "REGISTERDATETO" && value != "")
                    strRDateTo = Convert.ToDateTime(value);

                else if (field == "AN")
                    strAN = value;
                else if (field == "HN")
                    strAN = value;
                else if (field == "VN")
                    strAN = value;
            }
            else
                break;
        }

        dttmp = vDAL.GetDataListByConditions(strWard, strFoodType, strFoodCategory, strPName, strODateFrom, strODateTo, strRDateFrom, strRDateTo, strHN, strVN, strAN, "PATIENTNAME, RANK DESC",null);

        if (dttmp.Rows.Count > 0)
        {
            #region CreatTempTable

            DataColumn dcWardNameChar = new DataColumn("WardNameChar");
            DataColumn dcRoomNoChar = new DataColumn("RoomNoChar");
            DataColumn dcBedNoChar = new DataColumn("BedNoChar");
            DataColumn dcMealNameChar = new DataColumn("MealNameChar");
            DataColumn dcAnChar = new DataColumn("AnChar");
            DataColumn dcAgeChar = new DataColumn("AgeChar");
            DataColumn dcBmiChar = new DataColumn("BmiChar");
            DataColumn dcPNameChar = new DataColumn("PNameChar");
            DataColumn dcFoodTypeNameChar = new DataColumn("FoodTypeNameChar");
            DataColumn dcFoodCategoryNameChar = new DataColumn("FoodCategoryNameChar");
            DataColumn dcControlChar = new DataColumn("ControlChar");
            DataColumn dcQtyChar = new DataColumn("QtyChar");
            DataColumn dcIncreaseChar = new DataColumn("IncreaseChar");
            DataColumn dcRemarksChar = new DataColumn("RemarksChar");
            DataColumn dcLimitChar = new DataColumn("LimitChar");
            DataColumn dcFeedNameChar = new DataColumn("FeedNameChar");
            DataColumn dcImgUrlChar = new DataColumn("ImgUrlChar");
            DataColumn dcOrderDateChar = new DataColumn("OrderDateChar");
            DataColumn dcRegisterDateChar = new DataColumn("RegisterDateChar");
            DataColumn dcPhoto1 = new DataColumn("Photo1", typeof(System.Byte[]));
            DataColumn dcPhoto2 = new DataColumn("Photo2", typeof(System.Byte[]));
            DataColumn dcPhoto3 = new DataColumn("Photo3", typeof(System.Byte[]));

            tempTable.Columns.Add();
            tempTable.Columns.Add(dcWardNameChar);
            tempTable.Columns.Add(dcRoomNoChar);
            tempTable.Columns.Add(dcBedNoChar);
            tempTable.Columns.Add(dcMealNameChar);
            tempTable.Columns.Add(dcAnChar);
            tempTable.Columns.Add(dcAgeChar);
            tempTable.Columns.Add(dcBmiChar);
            tempTable.Columns.Add(dcPNameChar);
            tempTable.Columns.Add(dcFoodTypeNameChar);
            tempTable.Columns.Add(dcFoodCategoryNameChar);
            tempTable.Columns.Add(dcControlChar);
            tempTable.Columns.Add(dcQtyChar);
            tempTable.Columns.Add(dcIncreaseChar);
            tempTable.Columns.Add(dcRemarksChar);
            tempTable.Columns.Add(dcLimitChar);
            tempTable.Columns.Add(dcFeedNameChar);
            tempTable.Columns.Add(dcImgUrlChar);
            tempTable.Columns.Add(dcOrderDateChar);
            tempTable.Columns.Add(dcRegisterDateChar);
            tempTable.Columns.Add(dcPhoto1);
            tempTable.Columns.Add(dcPhoto2);
            tempTable.Columns.Add(dcPhoto3);

            #endregion

            tempTable.Rows.Clear();

            for (int i = 0; i < dttmp.Rows.Count; i++)
            {
                DataRow dr = tempTable.Rows.Add();
                dr["WardNameChar"] = dttmp.Rows[i]["WARDNAME"].ToString();
                dr["RoomNoChar"] = dttmp.Rows[i]["ROOMNO"].ToString();
                dr["BedNoChar"] = dttmp.Rows[i]["BEDNO"].ToString();
                dr["MealNameChar"] = dttmp.Rows[i]["MEALNAME"].ToString();
                dr["AnChar"] = dttmp.Rows[i]["AN"].ToString();
                dr["AgeChar"] = dttmp.Rows[i]["AGE"].ToString();
                dr["BmiChar"] = dttmp.Rows[i]["BMI"].ToString();
                dr["PNameChar"] = dttmp.Rows[i]["PATIENTNAME"].ToString();
                dr["FoodTypeNameChar"] = dttmp.Rows[i]["FOODTYPENAME"].ToString();
                dr["FoodCategoryNameChar"] = dttmp.Rows[i]["FOODCATEGORYNAME"].ToString();
                dr["ControlChar"] = dttmp.Rows[i]["CONTROL"].ToString();
                dr["QtyChar"] = dttmp.Rows[i]["QTY"].ToString();
                dr["IncreaseChar"] = dttmp.Rows[i]["INCREASE"].ToString();
                dr["RemarksChar"] = dttmp.Rows[i]["REMARKS"].ToString(); ;
                dr["LimitChar"] = dttmp.Rows[i]["LIMIT"].ToString();
                dr["FeedNameChar"] = dttmp.Rows[i]["FEEDNAME"].ToString();

                dr["OrderDateChar"] = Convert.ToDateTime(dttmp.Rows[i]["ORDERDATE"].ToString());
                if (Convert.IsDBNull(dttmp.Rows[i]["REGISTERDATE"]) == false)
                    dr["RegisterDateChar"] = Convert.ToDateTime(dttmp.Rows[i]["REGISTERDATE"].ToString());

                if (Convert.IsDBNull(dttmp.Rows[i]["IMGURL"]) == false)
                {
                    string[] temp = dttmp.Rows[i]["IMGURL"].ToString().Split(Convert.ToChar(","));

                    for (int j = 0; j < temp.Length; j++)
                    {
                        string path = temp[j];
                        FileStream FilStr = new FileStream(path, FileMode.Open);
                        BinaryReader BinRed = new BinaryReader(FilStr);

                        if (j == 0)
                            dr["Photo1"] = BinRed.ReadBytes((int)BinRed.BaseStream.Length);
                        else if (j == 1)
                            dr["Photo2"] = BinRed.ReadBytes((int)BinRed.BaseStream.Length);
                        else if (j == 2)
                            dr["Photo3"] = BinRed.ReadBytes((int)BinRed.BaseStream.Length);

                        FilStr.Close(); //»Ô´ FileStream
                        BinRed.Close(); //»Ô´ BinaryReader
                    }
                }
            }
        }

        #endregion

        BindNormalReport(reportName, "OrderFeedSlipDataSet", tempTable);
    }


    private void BindReport(string reportName)
    {
        switch (reportName)
        {
            case Constant.Reports.OrderSetSlipReport:
                BindOrderSetSlipReport(reportName);
                break;

            case Constant.Reports.OrderFeedSlipReport:
                BindOrderFeedSlipReport(reportName);
                break;

            default:
                BindNormalReport(reportName);
                break;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        BindReport(Request[Constant.QueryString.ReportName]);
    }
    
    protected void ctlReportViewer_Unload(object sender, EventArgs e)
    {
        rpt.Close();
        rpt.Dispose();
    }
}
