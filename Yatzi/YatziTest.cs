using AwesomeAssertions;
using Microsoft.VisualBasic.CompilerServices;

namespace Yatzy;

public class YatziTest
{
    [Theory]
    [InlineData(new[] { 1, 1, 3, 3, 6 }, 14)]
    [InlineData(new[] { 4, 5, 5, 6, 1 }, 21)]
    public void Si_TengoValoresDados_Y_TengoLaCategoria_Chance_Debe_Dar_PuntajeEsperado(int[] valoresDados,
        int puntajeEsperado)
    {
        //Arrange
        var categoria = "chance";

        //Act
        var puntajeCalculado = CalcularPuntaje(valoresDados, categoria);
        //Assert
        puntajeCalculado.Should().Be(puntajeEsperado);
    }

    [Theory]
    [InlineData(new[] { 1, 1, 1, 1, 1 }, 50)]
    [InlineData(new[] { 1, 1, 1, 2, 1 }, 0)]
    public void Si_TengoValoresDados_Y_TengoLaCategoria_Yatzy_Debe_Dar_PuntajeEsperado(int[] valoresDados,
        int puntajeEsperado)
    {
        //Arrange
        var categoria = "yatzy";
        //Act
        var puntajeCalculado = CalcularPuntaje(valoresDados, categoria);
        //Assert
        puntajeCalculado.Should().Be(puntajeEsperado);
    }

    [Theory]
    [InlineData(new[] { 1, 1, 2, 4, 4 }, 2, "ones")]
    [InlineData(new[] { 1, 1, 2, 4, 1 }, 3, "ones")]
    [InlineData(new[] { 2, 1, 2, 4, 4 }, 4, "twos")]
    [InlineData(new[] { 2, 1, 2, 5, 2 }, 6, "twos")]
    [InlineData(new[] { 3, 3, 2, 3, 2 }, 9, "threes")]
    [InlineData(new[] { 1, 2, 2, 5, 2 }, 0, "threes")]
    [InlineData(new[] { 3, 3, 3, 3, 2 }, 12, "threes")]
    [InlineData(new[] { 4, 4, 3, 2, 1 }, 8, "fours")]
    [InlineData(new[] { 4, 4, 3, 2, 4 }, 12, "fours")]
    [InlineData(new[] { 4, 5, 3, 2, 1 }, 5, "fives")]
    [InlineData(new[] { 4, 5, 3, 5, 1 }, 10, "fives")]
    [InlineData(new[] { 6, 5, 3, 6, 6 }, 18, "sixes")]
    [InlineData(new[] { 3, 5, 1, 2, 3 }, 0, "sixes")]
    public void Si_TengoValoresDados_Y_TengoAlgunaCategoriaNumerica_Debe_Dar_PuntajeEsperado(int[] valoresDados,
        int puntajeEsperado, string categoria)
    {
        //Arrange
        //Act
        var puntajeCalculado = CalcularPuntaje(valoresDados, categoria);
        //Assert
        puntajeCalculado.Should().Be(puntajeEsperado);
    }

    [Theory]
    [InlineData(new[] { 1, 5, 3, 6, 6 }, 12)]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 0)]
    [InlineData(new[] { 1, 1, 3, 2, 2 }, 4)]
    [InlineData(new[] { 2, 2, 3, 1, 1 }, 4)]
    public void Si_TengoValoresDados_Y_TengoLaCategoria_Par_Debe_Dar_PuntajeEsperado(int[] valoresDados,
        int puntajeEsperado)
    {
        //Arrange
        var categoria = "pair";
        //Act
        var puntajeCalculado = CalcularPuntaje(valoresDados, categoria);
        //Assert
        puntajeCalculado.Should().Be(puntajeEsperado);
    }

    [Theory]
    [InlineData(new[] { 1,1,2,3,3 }, 8)]
    [InlineData(new[] { 1,1,2,3,4 }, 0)]
    [InlineData(new[] { 1,1,1,1,4 }, 0)]
    public void Si_TengoValoresDados_Y_TengoLaCategoria_Two_Pair_Debe_Dar_PuntajeEsperado(int[] valoresDados, int puntajeEsperado)
    {
        //Arrange
        var categoria = "two pairs";
        //Act
        var puntajeCalculado = CalcularPuntaje(valoresDados, categoria);
        //Assert
        puntajeCalculado.Should().Be(puntajeEsperado);
    }

    [Theory]
    [InlineData(new[] { 4, 4, 4, 3, 1}, 12)]
    [InlineData(new[] { 2, 3, 5, 5, 5}, 15)]
    [InlineData(new[] { 2, 3, 5, 5, 1}, 0)]
    public void Si_TengoValoresDados_Y_TengoLaCategoria_Three_Of_A_Kind_Debe_Dar_PuntajeEsperado(int[] valoresDados,
        int puntajeEsperado)
    {
        //Arrange
        var categoria = "three of a kind";

        //Act
        var puntajeCalculado = CalcularPuntaje(valoresDados, categoria);

        //Assert
        puntajeCalculado.Should().Be(puntajeEsperado);

    }

    [Theory]
    [InlineData(new[] {1 ,1 ,1 ,1 ,3}, 4)]
    public void Si_TengoValoresDados_Y_TengoLaCategoria_Four_Of_A_Kind_Debe_Dar_PuntajeEsperando(int[] valoresDados, int puntajeEsperado)
    {
        //Arrange
        var categoria = "four of a kind";
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
            "ones" => CalcularNumericas(valoresDados, CategoriasNumericas.Ones),
            "twos" => CalcularNumericas(valoresDados, CategoriasNumericas.Twos),
            "threes" => CalcularNumericas(valoresDados, CategoriasNumericas.Threes),
            "fours" => CalcularNumericas(valoresDados, CategoriasNumericas.Fours),
            "fives" => CalcularNumericas(valoresDados, CategoriasNumericas.Fives),
            "sixes" => CalcularNumericas(valoresDados, CategoriasNumericas.Sixes),
            "pair" => CalcularCategoriasPorAgrupaciones(valoresDados,CategoriasNumericasRepetidas.Pair),
            "two pairs" => CalcularDosPares(valoresDados),
            "three of a kind" => CalcularCategoriasPorAgrupaciones(valoresDados,CategoriasNumericasRepetidas.ThreeOfAKind),
            "four of a kind" => CalcularCategoriasPorAgrupaciones(valoresDados,CategoriasNumericasRepetidas.four_of_a_kind),
            "chance" => CalcularChance(valoresDados)
        };
    }
    
    private static int CalcularYatzy(int[] valoresDados)
    {
        var sonTodosIguales = valoresDados.All(x => x.Equals(valoresDados[0]));
        return sonTodosIguales ? 50 : 0;
    }
    private static int CalcularNumericas(int[] valoresDados, CategoriasNumericas tipoCategoria)
    {
        return valoresDados.Where(w => w == (int)tipoCategoria).Sum();
    }
    private int CalcularCategoriasPorAgrupaciones(int[] valoresDados,CategoriasNumericasRepetidas agrupacion)
    {
        int cantidadAgrupacion = (int)agrupacion;
        var agrupacionEncontradas = valoresDados
            .GroupBy(valorDado => valorDado)
            .Where(grupo => grupo.Count() == cantidadAgrupacion)
            .Select(grupo => grupo.Key)
            .OrderByDescending(grupo => grupo)
            .FirstOrDefault();

        return agrupacionEncontradas * cantidadAgrupacion;
    }
    private int CalcularDosPares(int[] valoresDados)
    {
        var cantidadParGrupo = 2;
        var listaPares = valoresDados
            .CountBy(valorDado => valorDado)
            .Where(grupo => grupo.Value == cantidadParGrupo)
            .Select(grupo => grupo.Key)
            .ToList();
        
        return listaPares.Count == cantidadParGrupo ? listaPares.Select(pares => pares * cantidadParGrupo).Sum() : 0;
    }
    
    private static int CalcularChance(int[] valoresDados)
    {
        return valoresDados.Sum();
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

public enum CategoriasNumericasRepetidas
{
    Pair = 2,
    ThreeOfAKind = 3,
    four_of_a_kind = 4
}


