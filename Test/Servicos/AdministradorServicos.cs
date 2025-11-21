using System.Reflection;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Infraestrutura.DB;

namespace Test.Domain.Entidades;

[TestClass]
public sealed class AdministradorTeste
{
    private DbContexto CriarContextoDeTeste()
    {
        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));
        var builder = new ConfigurationBuilder()
            .SetBasePath(path ?? Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
        var configuration = builder.Build();
        return new DbContexto(configuration);
    }
    [TestMethod]
    public void TestandoSalvarAdministrador()
    {
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE administradores");
        var adm = new Administrador();

        adm.ID = 1;
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "adm";

        var administradorServico = new AdministradorServico(context);

        administradorServico.Incluir(adm);
        var admBanco = administradorServico.BuscaPorId(adm.ID);

        Assert.AreEqual(1, admBanco.ID);
        Assert.AreEqual(1, administradorServico.Todos(1).Count());

    }
}