<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DetalheClienteRebate.aspx.cs" Inherits="Raizen.SICCadastro.Rebate.WebSite.DetalheClienteRebate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        //Disable Element
        function disableElement(elem) {
            elem.disabled = true;
        }

        //Validação Data Inicial
        $(document).ready(function () {
            $("#<%= txtDataInicial.ClientID %>").mask("99/99/9999");

            $("#<%= txtDataInicial.ClientID %>").focusout(function () {
                if (isPeriodo($("#<%= txtDataInicial.ClientID %>").val()) == false) {
                    $("#<%= txtDataInicial.ClientID %>").val("");
                    $(ShowMessageData("$Por favor, digite uma data válida." + "#<%= txtDataInicial.ClientID %>"));
                } else {
                    formatDefault("$" + "#<%= txtDataInicial.ClientID %>");
                }
            });
        });

        //Validação Data Final
        $(document).ready(function () {
            $("#<%= txtDataFinal.ClientID %>").mask("99/99/9999");

            $("#<%= txtDataFinal.ClientID %>").focusout(function () {
                if (isPeriodo($("#<%= txtDataFinal.ClientID %>").val()) == false) {
                    $("#<%= txtDataFinal.ClientID %>").val("");
                    $(ShowMessageData("$Por favor, digite uma data válida." + "#<%= txtDataFinal.ClientID %>"));
                } else {
                    formatDefault("$" + "#<%= txtDataFinal.ClientID %>");
                }
            });
        });

        //Validação Data Aditivo
        $(document).ready(function () {
            $("#<%= txtDataAditivo.ClientID %>").mask("99/9999");

            $("#<%= txtDataAditivo.ClientID %>").focusout(function () {
                if (isPeriodo("01/" + $("#<%= txtDataAditivo.ClientID %>").val()) == false) {
                    $("#<%= txtDataAditivo.ClientID %>").val("");
                    $(ShowMessageData("$Por favor, digite um período válido." + "#<%= txtDataAditivo.ClientID %>"));
                } else {
                    formatDefault("$" + "#<%= txtDataAditivo.ClientID %>");
                }
            });
        });

        //Verifica se um periodo informado é valido
        function isPeriodo(txtDate) {
            var currVal = txtDate;
            if (currVal == "__/__/____" || currVal == "01/__/____")
                return true;
            if (currVal == '')
                return false;

            //Declare Regex 
            var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
            var dtArray = currVal.match(rxDatePattern); // is format OK?
            if (dtArray == null)
                return false;

            //Checks for mm/dd/yyyy format.
            dtMonth = dtArray[3];
            dtDay = dtArray[1];
            dtYear = dtArray[5];

            var dataAtual = new Date();
            var dataForm = new Date(dtYear, dtMonth - 1, dtDay);

            if (dtMonth < 1 || dtMonth > 12)
                return false;
            else if (dtDay < 1 || dtDay > 31)
                return false;
            else if (dataForm > dataAtual)
                return false;
            else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31)
                return false;
            else if (dtMonth == 2) {
                var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
                if (dtDay > 29 || (dtDay == 29 && !isleap))
                    return false;
            }
            return true;
        }

        //Apresenta Mensagens Validação
        function ShowMessageData(message) {
            $(document).ready(function () {
                var lista = message.split('$');

                var bulleTedList = "<ul>";
                for (var i = 1; i < lista.length; i++) {
                    var controle = lista[i].split('#');
                    var nomecontrole = "#" + controle[1];
                    bulleTedList += "<li>" + controle[0] + "</li>";
                    $(nomecontrole).css("background-color", "#FAFFBD");
                    $(nomecontrole).css("font-weight", "bold");
                    $(nomecontrole).css("color", "black");

                }
                bulleTedList += "</ul>";
                $("#dialog").html(bulleTedList);
                $("#dialog").dialog(
                {
                    title: 'Mensagem',
                    modal: true,
                    resizable: false,
                    draggable: false
                });
            });
        }

        //Exibe modal de confirmação
        function ShowMessageOK() {
            $(document).ready(function () {
                $("#dialogOK").dialog(
                {
                    title: 'Mensagem',
                    modal: true,
                    resizable: false,
                    draggable: true,
                    height: 180,
                    width: 300
                })
                $("#dialogOK").parent().appendTo($("form:first"));
            });
        };

        //Formata os controle para seu estado default
        function formatDefault(controles) {
            $(document).ready(function () {
                var lista = controles.split('$');
                for (var i = 1; i < lista.length; i++) {
                    var controle = lista[i].split('#');
                    var nomecontrole = "#" + controle[1];
                    $(nomecontrole).css("background-color", "white");
                    $(nomecontrole).css("font-weight", "normal");
                    $(nomecontrole).css("color", "black");
                }
            });
        }

        //Apresenta Mensagens Validação
        function ShowMessage(message) {
            $(document).ready(function () {
                $("#dialog").text(message);
                $("#dialog").dialog(
                {
                    title: 'Mensagem',
                    modal: true,
                    resizable: false,
                    draggable: false
                });
            });
        }


        // Novos
        function ShowLogDetalhado(logHtml) {
            document.getElementById("logContent").innerHTML = logHtml;
            $("#logModal").dialog({
                title: "Log Detalhado do Cálculo Retroativo",
                modal: true,
                width: 650,
                height: 450,
                resizable: false,
                draggable: true
            });
        }

        function FecharLogModal() {
            $("#logModal").dialog("close");
        }



    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <div id="dialog" style="display: none; width: 300px; height: 300px;">
    </div>
    <div id="dialogOK" style="display: none; width: 300px; height: 180px;">
        <br />
        <table style="width: 100%">
            <tr>
                <td colspan="2" class="editor-field">
                    <center>
                        <asp:Label ID="lblMensagemOK" runat="server" />
                    </center>
                </td>
            </tr>
            <tr style="width: 100%">
                <td>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="editor-field">
                    <center>
                        <asp:Button ID="btnOK" runat="server" Text="Confirmar" OnClick="btnOK_Click" OnClientClick="disableElement(this);"
                            UseSubmitBehavior="false" />
                    </center>
                </td>
                <td class="editor-field">
                    <center>
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
                    </center>
                </td>
            </tr>
        </table>
    </div>
    <%--<div id="divTop" style="text-align: right;">
        <asp:LinkButton ID="btnVoltar" runat="server" Text="<< Voltar para a Tela Anterior"
            OnClick="btnVoltar_Click" />
    </div>--%>
    <div id="DadosCliente">
        <fieldset>
            <legend>Dados do Cliente</legend>
            <table style="width: 890px" border="0px">
                <tr style="height: 30px">
                    <td class="display-label" style="width: 90px">
                        <asp:Label ID="Label1" Text="IBM Cliente:" runat="server" />
                    </td>
                    <td class="display-field" style="width: 160px">
                        <asp:Label runat="server" ID="lblIbmCliente" />
                    </td>
                    <td class="display-label" style="width: 120px">
                        <asp:Label ID="Label2" Text="Razão Social Cliente:" runat="server" />
                    </td>
                    <td class="display-field">
                        <asp:Label runat="server" ID="lblCliente" />
                    </td>
                    <td class="display-label" style="width: 50px">
                        <asp:Label ID="Label8" Text="Periodo:" runat="server" />
                    </td>
                    <td class="display-field" style="width: 50px">
                        <asp:Label runat="server" ID="lblPeriodo" />
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td class="display-label" style="width: 90px">
                        <asp:Label ID="Label3" Text="Tipo Contrato:" runat="server" />
                    </td>
                    <td class="display-field" style="width: 160px">
                        <asp:Label runat="server" ID="lblTipoContrato" />
                    </td>
                    <td class="display-label" style="width: 120px">
                        <asp:Label ID="Label4" Text="Frequência de Pagto.:" runat="server" />
                    </td>
                    <td class="display-field" colspan="3">
                        <asp:Label runat="server" ID="lblFrequenciaPagto" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    <div id="Extrato">
        <asp:Panel ID="pnlExtrato" runat="server" DefaultButton="btnConsultar">
            <fieldset>
                <legend>Extrato</legend>
                <table style="width: 890px">
                    <tr style="height: 30px">
                        <td class="display-label" style="width: 120px">
                            <asp:Label ID="Label6" Text="Data Inicial: " runat="server"></asp:Label>
                        </td>
                        <td class="display-label">
                            <asp:TextBox ID="txtDataInicial" runat="server" MaxLength="10"></asp:TextBox>
                        </td>
                        <td class="display-label" style="width: 130px">
                            <asp:Label ID="Label5" Text="Data Final: " runat="server"></asp:Label>
                        </td>
                        <td class="display-field">
                            <asp:TextBox ID="txtDataFinal" runat="server" MaxLength="10"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnConsultar" runat="server" Text="Consultar" OnClick="btnConsultar_Click">
                            </asp:Button>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:GridView ID="grvExtrato" runat="server" EnableModelValidation="True" GridLines="None"
                    BorderStyle="None" RowStyle-Height="26" Width="100%" AutoGenerateColumns="False">
                    <EmptyDataTemplate>
                        Nenhum registro encontrado</EmptyDataTemplate>
                    <Columns>
                        <asp:BoundField HeaderText="Data Lançamento" DataField="DtLancamentoSic" DataFormatString="{0:dd/MM/yyyy hh:mm}">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Lançamento" DataField="VlLancamentoSic" DataFormatString="{0:N}">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Saldo" DataField="VlSaldoAtualSic" DataFormatString="{0:N}">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Observação" DataField="DsObsComplementoSic">
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </fieldset>
        </asp:Panel>
    </div>
    <div id="Calculos">
        <table border="0px">
            <tr id="btnRow1" runat="server">
                <td style="width: 30%">
                    <asp:Panel ID="pnlAditivo" runat="server" DefaultButton="btnCalcularAditivo">
                        <fieldset>
                            <legend>Aditivo</legend>
                            <br />
                            <table>
                                <tr style="height: 30px">
                                    <td class="display-label">
                                        <asp:Label ID="Label7" Text="A partir de: " runat="server" Style="white-space: nowrap"></asp:Label>
                                    </td>
                                    <td class="display-label">
                                        <asp:TextBox ID="txtDataAditivo" runat="server" MaxLength="10" Width="80px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnCalcularAditivo" runat="server" Text="Calcular" OnClientClick="disableElement(this);"
                                            UseSubmitBehavior="false" ToolTip="Calcula o Aditivo a partir do período informado"
                                            OnClick="btnCalcularAditivo_Click"></asp:Button>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </asp:Panel>
                </td>
                <td style="width: 35%">
                    <asp:Panel ID="pnlStatus" runat="server" DefaultButton="btnAlterarStatus">
                        <fieldset>
                            <legend>Alterar Status</legend>
                            <br />
                            <table style="width: 100%">
                                <tr style="height: 30px">
                                    <td class="display-label">
                                        <asp:DropDownList ID="ddlStatusRebate" runat="server" Width="200px">
                                            <asp:ListItem Value="0" Text="SELECIONE" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="Informações Inconsistentes"></asp:ListItem>
                                            <asp:ListItem Value="7" Text="Cancelado"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnAlterarStatus" runat="server" Text="Alterar" ToolTip="Altera o cliente para o status selecionado"
                                            OnClientClick="disableElement(this);" OnClick="btnAlterarStatus_Click" UseSubmitBehavior="false">
                                        </asp:Button>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </asp:Panel>
                </td>
                <td style="width: 35%">
                    <fieldset>
                        <legend>Cálculo</legend>
                        <br />
                        <table style="width: 100%">
                            <tr style="height: 30px">
                                <td style="text-align: center">
                                    <asp:Button ID="btnRecalcular" runat="server" Text="Recalcular" OnClientClick="disableElement(this);"
                                        UseSubmitBehavior="false" ToolTip="Refaz o cálculo do último período" OnClick="btnRecalcular_Click">
                                    </asp:Button>
                                </td>
                                <td style="text-align: center">
                                    <asp:Button ID="btnRetroativo" runat="server" Text="Retroativo" OnClientClick="disableElement(this);"
                                        UseSubmitBehavior="false" ToolTip="Faz o cálculo retroativo para clientes inserido com atraso"
                                        OnClick="btnRetroativo_Click"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr style="width: 100%">
                <td style="width: 30%" colspan="2" id="btnRow2" runat="server">
                    <fieldset>
                        <legend>Pagamento</legend>
                        <table border="0" width="100%">
                            <tr>
                                <td style="height: 30px;" colspan="2">
                                    <asp:CheckBox ID="chkPagtoManual" runat="server" Text="Pagamento Manual (não enviar para o SAP)"
                                        ToolTip="Quando marcado, não envia ordem de pagamento ao SAP" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 410px">
                                    <asp:TextBox ID="txtObsPagto" runat="server" Height="38px" Width="400px" TextMode="MultiLine" />
                                </td>
                                <td style="vertical-align: bottom;">
                                    <asp:Button ID="btnPagtoManual" runat="server" Text="Salvar" OnClick="btnPagtoManual_Click" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
                <td style="text-align: right; vertical-align: bottom;">
                    <div id="div2" style="text-align: right; font-size: 10pt; bottom: -10px;">
                        <asp:LinkButton ID="btnVoltar2" runat="server" Text="<< Voltar para a Tela Anterior"
                            OnClick="btnVoltar_Click" />
                    </div>
                    <br />
                </td>
            </tr>
        </table>
        <div id="div1" style="text-align: right;">
        </div>
    </div>

    <div id="logModal" style="display: none; width: 600px; height: 400px;">
        <div id="logContent" style="overflow: auto; height: 350px; padding: 10px; border: 1px solid #ccc; background-color: #fff;"></div>
        <div style="text-align: center; margin-top: 10px;">
            <button onclick="FecharLogModal();">Fechar</button>
        </div>
    </div>
</asp:Content>


