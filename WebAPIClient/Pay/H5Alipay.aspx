<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="H5Alipay.aspx.cs" Inherits="WebAPIClient.Pay.H5Alipay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>支付宝</title>

    <style type="text/css">
        #payyrl {
            display: block; /* iframes are inline by default */
            background: #fff;
            border: none; /* Reset default border */
            height: 100vh; /* Viewport-relative units */
            width: 100vw;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <iframe runat="server" id="payyrl"></iframe>
        </div>
    </form>
</body>
</html>
