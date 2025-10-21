using AwesomeAssertions;

namespace MarsRover;

public class MarsRoversTest
{
    
    //La meseta debe tener dimensiones especificas (x e y).
    [Fact]
    public void La_meseta_debe_tener_dimensiones_especificas()
    {
        //Arrange
        var coordenadaMaximaX = 5;
        var coordenadaMaximaY = 5;

        //Act
        var meseta = new Meseta(coordenadaMaximaX, coordenadaMaximaY);
        
        //Assert
        meseta.CoordenadaMaximaX.Should().Be(coordenadaMaximaX);
        meseta.CoordenadaMaximaY.Should().Be(coordenadaMaximaY);
    }
}

public class Meseta
{

    public int CoordenadaMaximaX { get; set; } = 5;
    public int CoordenadaMaximaY { get; set; } = 5;
    public Meseta(int coordenadaMaximaX, int coordenadaMaximaY)
    {
        
    }

}