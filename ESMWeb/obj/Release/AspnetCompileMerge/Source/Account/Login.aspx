<%@ Page Title="Log In" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ESMWeb.Account.Login" %>

<%--http://startbootstrap.com/template-overviews/sb-admin-2/--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head runat="server">
    <title>English School Manager</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="English School Manager" />
    <meta name="author" content="Felipe Almeida" />
    <%--<link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />--%>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <!-- Bootstrap Core CSS -->
    <link href="~/bootstrap/css/bootstrap.min.css" rel="stylesheet" />

    <%--<link href="~/bootstrap/css/plugins/timePicker/timepicker.min.css" rel="stylesheet" />--%>
    <!-- MetisMenu CSS -->
    <link href="~/bootstrap/css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="~/bootstrap/css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="~/bootstrap/font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet"
        type="text/css" />

    <!-- Select2 -->
    <%--<link href="//cdnjs.cloudflare.com/ajax/libs/select2/4.0.0-rc.1/css/select2.min.css" rel="stylesheet" />--%>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <!-- jQuery -->
    <script type="text/javascript" src="/bootstrap/js/jquery-1.11.0.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script type="text/javascript" src="/bootstrap/js/bootstrap.min.js"></script>

    <!-- DataTables JavaScript -->
    <script type="text/javascript" src="/bootstrap/js/bootstrapValidator.js"></script>


    <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Por favor, conecte-se</h3>
                    </div>
                    <div class="panel-body">
                        <form runat="server" role="form">
                            <fieldset>
                                <div class="form-group">
                                    <asp:TextBox type="email" runat="server" ID="txtEmail" class="form-control" CssClass="form-control" placeholder="E-mail" required autofocus></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox runat="server" ID="txtSenha" CssClass="form-control" placeholder="Senha" type="password" Text="" required></asp:TextBox>
                                </div>
                                <div class="checkbox">
                                    <label>
                                        <asp:CheckBox runat="server" ID="cbLembrarMe" Text="Lembre-me" />
                                    </label>
                                </div>
                                <asp:Button ID="btnLogin" runat="server" ClientIDMode="Static" type="submit" Text="Login" CssClass="btn btn-lg btn-success btn-block" OnClick="btnLogin_Click" />

                                <p runat="server" visible="false" id="paragraphWrongAccount" class="red-color block" style="font-size: 1.5em; color: red;">Usuário ou senha inválido.</p>
                            </fieldset>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>



</body>
</html>
