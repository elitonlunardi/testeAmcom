using System;

namespace AMcom.Teste.DAL.Model.Enum
{
    public static class AvaliacaoConverter
    {
        private const string AbaixoMedia = "Desempenho mediano ou  um pouco abaixo da média";
        private const string AcimaMedia = "Desempenho acima da média";
        private const string MtAcimaMedia = "Desempenho muito acima da média";

        public static Avaliacao Converter(string avaliacao)
        {
            switch (avaliacao)
            {
                case AbaixoMedia:
                    return Avaliacao.Ruim;

                case AcimaMedia:
                    return Avaliacao.Mediano;

                case MtAcimaMedia:
                    return Avaliacao.Otimo;

                default: return Avaliacao.Ruim;
            }
        }
    }
}