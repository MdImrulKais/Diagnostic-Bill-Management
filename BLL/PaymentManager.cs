using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticBillManagementSystem.DAL;
using DiagnosticBillManagementSystem.Models.ViewModels;

namespace DiagnosticBillManagementSystem.BLL
{
    public class PaymentManager
    {
        private PaymentGateway aPaymentGateway = new PaymentGateway();

        public DueView GetDue(string billNo, string mobileNo)
        {
            return aPaymentGateway.GetDue(billNo, mobileNo);
        }

        public string MakePayment(int patientId)
        {
            int rowAffacted = aPaymentGateway.MakePayment(patientId);
            if (rowAffacted > 0)
                return "Payment Successful";
            else
                return "Sorry, payment is not successful !";
        }
    }
}
