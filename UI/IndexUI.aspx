<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexUI.aspx.cs" Inherits="DiagnosticBillManagementSystem.UI.IndexUI" %>

<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Index</title>
    <link href="../Styles/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Diagnostic Center Management System</h1>
            <hr />
            <br />
           <ul>
               <li><a href="TestTypeSetupUI.aspx">Test Type Name</a></li>
               <li><a href="TestSetupUI.aspx">Test Name</a></li>
               <li><a href="TestRequestEntry.aspx">Patient Information</a></li>
               <li><a href="PaymentUI.aspx">Payment Information</a></li>
           </ul>
    </div>
    </form>
</body>
</html>
