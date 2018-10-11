<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestTypeSetupUI.aspx.cs" Inherits="DiagnosticBillManagementSystem.UI.TestTypeSetupUI" %>

<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Test Type Name</title>
    <link href="../Styles/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <h1>Test Type Setup</h1>
        <hr/>
        <br/>
        <asp:Label ID="Lable1" Text="Type Name" CssClass="lable" runat="server"></asp:Label>
        <asp:TextBox ID="typeNameTextBox" CssClass="textBox" runat="server"></asp:TextBox>
        <br/>
        <asp:RequiredFieldValidator ID="requriedFieldValidator2" ControlToValidate="typeNameTextBox" CssClass="validatorText" ErrorMessage="*Requried" runat="server"></asp:RequiredFieldValidator>
        <br/>
        <asp:Label ID="outputLabel" CssClass="outputLabel" runat="server"></asp:Label>
        <br/>
        <br/>
        <asp:Button ID="saveButton" Text="Save" CssClass="button" runat="server" OnClick="saveButton_Click"/>
        <br/>
        <br/>
        <asp:GridView ID="TestTypeGridView" AutoGenerateColumns="False" CssClass="gridView" runat="server">
            <Columns>
                <asp:TemplateField HeaderText="SN" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Test Type" ItemStyle-Width="100px">
                <ItemTemplate>
                    <asp:Label Text='<%#Eval("TestTypeName") %>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:GridView>
       </form>
    <div align="center">
        <br/>
        <br/>
        <br/>
        <a href="IndexUI.aspx" style="font-size:20px;">Go To Home Page</a>
    </div>
</body>
</html>
