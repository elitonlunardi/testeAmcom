using System.Collections.Generic;
using AMcom.Teste.Service.DTO;
using FluentResults;

namespace AMcom.Teste.Service.Interface
{
    public interface IUbsService
    {
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
        Result<ICollection<UbsDTO>> ObterUbs(double latitude, double longitude, int quantidadeUbs = 5);
    }
}