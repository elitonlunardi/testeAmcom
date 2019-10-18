using System;
using System.Collections;
using CsvHelper;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AMcom.Teste.DAL.Interface;
using AMcom.Teste.DAL.Mapping;
using FluentResults;
using Microsoft.Extensions.Configuration;

namespace AMcom.Teste.DAL.Repository
{
    public class UbsRepository : IUbsRepository
    {
        // Implemente um método que retorne uma lista/coleção de objetos do tipo Ubs.
        // Caso necessário, crie um parâmetro para filtrar os objetos dessa coleção se a lógica não for 
        // implementada na camada de serviços.

        private readonly IConfiguration _configuration;

        public UbsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

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
        public Result<ICollection<Ubs>> Obter()
        {
            try
            {
                Result<ICollection<Ubs>> result;
                ObterPathArquivo();
                using (var reader = new StreamReader(ObterPathArquivo(), Encoding.UTF8))
                {
                    using (var csv = new CsvReader(reader))
                    {
                        csv.Configuration.Delimiter = ",";
                        csv.Configuration.RegisterClassMap(new UbsMap());
                        var data = csv.GetRecords<Ubs>().ToList();
                        result = Results.Ok<ICollection<Ubs>>(data);
                        return result;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                return Results.Fail<ICollection<Ubs>>("O arquivo CSV não foi encontrado.");
            }
            catch (Exception ex)
            {
                return Results.Fail<ICollection<Ubs>>($"Falha ao efetuar leitura do arquivo CSV. Motivos: \n {ex.Message}");
            }
        }

        /// <summary>
        /// Obtém o path do arquivo CSV.
        /// A configuração fica no appsettings.
        /// </summary>
        /// <returns>String com o path do arquivo</returns>
        private string ObterPathArquivo()
        {
            return _configuration.GetSection("arquivos:path").Value;
        }
    }
}
