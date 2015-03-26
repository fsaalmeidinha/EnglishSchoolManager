<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pagamentos.aspx.cs" MasterPageFile="~/Site.master" Inherits="ESMWeb.pagamento.pagamentos" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Pagamentos</h1>
            </div>
        </div>
        <div id="Div1">
            <form id="form_Pagamentos" runat="server" role="form">
                <%--<div class="row">
                <div class="col-lg-12">
                    <a href="cadastroAula.aspx">+ Nova aula</a>
                </div>
            </div>--%>

                <div id="divFiltros" class="row">
                    <div class="col-sm-12 col-md-12">
                        <div class="panel panel-default">
                            <div class="panel-heading heading_esconder" onclick="divNovoPagamentoClick(this);">
                                Filtros
                            </div>
                            <div class="panel-body body_esconder">

                                <div class="row">
                                    <div class="col-sm-3 col-md-3">
                                        <label>
                                            Data inicial vencimento*</label>
                                        <asp:TextBox runat="server" ClientIDMode="Static" ID="txtDataInicial" class="form-control datetimepicker date-mask campoFiltro" required></asp:TextBox>
                                    </div>
                                    <div class="col-sm-3 col-md-3">
                                        <label>
                                            Data final vencimento*</label>
                                        <asp:TextBox runat="server" ClientIDMode="Static" ID="txtDataFinal" class="form-control datetimepicker date-mask campoFiltro" required></asp:TextBox>
                                    </div>
                                    <div class="col-sm-3 col-md-3">
                                        <label>
                                            Boleto pago?</label>
                                        <asp:DropDownList runat="server" ID="ddlBoletoPago" CssClass="form-control">
                                            <asp:ListItem Text="Ambos" Value="A">
                                            </asp:ListItem>
                                            <asp:ListItem Text="Sim" Value="S">
                                            </asp:ListItem>
                                            <asp:ListItem Text="Não" Value="N" Selected="True">
                                            </asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-3 col-md-3">
                                        <asp:Button ID="btnFiltrar" runat="server" ClientIDMode="Static" type="submit" Text="Filtrar" CssClass="btn btn-lg btn-success btn-block" OnClientClick="filtrar();" OnClick="btnFiltrar_Click" />
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading heading_esconder" onclick="divNovoPagamentoClick(this);">
                                Pagamentos
                            </div>
                            <!-- /.panel-heading -->
                            <div class="panel-body body_esconder">
                                <div class="table-responsive">
                                    <table class="table table-striped table-bordered table-hover" id="tblPagamentos">
                                        <thead>
                                            <tr>
                                                <th>Nome aluno
                                                </th>
                                                <th width="100">Vencimento
                                                </th>
                                                <th width="80">Pago?
                                                </th>
                                                <th width="100">Valor
                                                </th>
                                                <th width="350">Ações
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater runat="server" ID="rptPagamentos">
                                                <ItemTemplate>
                                                    <tr class="odd gradeX">
                                                        <td>
                                                            <a target="_blank" href='<%# String.Format("../cadastros/cadastroAluno.aspx?Id={0}", Eval("Aluno.Id")) %>'><%# Eval("Aluno.Nome")  %></a>
                                                        </td>
                                                        <td>
                                                            <%# Convert.ToDateTime(Eval("DataPagamento")).ToString("dd/MM/yyyy")  %>
                                                        </td>
                                                        <td>
                                                            <%# Convert.ToBoolean(Eval("PagamentoEfetuado"))?"Sim" : "Não" %>
                                                        </td>
                                                        <td>R$ <%# Convert.ToDecimal(Eval("Valor")).ToString("N2") %>
                                                        </td>
                                                        <td>
                                                            <asp:Button runat="server" ID="btnConfirmarPagamento" CommandArgument='<%# Eval("Id") %>'
                                                                Visible='<%# !Convert.ToBoolean(Eval("PagamentoEfetuado")) %>'
                                                                Text="Confirmar pagamento" CssClass="btn-success" OnClientClick="confirmarPagamento();"
                                                                OnClick="btnConfirmarPagamento_Click" />
                                                            <asp:Button runat="server" CommandArgument='<%# Eval("Id") %>'
                                                                Visible='<%# !Convert.ToBoolean(Eval("PagamentoEfetuado")) %>'
                                                                Text="Excluir pagamento" CssClass="btn-danger" OnClientClick="excluirPagamento();"
                                                                OnClick="btnExcluirPagamento_Click" />
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <AlternatingItemTemplate>
                                                    <tr class="even gradeX">
                                                        <td>
                                                            <a target="_blank" href='<%# String.Format("../cadastros/cadastroAluno.aspx?Id={0}", Eval("Aluno.Id")) %>'><%# Eval("Aluno.Nome")  %></a>
                                                        </td>
                                                        </a> 
                                                        <td>
                                                            <%# Convert.ToDateTime(Eval("DataPagamento")).ToString("dd/MM/yyyy")  %>
                                                        </td>
                                                        <td>
                                                            <%# Convert.ToBoolean(Eval("PagamentoEfetuado"))?"Sim" : "Não" %>
                                                        </td>
                                                        <td>R$ <%# Convert.ToDecimal(Eval("Valor")).ToString("N2") %>
                                                        </td>
                                                        <td>
                                                            <asp:Button runat="server" ID="btnConfirmarPagamento" CommandArgument='<%# Eval("Id") %>'
                                                                Visible='<%# !Convert.ToBoolean(Eval("PagamentoEfetuado")) %>'
                                                                Text="Confirmar pagamento" CssClass="btn-success" OnClientClick="confirmarPagamento();"
                                                                OnClick="btnConfirmarPagamento_Click" />
                                                            <asp:Button runat="server" CommandArgument='<%# Eval("Id") %>'
                                                                Visible='<%# !Convert.ToBoolean(Eval("PagamentoEfetuado")) %>'
                                                                Text="Excluir pagamento" CssClass="btn-danger" OnClientClick="excluirPagamento();"
                                                                OnClick="btnExcluirPagamento_Click" />
                                                        </td>
                                                    </tr>
                                                </AlternatingItemTemplate>
                                            </asp:Repeater>
                                            <%--<tr class="odd gradeX">
                                            <td>
                                                Trident
                                            </td>
                                            <td>
                                                Internet Explorer 4.0
                                            </td>
                                            <td>
                                                Win 95+
                                            </td>
                                        </tr>--%>
                                        </tbody>
                                    </table>
                                    <asp:Label runat="server" ID="lblTotalPago" Style="float: left; color: green; font-weight: bold;"></asp:Label>
                                    <asp:Label runat="server" ID="lblTotalPendencias" Style="float: right; color: red; font-weight: bold;"></asp:Label>
                                </div>
                            </div>
                            <!-- /.panel-body -->
                        </div>
                        <!-- /.panel -->
                    </div>
                    <!-- /.col-lg-12 -->
                </div>

                <div id="divNovoPagamento" class="row">
                    <div class="col-sm-12 col-md-12">
                        <div class="panel panel-default">
                            <div class="panel-heading heading_esconder" onclick="divNovoPagamentoClick(this);">
                                Criar novo pagamento
                            </div>
                            <div class="panel-body body_esconder">

                                <div class="row">
                                    <div class="col-sm-6 col-md-6">
                                        <label>
                                            Aluno*</label>
                                        <br />
                                        <asp:DropDownList DataTextField="Nome" DataValueField="Id" runat="server" ID="ddlAluno"
                                            ClientIDMode="Static" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-3 col-md-3">
                                        <label>
                                            Data vencimento*</label>
                                        <asp:TextBox runat="server" ClientIDMode="Static" ID="txtDataVencimento" class="form-control datetimepicker date-mask campoNovoPagamento" required></asp:TextBox>
                                    </div>
                                    <div class="col-sm-3 col-md-3">
                                        <asp:Button ID="btnCriarPagamento" runat="server" ClientIDMode="Static" type="submit" Text="Criar pagamento" CssClass="btn btn-lg btn-success btn-block" OnClientClick="adicionarPagamento();" OnClick="btnCriarPagamento_Click" />
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </div>
        <!-- /#page-wrapper -->
    </div>
    <script>
        $(document).ready(function () {
            jQuery('#tblPagamentos').dataTable();
            jQuery('#ddlAluno').select2({ placeholder: "Selecione o aluno" });
        });

        function filtrar() {
            $('.campoFiltro').attr('required', '');
            $('.campoNovoPagamento').removeAttr('required');
        }

        function adicionarPagamento() {
            $('.campoNovoPagamento').attr('required', '');
            $('.campoFiltro').removeAttr('required');
        }

        function divNovoPagamentoClick(elementoClicado) {
            var elementoAlterarVisibilidade = $(elementoClicado).parent().find('.body_esconder');
            if (elementoAlterarVisibilidade.hasClass('clsHidden')) {
                elementoAlterarVisibilidade.removeClass('clsHidden');
            }
            else {
                elementoAlterarVisibilidade.addClass('clsHidden');
            }
        }

        function confirmarPagamento() {
            if (confirm('Deseja realmente confirmar o pagamento?')) {
                $('.campoNovoPagamento, .campoFiltro').removeAttr('required');
                return true;
            }
            else {
                return false;
            }
        }

        function excluirPagamento() {
            if (confirm('Deseja realmente excluir o pagamento?')) {
                $('.campoNovoPagamento, .campoFiltro').removeAttr('required');
                return true;
            }
            else {
                return false;
            }
        }

    </script>
    <style>
        #btnFiltrar, #btnCriarPagamento {
            margin-top: 18px;
        }

        .panel-heading.heading_esconder {
            cursor: pointer;
        }

        .clsHidden {
            display: none;
        }
    </style>
</asp:Content>
