<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>Log In</title>

    <script src="../js/jquery-3.1.1.min.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../css/styles.css" rel="stylesheet"/>
    <link href="../css/second-styles.css" rel="stylesheet"/>
    <link href="../css/animate.css" rel="stylesheet"/>
    <link href="../font-awesome/css/font-awesome.min.css" rel="stylesheet"/>

    <link rel="icon" href="../img/topico.png"/>
    <meta name="theme-color" content="#D85A4B" /> <!-- For Google adress bar. Cool inovative thing-->

    <link rel="stylesheet" type="text/css" href="../fonts/Bebas/MyFontsWebfontsKit.css"/>
    <link rel="stylesheet" type="text/css" href="../fonts/Penna/MyFontsWebfontsKit2.css"/>
    <link rel="stylesheet" type="text/css" href="../fonts/Nexa/MyFontsWebfontsKit3.css"/>
    <link rel="stylesheet" type="text/css" href="../fonts/Freight/font.css"/>
    <link rel="stylesheet" type="text/css" href="../fonts/Lato/font.css"/>
    <link rel="stylesheet" type="text/css" href="../fonts/LatoThin/font.css"/>
    <link rel="stylesheet" type="text/css" href="../fonts/LatoRegular/font.css"/>

</head>
<body style="overflow-y: hidden;">

    <body id="page-top" data-spy="scroll" data-target=".navbar-fixed-top">

  <nav class="navbar navbar-default navbar-fixed-top" style="background-color: #38454E;" role="navigation">
    <div class="container">
      <div class="navbar-header page-scroll">
        <a href="#menu-toggle" class="sidebar-button animated" id="menu-toggle"><i class="fa fa-bars fa-2x" aria-hidden="true"></i></a>

          <a class="logo page-scroll" href="../index.html"><img src="../img/iron-cross.png" alt=""></a>
            </div>
              </div>
                </nav>

  <div id="wrapper" class="">

        <div id="sidebar-wrapper">
            <ul class="sidebar-nav nexafont">
                <li>
                    <a href="login.aspx">Log In</a>
                </li>
                <li>
                    <a href="joinnow.html">Become a Member</a>
                </li>
                <li>
                    <a href="activities.html">Activities</a>
                </li>
                <li>
                    <a href="rules.html">Rules</a>
                </li>
                <li>
                    <a href="purpose.html">Our Purpose</a>
                </li>
                <li>
                    <a href="history.html">Club History</a>
                </li>
                <li>
                    <a href="contacts.html">Contacts</a>
                </li>
            </ul>
        </div>

      </div>

    </section>

    <form id="form1" runat="server" style="padding-top:30vh; text-align:center;">
    <div>

        <h5 id="infoLabel" class="latofont" style="color:lightcoral;" runat="server"></h5>

        <h4 class="latofont">User Name:</h4>
        <asp:TextBox ID="usernameBox" runat="server" OnTextChanged="usernameBox_TextChanged"></asp:TextBox>
        <br/><br/><br/>
        <h4 class="latofont">User Password:</h4>
        <asp:TextBox ID="passwordBox" runat="server" OnTextChanged="passwordBox_TextChanged" TextMode="Password"></asp:TextBox>
        <br/><br/>
        <asp:Button ID="loginbtn" class="btn btn-success" Text="Log in" runat="server" OnClick="loginbtn_Click" />



    </div>
    </form>

        <footer style="position:fixed;bottom:0;">

  <div class="footer-box-first">
    <div class="footer-subpages nexafont"><a href="purpose.html">About</a><a href="rules.html">Rules</a><a href="contacts.html">Contacts</a></div>
    <div class="footer-copyright nexafont"><p>Copyright © 2017 Aalborg Rowing Club</p></div>
  </div>

    <div class="footer-box-second">
      <div class="footer-social">

        <a href="https://www.facebook.com/AalborgRoklub/?fref=ts"><i class="fa fa-facebook-square fa-3x" aria-hidden="true"></i></a>
        <a href="https://www.linkedin.com/groups/833467/profile"><i class="fa fa-linkedin-square fa-3x" aria-hidden="true"></i></a>
        <a href="https://plus.google.com/"><i class="fa fa-google-plus-square fa-3x" aria-hidden="true"></i></a>

      </div>
    </div>

</footer>




    <script src="../js/jquery-3.1.1.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/customjs.js"></script>
    <script src="../js/jquery.easing.min.js"></script>
    <script src="../js/scrolling-nav.js"></script>

</body>
    <!-- SOLUTION BELONGS TO LIUTAURAS AND DEIVIDAS. GROUP 1. UCN 3'rd SEMESTER EXAM. -->
</html>
