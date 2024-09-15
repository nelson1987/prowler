# Fluxo de Desenvolvimento
Se estivermos falando de um projeto que tem acesso a dados.
## Teste de Falha
Incluiremos um teste unitário de Inserção, com um código parecido com o abaixo:

```csharp
using Xunit;

namespace Projeto.UnitTests.Entities
{
    public class PostUserUnitTests
    {
        [Fact]
        public void Fact_PostUser ()
        {
            // EXAMPLE
            var user = new User("LUCIANO PEREIRA", 33, true);

            // REPOSITORY
            ctx.User.Add(user);
            ctx.SaveChanges();

            // ASSERT
            Assert.Equal(1, user.Id);
        }
    }
}
```
### Eliminando erro de dependencia
Incluiremos no local devido no projeto a entidade da inserção, como no código abaixo:

```csharp
namespace Projeto.Domain.Entities
{
    public class User
    {
        public User()
        {

        }
        public User(int Id, string Name, int Age, bool IsActive)
        {
            this.Id = Id;
            this.Name = Name;
            this.Age = Age;
            this.IsActive = IsActive;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
    }
}
```
Devemos alterar o método de teste existente, incluindo na entidade um Id(nesse caso, 0)

```csharp
[Fact]
public void Fact_PostUser_NoRepository()
{
    // EXAMPLE
    var user = new User(0, "LUCIANO PEREIRA", 33, true);

    // REPOSITORY
    ctx.User.Add(user);
    ctx.SaveChanges();

    // ASSERT
    Assert.Equal(1, user.Id);
}

```

## Criando o Repositorio
Devemos implementar/alterar a classe de contexto como exibido abaixo

```csharp
using Projeto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Projeto.Infra.Repositories
{
    public class MyContext: DbContext
    {
        public DbSet<User> User => Set<User>;
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(e =>
            {
                e
                .ToTable("user")
                .HasKey(k => k.Id);

                e
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            });
        }
    }
}
```

## Teste de Integração de Base de Dados
Neste exemplo utilizamos o EFInMemory para realizar os comandos na base de dados

```csharp
using Projeto.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Projeto.UnitTest.Tests
{
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
            var options = builder.UseInMemoryDatabase("test").UseInternalServiceProvider(serviceProvider).Options;

            MyContext dbContext = new MyContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            return dbContext;
        }
    }
}
```

## Inclusao de classe base de teste no teste utilizado

```csharp
public class PostUserTest : BaseTest
```

### Sinal Verde - Teste executando com sucesso
## Refactor
Após o teste retornar com sucesso, iniciaremos a refatoração.
Nesse caso, utilizaremos o Repository Pattern.
Primeiro modificaremos a classe de teste, e em seguida implementaremos um repositório para essa entidade.
### Refactor de Método de teste
```csharp
[Fact]
public void Fact_PostUser()
{
    // EXAMPLE
    var user = new User(0, "LUCIANO PEREIRA", 33, true);

    // REPOSITORY
    user = new UserRepository(ctx).Post(user);

    // ASSERT
    Assert.Equal(1, user.Id);
}
```
### Criação de classe Repository
```csharp
using Projeto.Domain.Entities;

namespace Projeto.Infra.Repositories
{
    public class UserRepository
    {
        private readonly MyContext ctx;
        public UserRepository(MyContext ctx)
        {
            this.ctx = ctx;
        }
        public User Post(User user)
        {
            ctx.User.Add(user);
            ctx.SaveChanges();
            return user;
        }
    }
}
```

## Teste unitário de Entidade
### Vamos validar se o nome da entidade está respeitando as regras
Incluiremos o método abaixo na classe de Unit Tests

```csharp
[Theory]
[InlineData(null)]
[InlineData("")]
[InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
[InlineData("LUCIANO PEREIRA")]
public void Theory_PostUser_Name (string Name)
{
    var user = new User
    {
        Name = Name
    };
    Assert.Null(user.Name);
    Assert.Empty(user.Name);
    Assert.True(user.Name.Length > 20);
}
```
Após validarmos o teste renomearemos e refatoremos o método,como:

```csharp
[Theory]
[InlineData(null)]
[InlineData("")]
[InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
[InlineData("LUCIANO PEREIRA")]
public void Theory_PostUser_Name_NoValidation (string Name)
{
    var user = new User
    {
        Name = Name
    };

    var val = new PostUserValidator().Validate(user);
    Assert.False(val.IsValid);
}
```

### FluentAssertions
## Teste unitário para a classe de Entidade
```csharp
using Projeto.Domain.Entities;
using FluentValidation;

namespace Projeto.Infra.Validations
{
    public class PostUserValidator: AbstractValidator<User>
    {
        public PostUserValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .MaximumLength(20);
        }
    }
}
```

Após validarmos o teste renomearemos e refatoremos o método,como:

```csharp
[Theory]
[InlineData(null)]
[InlineData("")]
[InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
[InlineData("LUCIANO PEREIRA")]
public void Theory_PostUser_Name    (string Name)
{
    var user = new User
    {
        Name = Name
    };

    var val = new PostUserValidator().Validate(user);
    Assert.False(val.IsValid);
    
    if(!val.IsValid)
    {
        bool hasError = val.Errors.Any(a => a.ErrorCode.Equals(ErrorCode.ToString()));
        Assert.True(hasError);
    }
}
```

Bibliografia: https://dev.to/lucianopereira86/from-tdd-to-ddd-building-a-net-core-web-api-part-7-3n4d