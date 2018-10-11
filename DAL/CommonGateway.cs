using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace DiagnosticBillManagementSystem.DAL
{
    public class CommonGateway
    {
        protected string connectionSrting = WebConfigurationManager.ConnectionStrings["DiagnosticBillManagementConnectionString"].ConnectionString;
        public string Query { get; set; }
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }

        public CommonGateway()
        {
            Connection = new SqlConnection(connectionSrting);
        }
    }
}
