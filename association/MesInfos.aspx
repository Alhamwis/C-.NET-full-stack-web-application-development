<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MesInfos.aspx.cs" Inherits="association.MesInfos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.js"></script>
    <title></title>
    <style>
        a.btn.btn-danger {
            /* margin-left: -578px; */
            margin-right: 909px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="Email" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AutoGenerateEditButton="True" CssClass="table table-bordered table-hover table-responsive table-condensed">
                <Columns>
                    <asp:BoundField DataField="nom_complet" HeaderText="nom_complet" SortExpression="nom_complet" />
                    <asp:BoundField DataField="sexe" HeaderText="sexe" SortExpression="sexe" />
                    <asp:BoundField DataField="num_tel" HeaderText="num_tel" SortExpression="num_tel" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                    <asp:BoundField DataField="Age" HeaderText="Age" ReadOnly="True" SortExpression="Age" />
                    <asp:BoundField DataField="date_inscr" HeaderText="date_inscr" SortExpression="date_inscr" />
                    <asp:BoundField DataField="ville" HeaderText="ville" SortExpression="ville" />
                    <asp:BoundField DataField="paid" HeaderText="paid" SortExpression="paid" />
                    <asp:BoundField DataField="Paye" HeaderText="Paye" ReadOnly="True" SortExpression="Paye" />
                    <asp:BoundField DataField="role" HeaderText="role" SortExpression="role" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cnx %>" SelectCommand="SELECT Adherent.nom_complet, Adherent.sexe, Adherent.num_tel, Adherent.Email, Adherent.password, DATEDIFF(yyyy, Adherent.date_naissance, GETDATE()) AS Age, Adherent.date_inscr, ville.ville, Adherent.paid, Adherent.Paye, role.role FROM Adherent INNER JOIN role ON Adherent.role = role.idRole INNER JOIN ville ON Adherent.Villes = ville.idville WHERE (Adherent.Email = @e) or (Adherent.Email = @a)" UpdateCommand="UPDATE [Adherent] SET [nom_complet] = @nom_complet ,[sexe] = @sexe ,[num_tel] = @num_tel ,[Email] = @Email ,[password] = @password  ,[paid] = @paid where [Email]=@Email">
                <SelectParameters>
                    <asp:QueryStringParameter Name="e" QueryStringField="Email" />
                    <asp:SessionParameter Name="a" SessionField="adhd" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="nom_complet" />
                    <asp:Parameter Name="sexe" />
                    <asp:Parameter Name="num_tel" />
                    <asp:Parameter Name="Email" />
                    <asp:Parameter Name="password" />
                    <asp:Parameter Name="paid" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
        <div>
        <a class="btn btn-danger" href="https://localhost:44323/Home/Index" style="display: block; width: 88px; margin-left: auto; margin-right: auto;"><span class="glyphicon glyphicon-backward"> Return</span></a>
            </div>
    </form>
</body>
</html>
    
    
    