using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticBillManagementSystem.Models.EntityModels;

namespace DiagnosticBillManagementSystem.DAL
{
    public class TestGateway : CommonGateway
    {
        public int SaveTestType(TestType aTestType)
        {
            Query = "INSERT INTO TestTypeInfo (TestType) VALUES ('" + aTestType.TestTypeName + "')";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public bool CheckTestType(TestType aTestType)
        {
            Query = "SELECT * FROM TestTypeInfo WHERE TestType = '" + aTestType.TestTypeName + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool typeNameExists = Reader.HasRows;
            Reader.Close();
            Connection.Close();
            return typeNameExists;
        }

        public List<TestType> GetAllTestTypes()
        {
            Query = "SELECT * FROM TestTypeInfo";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            List<TestType> testTypes = new List<TestType>();
            while (Reader.Read())
            {
                TestType aTestType = new TestType();
                aTestType.TestTypeId = (int)Reader["TestTypeId"];
                aTestType.TestTypeName = Reader["TestType"].ToString();
                testTypes.Add(aTestType);
            }

            Reader.Close();
            Connection.Close();
            return testTypes;
        }

        public int SaveTest(Test aTest)
        {
            Query = "INSERT INTO TestInfo (TestName, Fee, TestTypeId) VALUES ('" + aTest.TestName + "','" + aTest.Fee + "','" + aTest.TestTypeId + "')";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public bool CheckTest(Test aTest)
        {
            Query = "SELECT * FROM TestInfo WHERE TestName = '" + aTest.TestName + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool testNameExists = Reader.HasRows;
            Reader.Close();
            Connection.Close();
            return testNameExists;
        }

        public List<Test> GetAllTest()
        {
            Query = "SELECT TestId, TestName, Fee, TestType FROM TestInfo JOIN TestTypeInfo ON TestInfo.TestTypeId=TestTypeInfo.TestTypeId ORDER BY TestName ASC";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            List<Test> testList = new List<Test>();
            while (Reader.Read())
            {
                Test aTest = new Test();
                aTest.TestId = (int)Reader["TestId"];
                aTest.TestName = Reader["TestName"].ToString();
                aTest.Fee = Convert.ToDouble(Reader["Fee"]);
                aTest.TestType = Reader["TestType"].ToString();

                testList.Add(aTest);
            }
            Reader.Close();
            Connection.Close();
            return testList;
        }
    }
}