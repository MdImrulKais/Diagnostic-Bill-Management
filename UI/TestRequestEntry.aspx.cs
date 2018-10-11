using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DiagnosticBillManagementSystem.BLL;
using DiagnosticBillManagementSystem.Models.EntityModels;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ListItem = System.Web.UI.WebControls.ListItem;

namespace DiagnosticBillManagementSystem.UI
{
    public partial class TestRequestEntry : System.Web.UI.Page
    {
        TestRequestManager aTestRequestManager = new TestRequestManager();
        TestManager aTestManager = new TestManager();
        private List<Test> testList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                testTypeDropDown.DataSource = aTestManager.GetAllTest();
                testTypeDropDown.DataTextField = "TestName";
                testTypeDropDown.DataValueField = "TestId";
                testTypeDropDown.DataBind();
                testTypeDropDown.Items.Insert(0, new ListItem("Select Test Name", "0"));
            }
        }

        protected void testTypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (testTypeDropDown.SelectedIndex == 0)
                feeTextBox.Text = "0";
            else
                feeTextBox.Text = aTestRequestManager.GetFee(Convert.ToInt32(testTypeDropDown.SelectedValue));
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            outputLabel.Text = "";
            Test aTest = new Test();
            aTest.TestId = Convert.ToInt32(testTypeDropDown.SelectedValue);
            aTest.TestName = testTypeDropDown.SelectedItem.Text;
            aTest.Fee = Convert.ToDouble(feeTextBox.Text);

            if (Session["TempTest"] == null)
            {
                testList = new List<Test>();
            }
            else
            {
                testList = (List<Test>)Session["TempTest"];
            }
            testList.Add(aTest);
            testRequestGridView.DataSource = testList;
            testRequestGridView.DataBind();
            Session["TempTest"] = testList;

            double sum = 0;
            for (int i = 0; i < testRequestGridView.Rows.Count; i++)
            {
                sum += Double.Parse(testRequestGridView.Rows[i].Cells[2].Text);
            }
            totalTextBox.Text = sum.ToString();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Patient aPatient = new Patient();
            aPatient.Name = patientNameTextBox.Text;
            aPatient.DateOfBirth = dateOfBirthTextBox.Text;
            aPatient.MobileNo = mobileNoTextBox.Text;
            aPatient.BillAmount = Convert.ToDouble(totalTextBox.Text);
            aPatient.PaymentStatus = 0;
            string date = DateTime.Now.ToString("yyyy-MM-dd");

            if (aTestRequestManager.SavePatient(aPatient) != "Please use another Mobile No !")
            {
                foreach (Test anyTest in (List<Test>)Session["TempTest"])
                {
                    TestRequest aTestRequest = new TestRequest();
                    aTestRequest.PatientId = aTestRequestManager.GetPatientId(aPatient.MobileNo);
                    aTestRequest.TestId = anyTest.TestId;
                    aTestRequest.EntryDate = date;

                    outputLabel.Text = aTestRequestManager.SaveTestRequest(aTestRequest);
                }


                PdfManager aPdfManager = new PdfManager();
                Document pdfDocument = new Document(PageSize.A4, 50f, 50f, 50f, 50f);
                PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

                pdfDocument.Open();
                pdfDocument.Add(aPdfManager.GetBillPdfParagraph(date, aTestRequestManager.GetPatientId(aPatient.MobileNo), aPatient.Name, aPatient.DateOfBirth, aPatient.MobileNo, testRequestGridView, totalTextBox.Text));
                pdfDocument.Close();

                patientNameTextBox.Text = string.Empty;
                dateOfBirthTextBox.Text = string.Empty;
                mobileNoTextBox.Text = string.Empty;
                testRequestGridView.DataSource = null;
                testRequestGridView.DataBind();
                Session["TempTest"] = null;
                totalTextBox.Text = String.Empty;
                testTypeDropDown.ClearSelection();

                Response.ContentType = "application/pdf";
                Response.AppendHeader("content-disposition", "attachment;filename=Bill.pdf");
                Response.Write(pdfDocument);
                Response.Flush();
                Response.End();
            }
            else
            {
                outputLabel.Text = "Please use another Mobile No !";
            }
        }
    }
}