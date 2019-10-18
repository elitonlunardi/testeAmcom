using System.Collections.Generic;
using System.Linq;
using AMcom.Teste.DAL.Interface;
using AMcom.Teste.Service.DTO;
using AMcom.Teste.Service.Interface;
using FluentResults;
using GeoCoordinatePortable;

namespace AMcom.Teste.Service.Service
{
    public class UbsService : IUbsService
    {
        // Implemente um método que retorne as 5 UBSs mais próximas de um ponto (latitude e longitude) que devem 
        // ser passados como parâmetro para o método e retorne uma lista/coleção de objetos do tipo UbsDTO.
        // Esta lista deve estar ordenada pela avaliação (da melhor para a pior) de acordo com os dados que constam
        // no objeto retornado pela camada de acesso a dados (DAL).

        private readonly IUbsRepository _ubsRepository;

        public UbsService(IUbsRepository ubsRepository)
        {
            _ubsRepository = ubsRepository;
        }

        /// <summary>
        /// Obtêm a lista de UBS mais próximas das coordenadas passadas.
        /// <para>
        /// Efetua os devidos tratamentos de erros para as coordenadas passadas.
        /// </para>
        /// </summary>
        /// <param name="latitude">Latitude que será utilizada para o filtro</param>
        /// <param name="longitude">Longitude que será utilizada para o filtro</param>
        /// <param name="quantidadeUbs">Quantidade de UBS retonaradas, default = 5</param>
        /// <returns>Lista das 5 UBS mais próximas encapsuladas com o objeto de tratamento da operação.</returns>
        public Result<ICollection<UbsDTO>> ObterUbs(double latitude, double longitude, int quantidadeUbs = 5)
        {
            //resultado de retorno
            Result<ICollection<UbsDTO>> result;

            if (latitude > 90 || latitude < -90)
                return Results.Fail<ICollection<UbsDTO>>("A latitude deve estar entre 90 e -90");

            if (longitude > 90 || longitude < -90)
                return Results.Fail<ICollection<UbsDTO>>("A longitude deve estar entre 90 e -90");

            //coordenadas que serão utilizadas para a comparação no csv
            var coordenadasBuscadas = new GeoCoordinate(latitude, longitude);

            //obtêm a lista de Ubs do repositório, encapsulada por uma classe que manipula erros ou sucesso
            var ubsTratamento = _ubsRepository.Obter();

            //se alguma exceção for lançada, é tratado nesse bloco
            if (ubsTratamento.IsFailed)
            {
                result = Results.Merge<ICollection<UbsDTO>>(ubsTratamento);
                return result;
            }

            //obtêm as 5 UBS mais próximas
            var ubsMaisProximas = ubsTratamento.Value
                .OrderBy(w => new GeoCoordinate(w.Latitude, w.Longitude)
                    .GetDistanceTo(coordenadasBuscadas))
                .Take(quantidadeUbs);

            //monta o objeto de retorno com resultado Ok(que não teve erros), ordena pela avaliação das 5 ubs mais próximas e faz o cast de entidade para DTO
            result = Results.Ok<ICollection<UbsDTO>>(ubsMaisProximas.OrderByDescending(a => a.Avaliacao)
                                .Select(ubs => (UbsDTO)ubs).ToList());
            return result;
        }
    }
}
