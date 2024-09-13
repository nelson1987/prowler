using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using FluentAssertions;
namespace Prowler.IntegrationTests;

public class UnitTest1
{
// criar uma lista com mock sem a propriedade de data.
// realizar a alteração que dirá que os 2 valores de data, serão a maior data entre eles.
// realizar o assert entre os 2 elementos excluindo a data
// verificar se as 2 datas são iguais a maior data


    private readonly IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization { ConfigureMembers = true });
    [Fact]
[Trait("Category","Unit Test"]
[DisplayName("Validar Lista de Entidade")]
    public void TestSetupGet()
    {
        _fixture.Freeze<Mock<Transferencia>>()
                .Setup(x => x.AlteraIdade(1))
                .Verifiable();
        // var transferenciaMock = new Mock<Transferencia>();
        // transferenciaMock.Object.AlteraIdade(It.IsAny<int>());
        
        var movimentacao = _fixture.Create<Movimentacao>();
        
        movimentacao.Transferencia.Idade.Should().Be(1);
    }
}
public class Transferencia
{
    public int Idade {get; private set;}   
    public void AlteraIdade(int idade)
    {
        Idade = idade;
    }
}
public class Movimentacao
{
    public Movimentacao(Transferencia transferencia)
    {
        Transferencia = transferencia;
    }
    public Transferencia Transferencia {get; private set;}   
}

public record ReceptCreatecommand(Recept Recept);
    public record Recept(int Id)
    {
        public ReceptCreatecommand ToCommand()
        {
            throw new NotImplementedException();
        }
    };
// public class Handler
// {
//     private readonly IService _service;
//     private readonly IProducer _producer;
//     public async Task<Response> Handle(ReceptCreatecommand request, CancellationToken cancellation)
//     {
//         request.Recept = _service.Calculate(request.Recept);
//         var  receptCreateCommand = request.Recept.ToCommand();
//         await _service.Validate(receptCreateCommand, cancellation);
//         await _producer.Produce(receptCreateCommand, cancellation);
//         return receptCreateCommand.Recept.Id;
//     }
// }