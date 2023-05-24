<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="SecurityProject2.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" BorderStyle="Solid" GridLines="Both" HorizontalAlign="Center">
                 <ItemTemplate>
        <table class = "table">
            <tr>
                <th colspan="2">
                    <b><%# Eval("Email") %></b>
                </th>
            </tr>
            <tr>
                <td colspan="2">
                    <%# Eval("Name") %>,
                    <%# Eval("DOB") %>,
                    <%# Eval("Mobileno") %>,
                    <%# Eval("Password") %>  <br />                   
                </td>
            </tr>
           
           
        </table>
    </ItemTemplate>
            </asp:DataList>
        </div>
    </form>
</body>
</html>
