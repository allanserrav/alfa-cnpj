<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CalculoAcerto.aspx.cs" Inherits="Raizen.SICCadastro.Rebate.WebSite.CalculoAcerto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <!-- Mensagens -->
    <div id="dialog" style="display: none; width: 300px; height: 300px;"></div>
    <script language="javascript">
        function ShowMessageData(m) {
            $("#dialog").html(m);
            $("#dialog").dialog({                
                title: 'Mensagem',
                modal: true,
                resizable: false,
                draggable: false,                
            });
        }
    </script>

    <!-- Ajustes de Inputs -->
    <script language="javascript">
        $(document).ready(function () {         
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

        //Controle dos Checks da Grid
        function checkAll(sender) {
            $('.ckb-grid').each(function (k, obj) {
                obj.children[0].checked = sender.checked;
            });
        }

        //Controle dos Checks da Grid
        function checkCheck(sender) {
            if (document.getElementById('ckbAll').checked)
                document.getElementById('ckbAll').checked = sender.checked;
        }
    </script>

    <!-- Pesquisa -->
    <fieldset>
        <legend>Pesquisar</legend>
        <br />
        <b>IBM: </b><asp:TextBox ID="txtIBM" runat="server" MaxLength="10" />       
        <asp:Button ID="btnPesquisar" runat="server" Text="Calcular Acertos" OnClick="btnPesquisar_Click" OnClientClick="_loader.show();"/>
        <br />
        <br /><b>
        <asp:Label ID="lblNome" runat="server" Text="" Visible="false"/></b>
    </fieldset>
    <!-- Resultados -->
    <asp:Panel ID="pnlResultado" runat="server" Visible="false">
        <fieldset>
            <legend>
                Bonificações
            </legend>
            <br />
            <asp:Repeater ID="rptBonifica" runat="server">
                <HeaderTemplate>
                    <table width="100%">
                        <tr>
                            <th style="width:50px;text-align:center"><input type="checkbox" onclick="checkAll(this)" id="ckbAll"/></th>
                            <th>Período</th>
                            <th>&nbsp;</th>
                            <th style="text-align:right;width:150px;">Bonificação Original</th>
                            <th style="text-align:right;width:150px;">Bonificação Acerto</th>
                            <th style="text-align:right;width:150px;">Saldo&nbsp;&nbsp;&nbsp;</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                        <tr>
                            <td style="width:50px;text-align:center">
                                <asp:CheckBox ID="ckb" runat="server" CssClass="ckb-grid" OnClick="checkCheck(this);"/>
                                <asp:HiddenField ID="hdnNrSeqRebateSic" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "NrSeqRebateSic")%>' />
                                <asp:HiddenField ID="hdnDtPeriodoSic" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "DtPeriodoSic")%>' />                                
                                <asp:HiddenField ID="hdnDtIniciocalculoRebateSic" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "DtIniciocalculoRebateSic")%>' />
                                <asp:HiddenField ID="hdnDtFimcalculoRebateSic" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "DtFimcalculoRebateSic")%>' />
                                <asp:HiddenField ID="hdnVlBonificacaoTotalSic" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "VlBonificacaoTotalSic")%>' />
                                <asp:HiddenField ID="hdnVlAcertoBonificacaoTotalSic" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "VlAcertoBonificacaoTotalSic")%>' />
                                <asp:HiddenField ID="hdnVlSaldoAcertoBonificacaoSic" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "VlSaldoAcertoBonificacaoSic")%>' />
                            </td>
                            <td style="width:50px"><%# DataBinder.Eval(Container.DataItem, "DtPeriodoSic", "{0:MM/yyyy}")%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "DsPeriodo")%></td>                                                        
                            <td style="text-align:right;"><%# DataBinder.Eval(Container.DataItem, "VlBonificacaoTotalSic", "{0:N2}")%></td>
                            <td style="text-align:right;"><%# DataBinder.Eval(Container.DataItem, "VlAcertoBonificacaoTotalSic", "{0:N2}")%></td>
                            <td style="text-align:right;"><%# DataBinder.Eval(Container.DataItem, "VlSaldoAcertoBonificacaoSic", "{0:N2}")%></td>
                        </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </fieldset>
        <div style="width:100%;text-align:right">
            <asp:Button Text="Lançar Acertos" runat="server" ID="btnLancarAcertos" OnClick="btnLancarAcertos_Click"  OnClientClick="_loader.show();"/>
        </div>
    </asp:Panel>    
</asp:Content>
