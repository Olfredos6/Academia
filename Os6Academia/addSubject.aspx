<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addSubject.aspx.cs" Inherits="Os6Academia.addSubject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Subject Full Name&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="subjectNameBox" runat="server"></asp:TextBox>
        <br />
        Subject Final Mark&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="markBox" runat="server"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="ADD" />
        <br/>
        <br/>
        &nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="&lt;&lt;Back to home" />
    
    </div>
    </form>
</body>
</html>
