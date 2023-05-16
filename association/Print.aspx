<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Print.aspx.cs" Inherits="association.Print" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <%-- <link href="css/bootstrap.css" rel="stylesheet" />--%>
    <link href="Content/bootstrap.css" rel="stylesheet" />
<%-- <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/html2canvas@1.0.0-rc.5/dist/html2canvas.min.js">
    </script>
<script type="text/javascript">
    function ConvertToImage(btnExport) {
        html2canvas($("#wrapper1")[0]).then(function (canvas) {
            var base64 = canvas.toDataURL();
            $("[id*=hfImageData]").val(base64);
            __doPostBack(btnExport.name, "");
        });
        return false;
    }
</script>--%>

     <script src="https://cdnjs.cloudflare.com/ajax/libs/html2canvas/1.4.1/html2canvas.esm.js"></script>
    <script src="html2canvas.js"></script>

    <title></title>
    <style>
        .wrapper1 {
            height: auto;
            display: flex;
            align-items: center;
            flex-direction: column;
            padding: 20px;
            margin: 20px;
            border: 3px dashed;
            width: 425px;
            flex-wrap: wrap;
            align-content: flex-end;
        }

        body {
            background-color: rgba(245,245,245,255);
        }

        input[type="file"] {
            margin-left: -219px;
        }

        img {
            margin-left: -356px;
            margin-top: -62px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <input type="file" name="myImage" accept="image/png, image/gif, image/jpeg" onchange="loadFile(event)" />
            <asp:Panel ID="pnlContents" runat="server">
                <div class="wrapper1">
                    <p class="lead" style="margin-left: 207px; font-style: oblique; font-family: cursive;">Humain<span style="color: forestgreen">CO</span></p>
                    <img id="output" width="84px" height="84px" />
                    <div>
                        <div>
                            Nom:<asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                        </div>

                        <div>
                            Ville:<asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div>
                        <div>
                            Role:<asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                        </div>
                        <div>
                            Code:<asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <br />
                </div>
        </div>
        </asp:Panel>
        <div class="col-auto">
            <button onclick="screenshot()">get img</button>
      
        </div>
    </form>

    <script type="text/javascript">
        function validateFileType() {
            var fileName = document.getElementById("fileName").value;
            var idxDot = fileName.lastIndexOf(".") + 1;
            var extFile = fileName.substr(idxDot, fileName.length).toLowerCase();
            if (extFile == "jpg" || extFile == "jpeg" || extFile == "png") {
                //TO DO
            } else {
                alert("Only jpg/jpeg and png files are allowed!");
            }
        }
    </script>
    <script>
        var loadFile = function (event) {
            var output = document.getElementById('output');
            output.src = URL.createObjectURL(event.target.files[0]);
            output.onload = function () {
                URL.revokeObjectURL(output.src);// free memory
            }
        };
    </script>
<script>
    html2canvas(document.getElementById("wrapper1")).then((canvas) => {
        document.body.appendChild(canvas);
    });
</script>

</body>
</html>
