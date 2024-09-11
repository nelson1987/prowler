namespace Prowler.IntegrationTests;

public class UnitTest1
{
    [Fact]
    public void TestSetupGet()
    {
        var transferenciaMock = new Mock<Transferencia>();
        transferenciaMock.SetupGet(x => x.Idade).Returns(1);
        
        var movimentacao = new Movimentacao(transferenciaMock.Object);
        
        movimentacao.Transferencia.Idade.Should().Be(1);
    }
}
public class Transferencia
{
    public int Idade {get; private set;}   
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
public class Handler
{
    private readonly IService _service;
    private readonly IProducer _producer;
    public async Task<Response> Handle(ReceptCreatecommand request, CancellationToken cancellation)
    {
        request.Recept = _service.Calculate(request.Recept);
        var  receptCreateCommand = request.Recept.ToCommand();
        await _service.Validate(receptCreateCommand, cancellation);
        await _producer.Produce(receptCreateCommand, cancellation);
        return receptCreateCommand.Recept.Id;
    }
}