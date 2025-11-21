using System.Drawing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using minimal_api.Migrations;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.Infraestrutura.DB;


namespace Api.Test.Helpers;

public class Setup
{
    public const string PORT = "5001";
    public static TestContext testContext = default!;
    public static WebApplicationFactory<Startup> http = default!;
    public static HttpClient client = default!;

    public static void ClassInit(TestContext testContext)
    {
        Setup.testContext = testContext;
        Setup.http = new WebApplicationFactory<Startup>();
        {
            builder.UseSetting("https_port", Setup.PORT).UseEnvironment("Testing");
            builder.ConfigureServices(services =>
            {
                services.AddScoped<IAdministradorServico, AdministradoresServicoMock>();
                services.AddScoped<IVeiculoServico, VeiculoServicoMock>();
            });
            
        }
        Setup.client = Setup.http.CreateClient();
    }

    private static void USeEnvironment(string v)
    {
        throw new NotImplementedException();
    }
}

public class WebApplicationFactory<T>
{
}