using BitzenAppDomain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProvaAppDomain.Entities
{
    public class Cliente : EntityBase
    {
        public int NCodCliente { get; private set; }
        public string CNome { get; private set; }
        public DateTime DNascimento { get; private set; }
        public string CSexo { get; private set; }
        public string CCep { get; private set; }
        public string CEndereco { get; private set; }
        public int NNumero { get; private set; }
        public string CComplemento { get; private set; }
        public string CEstado { get; private set; }
        public string CCidade { get; private set; }
        public string CBairro { get; private set; }

   

        public void PrepararDadosParaInserir(string cNome, string dNascimento, string cSexo, string cCep,string cEndereco, string nNumero, string cComplemento, string cEstado, string cCidade, string cBairro)
        {
            validarCNome(cNome);
            validarDNascimento(dNascimento);
            validarCSexo(cSexo);
            setCCep(cCep);
            setCEndereco(cEndereco);
            validarNNumero(nNumero);
            setCComplemento(cComplemento);
            setCEstado(cEstado);
            setCCidade(cCidade);
            setCBairro(cBairro);

        }

        public void PrepararDadosParaAtualizar(string nCodCliente,string cNome, string dNascimento, string cSexo, string cCep, string cEndereco, string nNumero, string cComplemento, string cEstado, string cCidade, string cBairro)
        {
            validarNCodCliente(nCodCliente);
            validarCNome(cNome);
            validarDNascimento(dNascimento);
            validarCSexo(cSexo);
            setCCep(cCep);
            setCEndereco(cEndereco);
            validarNNumero(nNumero);
            setCComplemento(cComplemento);
            setCEstado(cEstado);
            setCCidade(cCidade);
            setCBairro(cBairro);

        }

        #region validações
        private void validarNCodCliente(string nCodCliente)
        {
            int auxnCodCliente;
            if (int.TryParse(nCodCliente, out auxnCodCliente))
                NCodCliente = auxnCodCliente;
            else
                ListaErros.Add("O código do cliente está inválido");
        }

        private void validarDNascimento(string dNascimento)
        {
            DateTime auxdt;
            if (DateTime.TryParse(dNascimento, out auxdt))
                DNascimento = auxdt;
            else
                ListaErros.Add("Data de nascimento incorreta!");

        }

        private void validarCSexo(string cSexo)
        {
            if (string.IsNullOrEmpty(cSexo))
                ListaErros.Add("O sexo é obrigatório");
            else
            {
                CSexo = cSexo;
            }
        }

        private void validarCNome(string cNome)
        {
            if (string.IsNullOrEmpty(cNome))
                ListaErros.Add("O nome é obrigatório!");
            else
            {
                CNome = cNome;
            }
        }
        private void validarNNumero(string nNumero)
        {

            int auxNumero;
            if (int.TryParse(nNumero, out auxNumero))
                NNumero = auxNumero;
            else
                NNumero = 0;
        }

        #endregion

        #region setters
        public void setCCep(string cCep)
        {
            CCep = cCep;
        }
        public void setCEndereco(string cEndereco)
        {
            CEndereco = cEndereco;
        }
        public void setCCidade(string cCidade)
        {
            CCidade = cCidade;
        }
        public void setCComplemento(string cComplemento)
        {
            CComplemento = cComplemento;
        }
        public void setCEstado(string cEstado)
        {
            CEstado = cEstado;
        }
        public void setCBairro(string cBairro)
        {
            CBairro = cBairro;
        }

        #endregion

        public override bool EstaConsistente()
        {
            return !ListaErros.Any();
        }
    }
}
