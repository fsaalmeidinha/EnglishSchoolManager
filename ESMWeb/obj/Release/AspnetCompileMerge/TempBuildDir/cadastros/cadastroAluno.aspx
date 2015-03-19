<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastroAluno.aspx.cs"
    MasterPageFile="~/Site.master" Inherits="ESMWeb.cadastros.cadastroAluno" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="page-wrapper">
        <div id="main">
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
                            <div>
                                <div class="row">
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
                                <div>
                                    <form id="form_cadastro" runat="server" role="form">
                                        <div class="row form-group">
                                            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                                <label>
                                                    Nome*</label>
                                                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtNome" class="form-control" required />
                                            </div>
                                        </div>
                                        <div class="row form-group">
                                            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                                <label>
                                                    Email*</label>
                                                <asp:TextBox type="email" runat="server" ClientIDMode="Static" ID="txtEmail" name="txtEmail"
                                                    class="form-control" required />
                                            </div>
                                        </div>
                                        <div class="row form-group">
                                            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                                <label>
                                                    Telefone celular</label>
                                                <asp:TextBox type="text" runat="server" ClientIDMode="Static" ID="txtTelefone" name="txtTelefone"
                                                    class="form-control telefone" />
                                            </div>
                                        </div>
                                        <div class="row form-group">
                                            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                                <label>
                                                    Senha*</label>
                                                <asp:TextBox TextMode="Password" ClientIDMode="Static" runat="server" ID="txtSenha"
                                                    class="form-control" />
                                            </div>
                                        </div>
                                        <div class="row form-group">
                                            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                                <label>
                                                    Valor personalizado</label>
                                                <asp:CheckBox runat="server" ID="cbValorPersonalizado" onclick="cbValorPersonalizadoChanged();" ClientIDMode="Static" CssClass="form-control" />
                                            </div>
                                            <div id="divTxtValor" class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                                <label>
                                                    Valor*</label>
                                                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtValor" class="form-control" />
                                            </div>
                                        </div>

                                        <div class="row form-group">
                                            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                                <label>
                                                    Ativo*</label>
                                                <asp:CheckBox ClientIDMode="Static" runat="server" ID="cbAtivo" class="form-control" />
                                            </div>
                                        </div>
                                        <div class="row form-group">
                                            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                                <asp:Button runat="server" ClientIDMode="Static" type="submit" class="btn btn-default"
                                                    Text="Salvar" OnClick="btnSalvar_Click" />
                                            </div>
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            if ('<%= String.IsNullOrEmpty(Request.QueryString["Id"]).ToString().ToLower() %>' == 'false') {
                $('#txtEmail').attr('disabled', 'disabled');
            }
            else {
                $('#txtSenha').addClass('required');
            }

            jQuery("#txtValor").priceFormat({
                prefix: 'R$ ',
                centsSeparator: ',',
                thousandsSeparator: '.'
            });

            cbValorPersonalizadoChanged();
        });

        function cbValorPersonalizadoChanged() {
            if ($('#cbValorPersonalizado:checked').length > 0) {
                $('#divTxtValor').show();
            }
            else {
                $('#divTxtValor').hide();
            }
        }

    </script>
</asp:Content>
