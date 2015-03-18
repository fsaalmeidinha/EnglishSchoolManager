<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="listaHorariosAulas.aspx.cs"
    MasterPageFile="~/Site.master" Inherits="ESMWeb.cadastros.listaHorariosAulas" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    Horários das aulas por dia da semana</h1>
            </div>
        </div>
        <div id="Div1">
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Horários das aulas por dia da semana
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered table-hover" id="dataTables-example">
                                    <thead>
                                        <tr>
                                            <th>
                                                Dia semana
                                            </th>
                                            <th>
                                                Descrição aula
                                            </th>
                                            <th>
                                                Início
                                            </th>
                                            <th>
                                                Fim
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater runat="server" ID="rptHorariosAulas">
                                            <ItemTemplate>
                                                <tr class="odd gradeX">
                                                    <td>
                                                        <%# Eval("DescricaoDiaSemana") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("Aula.Descricao") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("DescricaoHorarioInicio") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("DescricaoHorarioFim") %>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <AlternatingItemTemplate>
                                                <tr class="even gradeX">
                                                    <td>
                                                        <%# Eval("DescricaoDiaSemana") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("Aula.Descricao") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("DescricaoHorarioInicio") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("DescricaoHorarioFim") %>
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
                            </div>
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>
                <!-- /.col-lg-12 -->
            </div>
        </div>
        <!-- /#page-wrapper -->
    </div>
    </div>
    <script>
        $(document).ready(function () {
            jQuery('#dataTables-example').dataTable();
        });
    </script>
</asp:Content>
