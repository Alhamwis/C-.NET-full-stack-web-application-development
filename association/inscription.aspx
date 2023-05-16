<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inscription.aspx.cs" Inherits="association.inscription" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <%-- <link href="css/bootstrap.css" rel="stylesheet" />--%>
    <link href="Content/bootstrap.css" rel="stylesheet" />

    <title></title>
    <style>
        .wrapper1 {
            height: auto;
            display: flex;
            align-items: center;
            flex-direction: column;
            justify-content: center;
            width: 100% !important;
            padding: 20px;
            background-color: #f5f5f5 !important;
        }

        body {
            background-color: rgba(245,245,245,255);
        }

   

        h1,h2 {
            text-align: center;
            
        }

        .radio .btn,
        .radio-inline .btn {
            padding-left: 2em;
            min-width: 7em;
            text-align: left;
        }

        .form-group {
            text-align: left;
        }
        #But2{
            background:#e8ac04;
            color:white;
        }

        .radio label,
        .radio-inline label {
            text-align: left;
            padding-left: 0.5em;
        }

        /*    element.style {
            margin-left: -1px;
            width: 198px;
        }*/
        select#DropDownList1 {
            margin-left: -1px;
            width: 198px;
        }

        label.btn.btn-default {
            margin-left: -98px;
        }

      /*  element.style {
            width: 198px;
        }*/

        select#DropDownList2 {
            width: 198px;
        }

        span#Label8 {
            width: 193px;
        }

        a.btn.btn-danger {
            /* margin-left: -578px; */
            margin-right: 909px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="wrapper1">
                            <p class="lead" style="margin-left: 207px; font-style: oblique; font-family: cursive;">Humain<span style="color: forestgreen">CO</span></p>

        <h2 style="color: forestgreen">Formulaire d'inscription</h2>
                         <%if (Session["run"] == "2")
                             {%>
                        <a class="btn btn-danger" href="https://localhost:44323/Adherent/Index" style="display:none"><span class="glyphicon glyphicon-backward"> Return</span></a>
                         <%}
                             if (Session["run"] == "1")
                             {%>
                        <a class="btn btn-danger" href="https://localhost:44323/Adherent/Index" style="display:block"><span class="glyphicon glyphicon-backward"> Return</span></a>
                        <%} %>
            <div>
                <div>
                    <asp:Label ID="Label1" runat="server" Text="Nom"></asp:Label>
                </div>
                <div>
                    <asp:TextBox ID="TextBNom" runat="server" CssClass="form-control" ></asp:TextBox>
                </div>
            </div>
                <br />

            <div>
                <div>
                    <asp:Label ID="Label2" runat="server" Text="Prenom"></asp:Label>
                </div>
                <div>
                    <asp:TextBox ID="TextBPrenom" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
               </div>
                <br />

                <div class="form-group">
                
                  <div class="radio">
                
                    <label class="btn btn-default" >
                
                      <asp:RadioButton ID="IsMale" runat="server"
                
                        GroupName="gender"
                
                        Checked="true"
                
                        Text="Homme" />
                
                    </label>
                
                  </div>
                
                </div>
                
                <div class="form-group">
                
                  <div class="radio">
                
                    <label class="btn btn-default" style:"margin-left: -140px;">
                
                      <asp:RadioButton ID="IsFemale" runat="server"
                
                        GroupName="gender"
                
                        Text="Femme" />
                
                    </label>
                
                  </div>
                
                </div>
                <br />

                 <div>
                <div>
                <asp:Label ID="Label4" runat="server" Text="Date Naissance : "></asp:Label>
                </div>
           <div>
            <asp:Calendar ID="Calendar1" runat="server" Visible="false" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
        </div>
                <div>
        <asp:TextBox ID="TextDate" runat="server" CssClass="form-control"></asp:TextBox>
         </div>
        <div>
            <br />
        <asp:Button ID="But2" runat="server" Text="GetDate" style="background-color: forestgreen"  class="btn btn-outline-warning" OnClick="But2_Click"/>
        </div>
            </div>
                   <br />
                 <div>
                    <asp:Label ID="Label7" runat="server" Text="Choisissez votre ville:"></asp:Label>
                <div>
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
                <br />
                 <div>
                <div>
                    <asp:Label ID="Label3" runat="server" Text="Numéro de téléphone"></asp:Label>
                </div>
                <div>
                    <asp:TextBox ID="TextPhone" runat="server" CssClass="form-control" ></asp:TextBox>
                </div>
            </div>
                <br />
             <div>
                <div>
                    <asp:Label ID="Label5" runat="server" Text="Email"></asp:Label>
                </div>
                <div>
                    <asp:TextBox ID="TextBEmail" runat="server" class="form-control" TextMode="Email"></asp:TextBox>
                </div>
            </div>
                <br />
             <div>
                <div>
                    <asp:Label ID="Label6" runat="server" Text="Password"></asp:Label>
                </div>
                <div>
                    <asp:TextBox ID="TextBPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <br />
                    <asp:Label ID="Label8" runat="server" Text="Quel genre de travail faites-vous pour nous aider:"></asp:Label>
                 <div>
                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
                <br />
                      <div>
                <div>
                    <asp:Label ID="Label9" runat="server" Text="Paiement:"></asp:Label>
                </div>
                <div>
                    <asp:TextBox ID="TexPaiement" runat="server"  CssClass="form-control" TextMode="Number" value="0"></asp:TextBox>
                </div>
            </div>
                <br />
            <div>
                <asp:Button ID="Button1" runat="server" Text="S'inscrire" class="btn btn-warning" style="background-color: forestgreen;border:1px solid green" OnClick="Button1_Click" />
                <asp:Button ID="Btn2" runat="server" Text="Update" style="background-color: forestgreen" CssClass="btn btn-warning" OnClick="Btn2_Click" Visible="false"/>
                <br />
            </div>
        </div>
        </div>
    </form>
</body>
</html>

