<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExportToPdf.aspx.cs" Inherits="RnD.KendoUISample.WebViews.ExportToPdf" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/themes/base/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../Content/App/app-style.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.8.24.min.js" type="text/javascript"></script>
</head>
<body>
    <script type="text/javascript">

        function PrintElement(elem) {
            PrintPopup($(elem).html());
        }

        function PrintPopup(data) {

            var mywindow = window.open('', 'Category List', 'height=auto,width=auto');
            mywindow.document.write('<html><head><title>Category List</title>');
            /*optional stylesheet*/ //mywindow.document.write('<link rel="stylesheet" href="main.css" type="text/css" />');
            mywindow.document.write('</head><body >');
            mywindow.document.write(data);
            mywindow.document.write('</body></html>');

            mywindow.print();
            mywindow.close();

            return true;

        }

    </script>
    <form id="form1" runat="server">
    <div id="gridViewZone">
        <asp:GridView ID="gvExportToPdf" runat="server">
        </asp:GridView>
    </div>
    <br />
    <div id="printZone">
        <asp:Button ID="btnCodePrint" runat="server" Text="Export To PDF by iTextSharp" class="button"
            OnClick="btnCodePrint_Click" />&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnJQPrint" runat="server" Text="Export To PDF by C#" class="button"
            OnClick="btnJQPrint_Click" />
    </div>
    </form>
    <br />
    <div>
        <button class="button" onclick="PrintElement('#gridViewZone')">
            JQ Print GridView Data
        </button>
    </div>
</body>
</html>
