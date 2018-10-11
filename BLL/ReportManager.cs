using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticBillManagementSystem.DAL;
using DiagnosticBillManagementSystem.Models.ViewModels;

namespace DiagnosticBillManagementSystem.BLL
{
    public class ReportManager
    {
        ReportGateway aReportGateway = new ReportGateway();

        public List<TestWiseReportView> GetTestWiseReportView(string fromDate, string toDate)
        {
            return aReportGateway.GetTestWiseReportView(fromDate, toDate);
        }

        public List<TypeWiseReportView> GetTypeWiseReportView(string fromDate, string toDate)
        {
            return aReportGateway.GetTypeWiseReportView(fromDate, toDate);
        }

        public List<UnpaidBillReportView> GetUnpaidBillReportView(string fromDate, string toDate)
        {
            return aReportGateway.GetUnpaidBillReportList(fromDate, toDate);
        }
    }
}
