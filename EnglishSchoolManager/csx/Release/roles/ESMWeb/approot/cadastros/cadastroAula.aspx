<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastroAula.aspx.cs" MasterPageFile="~/Site.master"
    Inherits="ESMWeb.cadastros.cadastroAula" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    Aulas</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <a href="listaAulas.aspx">Voltar</a>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Cadastro de aula
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
                                            <asp:Label ID="Label1" runat="server" Text='<%# "- " + Eval("Mensagem") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div class="col-lg-12">
                                <form id="form_cadastro" runat="server" role="form">
                                <div class="form-group">
                                    <label>
                                        Descrição</label>
                                    <asp:TextBox runat="server" ClientIDMode="Static" ID="txtDescricao" class="form-control" />
                                </div>
                                <div class="form-group">
                                    <label>
                                        Horarios</label>
                                    <div>
                                        <fieldset class="clsCamposHorarios">
                                            <div class="row">
                                                <div class="col-lg-2">
                                                    <label>
                                                        Dia semana</label></div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-2">
                                                    <select id="ddlDiaSemana" class="form-control">
                                                        <option label="Segunda" value="1"></option>
                                                        <option label="Terça" value="2"></option>
                                                        <option label="Quarta" value="3"></option>
                                                        <option label="Quinta" value="4"></option>
                                                        <option label="Sexta" value="5"></option>
                                                        <option label="Sabado" value="6"></option>
                                                        <option label="Domingo" value="0"></option>
                                                    </select></div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-2">
                                                    <label>
                                                        Horário inicial</label></div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-2">
                                                    <input type="text" id="txtHorarioInicial" class="form-control" />
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-2">
                                                    <label>
                                                        Horário final</label></div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-2">
                                                    <input type="text" id="txtHorarioFinal" class="form-control" />
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-2">
                                                    <div style="text-decoration: underline; cursor: pointer; color: Blue;" onclick="adicionarNovoHorario();">
                                                        + Adicionar
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-9">
                                                    <div class="table-responsive">
                                                        <asp:HiddenField ClientIDMode="Static" ID="hdnHorariosAula" runat="server" />
                                                        <table id="tblHorarios" class="table table-striped table-bordered table-hover">
                                                            <thead>
                                                                <tr>
                                                                    <th>
                                                                        Dia semana
                                                                    </th>
                                                                    <th>
                                                                        Horário inicial
                                                                    </th>
                                                                    <th>
                                                                        Horário final
                                                                    </th>
                                                                    <th>
                                                                    </th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Particular*</label>
                                    <asp:CheckBox ClientIDMode="Static" runat="server" ID="cbParticular" onClick="javascript:tratarAulaParticular();"
                                        class="form-control" />
                                </div>
                                <%--<div class="form-group clsAulaParticular">
                                    <label>
                                        Aluno*</label>
                                    <asp:DropDownList DataTextField="Nome" DataValueField="Id" ClientIDMode="Static"
                                        runat="server" ID="ddlAluno" class="form-control required clsAllowRequired" />
                                </div>--%>
                                <div class="form-group clsAulaEmGrupo">
                                    <label>
                                        Alunos*</label>
                                    <asp:ListBox DataTextField="Nome" DataValueField="Id" runat="server" ID="lbAlunos"
                                        SelectionMode="Multiple" ClientIDMode="Static" class="form-control"></asp:ListBox>
                                    <%--<asp:DropDownList ClientIDMode="Static" runat="server" ID="DropDownList1" class="form-control required" />--%>
                                </div>
                                <asp:Button ID="Button1" runat="server" ClientIDMode="Static" type="submit" class="btn btn-default"
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
        var horariosAula = [];

        $(document).ready(function () {
            if ('<%= String.IsNullOrEmpty(Request.QueryString["Id"]).ToString().ToLower() %>' == 'false') {
                $('#txtEmail').attr('disabled', 'disabled');
            }
            else {
                $('#txtSenha').addClass('required');
            }

            tratarAulaParticular();
            listarHorarios();
            $("#form_cadastro").validate();
        });

        function listarHorarios() {
            var horariosJson = $('#hdnHorariosAula').val();
            if (horariosJson != "") {
                horariosAula = JSON.parse($('#hdnHorariosAula').val());
            }
            $(horariosAula).each(function (ind, horario) { addHorario(horario, false); });
        }

        function tratarAulaParticular() {
            if ($('#cbParticular').is(':checked')) {
                //                $('.clsAulaParticular')[0].style.display = "inherit";
                //                $('.clsAulaParticular .clsAllowRequired').addClass('required');
                //                $('.clsAulaEmGrupo')[0].style.display = "none";
                //                $('.clsAulaEmGrupo .clsAllowRequired').removeClass('required');

                $('#lbAlunos').removeAttr("multiple");
            }
            else {
                //                $('.clsAulaParticular')[0].style.display = "none";
                //                $('.clsAulaParticular .clsAllowRequired').removeClass('required');
                //                $('.clsAulaEmGrupo')[0].style.display = "inherit";
                //                $('.clsAulaEmGrupo .clsAllowRequired').addClass('required');

                $('#lbAlunos').attr("multiple", "multiple");
            }
            $("#form_cadastro").validate();
        }

        function adicionarNovoHorario() {
            var horarioInicial = $('#txtHorarioInicial').val();
            var horarioFinal = $('#txtHorarioFinal').val();
            if (horarioInicial == "" || horarioFinal == "") {
                alert('Horários devem ser informados');
            }

            var idDiaSemana = $('#ddlDiaSemana option:selected').val();
            var descricaoDiaSemana = $('#ddlDiaSemana option:selected').attr('label');

            var horarioJson = { 'Codigo': new Date().getTime().toString(), 'HorarioInicio': getDateFromHourAndMinuteString(horarioInicial), 'HorarioFim': getDateFromHourAndMinuteString(horarioFinal), 'DiaSemanaId': idDiaSemana, 'DescricaoDiaSemana': descricaoDiaSemana, 'DescricaoHorarioInicio': horarioInicial, 'DescricaoHorarioFim': horarioFinal };
            addHorario(horarioJson, true);
        }

        function addHorario(horarioJson, addLista) {
            var trClass = ($('#tblHorarios tr').length % 2 == 0) ? "odd" : "even";
            $('#tblHorarios tbody').append('<tr id="' + horarioJson.Codigo + '" class="' + trClass + '"><td>' + horarioJson.DescricaoDiaSemana + '</td><td>' + horarioJson.DescricaoHorarioInicio + '</td><td>' + horarioJson.DescricaoHorarioFim + '</td><td><span onclick="removerHorario(this);" class="clsLink">Excluir</span></td></tr>')

            if (addLista) {
                horariosAula.push(horarioJson);
                atualizarHorariosAula();
            }
        }

        function getDateFromHourAndMinuteString(hourAndMinuteString) {
            var hora = parseInt(hourAndMinuteString.split(':')[0]);
            var minuto = parseInt(hourAndMinuteString.split(':')[1]);
            return new Date(2000, 0, 0, hora, minuto);
        }

        function removerHorario(item) {
            var linhaItem = $(item).closest('tr');
            var codigo = linhaItem.attr('id');
            var indRemover = -1;
            $(horariosAula).each(function (ind, horario) {
                if (horario.Codigo == codigo) {
                    indRemover = ind;
                }
            })
            horariosAula.splice(indRemover, 1);
            linhaItem.remove();
            atualizarHorariosAula();
        }

        function atualizarHorariosAula() {
            $('#hdnHorariosAula').val(customJSONstringify(horariosAula));
        }
    </script>
    <style>
        .clsCamposHorarios
        {
            margin-left: 25px;
        }
        
        .clsLink
        {
            text-decoration: underline;
            color: Blue;
            cursor: pointer;
        }
    </style>
</asp:Content>
