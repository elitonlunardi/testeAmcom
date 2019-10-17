using CsvHelper;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AMcom.Teste.DAL.Interface;
using AMcom.Teste.DAL.Mapping;
using AMcom.Teste.DAL.Model.Enum;

namespace AMcom.Teste.DAL.Repository
{
    public class UbsRepository : IUbsRepository
    {
        // Implemente um método que retorne uma lista/coleção de objetos do tipo Ubs.
        // Caso necessário, crie um parâmetro para filtrar os objetos dessa coleção se a lógica não for 
        // implementada na camada de serviços.

        public ICollection<Ubs> Obter()
        {
            using (var reader = new StreamReader("C:\\Users\\Eliton\\Documents\\Github\\testeAmcom\\dotnet\\src\\AMcom.Teste.DAL\\ubs.csv", Encoding.UTF8))
            {
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.Delimiter = ",";
                    csv.Configuration.RegisterClassMap(new UbsMap());
                    return csv.GetRecords<Ubs>().ToList();
                }
            }

        }
    }
}
