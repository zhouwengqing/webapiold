<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Xalipay.aspx.cs" Inherits="WebAPIClient.Pay.Xalipay" %>

<!DOCTYPE html>

<html lang="zh-cn" style="font-size: 100px !important">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>支付宝 扫一扫</title>

    <link rel="icon" href="../js/TB.ico" type="image/x-icon" />

    <meta name="keywords" content="">
    <meta name="description" content="">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta content="yes" name="apple-mobile-web-app-capable">
    <meta name="format-detection" content="telephone=no,email=no,adress=no">
    <link rel="stylesheet" href="../js/style.css">
    <script src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/base.js"></script>
    <script src="../js/jquery.qrcode.min.js"></script>
    <%-- <script src="../js/layer.js" type="text/javascript"></script>--%>
    <link rel="stylesheet" href="../js/layer.css" id="layuicss-layer">
    <style>
        .copy_btn {
            display: inline-block;
            width: 95%;
            height: 0.8rem;
            font-size: 18px;
            line-height: 0.8rem;
            letter-spacing: .05rem;
            background-color: #f8f8f8;
            color: red;
            font-weight: bold;
            -webkit-box-shadow: 0 .03rem .22rem 0 rgba(239,239,239,.5);
            -moz-box-shadow: 0 .03rem .22rem 0 rgba(239,239,239,.5);
            box-shadow: 0 .03rem .22rem 0 rgba(239,239,239,.5);
            -webkit-border-radius: .1rem;
            -moz-border-radius: .1rem;
            border-radius: .1rem;
        }
    </style>
</head>

<body class="alipay">
    <section class="wrap">
        <div class="top"><i class="logo"></i></div>
        <div class="main">
            <p class="money">￥100.00</p>
            <div class="box">
                <div class="qrcode">
                    <img class="logo-sm" src="../js/logo-alipay2.jpg" id="logo" style="display: none;">
                    <img src="" id="qrcode">
                    <div id="canvas" style="display: none;">
                        <canvas width="260" height="260"></canvas>
                    </div>
                </div>
                <p>打开支付宝[扫一扫]</p>
            </div>
            <p class="timeout">支付时间：<em id="minute" style="color: yellow; font-weight: bold;">01</em> 分 <em id="second" style="color: yellow; font-weight: bold;">29</em> 秒</p>

        </div>

        <div class="main" id="remark" style="margin-left: auto; margin-right: auto">
            <p class="orderid">
                1. 请将二维码截屏保存至相册<br>
                2. 打开支付宝扫一扫识别已保存的二维码<br>
                3. 请勿重复扫描，否则不会到账
            </p>
        </div>
        <input type="hidden" id="amount" runat="server" />
        <input type="hidden" id="imgamu" runat="server" />
        <script src="../js/clipboard.min.js"></script>
    </section>
    <script type="text/javascript">


        function isMobile() {
            var userAgentInfo = navigator.userAgent;
            var mobileAgents = ["Android", "iPhone", "SymbianOS", "Windows Phone", "iPad", "iPod"];
            var mobile_flag = false;

            //根据userAgent判断是否是手机
            for (var v = 0; v < mobileAgents.length; v++) {
                if (userAgentInfo.indexOf(mobileAgents[v]) > 0) {
                    mobile_flag = true;
                    break;
                }
            }
            var screen_width = window.screen.width;
            var screen_height = window.screen.height;
            //根据屏幕分辨率判断是否是手机
            if (screen_width < 500 && screen_height < 800) {
                mobile_flag = true;
            }
            return mobile_flag;
        }

        function mobileAgentsName(mobileAgentsName) {
            var userAgentInfo = navigator.userAgent;
            //var mobileAgents = [ "Android", "iPhone", "SymbianOS", "Windows Phone", "iPad","iPod"];
            var mobile_flag = false;
            //根据userAgent判断是否是手机

            if (userAgentInfo.indexOf(mobileAgentsName) > 0) {
                mobile_flag = true;
            }
            return mobile_flag;
        }

        $(function () {
            var intDiff = parseInt(120); //倒计时总秒数量
            $(".money").text("￥" + $("#amount").val())
            $("#qrcode").attr('src', $("#imgamu").val());
            if (isMobile()) {
                $('#remark').show();
            }
            function timer(intDiff) {
                window.setInterval(function () {
                    var day = 0,
                        hour = 0,
                        minute = 0,
                        second = 0;//时间默认值
                    if (intDiff > 0) {
                        day = Math.floor(intDiff / (60 * 60 * 24));
                        hour = Math.floor(intDiff / (60 * 60)) - (day * 24);
                        minute = Math.floor(intDiff / 60) - (day * 24 * 60) - (hour * 60);
                        second = Math.floor(intDiff) - (day * 24 * 60 * 60) - (hour * 60 * 60) - (minute * 60);
                        console.log(second,minute)
                        if (minute == 0 && second == 1) {
                            
                            getstatus("1");
                            clearInterval(timer);
                        }
                    }
                    if (minute <= 9) minute = '0' + minute;
                    if (second <= 9) second = '0' + second;
                    $('#minute').html(minute);
                    $('#second').html(second);
                    intDiff--;
                }, 1000);
            }

            timer(intDiff);

            function qrcode(text) {
                var canvas = $("#canvas").qrcode({
                    width: 260,
                    height: 260,
                    text: text
                }).hide();
                var canvas = canvas.find('canvas').get(0);
                $('#qrcode').attr('src', canvas.toDataURL('image/png'));
                //$("#logo").css('display','block');
            }
            function getstatus(val) {
                
                if (val == "1")
                    $('#qrcode').attr('src', "../js/expire.png");


            }
            getstatus("0");

            function closeWindow() {
                window.opener = null;
                window.open(' ', '_self', ' ');
                window.close();
            }
        })
</script>

    <div class="layui-layer-move"></div>
</body>
</html>
