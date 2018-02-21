<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rowlog.aspx.cs" Inherits="rowlog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>User Menu</title>

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
                    <a href="login.aspx">Log Out</a>
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

    <form id="form1" runat="server" style="padding-top:15vh; padding-left:10vw;padding-right:10vw!important;">


        <!-- Hello Label -->
        <asp:Label ID="HelloLabel" runat="server" Text="_"></asp:Label>
        <br />
        <br />

        <asp:Label ID="LevelLabel" runat="server" Text="_"></asp:Label>
        <br />
        <br />

        <!-- Info for a simple user -->
        <div id="memberinfo" runat="server">
            <asp:Label ID="lastRowedDistanceAndUpdateDate" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="AllDistance" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="registrationDate" runat="server" Text=""></asp:Label><br />
            <br />
            <br />
        </div>

        <!-- Members table -->
        <div id="infoContent" runat="server">
        <asp:GridView ID="membersTable" class="table table-hover" style="padding-left:5vw;padding-right:5vw;" onrowdatabound="membersTable_RowDataBound" autogeneratecolumns="False" emptydatatext="No data available." runat="server">
             <Columns>
                 <asp:BoundField DataField="id_user" HeaderText="Member ID" SortExpression="id" />
                 <asp:BoundField DataField="id_user_name" HeaderText="Member Name" SortExpression="name" />
                 <asp:BoundField DataField="id_user_level" HeaderText="Member Level" SortExpression="User Level" />
                 <asp:BoundField DataField="id_user_last_distance" HeaderText="Last rowed distance" SortExpression="LastDist" />
                 <asp:BoundField DataField="id_user_all_distance" HeaderText="All rowed distance" SortExpression="AllDist" />
                 <asp:BoundField DataField="id_user_last_update_time" HeaderText="Last update time" SortExpression="LastUpd" />
                 <asp:BoundField DataField="id_user_creation_date" HeaderText="Registration date" SortExpression="RegDate" />
             </Columns>
        </asp:GridView>
        <br />
           <div id="updatingDistance" runat="server">
        <!-- Updating rowed distance -->
        <asp:Label ID="Label1" runat="server" Text="What's your rowed distance today?"></asp:Label><br />
        <asp:TextBox ID="DistanceBox" runat="server"></asp:TextBox>
        <asp:Button ID="UpdateBtn" class="btn btn-success" runat="server" Text="Submit" OnClick="UpdateBtn_Click" />

               </div>
            </div>

        <section class="col-md-12" style="height:40vh;padding-left: 0px;">
                <!-- Updating password -->
                <br />
                <div id="newPassContainer" class="col-md-3" style="padding-left: 0px;" runat="server" >
                <asp:Label ID="Label3" runat="server" Text="Change password:"></asp:Label><br />
                <asp:TextBox ID="newPassBox" runat="server"></asp:TextBox><br /><br />
                <asp:Button ID="newPassButton" class="btn btn-success" runat="server" Text="Update Password" OnClick="newPassButton_Click" />
                </div>
                <!-- Creating a new membership -->


                <div id="registerContainer" class="col-md-3" style="text-align=right; margin-bottom=15vh;" runat="server">
                    <asp:Label ID="useridlabel" runat="server" Text=""></asp:Label>

                    <asp:Label ID="Label2" runat="server" Text="Create New User"></asp:Label>
                    Name: <br /><asp:TextBox ID="newMemberName" runat="server"></asp:TextBox><br />
                    Level: <br /><asp:TextBox ID="newMemberLevel" runat="server"></asp:TextBox><br />
                    Password: <br /><asp:TextBox ID="newMemberPass" runat="server"></asp:TextBox>
                    <asp:Button ID="newMemberBtn" class="btn btn-success" runat="server" Text="Create" OnClick="newMemberBtn_Click" />



                </div>
                <div class="col-md-6" style="text-align:right;" runat="server">
                <asp:Button ID="logOut" class="btn btn-danger" runat="server" Text="Log out" OnClick="logOut_Click" />
                </div>
        </section>




    </div>
    </form>

        </body>
        <footer style="bottom:0;">

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



    <!-- SOLUTION BELONGS TO LIUTAURAS AND DEIVIDAS. GROUP 1. UCN 3'rd SEMESTER EXAM. -->
</html>
