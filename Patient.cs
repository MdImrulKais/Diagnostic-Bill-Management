using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticBillManagementSystem.Models.EntityModels
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string MobileNo { get; set; }
        public double BillAmount { get; set; }
        public int PaymentStatus { get; set; }
    }
}