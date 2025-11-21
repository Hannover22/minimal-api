using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.Dominio.Servicos;

namespace Test.Mocks;

public class AdministradoresServicoMock : IAdministradorServico
{
    private static List<Administrador> administradores = new List<Administrador>()
    {
        new Administrador
        {
            ID = 1,
            Email = "adm@teste.com",
            Senha = "123456",
            Perfil = "adm"
        },
        new Administrador
        {
            ID = 2,
            Email = "editor@teste",
            Senha = "123456",
            Perfil = "Editor"
        }
    };
    public Administrador? BuscaPorId(int id)
    {
        return administradores.Find(a => a.ID == id);
    }

    public Administrador Incluir(Administrador administrador)
    {
        administrador.ID = administradores.Count() + 1;
        administradores.Add(administrador);

        return administrador;
    }

    public Administrador? Login(LoginDTO loginDTO)
    {
        return administradores.Find(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha);
    }

    public List<Administrador> Todos(int? pagina)
    {
        return administradores;
    }
}