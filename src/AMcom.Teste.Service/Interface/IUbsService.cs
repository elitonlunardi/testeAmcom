using System.Collections.Generic;
using AMcom.Teste.Service.DTO;

namespace AMcom.Teste.Service.Interface
{
    public interface IUbsService
    {
        IEnumerable<UbsDTO> ObterUbs(double latitude, double longitude, int quantidadeItens = 5);
    }
}