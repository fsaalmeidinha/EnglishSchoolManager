<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastroAluno.aspx.cs"
    MasterPageFile="~/Site.master" Inherits="ESMWeb.cadastros.cadastroAluno" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Alunos</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <a href="listaAlunos.aspx">Voltar</a>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Cadastro de aluno
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <asp:Repeater runat="server" ID="rptErros" Visible="false">
                                    <%--<HeaderTemplate>
                                        <div class="clsErros_title">
                                            Erros</div>
                                    </HeaderTemplate>--%>
                                    <ItemTemplate>
                                        <div class="clsErros_msg">
                                            <asp:Label runat="server" Text='<%# "- " + Eval("Mensagem") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div class="col-lg-12">
                                <form id="form_cadastro" runat="server" role="form">
                                    <div class="form-group">
                                        <label>
                                            Nome*</label>
                                        <asp:TextBox runat="server" ClientIDMode="Static" ID="txtNome" class="form-control" required />
                                    </div>
                                    <div class="form-group">
                                        <label>
                                            Email*</label>
                                        <asp:TextBox type="email" runat="server" ClientIDMode="Static" ID="txtEmail" name="txtEmail"
                                            class="form-control" required />
                                    </div>
                                    <div class="form-group">
                                        <label>
                                            Telefone celular</label>
                                        <asp:TextBox type="text" runat="server" ClientIDMode="Static" ID="txtTelefone" name="txtTelefone"
                                            class="form-control telefone" />
                                    </div>
                                    <div class="form-group">
                                        <label>
                                            Senha*</label>
                                        <asp:TextBox TextMode="Password" ClientIDMode="Static" runat="server" ID="txtSenha"
                                            class="form-control" />
                                    </div>
                                    <div class="form-group">
                                        <label>
                                            Ativo*</label>
                                        <asp:CheckBox ClientIDMode="Static" runat="server" ID="cbAtivo" class="form-control" />
                                    </div>
                                    <asp:Button runat="server" ClientIDMode="Static" type="submit" class="btn btn-default"
                                        Text="Salvar" OnClick="btnSalvar_Click" />
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            //$(".telefone").mask("99999-9999");

            if ('<%= String.IsNullOrEmpty(Request.QueryString["Id"]).ToString().ToLower() %>' == 'false') {
                $('#txtEmail').attr('disabled', 'disabled');
            }
            else {
                $('#txtSenha').addClass('required');
            }

            jQuery("#form_cadastro").validate();
        });
    </script>
</asp:Content>
