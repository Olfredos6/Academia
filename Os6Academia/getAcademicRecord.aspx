<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getAcademicRecord.aspx.cs" Inherits="Os6Academia.getAcademicRecord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
        <p>
            <br />
            <asp:Label ID="Label1" runat="server" BackColor="#FF9999" ForeColor="#666666" Text="Modify an entry :"></asp:Label>
        </p>
        <p>
            <asp:Label ID="SubjectNameLabel" runat="server" Text="Subject Name"></asp:Label>
            <asp:TextBox ID="subjectBox" runat="server" Width="272px"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Enter new Final Mark" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="newMarkBox" runat="server" Visible="False" Width="66px"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Update" Visible="False" />
            <br />
            <asp:Label ID="IDLabel" runat="server" Text="Subject ID "></asp:Label>
&nbsp;&nbsp; <asp:TextBox ID="IDBox" runat="server" Width="45px"></asp:TextBox>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Modify" Width="136px" />
            <asp:Label ID="errorLabel" runat="server" ForeColor="Red" Text="Incorrect ID or Subject Name" Visible="False"></asp:Label>
         </p>
    &nbsp;<p>
            <asp:Button ID="Button3" runat="server" OnClick="Button2_Click" Text="&lt;&lt;Back to home" />
        </p>
    </form>

</body>
</html>
