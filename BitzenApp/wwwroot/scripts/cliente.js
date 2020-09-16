document.addEventListener("DOMContentLoaded", function () {
    abrirLoader();
    carregarDadosTabelaClientes();
    cep();
  
});
document.getElementById("btnNovoRegistro").addEventListener("click", function () {
    ModalNovoRegistro();
});



document.getElementById("salvar_cliente").addEventListener("click", function () {
    NovoCliente();
});



function NovoCliente() {

    let nome = document.getElementById('txtNome').value;
    let data = document.getElementById('dtNascimento').value;
    let selsexo = document.getElementById('selSexo').value;
    let cep = document.getElementById('txtCep').value;
    let endereco = document.getElementById('txtEndereco').value;
    let numero = document.getElementById('txtNumero').value;
    let complemento = document.getElementById('txtComplemento').value;
    let bairro = document.getElementById('txtBairro').value;
    let cidade = document.getElementById('txtCidade').value;
    let estado = document.getElementById('txtEstado').value;

    let erros = "";

    if (nome == "" || nome == null)
        erros += "Nome obrigatório!";
    if (data == "" || data == null)
        erros += "</br>Data de Nascimento obrigatória!";
    if (selsexo == 0 || selsexo == null)
        erros += "</br>Selecione o sexo!";
   
    if (erros.length == 0) {

        const dto = {
            CNome: nome,
            DNascimento: data,
            CSexo: selsexo,
            CCep: cep,
            DAno: data,
            CEndereco: endereco,
            NNumero: numero,
            CComplemento: complemento,
            CEstado: estado,
            CCidade: cidade,
            CBairro: bairro
        };

        document.getElementById('salvar_cliente').disabled = true;

        fetch('../../cadastro/cliente/adicionar', {
            method: 'post',
            headers: {
                'Accept': 'application/json, text/plain, */*',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(dto)
        }).then(res => res.json())
            .then(res => {
                if (res == 1) {
                    toastr['success'](MSG_SUCESSO, TITULO_TOASTR_SUCESSO);
                    AtualizaTable();
                    jQuery('#modalNovoRegistro').modal('hide');
                    $("#selSexo").val(0);
                    $("#txtNome").val("");
                    $("#dtNascimento").val("");
                    $("#txtCep").val("");
                    $("#txtEndereco").val("");
                    $("#txtNumero").val("");
                    $("#txtComplemento").val("");
                    $("#txtBairro").val("");
                    $("#txtCidade").val("");
                    $("#txtEstado").val("");
                } else {
                    toastr['error'](MSG_ERRO_INSERIR, TITULO_TOASTR_ERRO);
                }
            });

        document.getElementById('salvar_cliente').disabled = false;

    }
    else
        toastr['error'](erros, TITULO_TOASTR_ATENCAO);
}




async function carregarDadosTabelaClientes() {
    const response = await fetch('cliente/obterTodosCliente');
    const data = await response.json();
    let tr = '';
    var date;
    data.map(dado => {
        date = dado.dNascimento.split(' ');
        tr += `<tr>
               <td>${dado.nCodCliente}</td>
               <td>${dado.cNome}</td>
               <td>${date[0]}</td><td>`;
            if (dado.cSexo == 'M')
                tr += "Masculino";
            else
            if (dado.cSexo == "F")
                tr += "Feminino";
            else
                tr += "Outro";
            tr+=`
               <td>${dado.cCep}</td>
               <td>${dado.cEndereco}, ${dado.nNumero}</td>
               <td>${dado.cComplemento}</td>
               <td>${dado.cBairro}</td>
               <td>${dado.cCidade} - ${dado.cEstado}</td>
               <td>
                    <button class="btn btn-icon btn-primary" id="btnAlterarCliente${dado.nCodCliente}" onclick="AlterarCliente(${dado.nCodCliente})"><i class="fa fa-edit"></i></button>
                    <button class="btn btn-icon btn-danger" id="btnRemoverCliente${dado.nCodCliente}" onclick="RemoverCliente(${dado.nCodCliente})"><i class="fa fa-trash"></i></button>
               </td>
               </tr>`;

    });
    jQuery('#ClientesCadastrados > tbody').html(tr);
    let nomeTabela = 'ClientesCadastrados';
    dataTable(nomeTabela);
    fecharLoader();
}

function limparCampos() {
    $("#txtEndereco").val("");
    $("#txtCidade").val("");
    $("#txtEstado").val("");

    $("#txtEnderecoAlt").val("");
    $("#txtCidadeAlt").val("");
    $("#txtEstadoAlt").val("");

    $('#txtEstado').attr('disabled', false);
    $('#txtCidade').attr('disabled', false);

    $('#txtEstadoAlt').attr('disabled', false);
    $('#txtCidadeAlt').attr('disabled', false);
}

function cep() {
    $("#txtCepAlt").blur(function () {
        var cep = $(this).val().replace(/\D/g, '');
        if (cep != "") {
            var validacep = /^[0-9]{8}$/;
            if (validacep.test(cep)) {

                $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                    if (!("erro" in dados)) {
                        $("#txtEnderecoAlt").val(dados.logradouro);
                        $("#txtCidadeAlt").val(dados.localidade);
                        $("#txtEstadoAlt").val(dados.uf);
                        $("#txtComplementoAlt").val(dados.complemento);
                        $("#txtBairroAlt").val(dados.bairro);

                        $('#txtEstadoAlt').attr('disabled', true);
                        $('#txtCidadeAlt').attr('disabled', true);

                    }
                    else {
                        limparCampos();
                    }
                });
            } //end if.
            else {
                toastr['error']("CEP não foi encontrado", TITULO_TOASTR_ATENCAO);
                limparCampos();
            }
        }
        else {
            toastr['error']("CEP não foi encontrado", TITULO_TOASTR_ATENCAO);
            limparCampos();
        }

    });


    $("#txtCep").blur(function () {
        var cep = $(this).val().replace(/\D/g, '');
        if (cep != "") {
            var validacep = /^[0-9]{8}$/;
            if (validacep.test(cep)) {

                $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                    if (!("erro" in dados)) {
                        $("#txtEndereco").val(dados.logradouro);
                        $("#txtCidade").val(dados.localidade);
                        $("#txtEstado").val(dados.uf);
                        $("#txtBairro").val(dados.bairro);
                        $("#txtComplemento").val(dados.complemento);


                        $('#txtEstado').attr('disabled', true);
                        $('#txtCidade').attr('disabled', true);

                    }
                    else {
                        limparCampos();
                    }
                });
            } //end if.
            else {
                toastr['error']("CEP não foi encontrado", TITULO_TOASTR_ATENCAO);
                limparCampos();
            }
        }
        else {
            toastr['error']("CEP não foi encontrado", TITULO_TOASTR_ATENCAO);
            limparCampos();
        }

    });
}


async function AlterarCliente(codigo) {


    const response = await fetch('cliente/obterporid/' + codigo);
    const data = await response.json();
    $("#hdnId").val(data.nCodCliente);
    $("#selSexoAlt").val(data.cSexo);
    $("#txtNomeAlt").val(data.cNome);
    var a = converterPadraoDataEUA(data.dNascimento);
    $('#dtNascimentoAlt').val(converterPadraoDataEUA(data.dNascimento));
    $("#txtCepAlt").val(data.cCep);
    $("#txtEnderecoAlt").val(data.cEndereco);
    $("#txtNumeroAlt").val(data.nNumero);
    $("#txtComplementoAlt").val(data.cComplemento);
    $("#txtBairroAlt").val(data.cBairro);
    $("#txtCidadeAlt").val(data.cCidade);
    $("#txtEstadoAlt").val(data.cEstado);


    jQuery('#modalAlterarRegistro').modal({
        backdrop: 'static',
        keyboard: false
    });

}



function ModalNovoRegistro() {

    jQuery('#modalNovoRegistro').modal({
        backdrop: 'static',
        keyboard: false
    });
}



function RemoverCliente(id) {

    jQuery('#modalConfirmarExclusaoCliente').modal({
        backdrop: 'static',
        keyboard: false
    }).one('click', '#delete_cliente', function (e) {

        fetch('../../cadastro/cliente/remover', {
            method: 'post',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(id)
        }).then(res => res.json())
            .then(res => {

                if (res == 1) {

                    jQuery('#modalConfirmarExclusaoCliente').modal('hide');
                    AtualizaTable();
                    toastr['success'](MSG_EXCLUIDO, TITULO_TOASTR_SUCESSO);

                }
                else {
                    jQuery('#modalConfirmarExclusaoCliente').modal('hide');
                    toastr['error'](MSG_ERRO_EXCLUIR, TITULO_TOASTR_ERRO);
                }
            });

    });

}

document.getElementById("alterar_cliente").addEventListener("click", function () {
    AtualizarCliente();
});

function AtualizarCliente() {

    let cliente = document.getElementById('hdnId').value;
    let nome = document.getElementById('txtNomeAlt').value;
    let data = document.getElementById('dtNascimentoAlt').value;
    let selsexo = document.getElementById('selSexoAlt').value;
    let cep = document.getElementById('txtCepAlt').value;
    let endereco = document.getElementById('txtEnderecoAlt').value;
    let numero = document.getElementById('txtNumeroAlt').value;
    let complemento = document.getElementById('txtComplementoAlt').value;
    let bairro = document.getElementById('txtBairroAlt').value;
    let cidade = document.getElementById('txtCidadeAlt').value;
    let estado = document.getElementById('txtEstadoAlt').value;

    let erros = "";

    if (nome == "" || nome == null)
        erros += "Nome obrigatório!";
    if (data == "" || data == null)
        erros += "</br>Data de Nascimento obrigatória!";
    if (selsexo == 0 || selsexo == null)
        erros += "</br>Selecione o sexo!";

    if (erros.length == 0) {

        const dto = {
            NCodCliente: cliente,
            CNome: nome,
            DNascimento: data,
            CSexo: selsexo,
            CCep: cep,
            DAno: data,
            CEndereco: endereco,
            NNumero: numero,
            CComplemento: complemento,
            CEstado: estado,
            CCidade: cidade,
            CBairro: bairro
        };

        document.getElementById('alterar_cliente').disabled = true;

        fetch('../../cadastro/cliente/alterar', {
            method: 'post',
            headers: {
                'Accept': 'application/json, text/plain, */*',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(dto)
        }).then(res => res.json())
            .then(res => {
                if (res == 1) {
                    toastr['success'](MSG_ATUALIZADO, TITULO_TOASTR_SUCESSO);
                    AtualizaTable();
                    jQuery('#modalAlterarRegistro').modal('hide');
                    $("#selSexoAlt").val(0);
                    $("#txtNomeAlt").val("");
                    $("#dtNascimentoAlt").val("");
                    $("#txtCepAlt").val("");
                    $("#txtEnderecoAlt").val("");
                    $("#txtNumeroAlt").val("");
                    $("#txtComplementoAlt").val("");
                    $("#txtBairroAlt").val("");
                    $("#txtCidadeAlt").val("");
                    $("#txtEstadoAlt").val("");
                    $("#hdnId").val("0");
                } else {
                    toastr['error'](MSG_ERRO_ATUALIZAR, TITULO_TOASTR_ERRO);
                }
            });

        document.getElementById('alterar_cliente').disabled = false;

    }
    else
        toastr['error'](erros, TITULO_TOASTR_ATENCAO);
}

function AtualizaTable() {

    document.getElementById('destroy').innerHTML = "";
    document.getElementById('destroy').innerHTML = `
                    <table class="table table-striped" id="ClientesCadastrados">
                        <thead>
                            <tr>
                                <th scope="col">#</th>
                                <th scope="col">Nome</th>
                                <th scope="col">Nascimento</th>
                                <th scope="col">Sexo</th>
                                <th scope="col">Cep</th>
                                <th scope="col">Endereço</th>
                                <th scope="col">Complemento</th>
                                <th scope="col">Bairro</th>
                                <th scope="col">Cidade</th>
                                <th scope="col" style="min-width:80px!important">Opções</th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>    `;

    carregarDadosTabelaClientes();
}
