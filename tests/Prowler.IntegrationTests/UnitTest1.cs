using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using FluentAssertions;
namespace Prowler.IntegrationTests;
public class MyContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Transferencia>(e =>
        {
            e
            .ToTable("TB_Transferencia")
            .HasKey(k => k.Id);

            e
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

            // e
            // .Property(p => p.Idade)
            // .ValueGeneratedOnAdd();
        });
    }
}
public class TransferenciaUnitTest : BaseTest
{
    // criar uma lista com mock sem a propriedade de data.
    // realizar a alteração que dirá que os 2 valores de data, serão a maior data entre eles.
    // realizar o assert entre os 2 elementos excluindo a data
    // verificar se as 2 datas são iguais a maior data


    private readonly IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization { ConfigureMembers = true });

    [Trait("Category", "Unit Test")]
    [Fact(DisplayName = "Validar Lista de Entidade")]
    public async Task Fact_PostTransferencia()
    {
        var transferencia = new Transferencia(0, 18);
        ctx.Set<Transferencia>().AddAsync(transferencia);
        ctx.SaveChangesAsync();
        
        transferencia.Id.Should().Be(1);
        
        // _fixture.Freeze<Mock<Transferencia>>()
        //         .Setup(x => x.AlteraIdade(1))
        //         .Verifiable();
        // var transferenciaMock = new Mock<Transferencia>();
        // transferenciaMock.Object.AlteraIdade(It.IsAny<int>());

        // var movimentacao = _fixture.Create<Movimentacao>();

        // movimentacao.Transferencia.Idade.Should().Be(1);
    }
}
public class Entity
{
    public int Id { get; private set; }
}
public class Transferencia : Entity
{
    public int Idade { get; private set; }
    public Transferencia()
    {
        
    }
    public Transferencia(int id, int idade)
    {
        Id = id;
        Idade = idade;
    }
}
public class Movimentacao
{
    public Movimentacao(Transferencia transferencia)
    {
        Transferencia = transferencia;
    }
    public Transferencia Transferencia { get; private set; }
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
public class BaseTest
    {
        protected MyContext ctx;
        public BaseTest(MyContext ctx = null)
        {
            this.ctx = ctx ?? GetInMemoryDBContext();
        }
        protected MyContext GetInMemoryDBContext()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<MyContext>();
            var options = builder
                .UseInMemoryDatabase("test")
                .UseInternalServiceProvider(serviceProvider)
                .Options;

            MyContext dbContext = new MyContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            return dbContext;
        }
    }