using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticBillManagementSystem.Models.ViewModels
{
    public class DueView
    {
        public int PatientId { get; set; }
        public string Amount { get; set; }
        public string DueDate { get; set; }
    }
}