<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="authentification.aspx.cs" Inherits="association.authentification" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <style>
        img.img-fluid {
            width: 528px;
            height: 308px;
            display: inline-block;
            border-radius: 10px;
            margin: 10px;
        }

        body {
            background-color: rgba(245,245,245,255);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class=" page-holder d-flex align-items-center">
            <div class="container">
                <div class="row align-items-center py-5">
                    <div class="col-5 col-lg-7 mx-auto mb-5 mb-lg-0">
                        <div class="pr-lg-5">
                            <img src="img/web.jpg" alt="" class="img-fluid" />
                            <p class="lead" style="margin-left: 207px; font-style: oblique; font-family: cursive;">Humain<span style="color: forestgreen">CO</span></p>
                        </div>
                    </div>
                    <div class="col-lg-5 px-lg-4">
                        <h1 class="text-base text-primary text-uppercase mb-4" style="color: forestgreen">Se Connecter</h1>
                        <h2 class="mb-4">Welcome Back!</h2>
                        <div class="form-group mb-4">
                            <asp:TextBox required="true" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="UserID" runat="server" ID="id"></asp:TextBox>

                        </div>
                        <div class="form-group mb-4">
                            <asp:TextBox required="true" TextMode="Password" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Password" runat="server" ID="key"></asp:TextBox>

                        </div>
                        <div class="form-group mb-4">
                            <div class="custom-control custom-checkbox">
                                <asp:CheckBox Text="&nbsp&nbsp&nbspRemember Me" runat="server" AutoPostBack="false" />
                            </div>
                        </div>
                        <asp:Button Text="LOGIN" Style="background-color: forestgreen;"
                            CssClass="btn btn-primary" Height="50px" Width="400px" runat="server" ID="keyid" OnClick="keyid_Click" />
                    </div>
                    <br />
                    <asp:LinkButton ID="LinkButton1" runat="server" Visible="false" Style="color: forestgreen" OnClick="LinkButton1_Click1">Créer un nouveau compte</asp:LinkButton>
                </div>
                <footer class="footer bg-white shadow align-self-end py-3 px-xl-5 w-100 " style="text-align: end; margin-top: 390px">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-6 text-center text-md-left text-primary">
                                <p class="mb-2 mb-md-0">Province &copy;2022</p>
                            </div>

                        </div>
                    </div>
                </footer>
            </div>
        </div>
    </form>
</body>
</html>
