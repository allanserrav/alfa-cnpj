<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="Raizen.SICCadastro.Rebate.WebSite.Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
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
        function ApresentarMenu() {

            $(document).ready(function () {
                $("#Menu").dialog(
                    {
                        title: 'Escolha um dos itens do menu',
                        modal: true,
                        width: 900,
                        height: 550,
                        resizable: false,
                        draggable: false
                    });

                $("#Menu").parent().appendTo($("form:first"));
            });
        }

    </script>
    <div id="dialog" style="display: none; width: 300px; height: 300px;">
    </div>
    <div class="title">Login </div>
    <hr class="separator" />
    <div class="subtitle">Informe abaixo seu Usuário e a Senha </div>
    <div class="input-container">
        <asp:TextBox
            ID="txtUsuario"
            runat="server"
            MaxLength="18"
            placeholder="Usuário"
            CssClass="input"
            BorderStyle="None" />
        <asp:RequiredFieldValidator
            ID="RequiredFieldValidator1"
            ErrorMessage="*"
            ControlToValidate="txtUsuario"
            runat="server" ValidationGroup="logar" />
    </div>
    <div class="input-container">
        <asp:TextBox
            ID="txtSenha"
            runat="server"
            MaxLength="15"
            BorderStyle="None"
            placeholder="Senha"
            TextMode="Password"
            CssClass="input" />
        <asp:RequiredFieldValidator
            ID="RequiredFieldValidator2"
            ErrorMessage="*"
            ControlToValidate="txtSenha"
            runat="server"
            ValidationGroup="logar" />
    </div>
    <div class="button-container">
        <asp:Button
            runat="server"
            ID="btnEntrar"
            Text="Entrar"
            Width="240px"
            Height="45px"
            BackColor="#82186E"
            Style="background-image: unset; background-repeat: unset; border-radius: 5px; margin-right: 7px; padding: unset;"
            ValidationGroup="logar"
            OnClick="btnEntrar_Click" />
    </div>
</asp:Content>
