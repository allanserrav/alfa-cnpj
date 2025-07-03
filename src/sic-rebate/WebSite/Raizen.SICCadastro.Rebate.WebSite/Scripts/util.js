// Exibe mensagem em forma de dialog
function ShowMessageMaster(message, width, height) {
    $(document).ready(function () {
        $("#dialog-master").text(message);
        $("#dialog-master").dialog(
            {
                title: 'Mensagem',
                modal: true,
                resizable: false,
                draggable: false,
                width: width,
                height: height
            });
    });
}

// Exibe uma lista de mensagens
function ShowMessageListMaster(arrMessages, width, height) {
    $(document).ready(function () {
        var bulleTedList = "<ul>";
        for (var i = 0; i < arrMessages.length; i++) {
            var message = arrMessages[i];
            bulleTedList += "<li>" + message + "</li>";
        }
        bulleTedList += "</ul>";
        $("#dialog-master").html(bulleTedList);
        $("#dialog-master").dialog(
            {
                title: 'Mensagem',
                modal: true,
                resizable: false,
                draggable: false,
                width: width,
                height: height
            });
    });
}

// Exibe um dialogo de confirmação
function ConfirmDialog(message, confirmFunction, cancelFunction) {
    $("#dialog-confirm-master").dialog(
        {
            title: 'Confirmar',
            modal: true,
            resizable: false,
            draggable: false,
            width: 450,
            buttons: {
                "Sim": function () {
                    confirmFunction();
                    $(this).dialog("close");
                },
                "Não": function () {
                    if (cancelFunction) {
                        cancelFunction();
                    }

                    $(this).dialog("close");
                }
            }
        });
    $("#dialog-confirm-master").find("p").text(message);
}


function MessageBox_Show(titulo, mensagem, width, height, exibirBotaoFechar) {
    $(".MessageBox").dialog(
        {
            title: titulo,
            modal: true,
            resizable: false,
            draggable: false,
            width: width,
            height: height,
            open: function () {
                var vet = $(".MessageBox input")
                if (vet.length > 0) {
                    vet[0].focus();
                }

                //*** Checa se não é para exibir o botão de fechar
                if (!exibirBotaoFechar) {
                    $('.ui-dialog-titlebar-close').hide();
                }
            },
            close: function (ev, ui) {
                $(".MessageBox").remove();
            },
        });

    $(".MessageBox #textoMensagem").html(mensagem);
    $(".MessageBox").parent().appendTo($("form:first"));

    /*Correção de bug, onde após postback é criado mais de um modal
     * impedindo a correta exibição dos botões do modal
     * Executado apenas na página: CadastroContrato.aspx
     * */
    $(document).ready(function () {
        if ($(".MessageBox").length > 1 &&
            window.location.href.indexOf('CadastroContrato.aspx') != -1) {
            $(".MessageBox").last().remove();
        }
    });
}


function MessageBox_ShowLista(titulo, mensagem, width, height, exibirBotaoFechar, lista) {
    var itens = "";
    for (var i = 0; i < lista.length; i++) {
        itens += "<li>" + lista[i].Mensagem + "</li>";

        var controle = $("#" + lista[i].ClientID);
        controle.css("background-color", "#FAFFBD");
        controle.css("font-weight", "bold");
        controle.css("color", "black");
    }

    if (exibirBotaoFechar) {
        $(".MessageBox input").each(function () {
            $(this).click(function (e) {

                //*** Fecha o popup de mensagem
                MessageBox_Close();

                //*** Pega o primeiro cara da lista de joga o focu nele
                $("#" + lista[0].ClientID).select();

                //*** Previne de dar post na pagina e assim perder a formatação nova dos controles
                e.preventDefault()

            });
        });
    }

    MessageBox_Show(titulo, mensagem + "<br/><ul>" + itens + "</ul>", width, height, exibirBotaoFechar);
}

function MessageBox_Close() {
    $(".MessageBox").dialog("close");
}

//function Dialog_Centralizar() {
//    $('.ui-dialog-content').dialog("option", "position", "center");
//}

function Dialog_Centralizar() {
    var dialog = $('.ui-dialog-content');
    var windowWidth = $(window).width();
    var windowHeight = $(window).height();
    var scrollTop = $(window).scrollTop();

    // Calcula a posição central considerando o scroll
    var top = scrollTop + (windowHeight - dialog.dialog("widget").outerHeight()) / 2;
    var left = (windowWidth - dialog.dialog("widget").outerWidth()) / 2;

    // Define a nova posição do diálogo
    dialog.dialog("widget").css({
        top: top + "px",
        left: left + "px",
        position: "absolute"  // Define como 'absolute' para melhor controle
    });
}

function MessageBox_getKeyPress(e) {
    if (e.keyCode == 27 || e.which == 27) {
        MessageBox_Close();
    }
}

function abrirModalIframe(filtro, titulo) {
    $(filtro).click(function (e) {
        var page = $(this).attr('href');
        var $dialog = $('<div></div>')
            .html('<iframe style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
            .dialog({
                autoOpen: false,
                modal: true,
                height: 600,
                width: 850,
                title: titulo
            });
        $dialog.dialog('open');
        e.preventDefault();
    });
}

function abrirModal(filtro, titulo, width, height) {
    $(filtro).dialog(
        {
            title: titulo,
            modal: true,
            resizable: false,
            draggable: false,
            width: width,
            height: height,
            open: function () {
                $(this).parent()
                    .find(".ui-dialog-titlebar-close")
                    .hide();
            },
            close: function (ev, ui) {
                //Sem ação não efetua nenhuma operação
            }
        });
    $(filtro).parent().appendTo($("form:first"));
}

var _abrirModal = function (seletor, options) {
    //$(seletor).dialog({
    //    modal: true,
    //    title: options && options.title ? options.title : '',
    //    resizable: options && options.resizable ? options.resizable : false,
    //    draggable: options && options.draggable ? options.draggable : false,
    //    width: options && options.width ? options.width : 'auto',
    //    height: options && options.height ? options.height : 'auto',
    //    open: options && options.open ? options.open : function () {
    //        //Sem ação não efetua nenhuma operação
    //    },
    //    close: options && options.close ? options.close : function () {
    //        //Sem ação não efetua nenhuma operação
    //    }
    //}).dialogExtend({
    //    "maximize": true,
    //    "minimize": true,
    //    "dblclick": "maximize"
    //});
    //$(seletor).parent().appendTo($("form:first"));
    $(seletor)
        .dialog({
            "title": options && options.title ? options.title : '',
            "modal": true,
            width: options && options.width ? options.width : 'auto',
            height: options && options.height ? options.height : 'auto'

        })
    .dialogExtend({
        
});
//Bind to event by type
//NOTE : You must bind() the <dialogextendload> event before dialog-extend is created
    $(seletor)
    .bind("dialogextendload", function (evt) {  })
    .dialogExtend();
}

var abrirModalGed = function (seletor, options) {
    var _options = {
        title: 'GED',
        resizable: true,
        draggable: true,
        width: options && options.width ? options.width : 'auto',
        height: options && options.height ? options.height : 'auto',
        open: options && options.open ? options.open : function () { //Sem ação não efetua nenhuma operação
        },
        close: options && options.close ? options.close : function () { //Sem ação não efetua nenhuma operação
        }
    };
    _abrirModal(seletor, _options);
}

function fecharModal(filtro) {
    $(filtro).dialog('close');
}

/* Funções que devem ser utilizados para GridView com checkboxes */
function CheckBoxHeaderClick(checkBoxHeader, gridID, checkBoxesID) {
    var $grid = $("table[id$=" + gridID + "]");
    var $checkBoxes = $("input[id*=" + checkBoxesID + "]:not(:disabled)", $grid);
    $checkBoxes.each(function () {
        this.checked = checkBoxHeader.checked;
    });
}

function CheckBoxClick(gridID, checkBoxHeaderID) {
    var $grid = $("table[id$=" + gridID + "]");
    var $checkBoxHeader = $("input[id$=" + checkBoxHeaderID + "]", $grid);
    var $checkBoxes = $("input[type=checkbox]:not(:disabled)", $grid).not($checkBoxHeader);
    var totalCheckBoxes = $checkBoxes.length;
    var totalCheckBoxesCheckeds = $checkBoxes.filter(":checked").length;

    if (totalCheckBoxesCheckeds < totalCheckBoxes)
        $checkBoxHeader.attr("checked", false);
    else if (totalCheckBoxesCheckeds == totalCheckBoxes)
        $checkBoxHeader.attr("checked", true);
}

function AcertarCheckBoxHeader(gridID, checkBoxHeaderID) {
    var $grid = $("table[id$=" + gridID + "]");
    var $checkBoxHeader = $("input[id$=" + checkBoxHeaderID + "]", $grid);
    var $checkBoxes = $("input[type=checkbox]:not(:disabled)", $grid).not($checkBoxHeader);
    var totalCheckBoxes = $checkBoxes.length;
    var totalCheckBoxesCheckeds = $checkBoxes.filter(":checked").length;

    if (totalCheckBoxesCheckeds < totalCheckBoxes)
        $checkBoxHeader.attr("checked", false);
    else if (totalCheckBoxesCheckeds == totalCheckBoxes)
        $checkBoxHeader.attr("checked", true);
}
/* Funções que devem ser utilizados para GridView com checkboxes */

function ativarBlockUI($elemento) {
    $('form').submit(function () {
        if (typeof Page_IsValid === 'undefined' || Page_IsValid == true) {
            // clear out plugin default styling
            $.blockUI.defaults.css = {};
            if ($elemento) $.blockUI({ message: $elemento.html() });
            else $.blockUI({ message: '<h2><img src="/Cadastro/images/Logos/loading-raizen-64x64.GIF" /><span> Por favor aguarde...</span></h2>' });
        }
    });
}

function desativarBlockUI() { $.unblockUI(); }

function loadMessage($elemento) {
    $.blockUI.defaults.css = {};
    $.blockUI({ message: $elemento.html() });
}

// First, checks if it isn't implemented yet.
if (!String.prototype.format) {
    String.prototype.format = function () {
        var args = arguments;
        return this.toString().replace(/{(\d+)}/g, function (match, number) {
            return typeof args[number] != 'undefined'
                ? args[number]
                : match
                ;
        });
    };
}

function abrirInfoCliente(element) {
    $(document).ready(function () {
        $("#" + element).dialog(
            {
                title: "Informações Cliente",
                modal: true,
                resizable: false,
                draggable: false,
                width: 800,
                height: 500
            });

        $("#" + element).parent().appendTo($("form:first"));
    })
};

var filtroTabela = function (seletorSelect, seletorTabela, textoSelecaoVazia) {

    $(seletorSelect).change(function () {

        var _rows = $(seletorTabela + " tr:not(.listaGED_header)");

        var _value = $(seletorSelect + ' option:selected').val();
        //SE SELECIONADO NADA, MOSTRA TUDO
        if (_value == (textoSelecaoVazia ? textoSelecaoVazia : '')) {
            _rows.show();
            return;
        }

        _rows.hide();
        _rows
            .filter(function (i, v) {
                var _row = $(this);
                if (_row.is(':contains("' + _value + '")')) {
                    return true;
                } else return false;
            })
            .show();
    });

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
    var dtMonth = dtArray[3];
    var dtDay = dtArray[1];
    var dtYear = dtArray[5];

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


function formatIBM($campo) {
    var _valor = $campo.val();
    if (_valor == '' || _valor == 0)
        return;
    while (_valor.length < 10) {
        _valor = '0' + _valor;
    }
    $campo.val(_valor);
}