<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CalculoRebate.aspx.cs" Inherits="Raizen.SICCadastro.Rebate.WebSite.CalculoRebate"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        //Disable Element
        function disableElement(elem) {
            elem.disabled = true;
        }

        //Definições de carregamento da página
        $(document).ready(function () {
            $("#<%= txtPeriodo.ClientID %>").mask("99/9999");

            $("#<%= txtPeriodo.ClientID %>").focusout(function () {
                if (isPeriodo($("#<%= txtPeriodo.ClientID %>").val()) == false) {
                    $("#<%= txtPeriodo.ClientID %>").val("");
                    ShowMessageData("$Por favor, digite um período válido." + "#<%= txtPeriodo.ClientID %>");
                } else {
                    formatDefault("$" + "#<%= txtPeriodo.ClientID %>");
                }
            });

            $("#<%= txtIBM.ClientID %>").focusout(function () {
                formatIBM("<%= txtIBM.ClientID %>");
            });

            $("#<%= txtIBM.ClientID %>").keypress(function (event) {
                var keycode = (event.keyCode ? event.keyCode : event.which);
                if (keycode == '13') {
                    formatIBM("<%= txtIBM.ClientID %>");
                }
            });
        });

        //Formata IBM
        function formatIBM(txtIBM) {
            if (document.getElementById(txtIBM).value == '' || document.getElementById(txtIBM).value == 0)
                return;

            var str = '' + document.getElementById(txtIBM).value;

            while (str.length < 10) {
                str = '0' + str;
            }
            document.getElementById(txtIBM).value = str;
        }

        //Verifica se um periodo informado é valido
        function isPeriodo(txtDate) {
            var currVal = txtDate;
            if (currVal == "__/____")
                return true;
            if (currVal == '')
                return false;

            currVal = "01/" + currVal;
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

            if (dtMonth < 1 || dtMonth > 12)
                return false;
            else if (dtDay < 1 || dtDay > 31)
                return false;
            else if (dtYear > dataAtual.getFullYear())
                return false;
            else if (dtMonth > (dataAtual.getMonth() + 1) && dtYear > dataAtual.getFullYear())
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

        //Apresenta Mensagens Validação
        function ShowMessageLista(message) {
            $(document).ready(function () {
                var lista = message.split('$');
                var bulleTedList = "<ul>";
                for (var i = 1; i < lista.length; i++) {
                    var controle = lista[i].split('#');
                    var nomecontrole = "" + controle[1];
                    bulleTedList += "<li>" + controle[0] + "</li>";
                    $(nomecontrole).css("background-color", "#FAFFBD");
                    $(nomecontrole).css("font-weight", "bold");
                    $(nomecontrole).css("color", "black");
                }
                bulleTedList += "</ul>";
                $("#dialogLista").html(bulleTedList);
                $("#dialogLista").dialog(
                {
                    title: 'Mensagem',
                    modal: true,
                    resizable: false,
                    draggable: true,
                    height: 300,
                    width: 600

                });
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

        //Exibe modal de Detalhe
        function ShowDialogDetalhe() {
            $(document).ready(function () {
                $("#dialogDetalhe").dialog(
                {
                    title: 'Detalhe',
                    modal: true,
                    resizable: false,
                    draggable: true,
                    height: 450,
                    width: 650
                })
                $("#dialogDetalhe").parent().appendTo($("form:first"));
            });
        };

        //-------------------------------------------------------------------------------------------------
        //CheckBox GridView--------------------------------------------------------------------------------
        function HeaderClickSupport() {
            var grid = document.getElementById('<%= grvResultado.ClientID %>');
            var HeaderCheckBox;

            var cell = grid.rows[0].cells[0];
            for (j = 0; j < cell.childNodes.length; j++) {
                if (cell.childNodes[j].type == "checkbox") {
                    HeaderCheckBox = cell.childNodes[j];
                }
            }

            //Get target base & child control.            
            var TargetChildControl = "chkAprovado";

            //Get all the control of the type INPUT in the base control.
            var Inputs = grid.getElementsByTagName("input");

            //Checked/Unchecked all the checkBoxes in side the GridView.
            var cont = 0;
            var total = parseInt('<%= this.grvResultado.Rows.Count %>');
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(TargetChildControl, 0) >= 0 && Inputs[n].checked)
                    cont = cont + 1;

            //Reset Counter            
            if (cont == total)
                HeaderCheckBox.checked = true;
        }

        function HeaderClick(CheckBox) {
            //Get target base & child control.
            var TargetBaseControl = document.getElementById('<%= this.grvResultado.ClientID %>');
            var TargetChildControl = "chkAprovado";

            //Get all the control of the type INPUT in the base control.
            var Inputs = TargetBaseControl.getElementsByTagName("input");

            //Checked/Unchecked all the checkBoxes in side the GridView.
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' &&
                Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[n].checked = CheckBox.checked;
        }

        function ChildClick(CheckBox, HCheckBox) {
            //get target control.
            var HeaderCheckBox = document.getElementById(HCheckBox);

            //Get target base & child control.            
            var TargetChildControl = "chkAprovado";

            //Get all the control of the type INPUT in the base control.
            var grid = document.getElementById('<%= grvResultado.ClientID %>');
            var Inputs = grid.getElementsByTagName("input");

            //Checked/Unchecked all the checkBoxes in side the GridView.
            var cont = 0;
            var total = parseInt('<%= this.grvResultado.Rows.Count %>');
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(TargetChildControl, 0) >= 0 && Inputs[n].checked)
                    cont = cont + 1;

            //Change state of the header CheckBox.
            if (cont < total)
                HeaderCheckBox.checked = false;
            else if (cont == total)
                HeaderCheckBox.checked = true;
        }
        //CheckBox GridView--------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------       

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <div id="dialog" style="display: none; width: 300px; height: 300px;">
    </div>
    <div id="dialogLista" style="display: none; width: 800px; height: 600px;">
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
    <div id="dialogDetalhe" style="display: none;">
        <div>
            <fieldset>
                <legend>Dados do Cliente</legend>
                <table style="width: 100%">
                    <tr style="height: 30px">
                        <td class="display-label" style="width: 120px;">
                            <asp:Label ID="Label1d" Text="IBM Cliente:" runat="server" />
                        </td>
                        <td class="display-field" style="width: 130px">
                            <asp:Label runat="server" ID="lblIbmCliente" />
                        </td>
                        <td class="display-label" style="width: 130px">
                            <asp:Label ID="Label2d" Text="Razão Social:" runat="server" />
                        </td>
                        <td class="display-field" style="width: 200px">
                            <asp:Label runat="server" ID="lblCliente" />
                        </td>
                    </tr>
                    <tr style="height: 30px">
                        <td class="display-label">
                            <asp:Label ID="Label3d" Text="Tipo Contrato:" runat="server" />
                        </td>
                        <td class="display-field">
                            <asp:Label runat="server" ID="lblTipoContrato" />
                        </td>
                        <td class="display-label">
                            <asp:Label ID="Label4d" Text="Pagamento:" runat="server" />
                        </td>
                        <td class="display-field">
                            <asp:Label runat="server" ID="lblFrequenciaPagto" />
                        </td>
                    </tr>
                    <tr style="height: 30px">
                        <td class="display-label">
                            <asp:Label ID="Label5d" Text="Valor Bonificação: " runat="server"></asp:Label>
                        </td>
                        <td class="display-label">
                            <asp:Label ID="lblValorTotal" runat="server"></asp:Label>
                        </td>
                        <td class="display-label">
                            <asp:Label ID="Label6d" Text="Período do Cálculo: " runat="server"></asp:Label>
                        </td>
                        <td class="display-field">
                            <asp:Label ID="lblPeriodo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <asp:Panel ID="pnlControleVolume" runat="server" Visible="false">
                        <tr>
                            <td class="display-label"><span>Volume Limite</span></td>
                            <td class="display-field">
                                <asp:Label ID="lblVolumeLimite" runat="server"></asp:Label>
                            </td>
                            <td class="display-label"><span>Volume Comprado</span></td>
                            <td class="display-field">
                                <asp:Label ID="lblVolumeComprado" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </fieldset>
        </div>
        <asp:Panel ID="pnlPagamentoProporcional" runat="server">
            <fieldset>
                <legend>Pagamento Proporcional</legend>
                <asp:GridView ID="grvPagamentoProporcional" runat="server"
                    GridLines="None"
                    BorderStyle="None"
                    Width="100%"
                    RowStyle-Height="38"
                    AutoGenerateColumns="false"
                    EnableModelValidation="true">
                    <Columns>
                        <asp:BoundField HeaderText="IBM" DataField="NrIbmClienteSic" />
                        <asp:BoundField HeaderText="Cod. Fornecedor" DataField="NrCodigoFornecedorRebateSic" />
                        <asp:BoundField HeaderText="Vol. Comprado" DataField="VlVolumeCalculadoSic" DataFormatString="{0:N}" />
                        <asp:BoundField HeaderText="Valor Bonif." DataField="VlValorBonificacaoProporcionalSic" DataFormatString="{0:N}" />
                        <%--<asp:BoundField HeaderText="% Ref." DataField="VlProporcaoSic" />--%>
                    </Columns>
                </asp:GridView>
            </fieldset>
        </asp:Panel>
        <div>
            <fieldset>
                <legend>Detalhe da Bonificação</legend>
                <br />
                <div id="divProporcional" runat="server" visible="false">
                    <asp:Label ID="lblProporcional" runat="server" Text="" CssClass="display-label"></asp:Label>
                    <br />
                    <br />
                </div>
                <asp:GridView ID="grvDetalhe" runat="server" GridLines="None" BorderStyle="None"
                    Width="100%" RowStyle-Height="38" AutoGenerateColumns="False" EnableModelValidation="True"
                    OnRowDataBound="grvDetalhe_RowCreated">
                    <EmptyDataTemplate>
                        Nenhum registro encontrado</EmptyDataTemplate>
                    <RowStyle Height="26px"></RowStyle>
                    <Columns>
                        <asp:BoundField HeaderText="Categoria" DataField="NomeCategoria">
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Bonif. Unit." DataField="BonificacaoUnitaria" DataFormatString="{0:N}">
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Vol. Contratado" DataField="VolumeContratado" DataFormatString="{0:N}">
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="% Mín." DataField="PercentualMinimo">
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="% Máx." DataField="PercentualMáximo">
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Vol. Mín." DataField="VolumeMinimo" DataFormatString="{0:N}">
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Vol. Máx" DataField="VolumeMaximo" DataFormatString="{0:N}">
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Vol. Comprado" DataField="VolumeCompradoPeriodo" DataFormatString="{0:N}">
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Valor Bonif." DataField="ValorBonificacaoCategoria" DataFormatString="{0:N}">
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="grvDetalheEscalonado" runat="server" 
                    GridLines="None" BorderStyle="None"
                    Width="100%" RowStyle-Height="38" 
                    AutoGenerateColumns="False">
                    <EmptyDataTemplate>Nenhum registro encontrado</EmptyDataTemplate>
                    <RowStyle Height="26px"></RowStyle>
                    <Columns>
                        <asp:BoundField HeaderText="Categoria" DataField="NomeCategoria">
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Bonif. Unit." DataField="BonificacaoUnitaria" DataFormatString="{0:N}">
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Vol. Mín." DataField="VolumeMinimo" DataFormatString="{0:N}">
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Vol. Máx" DataField="VolumeMaximo" DataFormatString="{0:N}">
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Vol. Comprado" DataField="VolumeCompradoPeriodo" DataFormatString="{0:N}">
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Valor Bonif." DataField="ValorBonificacaoCategoria" DataFormatString="{0:N}">
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblInfo" runat="server" Text="" ForeColor="Red" />
            </fieldset>
        </div>
    </div>
    <div>
        <asp:Panel ID="pnlDefault" DefaultButton="btnBuscar" runat="server">
            <fieldset>
                <legend>Buscar Bonificação</legend>
                <br />
                <table style="width: 100%" border="0px">
                    <tr>
                        <td class="editor-label" style="width: 65px">
                            <asp:Label ID="lblPeriodoBusca" Text="Período: " runat="server" />
                        </td>
                        <td class="editor-field" style="width: 20px">
                            &nbsp;<asp:TextBox runat="server" ID="txtPeriodo" MaxLength="7" />
                        </td>
                        <td class="editor-label" style="width: 10px">
                            <asp:Label ID="lblIBM" Text="IBM: " runat="server" />
                        </td>
                        <td class="editor-field" style="width: 25px">
                            <asp:TextBox runat="server" ID="txtIBM" MaxLength="10" />
                        </td>
                        <td class="editor-label" style="width: 10px">
                            <asp:Label ID="lblFiltro" Text="Situação: " runat="server" />
                        </td>
                        <td class="editor-field" style="width: 260px">
                            <asp:DropDownList ID="ddlSituacao" runat="server" Width="250px" AutoPostBack="False">
                                <asp:ListItem Text="SELECIONE" Value="0" />
                                <asp:ListItem Text="Bonificação Pendente de Pagamento" Value="1" />
                                <asp:ListItem Text="Aprovado pelo Analista" Value="2" />
                                <asp:ListItem Text="Enviado Aprovacao do Gestor" Value="3" />
                                <asp:ListItem Text="Enviado para Pagamento" Value="4" />
                                <asp:ListItem Text="Pago" Value="5" />
                                <asp:ListItem Text="Bonificação Cancelada" Value="6" />
                                <asp:ListItem Text="Calculo Retroativo" Value="7" />
                                <asp:ListItem Text="Rebate com Débito" Value="8" />
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvSituacao" ErrorMessage="*" ControlToValidate="ddlSituacao"
                                ValidationGroup="Buscar" runat="server" />
                        </td>
                        <td class="editor-field" style="width: 30px">
                        </td>
                    </tr>
                    <tr>
                        <td class="editor-label">
                            Tipo Rebate:
                        </td>
                        <td colspan="3">
                            <table>
                                <tr>
                                    <td><asp:CheckBox ID="chkFaixaVolume" runat="server" Text="Faixa Volume" Checked="true" /></td>
                                    <td><asp:CheckBox ID="chkEscalonado" runat="server" Text="Escalonado" Checked="true" /></td>
                                </tr>
                                <tr>
                                    <td><asp:CheckBox ID="chkMediaVolume" runat="server" Text="Global Média Volume" Checked="true" /></td>
                                    <td><asp:CheckBox ID="chkSomaVolume" runat="server" Text="Global Soma Volume" Checked="true" /></td>
                                </tr>
                            </table>
                        </td>
                        <td class="editor-label" style="width: 10px">
                            <asp:Label ID="Label2" Text="Canal: " runat="server" />
                        </td>
                        <td class="editor-field" style="width: 260px">
                            <asp:DropDownList ID="ddlCanal" runat="server" Width="250px" AutoPostBack="False">
                                <asp:ListItem Text="SELECIONE" Value="0" />
                                <asp:ListItem Text="A" Value="A" />
                                <asp:ListItem Text="C" Value="C" />
                                <asp:ListItem Text="V" Value="V" />
                            </asp:DropDownList>
                        </td>
                        <td class="editor-field" style="width: 30px">
                            <asp:Button Text="Consultar" runat="server" ID="btnBuscar" ValidationGroup="Buscar"
                                CausesValidation="false" OnClick="btnBuscar_Click" OnClientClick="disableElement(this);"
                                UseSubmitBehavior="false" />
                        </td>
                    </tr>
                    <tr>
                        <td class="editor-label">
                        </td>
                        <td colspan="3">
                        </td>
                        <td class="editor-label" style="width: 50px">
                            <asp:Label ID="Label3" Text="Aprovação Massiva: " runat="server" />
                        </td>
                        <td class="editor-field" style="width: 260px">
                            <asp:CheckBox ID="chkAprovacaoMassiva" runat="server" Width="50px" AutoPostBack="False">
                            </asp:CheckBox>
                        </td>
                        <td class="editor-field" style="width: 30px">
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset>
                <legend>Resultado</legend>
                <br />
                <div style="text-align: center;" runat="server" id="divHeader" visible="false">
                    <asp:Label runat="server" ID="lblTotal" Text="0" />
                    <asp:Label runat="server" ID="lblInfoReg" Text=" registro(s) encontrado(s) - R$" />
                    <asp:Label runat="server" ID="lblTotalMoeda" Text="0" />
                    (
                    <asp:LinkButton Text="Selecionar Todos" runat="server" ID="lnkSelecionarTodos" CausesValidation="false"
                        OnClick="lnkSelecionarTodosBuscar_Click" />
                    /
                    <asp:LinkButton Text="Desmarcar Todos" runat="server" ID="lnkLimparSelecao" CausesValidation="false"
                        OnClick="lnkLimparSelecao_Click" />
                    )
                </div>
                <br />
                <asp:GridView ID="grvResultado" runat="server" GridLines="None" BorderStyle="None"
                    RowStyle-Height="26" AutoGenerateColumns="False" EnableModelValidation="True"
                    DataKeyNames="CodigoCalculoRebate" OnRowCreated="grvResultado_RowCreated" Width="880px"
                    AllowPaging="true" PageSize="50" EmptyDataText="No Record Found" OnPageIndexChanging="grvResultado_PageIndexChanging"
                    OnDataBound="grvResultado_DataBound" OnRowDataBound="grvResultado_RowDataBound"
                    AllowSorting="true" OnSorting="grvResultado_Sorting">
                    <RowStyle Height="26px"></RowStyle>
                    <PagerTemplate>
                        <hr style="width: 100%;">
                        <table border="0" width="100%">
                            <tr>
                                <td style="text-align: left; vertical-align: middle;">
                                    <asp:Label ID="Label1" Text="Página: " runat="server"></asp:Label>
                                    <asp:DropDownList ID="ddCurrentPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddCurrentPage_SelectedIndexChanged"
                                        Width="15px">
                                    </asp:DropDownList>
                                    <asp:Label ID="lblOf" runat="server" Style="text-align: center;" Text="de"></asp:Label>
                                    <asp:Label ID="lblTotalPage" runat="server"></asp:Label>
                                </td>
                                <td style="text-align: right; vertical-align: middle;">
                                    <asp:ImageButton ID="imgPageFirst" runat="server" CommandArgument="First" CommandName="Page"
                                        ImageUrl="~/images/icons/resultset_first.png" OnCommand="imgPageFirst_Command" />
                                    <asp:ImageButton ID="imgPagePrevious" runat="server" CommandArgument="Prev" CommandName="Page"
                                        ImageUrl="~/images/icons/resultset_previous.png" OnCommand="imgPagePrevious_Command" />
                                    <asp:ImageButton ID="imgPageNext" runat="server" CommandArgument="Next" CommandName="Page"
                                        ImageUrl="~/images/icons/resultset_next.png" OnCommand="imgPageNext_Command" />
                                    <asp:ImageButton ID="imgPageLast" runat="server" CommandArgument="Last" CommandName="Page"
                                        ImageUrl="~/images/icons/resultset_last.png" OnCommand="imgPageLast_Command" />
                                </td>
                            </tr>
                        </table>
                    </PagerTemplate>
                    <EmptyDataTemplate>
                        <div style="text-align: center;">
                            Nenhum Registro Encontrado.</div>
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkAprovado" runat="server" Checked=' <%# Eval("Selecionado")%>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20px" />
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkHeaderAprovado" onclick="javascript:HeaderClick(this);" runat="server"
                                    Visible="true" />
                            </HeaderTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="IBM" DataField="CodigoIBM">
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Fornecedor" DataField="CodigoIBMFornecedor">
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Cliente" DataField="NomeCliente">
                            <HeaderStyle HorizontalAlign="Center" Width="125px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="">
                            <HeaderStyle HorizontalAlign="Center" Width="2px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Calculo" DataField="TipoBonificacao">
                            <HeaderStyle HorizontalAlign="Center" Width="40px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Bonificação" DataField="ValorBonificacao" SortExpression="ValorBonificacao" DataFormatString="{0:N}"
                            NullDisplayText="0,00">
                            <HeaderStyle HorizontalAlign="Center" Width="50px" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Bonif. Ant." DataField="ValorBonificacaoAnterior" DataFormatString="{0:N}"
                            NullDisplayText="0,00">
                            <HeaderStyle HorizontalAlign="Center" Width="50px" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Diferença" DataField="PercentualDiferencaBonificacao"
                            DataFormatString="{0:P0}" NullDisplayText="0,00">
                            <HeaderStyle HorizontalAlign="Center" Width="50px" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Débito" DataField="ValorDebito" DataFormatString="{0:N}"
                            NullDisplayText="0,00">
                            <HeaderStyle HorizontalAlign="Center" Width="50px" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Dt. Pagto." DataField="DataPagamento" DataFormatString="{0:dd/MM/yyyy}">
                            <HeaderStyle HorizontalAlign="Center" Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Status" DataField="DescricaoStatus">
                            <HeaderStyle HorizontalAlign="Center" Width="85px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnDetalhe" runat="server" ImageUrl="~/images/icons/zoom.png"
                                    ToolTip="Detalhe" CommandArgument=' <%# Eval("CodigoCalculoRebate")%>' OnClick="btnDetalhe_Click" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="20px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnOutrasOpcoes" runat="server" ImageUrl="~/images/icons/add.png"
                                    ToolTip="Outras Opções" CommandArgument=' <%# Eval("CodigoCalculoRebate")%>'
                                    OnClick="btnOutrasOpcoes_Click" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="20px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
            </fieldset>
            <div style="float: right">
                <table>
                    <tr>
                        <td id="tdExportar" runat="server">
                            <div style="margin:5px 5px 0px 5px;">
                                <asp:Button ID="btnExportar" Text="Exportar Excel" runat="server" 
                                    onclick="btnExportar_Click" />
                            </div>
                        </td>
                        <td style="width: 120px" id="tdCalculo" runat="server">
                            <fieldset>
                                <legend>Débitos</legend>
                                <br />
                                <table>
                                    <tr>
                                        <td style="width: 120px; text-align: center">
                                            <asp:Button Text="Consultar" runat="server" ID="btnConsultarDebito" CausesValidation="false"
                                                OnClick="btnConsultarDebito_Click" OnClientClick="disableElement(this);" UseSubmitBehavior="false" />
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                        <td style="width: 240px" id="tdAnalista" runat="server">
                            <fieldset>
                                <legend>Aprovação Analista</legend>
                                <br />
                                <table>
                                    <tr>
                                        <td style="width: 120px; text-align: center">
                                            <asp:Button Text="Aprovar" runat="server" ID="Button1" CausesValidation="false" OnClick="btnAprovar_Click"
                                                OnClientClick="disableElement(this);" UseSubmitBehavior="false" />
                                        </td>
                                        <td style="width: 120px; text-align: center">
                                            <asp:Button Text="Enviar" runat="server" ID="btnEnviar" CausesValidation="false"
                                                OnClick="btnEnviar_Click" OnClientClick="disableElement(this);" UseSubmitBehavior="false" />
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                        <td style="width: 240px" id="tdGerente" runat="server">
                            <fieldset>
                                <legend>Aprovação Gerencial</legend>
                                <br />
                                <table>
                                    <tr>
                                        <td style="width: 120px; text-align: center">
                                            <asp:Button Text="Reprovar" runat="server" ID="btnReprovar" CausesValidation="false"
                                                OnClick="btnReprovar_Click" OnClientClick="disableElement(this);" UseSubmitBehavior="false" />
                                        </td>
                                        <td style="width: 120px; text-align: center">
                                            <asp:Button Text="Aprovar" runat="server" ID="btnAprovarGerente" CausesValidation="false"
                                                OnClick="btnAprovarGerente_Click" OnClientClick="disableElement(this);" UseSubmitBehavior="false" />
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
