using MinimalApi.Dominio.Entidades;

namespace Test.Domain.Entidades;

[TestClass]
public sealed class VeiculosTest
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        var veiculo = new Veiculo();

        veiculo.Id = 1;
        veiculo.Marca = "Ford";
        veiculo.Nome = "Fiesta";
        veiculo.Ano = 2016;

        Assert.AreEqual(1, veiculo.Id);
        Assert.AreEqual("Ford", veiculo.Marca);
        Assert.AreEqual("Fiesta", veiculo.Nome);
        Assert.AreEqual(2016, veiculo.Ano);

    }
}