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
    // [ ] Los rovers deben empezar su recorrido en las posiciones y orientacion proporcionada (1 2 N - 3 3 E)
    [Theory]
    [InlineData(1, 2, "N")]
    [InlineData(3, 3, "E")]
    public void Si_AgregoUnRoverALaMeseta_Debe_IniciarEnLaPosicionDada(int coordenadaX, int coordenadaY, string orientacion)
    {
        //Arrange
        
        //Act
        var rover = new Rover(coordenadaX,coordenadaY,orientacion);
        //Assert
        var estaEnPosicion = rover.EstaEnPosicion(coordenadaX, coordenadaY);
        var estaEnOrientacion = rover.EstaEnOrientacion(orientacion);

        estaEnPosicion.Should().BeTrue();
        estaEnOrientacion.Should().BeTrue();
    }
    // [ ] Los rovers deben empezar su recorrido en las posiciones y orientacion proporcionada (1 2 N - 3 3 E)
    [Fact]
    public void Si_AgregoUnRoverALaMesetaYEsteNoEstaEnLaPosicionYOrientacionDada_Debe_RetornarFalso()
    {
        //Arrange
        
        //Act
        var rover = new Rover(1,2,"N");
        //Assert
        var estaEnPosicion = rover.EstaEnPosicion(1, 3);
        var estaEnOrientacion = rover.EstaEnOrientacion("E");

        estaEnPosicion.Should().BeFalse();
        estaEnOrientacion.Should().BeFalse();
    }
}

public class Rover(int coordenadaX, int coordenadaY, string orientacion)
{
    private int CoordenadaX { get; set; } = coordenadaX;
    private int CoordenadaY { get; set; } = coordenadaY;
    private string Orientacion { get; set; } = orientacion;

    public bool EstaEnPosicion(int coordenadaXEsperada, int coordenadaYEsperada) 
        => coordenadaXEsperada == CoordenadaX && coordenadaYEsperada == CoordenadaY;

    public bool EstaEnOrientacion(string orientacionEsperada) => orientacionEsperada == Orientacion;

}

public class Meseta(int coordenadaMaximaX, int coordenadaMaximaY)
{

    public int CoordenadaMaximaX { get; init; } = coordenadaMaximaX;
    public int CoordenadaMaximaY { get; init; } = coordenadaMaximaY;
}