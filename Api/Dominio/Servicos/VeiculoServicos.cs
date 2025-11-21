using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.Infraestrutura.DB;

public class VeiculoServicos : IVeiculoServico
{
    private readonly DbContexto _contexto;

    public VeiculoServicos(DbContexto contexto)
    {
        this._contexto = contexto;
    }
    public void Apagar(Veiculo veiculo)
    {
        this._contexto.Veiculos.Add(veiculo);
        _contexto.SaveChanges();
    }

    public void Atualizar(Veiculo veiculo)
    {
        this._contexto.Veiculos.Update(veiculo);
        _contexto.SaveChanges();
    }

    public Veiculo? BuscaPorId(int id)
    {
        return _contexto.Veiculos.Where(v => v.Id == id).FirstOrDefault();
    }

    public void Incluir(Veiculo veiculo)
    {
        _contexto.Veiculos.Add(veiculo);
        _contexto.SaveChanges();
    }

    public List<Veiculo> Todos(int? pagina = 1, string? nome = null, string? marca = null)
    {
        var query = _contexto.Veiculos.AsQueryable();
        if (!string.IsNullOrEmpty(nome))
        {
            query = query.Where(v => EF.Functions.Like(v.Nome.ToLower(), $"%{nome}%"));
        }
        int ItensPorPagina = 10;
        if(pagina != null){
            query = query.Skip(((int)pagina - 1) * ItensPorPagina).Take(ItensPorPagina);
        }
        return query.ToList();
    }
}