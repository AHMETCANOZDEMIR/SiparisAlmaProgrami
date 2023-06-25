<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsUI.Default1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Anasayfa - Sipariş Alma Programı</title>
    <link href="Stil.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <header>
                <div id="logoAlani">
                    <h1>Sipariş Alma Programı</h1>
                </div>

                <ul id="menu">
                    <li><a href="/">Anasayfa</a></li>
                    <li><a href="#">Hakkımızda</a></li>
                    <li><a href="#">Ürünlerimiz</a></li>
                    <li><a href="#">İletişim</a></li>
                </ul>
            </header>
            <div id="govde">
                <asp:Repeater ID="rptUrunler" runat="server">
                    <ItemTemplate>
                        <div>
                            <a href="#">
                                <img src="/Images/<%#Eval("Image") %>" alt="Resim Yok" />
                                <h3><%#Eval("Name") %></h3>
                            </a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
</body>
</html>
