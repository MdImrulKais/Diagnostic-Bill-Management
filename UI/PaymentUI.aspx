<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentUI.aspx.cs" Inherits="DiagnosticBillManagementSystem.UI.PaymentUI" %>

<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Payment Information</title>
    <link href="../Styles/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <h1>Payment</h1>
        <hr/>
        <br/>
        <asp:Label ID="billNoLabel" Text="Bill No" CssClass="lable" runat="server"></asp:Label>
        <asp:TextBox ID="billNoTextBox" CssClass="textBox" runat="server"></asp:TextBox>
        <br/>
        <asp:Label ID="orLabel" Text="Or" CssClass="lable" runat="server"></asp:Label>
        <br/>
        <br/>
        <asp:Label ID="mobileNoLabel" Text="Mobile No" CssClass="lable" runat="server"></asp:Label>
        <asp:TextBox ID="mobileNoTextBox" CssClass="textBox" runat="server"></asp:TextBox>
        <br/>
        <br/>
        <asp:Button ID="searchButton" Text="Search" CssClass="button" runat="server" OnClick="searchButton_Click"/>
        <br/>
        <br/>
        <asp:Label ID="outputLabel" CssClass="outputLabel" runat="server"></asp:Label>
        <br/>
        <br/>
        <asp:Label ID="amountLabel" Text="Amount" CssClass="lable" runat="server"></asp:Label>
        <asp:TextBox ID="amountTextBox" CssClass="textBox" ReadOnly="True" runat="server"></asp:TextBox>
        <br/>
        <br/>
        <asp:Label ID="dueDateLabel" Text="Due Date" CssClass="lable" runat="server"></asp:Label>
        <asp:TextBox ID="dueDateTextBox" CssClass="textBox" ReadOnly="True" runat="server"></asp:TextBox>
        <br/>
        <br/>
        <asp:Button ID="payButton" Text="Pay" CssClass="button" runat="server" OnClick="payButton_Click"/>
    </form>
    <div align="center">
        <br/>
        <br/>
        <br/>
        <a href="IndexUI.aspx" style="font-size:20px;">Go To Home Page</a>
    </div>
</body>
</html>
