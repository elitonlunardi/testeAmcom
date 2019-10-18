using System;
using System.Collections.Generic;
using AMcom.Teste.DAL;
using AMcom.Teste.Service.DTO;
using AMcom.Teste.Service.Service;
using Bogus;
using FluentResults;
using Moq.AutoMock;
using Xunit;

namespace AMcom.Teste.Service.Tests
{
    [CollectionDefinition(nameof(UbsServiceCollection))]
    public class UbsServiceCollection : ICollectionFixture<UbsServiceFixtures>
    {

    }
    public class UbsServiceFixtures : IDisposable
    {
        public AutoMocker Mocker;

        public UbsServiceFixtures()
        {
            Mocker = new AutoMocker();
        }

        public Result<ICollection<Ubs>> ObterUbsValidas(int quantidade)
        {
            var faker = new Faker<Ubs>("pt_BR")
                .CustomInstantiator(f => new Ubs
                {
                    AvaliacaoDescricao = "Qualquer avaliação",
                    Bairro = f.Address.StreetSuffix(),
                    Cidade = f.Address.City(),
                    Endereco = f.Address.FullAddress(),
                    Latitude = f.Random.Int(-90, 90),
                    Longitude = f.Random.Int(-90, 90),
                    Nome = f.Company.CompanyName()
                });

            Result<ICollection<Ubs>> result;
            result = Results.Ok<ICollection<Ubs>>(faker.Generate(quantidade));
            return result;
        }

        public Result<ICollection<UbsDTO>> ObterUbsDtosValidas(int quantidade)
        {
            var random = new Random();
            var faker = new Faker<UbsDTO>("pt_BR")
                .CustomInstantiator(f => new UbsDTO(f.Company.CompanyName(), f.Company.CompanyName(), "Qualquer avaliação"));

            Result<ICollection<UbsDTO>> result;
            result = Results.Ok<ICollection<UbsDTO>>(faker.Generate(quantidade));
            return result;
        }

        public double LatitudeValida()
        {
            var rnd = new Random();
            return rnd.Next(-90, 90);
        }
        public double LatitudeInvalida()
        {
            var rnd = new Random();
            return rnd.Next(90, 150);
        }

        public double LongitudeValida()
        {
            var rnd = new Random();
            return rnd.Next(-90, 90);
        }
        public double LongitudeInvalida()
        {
            var rnd = new Random();
            return rnd.Next(90, 150);
        }

        public UbsService ObterUbsService()
        {
            return Mocker.CreateInstance<UbsService>();
        }


        public void Dispose() { }
    }
}