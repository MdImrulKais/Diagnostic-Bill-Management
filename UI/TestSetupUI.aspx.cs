using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticBillManagementSystem.BLL;
using DiagnosticBillManagementSystem.Models.EntityModels;

namespace DiagnosticBillManagementSystem.UI
{
    public partial class TestSetupUI : System.Web.UI.Page
    {
        TestManager aTestManager = new TestManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                testTypeDropDownList.DataSource = aTestManager.GetAllTestTypes();
                testTypeDropDownList.DataTextField = "TestTypeName";
                testTypeDropDownList.DataValueField = "TestTypeId";
                testTypeDropDownList.DataBind();
                testTypeDropDownList.Items.Insert(0, new ListItem("Select Test Type", "0"));
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Test aTest = new Test();
            aTest.TestName = testNameTextBox.Text;
            aTest.Fee = Double.Parse(feeTextBox.Text);
            aTest.TestTypeId = Convert.ToInt32(testTypeDropDownList.SelectedValue);
            outputLabel.Text = aTestManager.SaveTest(aTest);

            testNameTextBox.Text = string.Empty;
            feeTextBox.Text = string.Empty;

            testSetupGridView.DataSource = aTestManager.GetAllTest();
            testSetupGridView.DataBind();

            testTypeDropDownList.ClearSelection();
        }
    }
}