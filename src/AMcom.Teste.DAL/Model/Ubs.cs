using AMcom.Teste.DAL.Model.Enum;

namespace AMcom.Teste.DAL
{
    public class Ubs
    {
        // Esta classe deve conter as seguintes propriedades:
        // vlr_latitude, vlr_longitude, nom_estab, dsc_endereco, dsc_bairro, dsc_cidade, dsc_estrut_fisic_ambiencia

        /// <summary>
        /// vlr_latitude
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// vlr_longitude
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// nom_estab
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// dsc_endereco
        /// </summary>
        public string Endereco { get; set; }

        /// <summary>
        /// dsc_bairro
        /// </summary>
        public string Bairro { get; set; }

        /// <summary>
        /// dsc_cidade
        /// </summary>
        public string Cidade { get; set; }

        /// <summary>
        /// dsc_estrut_fisic_ambiencia
        /// </summary>
        public string AvaliacaoDescricao { get; set; }

        public Avaliacao Avaliacao => AvaliacaoConverter.Converter(AvaliacaoDescricao);

    }
}
