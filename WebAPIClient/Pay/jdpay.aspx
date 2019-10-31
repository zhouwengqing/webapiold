<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jdpay.aspx.cs" Inherits="WebAPIClient.Pay.jdpay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style type="text/css">
        #payyrl {
            display: block; /* iframes are inline by default */
            background: #fff;
            border: none; /* Reset default border */
            height: 100vh; /* Viewport-relative units */
            width: 100vw;
        }

        html, body {
            width: 100%;
            height: 100%;
            padding: 0px;
            margin: 0px;
        }

        .imgcss {
            width: 100%;
            height: 100%;
            position: relative;
        }

        #img {
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate3d(-50%,-50%,0)
        }
    </style>
    <title>京东扫码支付</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Image runat="server" ID="img" AlternateText="京东二维码" ImageUrl="/i/eg_banner_w3school.gif" />
    </form>
</body>
</html>
