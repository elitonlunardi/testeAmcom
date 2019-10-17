using System.Collections.Generic;
using System.Linq;
using AMcom.Teste.DAL;
using AMcom.Teste.DAL.Interface;
using AMcom.Teste.Service.DTO;
using AMcom.Teste.Service.Interface;
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

        public IEnumerable<UbsDTO> ObterUbs(double latitude, double longitude, int quantidadeUbs = 5)
        {
            var coordenadasBuscadas = new GeoCoordinate(latitude, longitude);

            return _ubsRepository.Obter()
                .OrderBy(w => new GeoCoordinate(w.Latitude, w.Longitude)
                    .GetDistanceTo(coordenadasBuscadas))
                .ThenBy(u => u.Avaliacao)
                .Select(u => (UbsDTO)u)
                .Take(quantidadeUbs);
        }
    }
}
