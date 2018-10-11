using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticBillManagementSystem.DAL;
using DiagnosticBillManagementSystem.Models.EntityModels;

namespace DiagnosticBillManagementSystem.BLL
{
    public class TestRequestManager
    {
        TestRequestGateway aTestRequestGateway = new TestRequestGateway();

        public string SavePatient(Patient aPatient)
        {
            if (aTestRequestGateway.CheckPatient(aPatient))
            {
                return "Please use another Mobile No !";
            }
            else
            {
                int rowAffacted = aTestRequestGateway.SavePatient(aPatient);
                if (rowAffacted > 0)
                    return "Patient Information saved.";
                else
                    return "Sorry, Patient Information saved failed !";
            }
        }

        public string GetFee(int TestId)
        {
            return aTestRequestGateway.GetFee(TestId);
        }

        public int GetPatientId(string mobileNo)
        {
            return aTestRequestGateway.GetPatientId(mobileNo);
        }

        public string SaveTestRequest(TestRequest aTestRequest)
        {
            int rowAffacted = aTestRequestGateway.SaveTestRequest(aTestRequest);
            if (rowAffacted > 0)
                return "Test Request Saved";
            else
                return "Sorry, Test Request saved failed !";
        }
    }
}