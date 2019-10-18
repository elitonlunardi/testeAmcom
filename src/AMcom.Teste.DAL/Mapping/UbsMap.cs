using System;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace AMcom.Teste.DAL.Mapping
{
    /// <summary>
    /// Classe de mapeamento das colunas do arquivo no excel para a entidade.
    /// Herança do próprio CsvHelper.
    /// </summary>
    public class UbsMap : ClassMap<Ubs>
    {
        public UbsMap()
        {
            Map(m => m.Latitude).Name("vlr_latitude");
            Map(m => m.Longitude).Name("vlr_longitude");
            Map(m => m.Nome).Name("nom_estab");
            Map(m => m.Endereco).Name("dsc_endereco");
            Map(m => m.Bairro).Name("dsc_bairro");
            Map(m => m.Cidade).Name("dsc_cidade");
            Map(m => m.AvaliacaoDescricao).Name("dsc_estrut_fisic_ambiencia");
        }
    }
}
