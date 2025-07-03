<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroRestricao.aspx.cs" Inherits="Raizen.SICCadastro.Rebate.WebSite.CadastroRestricao" %>

<%@ Register Src="Controls/MessageBox.ascx" TagName="MessageBox" TagPrefix="RZ" %>
<%@ Register Src="Controls/ucPaginacaoRodape.ascx" TagPrefix="RZ" TagName="ucPaginacaoRodape" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        input[type="submit"] {
            font-family: Arial;
            font-size: small !important;
        }

        .hidden-field
        {
            display:none;
        }
    </style>


    <script type="text/javascript">

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

       
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <fieldset>
            <legend>Cadastro de Restrições</legend>
   <br />
            <asp:Panel runat="server" >
                <table>                    
                    <tr>
                        <td style="width: 100px">
                            <span>Ibm:</span>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtIbm" Width="150px" MaxLength="20" oninput="this.value = this.value.replace(/[^0-9]/g, '')"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="txtIbm"
                                ErrorMessage="*"
                                ValidationGroup="Restricao">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <span>&nbsp;</span>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <span>Motivo:</span>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtMotivo" Width="550px" MaxLength="100"/>                            
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <span>&nbsp;</span>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <span>Tipos de Restrições:</span>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <span>&nbsp;</span>
                        </td>
                        <td class="editor-field" >
                            <asp:CheckBoxList ID="chkTipoRestricao" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" RepeatLayout="Table" Width="100%" CssClass="custom-checkbox-list" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </fieldset>
    <div style="float: right; margin-top: 10px;">
        <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" ValidationGroup="Restricao" />
    </div>
    <RZ:MessageBox ID="MessageBox" runat="server" Height="200" OnResultado="MessageBox_Resultado" />
</asp:Content>
