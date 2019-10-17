using AMcom.Teste.DAL;
using AMcom.Teste.DAL.Model.Enum;

namespace AMcom.Teste.Service.DTO
{
    public class UbsDTO
    {
        // Esta classe deve conter as seguintes propriedades:
        // Nome, Endereco e Avaliacao

        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Avaliacao { get; set; }

        public UbsDTO(string nome, string endereco, string avaliacao)
        {
            Nome = nome;
            Endereco = endereco;
            Avaliacao = avaliacao;
        }

        public static explicit operator UbsDTO(Ubs ubs)
        {
            return new UbsDTO(ubs.Nome, $"{ubs.Endereco} - {ubs.Bairro} - {ubs.Cidade}", ubs.AvaliacaoDescricao);
        }
    }
}
