<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="calendarioAulas.aspx.cs"
    MasterPageFile="~/Site.master" Inherits="ESMWeb.calendarios.calendarioAulas" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    Calendário de horários de aulas</h1>
            </div>
        </div>
        <div id="Div1">
            <%--<div id="divCarregando">
                <h2>
                    Carregando...</h2>
            </div>--%>
            <div class="row">
                <div class="col-lg-12">
                    <div class="table-responsive">
                        <div id="divHorariosAulas">
                            <table class="table table-striped table-bordered table-hover">
                                <thead>
                                    <tr>
                                        <th>
                                        </th>
                                        <th>
                                            Seg
                                        </th>
                                        <th>
                                            Ter
                                        </th>
                                        <th>
                                            Qua
                                        </th>
                                        <th>
                                            Qui
                                        </th>
                                        <th>
                                            Sex
                                        </th>
                                        <th>
                                            Sáb
                                        </th>
                                        <th>
                                            Dom
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater runat="server" ID="rptHorariosAulas">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <b>
                                                        <%# Eval("Horario") %></b>
                                                </td>
                                                <td <%# "onclick='openClass(" + Eval("AulaSegunda.Id")  + ")'" %> <%# "style='background-color:"+ Eval("BGColorSegunda") + "'" %>>
                                                </td>
                                                <td <%# "onclick='openClass(" + Eval("AulaTerca.Id")  + ")'" %> <%# "style='background-color:"+ Eval("BGColorTerca") + "'" %>>
                                                </td>
                                                <td <%# "onclick='openClass(" + Eval("AulaQuarta.Id")  + ")'" %> <%# "style='background-color:"+ Eval("BGColorQuarta") + "'" %>>
                                                </td>
                                                <td <%# "onclick='openClass(" + Eval("AulaQuinta.Id")  + ")'" %> <%# "style='background-color:"+ Eval("BGColorQuinta") + "'" %>>
                                                </td>
                                                <td <%# "onclick='openClass(" + Eval("AulaSexta.Id")  + ")'" %> <%# "style='background-color:"+ Eval("BGColorSexta") + "'" %>>
                                                </td>
                                                <td <%# "onclick='openClass(" + Eval("AulaSabado.Id")  + ")'" %> <%# "style='background-color:"+ Eval("BGColorSabado") + "'" %>>
                                                </td>
                                                <td <%# "onclick='openClass(" + Eval("AulaDomingo.Id")  + ")'" %> <%# "style='background-color:"+ Eval("BGColorDomingo") + "'" %>>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <b>Legenda</b>
                        </div>
                        <div class="table-responsive">
                            <div id="divLegendaAulas">
                                <table class="table table-striped table-bordered table-hover" id="tblLegendaAulas">
                                    <tbody>
                                        <asp:Repeater runat="server" ID="rptLegenda">
                                            <ItemTemplate>
                                                <tr>
                                                    <td class="corAula" <%# "style='background-color:"+ Eval("Value") + "'" %>>
                                                    </td>
                                                    <td>
                                                        <a href="#" <%# "onclick='openClass(" + Eval("Key.Id")  + ")'" %>>
                                                            <%# Eval("Key.Descricao") %>
                                                        </a>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $('#tblHorariosAulas').dataTable();
            $('#tblLegendaAulas').dataTable();
        });

        function openClass(classId) {
            if (classId != undefined) {
                var win = window.open('/cadastros/cadastroAula.aspx?Id=' + classId, '_blank');
                if (win) {
                    win.focus();
                } else {
                    //Broswer has blocked it
                    alert('Please allow popups for this site');
                }
            }
        }
    </script>
    <style>
        #divHorariosAulas
        {
            /*display:
    none;*/ /*min-width: 500px;*/
        }
        #tblHorariosAulas thead tr td
        {
            /*width: 60px;*/
            height: 30px;
        }
        .corAula
        {
            width: 60px;
        }
    </style>
</asp:Content>
