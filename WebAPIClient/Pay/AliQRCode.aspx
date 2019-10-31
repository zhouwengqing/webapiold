<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AliQRCode.aspx.cs" Inherits="WebAPIClient.Pay.AliQRCode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <meta name="viewport" content="width=750,target-densitydpi=device-dpi,user-scalable=no" />
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
    <title>支付宝扫码</title>
</head>
<body>
    <form id="form1" runat="server">
          <div>
            <asp:Image runat="server" ID="img" AlternateText="支付宝二维码" ImageUrl="/i/eg_banner_w3school.gif" />
        </div>
    </form>
</body>
</html>
