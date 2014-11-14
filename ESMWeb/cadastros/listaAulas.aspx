<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="listaAulas.aspx.cs" MasterPageFile="~/Site.master"
    Inherits="ESMWeb.cadastros.listaAulas" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    Aulas</h1>
            </div>
        </div>
        <div id="Div1">
            <div class="row">
                <div class="col-lg-12">
                    <a href="cadastroAula.aspx">+ Nova aula</a>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Lista de aulas
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered table-hover" id="dataTables-example">
                                    <thead>
                                        <tr>
                                            <th>
                                                Descrição / Horarios
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater runat="server" ID="rptUsuarios">
                                            <ItemTemplate>
                                                <tr class="odd gradeX">
                                                    <td>
                                                        <a href='<%# "/cadastros/cadastroAula.aspx?Id=" + Eval("Id") %>'>
                                                            <%# (Eval("Descricao") == "" ? String.Empty:Eval("Descricao") + " - ").ToString() + (Eval("DescricaoHorariosAula") ?? String.Empty).ToString()%></a>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <AlternatingItemTemplate>
                                                <tr class="even gradeX">
                                                    <td>
                                                        <a href='<%# "/cadastros/cadastroAula.aspx?Id=" + Eval("Id") %>'>
                                                            <%# (Eval("Descricao") == "" ? String.Empty:Eval("Descricao") + " - ").ToString() + (Eval("DescricaoHorariosAula") ?? String.Empty).ToString()%></a>
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
            $('#dataTables-example').dataTable();
        });
    </script>
</asp:Content>
