using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticBillManagementSystem.Models.EntityModels
{
    public class TestRequest
    {
        public int PatientId { get; set; }
        public int TestId { get; set; }
        public string EntryDate { get; set; }
    }
}