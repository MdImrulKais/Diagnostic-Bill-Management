using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticBillManagementSystem.Models.ViewModels
{
    public class TypeWiseReportView
    {
        public string TestType { get; set; }
        public string NoOfTest { get; set; }
        public string TotalAmount { get; set; }
    }
}