<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScanWX.aspx.cs" Inherits="WebAPIClient.Pay.ScanWX" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <style type="text/css">
        #payyrl {
            display: block; /* iframes are inline by default */
            background:#fff;
            border: none; /* Reset default border */
            height: 100vh; /* Viewport-relative units */
            width: 100vw;
        }

       
    </style>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>微信扫码</title>
</head>
<body>
    <form id="form1" runat="server">
         <div>
            <iframe runat="server" id="payyrl" ></iframe>
        </div>
    </form>
</body>
</html>
