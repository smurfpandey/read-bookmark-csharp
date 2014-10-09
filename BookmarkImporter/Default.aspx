<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BookmarkImporter.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload ID="fuBookmark" runat="server" />
        <asp:Button ID="btnUpload" runat="server" Text="Utha lo!" OnClick="btnUpload_Click" />
    </div>
    </form>
</body>
</html>
