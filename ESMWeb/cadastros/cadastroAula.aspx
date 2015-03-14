<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastroAula.aspx.cs" MasterPageFile="~/Site.master"
    Inherits="ESMWeb.cadastros.cadastroAula" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="page-wrapper">
        <div id="main">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Aulas</h1>
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
                            <div>
                                <div class="row">
                                    <asp:Repeater runat="server" ID="rptErros" Visible="false">
                                        <%--<HeaderTemplate>
                                        <div class="clsErros_title">
                                            Erros</div>
                                    </HeaderTemplate>--%>
                                        <ItemTemplate>
                                            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 clsErros_msg">
                                                <asp:Label ID="Label1" runat="server" Text='<%# "- " + Eval("Mensagem") %>'></asp:Label>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <div>
                                    <form id="form_cadastro" runat="server" role="form">
                                        <div class="row form-group">
                                            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                                <label>
                                                    Descrição*</label>
                                                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtDescricao" CssClass="form-control" required />
                                            </div>
                                        </div>
                                        <div class="row form-group">
                                            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                                <label>
                                                    Horários</label>
                                                <asp:HiddenField ClientIDMode="Static" ID="hdnHorariosAula" runat="server" />
                                                <table id="tblHorarios" style="max-width: 600px;" class="table table-striped table-bordered table-hover">
                                                    <thead>
                                                        <tr>
                                                            <th>Dia semana
                                                            </th>
                                                            <th>Horário inicial
                                                            </th>
                                                            <th>Horário final
                                                            </th>
                                                            <th><span onclick="adicionarNovoHorario(this);" class="clsLink">Novo</span></th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                        <div class="row form-group">
                                            <div class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
                                                <label>
                                                    Particular*</label>
                                                <asp:CheckBox ClientIDMode="Static" runat="server" ID="cbParticular" onClick="javascript:tratarAulaParticular();"
                                                    class="form-control" />
                                            </div>
                                        </div>
                                        <div class="row form-group">
                                            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                                <label>
                                                    Valor por aluno*</label>
                                                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtValor" class="form-control" required />
                                            </div>
                                        </div>
                                        <div class="row form-group clsAulaEmGrupo">
                                            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                                <label>
                                                    Alunos*</label>
                                                <asp:ListBox DataTextField="Nome" DataValueField="Id" runat="server" ID="lbAlunos"
                                                    SelectionMode="Multiple" ClientIDMode="Static" class="form-control"></asp:ListBox>
                                                <%--<asp:DropDownList ClientIDMode="Static" runat="server" ID="DropDownList1" class="form-control required" />--%>
                                            </div>
                                        </div>
                                        <div class="row form-group">
                                            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                                <asp:Button ID="btnSalvar" runat="server" ClientIDMode="Static" type="submit" OnClientClick="atualizarHorariosAula();" class="btn btn-default"
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
            //jQuery('#main').validate();
        });


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

            //jQuery(".hora").mask("99:99");
            //jQuery.validator.addClassRules({
            //    hora: { time: true }
            //});

            jQuery("#txtValor").priceFormat({
                prefix: 'R$ ',
                centsSeparator: ',',
                thousandsSeparator: '.'
            });
        });

        function listarHorarios() {
            var horariosJson = $('#hdnHorariosAula').val();
            if (horariosJson != "") {
                horariosAula = JSON.parse($('#hdnHorariosAula').val());
            }

            $(horariosAula).each(function (ind, horario) {
                $.tmpl($('#horarioAulaTemplate'), horario).appendTo("#tblHorarios tbody");
                $('#tblHorarios tbody .clsDdlDiaSemana:last option[value=' + horario.DiaSemanaId + ']')[0].selected = true;
                $('#tblHorarios tbody .clsHoraInicial:last option[value=' + horario.HoraInicial + ']')[0].selected = true;
                $('#tblHorarios tbody .clsMinutoInicial:last option[value=' + horario.MinutoInicial + ']')[0].selected = true;
                $('#tblHorarios tbody .clsHoraFinal:last option[value=' + horario.HoraFinal + ']')[0].selected = true;
                $('#tblHorarios tbody .clsMinutoFinal:last option[value=' + horario.MinutoFinal + ']')[0].selected = true;

            });
        }

        function tratarAulaParticular() {
            if ($('#cbParticular').is(':checked')) {
                $('#lbAlunos').removeAttr("multiple");
                jQuery('#lbAlunos').select2({ multiple: false, placeholder: "Selecione o alunos desta aula" });
            }
            else {
                $('#lbAlunos').attr("multiple", "multiple");
                jQuery('#lbAlunos').select2({ multiple: true, placeholder: "Selecione o(s) alunos desta aula" });
            }
        }

        function adicionarNovoHorario() {
            var horarioTmpl = {
                DiaSemanaId: 1,
                HoraInicial: '07',
                MinutoInicial: '00',
                HoraFinal: '07',
                MinutoFinal: '00'
            };
            $.tmpl($('#horarioAulaTemplate'), horarioTmpl).appendTo("#tblHorarios tbody");
            $('#tblHorarios tbody .clsDdlDiaSemana:last option[value=' + horarioTmpl.DiaSemanaId + ']')[0].selected = true;
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
        }

        function atualizarHorariosAula() {
            $('#hdnHorariosAula').val(recuperarHorariosAulasJSON());
        }

        function recuperarHorariosAulasJSON() {
            var horarios = [];

            $('#tblHorarios tbody tr').each(function (ind, linhaTR) {
                var diaSemanaId = $(linhaTR).find('select').val();

                horarios.push({
                    DiaSemanaId: diaSemanaId,
                    HoraInicial: $(linhaTR).find('.clsHoraInicial').val(),
                    MinutoInicial: $(linhaTR).find('.clsMinutoInicial').val(),
                    HoraFinal: $(linhaTR).find('.clsHoraFinal').val(),
                    MinutoFinal: $(linhaTR).find('.clsMinutoFinal').val()
                });
            });

            return JSON.stringify(horarios);
        }
    </script>

    <script id="horarioAulaTemplate" type="text/x-jQuery-tmpl">
        <tr>
            <td>
                <select class="form-control clsDdlDiaSemana">
                    <option label="Segunda" value="1"></option>
                    <option label="Terça" value="2"></option>
                    <option label="Quarta" value="3"></option>
                    <option label="Quinta" value="4"></option>
                    <option label="Sexta" value="5"></option>
                    <option label="Sabado" value="6"></option>
                    <option label="Domingo" value="0"></option>
                </select></td>
            <td>
                <select style="width: 70px; float: left;" class="form-control clsHoraInicial">
                    <option label="07" value="07"></option>
                    <option label="08" value="08"></option>
                    <option label="09" value="09"></option>
                    <option label="10" value="10"></option>
                    <option label="11" value="11"></option>
                    <option label="12" value="12"></option>
                    <option label="13" value="13"></option>
                    <option label="14" value="14"></option>
                    <option label="15" value="15"></option>
                    <option label="16" value="16"></option>
                    <option label="17" value="17"></option>
                    <option label="18" value="18"></option>
                    <option label="19" value="19"></option>
                    <option label="20" value="20"></option>
                    <option label="21" value="21"></option>
                    <option label="22" value="22"></option>
                    <option label="23" value="23"></option>
                </select>
                <div style="float: left; padding: 5px;">:</div>
                <select style="width: 70px; float: left;" class="form-control clsMinutoInicial">
                    <option label="00" value="00"></option>
                    <option label="15" value="15"></option>
                    <option label="30" value="30"></option>
                    <option label="45" value="45"></option>
                </select>
            </td>
            <td>
                <select style="width: 70px; float: left;" class="form-control clsHoraFinal">
                    <option label="07" value="07"></option>
                    <option label="08" value="08"></option>
                    <option label="09" value="09"></option>
                    <option label="10" value="10"></option>
                    <option label="11" value="11"></option>
                    <option label="12" value="12"></option>
                    <option label="13" value="13"></option>
                    <option label="14" value="14"></option>
                    <option label="15" value="15"></option>
                    <option label="16" value="16"></option>
                    <option label="17" value="17"></option>
                    <option label="18" value="18"></option>
                    <option label="19" value="19"></option>
                    <option label="20" value="20"></option>
                    <option label="21" value="21"></option>
                    <option label="22" value="22"></option>
                    <option label="23" value="23"></option>
                </select>
                <div style="float: left; padding: 5px;">:</div>
                <select style="width: 70px; float: left;" class="form-control clsMinutoFinal">
                    <option label="00" value="00"></option>
                    <option label="15" value="15"></option>
                    <option label="30" value="30"></option>
                    <option label="45" value="45"></option>
                </select>
            </td>
            <td><span onclick="removerHorario(this);" class="clsLink">Excluir</span></td>
        </tr>
    </script>

    <style>
        .clsLink {
            text-decoration: underline;
            color: Blue;
            cursor: pointer;
        }
    </style>
</asp:Content>
