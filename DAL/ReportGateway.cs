using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticBillManagementSystem.Models.ViewModels;

namespace DiagnosticBillManagementSystem.DAL
{
    public class ReportGateway : CommonGateway
    {
        public List<TestWiseReportView> GetTestWiseReportView(string fromDate, string toDate)
        {
            Query = "SELECT ti.TestName,ti.Fee, COUNT(tr.TestId) AS NoOfTest, (Fee*COUNT(tr.TestId)) AS TotalAmount FROM TestInfo AS ti LEFT JOIN TestRequest AS tr ON ti.TestId=tr.TestId WHERE tr.EntryDate BETWEEN '" + fromDate + "' AND '" + toDate + "' OR tr.EntryDate IS NULL GROUP BY ti.TestName, ti.Fee";
            List<TestWiseReportView> TestWiseReportList = new List<TestWiseReportView>();
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                TestWiseReportView aTestWiseReport = new TestWiseReportView();
                aTestWiseReport.TestName = Reader["TestName"].ToString();
                aTestWiseReport.NoOfTest = Reader["NoOfTest"].ToString();
                aTestWiseReport.TotalAmount = Reader["TotalAmount"].ToString();

                TestWiseReportList.Add(aTestWiseReport);
            }
            Reader.Close();
            Connection.Close();
            return TestWiseReportList;
        }

        public List<TypeWiseReportView> GetTypeWiseReportView(string fromDate, string toDate)
        {
            Query = "SELECT a.TestType , Sum(a.NoOfTest) AS NoOfTest , Sum(a.TotalAmount) AS TotalAmount FROM (SELECT tyi.TestType, Count(tr.testId) As NoOfTest, (Fee*Count(tr.testId)) As TotalAmount From TestTypeInfo AS tyi Left Outer Join TestInfo AS ti ON tyi.TestTypeId = ti.TestTypeId Left Outer Join TestRequest tr ON ti.TestId = tr.TestId WHERE EntryDate BETWEEN '" + fromDate + "' AND '" + toDate + "' OR EntryDate IS NULL GROUP BY tyi.TestType, Fee) a GROUP BY a.TestType";
            List<TypeWiseReportView> TypeWiseReportView = new List<TypeWiseReportView>();
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                TypeWiseReportView aTypeWiseReport = new TypeWiseReportView();
                aTypeWiseReport.TestType = Reader["TestType"].ToString();
                aTypeWiseReport.NoOfTest = Reader["NoOfTest"].ToString();
                aTypeWiseReport.TotalAmount = Reader["TotalAmount"].ToString();

                TypeWiseReportView.Add(aTypeWiseReport);
            }
            Reader.Close();
            Connection.Close();
            return TypeWiseReportView;
        }

        public List<UnpaidBillReportView> GetUnpaidBillReportList(string fromDate, string toDate)
        {
            Query = "SELECT p.PatientId AS BillNo, Name, MobileNo, BillAmount, COUNT(*) " +
                    "FROM PatientInfo AS p LEFT JOIN TestRequest AS tr " +
                    "ON p.PatientId=tr.PatientId " +
                    "WHERE PaymentStatus='0' AND tr.EntryDate BETWEEN '" + fromDate + "' AND '" + toDate + "' " +
                    "GROUP BY p.PatientId, Name, MobileNo, BillAmount";
            List<UnpaidBillReportView> UnpaidBillReportList = new List<UnpaidBillReportView>();
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                UnpaidBillReportView aReportView = new UnpaidBillReportView();
                aReportView.BillNo = Reader["BillNo"].ToString();
                aReportView.Name = Reader["Name"].ToString();
                aReportView.MobileNo = Reader["MobileNo"].ToString();
                aReportView.BillAmount = Reader["BillAmount"].ToString();
                UnpaidBillReportList.Add(aReportView);
            }
            Reader.Close();
            Connection.Close();
            return UnpaidBillReportList;
        }
    }
}