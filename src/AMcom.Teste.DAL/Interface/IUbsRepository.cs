using System;
using FluentResults;
using System.Collections.Generic;
using System.IO;

namespace AMcom.Teste.DAL.Interface
{
    public interface IUbsRepository
    {
        /// <summary>
        /// Obtêm os arquivos das UBS do arquivo excel.
        /// <para>
        /// O retorno é um objeto do tipo <see cref="Result"/> que
        /// possui a coleção de UBS extraídas do excel.
        /// </para>
        /// </summary>
        /// <returns>Result com a coleção de UBS.</returns>
        /// <exception cref="FileNotFoundException">Caso o arquivo não seja encontrado.</exception>
        /// <exception cref="Exception">Caso aconteça algum problema na manipulação do arquivo.</exception>
        Result<ICollection<Ubs>> Obter();
    }
}