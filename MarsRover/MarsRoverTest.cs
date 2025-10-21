using AwesomeAssertions;

namespace MarsRover;

public class MarsRoversTest
{
    
    //La meseta debe tener dimensiones especificas (x e y).
    [Theory]
    [InlineData(5, 5)]
    [InlineData(7, 7)]
    public void La_meseta_debe_tener_dimensiones_especificas(int coordenadaMaximaX, int coordenadaMaximaY)
    {
        //Arrange
     
        //Act
        var meseta = new Meseta(coordenadaMaximaX, coordenadaMaximaY);
        
        //Assert
        meseta.CoordenadaMaximaX.Should().Be(coordenadaMaximaX);
        meseta.CoordenadaMaximaY.Should().Be(coordenadaMaximaY);
    }
    
}

public class Meseta(int coordenadaMaximaX, int coordenadaMaximaY)
{

    public int CoordenadaMaximaX { get; init; } = coordenadaMaximaX;
    public int CoordenadaMaximaY { get; init; } = coordenadaMaximaY;
}