using AMcom.Teste.DAL.Interface;
using AMcom.Teste.Service.Interface;
using Xunit;
using FluentAssertions;

namespace AMcom.Teste.Service.Tests
{
    [Collection(nameof(UbsServiceCollection))]
    public class UbsServiceTest
    {
        // Implemente os testes unitários para o método criado no UbsService. Faça quantos testes achar
        // pertinente para validar a sua lógica de aplicação.

        private readonly UbsServiceFixtures _ubsServiceFixtures;

        public UbsServiceTest(UbsServiceFixtures ubsServiceFixtures)
        {
            _ubsServiceFixtures = ubsServiceFixtures;
        }

        [Fact(DisplayName = "Obter cinco ubs do repositório sem erros")]
        public void UbsService_ObterUbsCorreto_DeveRetornar5Ubs()
        {
            //Arrange
            _ubsServiceFixtures.Mocker
                .GetMock<IUbsRepository>()
                .Setup(c => c.Obter())
                .Returns(_ubsServiceFixtures.ObterUbsValidas(5));

            _ubsServiceFixtures.Mocker
                .GetMock<IUbsService>()
                .Setup(c => c.ObterUbs(_ubsServiceFixtures.LatitudeValida(), _ubsServiceFixtures.LongitudeValida(), 5))
                .Returns(_ubsServiceFixtures.ObterUbsDtosValidas(5));

            var ubsService = _ubsServiceFixtures.ObterUbsService();

            //Act
            var ubs = ubsService.ObterUbs(_ubsServiceFixtures.LatitudeValida(), _ubsServiceFixtures.LongitudeValida());

            //Assert
            ubs.Value.
                Should().HaveCount(5, "não há erros");
            ubs.Errors.
                Should().HaveCount(0, "não há erros");
        }

        [Theory(DisplayName = "Latitude abaixo de 90 ou acima de -90 não deve gerar erro")]
        [InlineData(10.3)]
        [InlineData(45)]
        [InlineData(-65.2)]
        [InlineData(-40.1)]
        public void UbsService_ObterUbsLatitudeCorreta_DeveGerarSucesso(double latitude)
        {
            //Arrange
            _ubsServiceFixtures.Mocker.GetMock<IUbsRepository>()
                .Setup(c => c.Obter())
                .Returns(_ubsServiceFixtures.ObterUbsValidas(5));

            var ubsService = _ubsServiceFixtures.ObterUbsService();

            //Act
            var ubs = ubsService.ObterUbs(latitude, _ubsServiceFixtures.LongitudeValida());

            //Assert
            ubs.Errors.
                Should().HaveCount(0, "a latitude está correta");

            ubs.Value
                .Should().HaveCount(5, "a latitude está correta");
        }

        [Theory(DisplayName = "Latitude acima de 90 ou abaixo de -90 deve gerar erro")]
        [InlineData(91)]
        [InlineData(300.2)]
        [InlineData(-91)]
        [InlineData(-150.5)]

        public void UbsService_ObterUbsLatitudeIncorreta_DeveGerarErro(double latitude)
        {
            //Arrange
            _ubsServiceFixtures.Mocker.GetMock<IUbsRepository>()
                .Setup(c => c.Obter())
                .Returns(_ubsServiceFixtures.ObterUbsValidas(5));

            var ubsService = _ubsServiceFixtures.ObterUbsService();

            //Act
            var ubs = ubsService.ObterUbs(latitude, _ubsServiceFixtures.LongitudeValida());

            //Assert
            ubs.Errors.
                Should().HaveCountGreaterThan(0, "a latitude está inválida");
        }

        [Theory(DisplayName = "Longitude abaixo de 90 ou acima de -90 não deve gerar erro")]
        [InlineData(68.1)]
        [InlineData(36)]
        [InlineData(-82.4)]
        [InlineData(-8.7)]
        public void UbsService_ObterUbsLongitudeCorreta_DeveGerarSucesso(double longitude)
        {
            //Arrange
            _ubsServiceFixtures.Mocker.GetMock<IUbsRepository>()
                .Setup(c => c.Obter())
                .Returns(_ubsServiceFixtures.ObterUbsValidas(5));

            var ubsService = _ubsServiceFixtures.ObterUbsService();

            //Act
            var ubs = ubsService.ObterUbs(_ubsServiceFixtures.LatitudeValida(), longitude);

            //Assert
            ubs.Errors.
                Should().HaveCount(0, "a longitude está correta");

            ubs.Value
                .Should().HaveCount(5, "a longitude está correta");
        }


        [Theory(DisplayName = "Longitude acima de 90 ou abaixo de -90 deve gerar erro")]
        [InlineData(91.8)]
        [InlineData(100.2)]
        [InlineData(-91)]
        [InlineData(-150.5)]

        public void UbsService_ObterUbsLongitudeIncorreta_DeveGerarErro(double longitude)
        {
            //Arrange
            _ubsServiceFixtures.Mocker.GetMock<IUbsRepository>()
                .Setup(c => c.Obter())
                .Returns(_ubsServiceFixtures.ObterUbsValidas(5));

            var ubsService = _ubsServiceFixtures.ObterUbsService();

            //Act
            var ubs = ubsService.ObterUbs(_ubsServiceFixtures.LatitudeValida(), longitude);

            //Assert
            ubs.Errors.
                Should().HaveCountGreaterThan(0, "a latitude está inválida");
        }
    }


}
