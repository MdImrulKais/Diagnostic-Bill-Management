using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticBillManagementSystem.Models.ViewModels;

namespace DiagnosticBillManagementSystem.DAL
{
    public class PaymentGateway : CommonGateway
    {
        public DueView GetDue(string billNo, string mobileNo)
        {
            DueView aDueView = null;
            Query = "SELECT p.PatientId, p.BillAmount, tr.EntryDate AS DueDate FROM PatientInfo AS p JOIN TestRequest AS tr ON p.PatientId = tr.PatientId WHERE p.PaymentStatus='0' AND (p.PatientId='" + billNo + "' OR p.MobileNo='" + mobileNo + "') ";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                aDueView = new DueView();
                while (Reader.Read())
                {
                    aDueView.PatientId = Convert.ToInt32(Reader["PatientId"]);
                    aDueView.Amount = Reader["BillAmount"].ToString();
                    aDueView.DueDate = Reader["DueDate"].ToString();
                }
                Reader.Close();
                Connection.Close();
                return aDueView;
            }
            else
            {
                Connection.Close();
                return aDueView;
            }
        }

        public int MakePayment(int patientId)
        {
            Query = "UPDATE PatientInfo SET PaymentStatus='1' WHERE PatientId='" + patientId + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffacted = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffacted;
        }
    }
}