/**
 * Script responsável por métodos padrões e validações
*/
document.addEventListener("DOMContentLoaded", function () {

    $('input[type=text]').keyup(function () {
        this.value = this.value.toUpperCase();
    });
    $('textarea').keyup(function () {
        this.value = this.value.toUpperCase();
    });
    $('.maskDinheiro').mask("#.##0,00", { reverse: true });
    $('.maskData').mask('00/00/0000');
    $('.maskTelefone').mask('(99) 999999999');
    $('.maskTel').mask('0000-00009');
    $('.maskDdd').mask('99');
    $('.maskCnpj').mask('00.000.000/0000-00');
    $('.maskCpf').mask('000.000.000-00');
    $('.maskCep').mask('00000-000');
    $('.maskMesAno').mask('00/0000');



});

function Alerta(divId, msg) {
    $("#" + divId).html(msg);
    $("#" + divId).show(300);
    $("#" + divId).delay(3000);
    $("#" + divId).hide(300);
};




// foi criado este método para conseguir atualizar o datatable
// primeiro destroi o datatable e depois cria outro novo.
function destruirDataTable(nomeTabela) {

    if ($.fn.dataTable.isDataTable(`#${nomeTabela}`)) {
        $(`#${nomeTabela}`).DataTable().destroy();
    }
}

function dataTable(nomeTabela, valida = 0, ordenacao = 'desc') {

    $(`#${nomeTabela}`).on('prepreInit.dt').DataTable({
        "language": {
            "lengthMenu": "Mostrar _MENU_ registros por página",
            "zeroRecords": "Não foram encontrados registros",
            "searchPlaceholder": "Buscar registros",
            "info": "Mostrando registros de _START_ ao _END_ de um total de  _TOTAL_ registros",
            "infoEmpty": "Não existem registros",
            "infoFiltered": "(filtrado de um total de _MAX_ registros)",
            "search": "Buscar:",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": "Próximo",
                "previous": "Anterior"
            },

        },
        "iDisplayLength": 8,
        "bDestroy": true,
        "order":[[valida,ordenacao],[0,'asc']],
        "initComplete": fecharLoader()

    });


}

function converterPadraoDataBr(dt) {
    if (dt != null && dt != "") {
        dt = dt.split('-');
        let data = dt[2] + '/' + dt[1] + '/' + dt[0];
        return data;
    }
    return "";
}

function converterPadraoDataEUA(dt) {
    let data = "";
    var date = dt.split(' ');
    dt = date[0]
    if (dt != null && dt != "") {
        dt = dt.split('/');
        data = dt[2] + '-' + dt[1] + '-' + dt[0];
    }
    return data;
}

function abrirLoader() {
    $('#divLoader').modal('show');
}

function fecharLoader() {
    setTimeout(function () {
        $('#divLoader').modal('hide');
    }, 500);
}

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}