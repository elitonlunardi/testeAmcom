using System.Collections.Generic;
using AMcom.Teste.Service.DTO;
using FluentResults;

namespace AMcom.Teste.Service.Interface
{
    public interface IUbsService
    {
        Result<ICollection<UbsDTO>> ObterUbs(double latitude, double longitude, int quantidadeItens = 5);
    }
}