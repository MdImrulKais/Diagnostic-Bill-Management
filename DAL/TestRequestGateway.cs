using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticBillManagementSystem.Models.EntityModels;

namespace DiagnosticBillManagementSystem.DAL
{
    public class TestRequestGateway : CommonGateway
    {
        public bool CheckPatient(Patient aPatient)
        {

            Query = "SELECT * FROM PatientInfo WHERE MobileNo = '" + aPatient.MobileNo + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool patientExists = Reader.HasRows;
            Reader.Close();
            Connection.Close();
            return patientExists;
        }

        public int SavePatient(Patient aPatient)
        {
            Query = "INSERT INTO PatientInfo (Name, DateOfBirth, MobileNo, BillAmount, PaymentStatus) VALUES ('" + aPatient.Name + "','" + aPatient.DateOfBirth + "','" + aPatient.MobileNo + "','" + aPatient.BillAmount + "','" + aPatient.PaymentStatus + "')";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public string GetFee(int TestId)
        {
            Query = "SELECT * FROM TestInfo WHERE TestId='" + TestId + "'";
            Command = new SqlCommand(Query, Connection);
            string fee = String.Empty;
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                fee = Reader["Fee"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return fee;
        }

        public int GetPatientId(string mobileNo)
        {
            Query = "SELECT * FROM PatientInfo WHERE MobileNo='" + mobileNo + "'";
            Command = new SqlCommand(Query, Connection);
            int patientId = 0;
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                patientId = Convert.ToInt32(Reader["PatientId"]);
            }
            Reader.Close();
            Connection.Close();
            return patientId;
        }

        public int SaveTestRequest(TestRequest aTestRequest)
        {
            Query = "INSERT INTO TestRequest (PatientId, TestId, EntryDate) VALUES ('" + aTestRequest.PatientId + "','" + aTestRequest.TestId + "','" + aTestRequest.EntryDate + "')";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
    }
}