using AwesomeAssertions;

namespace Yatzy;

public class YatziTest
{
    [Theory]
    [InlineData(new int[] { 1, 1, 3, 3, 6 }, 14)]
    [InlineData(new int[] { 4, 5, 5, 6, 1 }, 21)]
    public void Si_TengoValoresDados_Y_TengoLaCategoria_Chance_Debe_Dar_PuntajeEsperado(int[] valoresDados, int puntajeEsperado)
    {
        //Arrange
        var categoria = "chance";
        
        //Act
        var puntajeCalculado = CalcularPuntaje(valoresDados, categoria);
        //Assert
        puntajeCalculado.Should().Be(puntajeEsperado);
    }

    [Theory]
    [InlineData(new int[] { 1, 1, 1, 1, 1 }, 50)]
    [InlineData(new int[] { 1, 1, 1, 2, 1 }, 0)]
    public void Si_TengoValoresDados_Y_TengoLaCategoria_Yatzy_Debe_Dar_PuntajeEsperado(int[] valoresDados, int puntajeEsperado)
    {
        //Arrange
        var categoria = "yatzy";
        //Act
        var puntajeCalculado = CalcularPuntaje(valoresDados, categoria);
        //Assert
        puntajeCalculado.Should().Be(puntajeEsperado);
    }

    [Theory]
    [InlineData(new int[] { 1,1,2,4,4 }, 2,"ones")]
    [InlineData(new int[] { 1,1,2,4,1 }, 3,"ones")]
    [InlineData(new int[] { 2,1,2,4,4 }, 4,"twos")]
    [InlineData(new int[] { 2,1,2,5,2 }, 6,"twos")]
    [InlineData(new int[] { 3,3,2,3,2 }, 9,"threes")]
    [InlineData(new int[] { 3,3,3,3,2 }, 12,"threes")]
    public void Si_TengoValoresDados_Y_TengoAlgunaCategoriaNumerica_Debe_Dar_PuntajeEsperado(int[] valoresDados, int puntajeEsperado,string categoria)
    {
        //Arrange
        //Act
        var puntajeCalculado = CalcularPuntaje(valoresDados, categoria);
        //Assert
        puntajeCalculado.Should().Be(puntajeEsperado);
    }
    
    private int CalcularPuntaje(int[] valoresDados, string categoria)
    {
        return categoria switch
        {
            "yatzy" => CalcularYatzy(valoresDados),
            "ones" => CalcularNumericas(valoresDados,CategoriasNumericas.Ones),
            "twos" => CalcularNumericas(valoresDados, CategoriasNumericas.Twos),
            "threes" => CalcularNumericas(valoresDados, CategoriasNumericas.Threes),
            "chance" => CalcularChance(valoresDados)
        };
    }

    private static int CalcularNumericas(int[] valoresDados, CategoriasNumericas tipoCategoria)
    {
        return valoresDados.Where(w => w == (int)tipoCategoria).Sum();
    }

    private static int CalcularChance(int[] valoresDados)
    {
        return valoresDados.Sum();
    }

    private static int CalcularYatzy(int[] valoresDados)
    {
        var sonTodosIguales = valoresDados.All(x => x.Equals(valoresDados[0]));
        return sonTodosIguales ? 50 : 0;
    }
    
    
}

public enum CategoriasNumericas
{
    Ones = 1,
    Twos = 2,
    Threes = 3,
    Fours = 4,
    Fives = 5,
    Sixes = 6
}

