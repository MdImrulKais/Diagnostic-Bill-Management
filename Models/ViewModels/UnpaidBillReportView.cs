using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticBillManagementSystem.Models.ViewModels
{
    public class UnpaidBillReportView
    {
        public string BillNo { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string BillAmount { get; set; }
    }
}