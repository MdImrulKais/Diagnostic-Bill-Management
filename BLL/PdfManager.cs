using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Web.UI.WebControls;
using Font = iTextSharp.text.Font;


namespace DiagnosticBillManagementSystem.BLL
{
    public class PdfManager
    {
        
        public Paragraph GetBillPdfParagraph(string printDate, int PatientId, string patientName, string dateOfBirth, string mobileNo, GridView aGridView, string totalFee)
        {
            var titleFont = FontFactory.GetFont("Candara", 18, Font.BOLD);
            Phrase headingPhrase = new Phrase("Bill Copy" + Environment.NewLine, titleFont);
            Phrase dotlinePhrase = new Phrase("======================================================================" + Environment.NewLine);
            Phrase printDatePhrase = new Phrase("Print Date: " + printDate + Environment.NewLine);
            Phrase billNoPhrase = new Phrase("Bill No: " + PatientId + Environment.NewLine);
            Phrase patientNamePhrase = new Phrase("Patient Name: " + patientName + Environment.NewLine);
            Phrase dateOfBirthPhrase = new Phrase("Date of Birth: " + dateOfBirth + Environment.NewLine);
            Phrase mobileNoPhrase = new Phrase("Mobile No: " + mobileNo + Environment.NewLine);
            Phrase selectedTestPhrase = new Phrase("Selected Tests are: " + Environment.NewLine);

            PdfPTable pdfTable = new PdfPTable(3);

            PdfPCell SN = new PdfPCell(new Phrase("SN"));
            SN.HorizontalAlignment = 1;
            pdfTable.AddCell(SN);
            PdfPCell TestName = new PdfPCell(new Phrase("Test Name"));
            TestName.HorizontalAlignment = 1;
            pdfTable.AddCell(TestName);
            PdfPCell Fee = new PdfPCell(new Phrase("Fee"));
            Fee.HorizontalAlignment = 1;
            pdfTable.AddCell(Fee);

            int sn = 1;
            for (int i = 0; i < aGridView.Rows.Count; i++)
            {
                PdfPCell snCell = new PdfPCell(new Phrase(sn++.ToString()));
                PdfPCell testNameCell = new PdfPCell(new Phrase(aGridView.Rows[i].Cells[1].Text));
                PdfPCell feeCell = new PdfPCell(new Phrase(aGridView.Rows[i].Cells[2].Text));
                snCell.HorizontalAlignment = 1;
                feeCell.HorizontalAlignment = 1;
                pdfTable.AddCell(snCell);
                pdfTable.AddCell(testNameCell);
                pdfTable.AddCell(feeCell);
            }

            Phrase totalPhrase = new Phrase("Total Fee: " + totalFee + Environment.NewLine);
            Phrase paymentStatusPhrase = new Phrase("Payment Status : Unpaid" + Environment.NewLine);
            Phrase dotlinePhrase2 = new Phrase("======================================================================" + Environment.NewLine);
            Phrase creditPhrase = new Phrase("<--- Health is Wealth --->");

            Paragraph aParagraph = new Paragraph();
            aParagraph.Add(headingPhrase);
            aParagraph.Add(dotlinePhrase);
            aParagraph.Add(printDatePhrase);
            aParagraph.Add(billNoPhrase);
            aParagraph.Add(patientNamePhrase);
            aParagraph.Add(dateOfBirthPhrase);
            aParagraph.Add(mobileNoPhrase);
            aParagraph.Add(Chunk.NEWLINE);
            aParagraph.Add(selectedTestPhrase);
            aParagraph.Add(pdfTable);
            aParagraph.Add(Chunk.NEWLINE);
            aParagraph.Add(totalPhrase);
            aParagraph.Add(paymentStatusPhrase);
            aParagraph.Add(dotlinePhrase2);
            aParagraph.Add(creditPhrase);

            return aParagraph;
        }

        public Paragraph GetTypeWiseReportPdfParagraph(string fromDate, string toDate, GridView aGridView, string totalFee)
        {
            var titleFont = FontFactory.GetFont("Candara", 18, Font.BOLD);
            Phrase headingPhrase = new Phrase("Type Wise Report" + Environment.NewLine, titleFont);
            Phrase dotlinePhrase = new Phrase("======================================================================" + Environment.NewLine);
            Phrase fromDatePhrase = new Phrase("From Date: " + fromDate + Environment.NewLine);
            Phrase toDatePhrase = new Phrase("To Date: " + toDate + Environment.NewLine);

            PdfPTable pdfTable = new PdfPTable(4);

            PdfPCell SN = new PdfPCell(new Phrase("SN"));
            SN.HorizontalAlignment = 1;
            pdfTable.AddCell(SN);
            PdfPCell TestType = new PdfPCell(new Phrase("Test Type"));
            TestType.HorizontalAlignment = 1;
            pdfTable.AddCell(TestType);
            PdfPCell NoOfTest = new PdfPCell(new Phrase("No Of Test"));
            NoOfTest.HorizontalAlignment = 1;
            pdfTable.AddCell(NoOfTest);
            PdfPCell TotalAmount = new PdfPCell(new Phrase("Total Amount"));
            TotalAmount.HorizontalAlignment = 1;
            pdfTable.AddCell(TotalAmount);

            int sn = 1;
            for (int i = 0; i < aGridView.Rows.Count; i++)
            {
                PdfPCell snCell = new PdfPCell(new Phrase(sn++.ToString()));
                PdfPCell testTypeCell = new PdfPCell(new Phrase(aGridView.Rows[i].Cells[1].Text));
                PdfPCell noOfTestCell = new PdfPCell(new Phrase(aGridView.Rows[i].Cells[2].Text));
                PdfPCell totalAmountCell = new PdfPCell(new Phrase(aGridView.Rows[i].Cells[3].Text));

                snCell.HorizontalAlignment = 1;
                noOfTestCell.HorizontalAlignment = 1;
                totalAmountCell.HorizontalAlignment = 1;

                pdfTable.AddCell(snCell);
                pdfTable.AddCell(testTypeCell);
                pdfTable.AddCell(noOfTestCell);
                pdfTable.AddCell(totalAmountCell);

            }

            Phrase totalPhrase = new Phrase("Total: " + totalFee + Environment.NewLine);
            Phrase dotlinePhrase2 = new Phrase("======================================================================" + Environment.NewLine);
            Phrase creditPhrase = new Phrase("<--- Managed by Team_MVC --->");

            Paragraph aParagraph = new Paragraph();
            aParagraph.Add(headingPhrase);
            aParagraph.Add(dotlinePhrase);
            aParagraph.Add(fromDatePhrase);
            aParagraph.Add(toDatePhrase);
            aParagraph.Add(Chunk.NEWLINE);
            aParagraph.Add(pdfTable);
            aParagraph.Add(Chunk.NEWLINE);
            aParagraph.Add(totalPhrase);
            aParagraph.Add(dotlinePhrase2);
            aParagraph.Add(creditPhrase);

            return aParagraph;
        }

        public Paragraph GetTestWiseReportPdfParagraph(string fromDate, string toDate, GridView aGridView, string totalFee)
        {
            var titleFont = FontFactory.GetFont("Candara", 18, Font.BOLD);
            Phrase headingPhrase = new Phrase("Test Wise Report" + Environment.NewLine, titleFont);
            Phrase dotlinePhrase = new Phrase("======================================================================" + Environment.NewLine);
            Phrase fromDatePhrase = new Phrase("From Date: " + fromDate + Environment.NewLine);
            Phrase toDatePhrase = new Phrase("To Date: " + toDate + Environment.NewLine);

            PdfPTable pdfTable = new PdfPTable(4);

            PdfPCell SN = new PdfPCell(new Phrase("SN"));
            SN.HorizontalAlignment = 1;
            pdfTable.AddCell(SN);
            PdfPCell TestName = new PdfPCell(new Phrase("Test Name"));
            TestName.HorizontalAlignment = 1;
            pdfTable.AddCell(TestName);
            PdfPCell NoOfTest = new PdfPCell(new Phrase("No Of Test"));
            NoOfTest.HorizontalAlignment = 1;
            pdfTable.AddCell(NoOfTest);
            PdfPCell TotalAmount = new PdfPCell(new Phrase("Total Amount"));
            TotalAmount.HorizontalAlignment = 1;
            pdfTable.AddCell(TotalAmount);

            int sn = 1;
            for (int i = 0; i < aGridView.Rows.Count; i++)
            {
                PdfPCell snCell = new PdfPCell(new Phrase(sn++.ToString()));
                PdfPCell testNameCell = new PdfPCell(new Phrase(aGridView.Rows[i].Cells[1].Text));
                PdfPCell noOfTestCell = new PdfPCell(new Phrase(aGridView.Rows[i].Cells[2].Text));
                PdfPCell totalAmountCell = new PdfPCell(new Phrase(aGridView.Rows[i].Cells[3].Text));

                snCell.HorizontalAlignment = 1;
                noOfTestCell.HorizontalAlignment = 1;
                totalAmountCell.HorizontalAlignment = 1;

                pdfTable.AddCell(snCell);
                pdfTable.AddCell(testNameCell);
                pdfTable.AddCell(noOfTestCell);
                pdfTable.AddCell(totalAmountCell);
            }

            Phrase totalPhrase = new Phrase("Total: " + totalFee + Environment.NewLine);
            Phrase dotlinePhrase2 = new Phrase("======================================================================" + Environment.NewLine);
            Phrase creditPhrase = new Phrase("<--- Managed by Team_MVC --->");

            Paragraph aParagraph = new Paragraph();
            aParagraph.Add(headingPhrase);
            aParagraph.Add(dotlinePhrase);
            aParagraph.Add(fromDatePhrase);
            aParagraph.Add(toDatePhrase);
            aParagraph.Add(Chunk.NEWLINE);
            aParagraph.Add(pdfTable);
            aParagraph.Add(Chunk.NEWLINE);
            aParagraph.Add(totalPhrase);
            aParagraph.Add(dotlinePhrase2);
            aParagraph.Add(creditPhrase);

            return aParagraph;
        }

        public Paragraph GetUnpaidBillReportPdfParagraph(string fromDate, string toDate, GridView aGridView, string totalFee)
        {
            var titleFont = FontFactory.GetFont("Candara", 18, Font.BOLD);
            Phrase headingPhrase = new Phrase("Unpaid Bill Report" + Environment.NewLine, titleFont);
            Phrase dotlinePhrase = new Phrase("======================================================================" + Environment.NewLine);
            Phrase fromDatePhrase = new Phrase("From Date: " + fromDate + Environment.NewLine);
            Phrase toDatePhrase = new Phrase("To Date: " + toDate + Environment.NewLine);

            PdfPTable pdfTable = new PdfPTable(5);

            PdfPCell SN = new PdfPCell(new Phrase("SN"));
            SN.HorizontalAlignment = 1;
            pdfTable.AddCell(SN);
            PdfPCell BillNo = new PdfPCell(new Phrase("Bill No"));
            BillNo.HorizontalAlignment = 1;
            pdfTable.AddCell(BillNo);
            PdfPCell PatientName = new PdfPCell(new Phrase("Patient Name"));
            PatientName.HorizontalAlignment = 1;
            pdfTable.AddCell(PatientName);
            PdfPCell MobileNo = new PdfPCell(new Phrase("Mobile No"));
            MobileNo.HorizontalAlignment = 1;
            pdfTable.AddCell(MobileNo);
            PdfPCell TotalAmount = new PdfPCell(new Phrase("Billl Amount"));
            TotalAmount.HorizontalAlignment = 1;
            pdfTable.AddCell(TotalAmount);

            int sn = 1;
            for (int i = 0; i < aGridView.Rows.Count; i++)
            {
                PdfPCell snCell = new PdfPCell(new Phrase(sn++.ToString()));
                PdfPCell billNoCell = new PdfPCell(new Phrase(aGridView.Rows[i].Cells[1].Text));
                PdfPCell nameCell = new PdfPCell(new Phrase(aGridView.Rows[i].Cells[2].Text));
                PdfPCell mobileNoCell = new PdfPCell(new Phrase(aGridView.Rows[i].Cells[3].Text));
                PdfPCell billAmountCell = new PdfPCell(new Phrase(aGridView.Rows[i].Cells[4].Text));

                snCell.HorizontalAlignment = 1;
                billNoCell.HorizontalAlignment = 1;
                mobileNoCell.HorizontalAlignment = 1;
                billAmountCell.HorizontalAlignment = 1;

                pdfTable.AddCell(snCell);
                pdfTable.AddCell(billNoCell);
                pdfTable.AddCell(nameCell);
                pdfTable.AddCell(mobileNoCell);
                pdfTable.AddCell(billAmountCell);
            }

            Phrase totalPhrase = new Phrase("Total: " + totalFee + Environment.NewLine);
            Phrase dotlinePhrase2 = new Phrase("======================================================================" + Environment.NewLine);
            Phrase creditPhrase = new Phrase("<--- Managed by Team --->");

            Paragraph aParagraph = new Paragraph();
            aParagraph.Add(headingPhrase);
            aParagraph.Add(dotlinePhrase);
            aParagraph.Add(fromDatePhrase);
            aParagraph.Add(toDatePhrase);
            aParagraph.Add(Chunk.NEWLINE);
            aParagraph.Add(pdfTable);
            aParagraph.Add(Chunk.NEWLINE);
            aParagraph.Add(totalPhrase);
            aParagraph.Add(dotlinePhrase2);
            aParagraph.Add(creditPhrase);

            return aParagraph;
        }
    }
}
