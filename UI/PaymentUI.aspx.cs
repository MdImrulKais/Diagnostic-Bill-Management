using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticBillManagementSystem.BLL;
using DiagnosticBillManagementSystem.Models.ViewModels;

namespace DiagnosticBillManagementSystem.UI
{
    public partial class PaymentUI : System.Web.UI.Page
    {
        PaymentManager aPaymentManager = new PaymentManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            outputLabel.Text = "";
            amountTextBox.Text = "";
            dueDateTextBox.Text = "";
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            if (billNoTextBox.Text != "" || mobileNoTextBox.Text != "")
            {
                DueView aDueView = new DueView();
                aDueView = aPaymentManager.GetDue(billNoTextBox.Text, mobileNoTextBox.Text);
                if (aDueView != null)
                {
                    Session["patientId"] = aDueView.PatientId;
                    amountTextBox.Text = aDueView.Amount;
                    dueDateTextBox.Text = aDueView.DueDate;
                }
                else
                {
                    outputLabel.ForeColor = Color.Red;
                    outputLabel.Text = "No Unpaid bill information found For this Bill No/Mobile No !";
                }
            }
            else
            {
                amountTextBox.Text = "";
                dueDateTextBox.Text = "";
                outputLabel.ForeColor = Color.Brown;
                outputLabel.Text = "Please insert Bill No or Mobile No";
            }
        }

        protected void payButton_Click(object sender, EventArgs e)
        {
            outputLabel.Text = aPaymentManager.MakePayment(Convert.ToInt32(Session["patientId"]));
            Session["patientId"] = null;
        }
    }
}