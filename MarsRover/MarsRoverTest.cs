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
    
    //[ ] Los rovers pueden avanzar al frente con la instrucción 'M'
    [Fact]
    public void Si_SeLeDaLaInstruccion_M_AlRoverYEstaEnUnaPosicionDeterminada_Debe_AvanzarAlFrente()
    {
        //Arrange
        var rover = new Rover(1,2,"N");
        
        //Act
        rover.EjecutarInstrucciones("M");

        //Assert
        var estaEnPosicion = rover.EstaEnPosicion(1, 3);
        var estaEnOrientacion = rover.EstaEnOrientacion("N");

        estaEnPosicion.Should().BeTrue();
        estaEnOrientacion.Should().BeTrue();
    }
    
    //[ ] Los rovers pueden girar a la izquierda con la instrucción 'L'.
    [Fact]
    public void Si_SeLeDaLaInstruccion_L_ElRoverQueEstaEnLaOrientacion_N_Debe_GirarHaciaLaIzquierdaYQuedarEnLaOrientacion_O()
    {
        //Arrange
        var rover = new Rover(1,2,"N");
        
        //Act
        rover.EjecutarInstrucciones("L");

        //Assert
        var estaEnPosicion = rover.EstaEnPosicion(1, 2);
        var estaEnOrientacion = rover.EstaEnOrientacion("O");

        estaEnPosicion.Should().BeTrue();
        estaEnOrientacion.Should().BeTrue();
    }
    
    [Fact]
    public void Si_SeLeDaLaInstruccion_R_ElRoverQueEstaEnLaOrientacion_N_Debe_GirarHaciaLaDerechaYQuedarEnLaOrientacion_E()
    {
        //Arrange
        var rover = new Rover(1,2,"N");
        
        //Act
        rover.EjecutarInstrucciones("R");

        //Assert
        var estaEnPosicion = rover.EstaEnPosicion(1, 2);
        var estaEnOrientacion = rover.EstaEnOrientacion("E");

        estaEnPosicion.Should().BeTrue();
        estaEnOrientacion.Should().BeTrue();
    }
    
    //Si el rover está orientado en 'N' y se le da la instrucción 'RR' su orientación final debe ser 'S'
    [Fact]
    public void Si_SeLeDaLaInstruccion_RR_ElRoverQueEstaEnLaOrientacion_N_Debe_GirarHaciaLaDerechaYQuedarEnLaOrientacion_S()
    {
        //Arrange
        var rover = new Rover(1,2,"N");
        
        //Act
        rover.EjecutarInstrucciones("RR");

        //Assert
        var estaEnPosicion = rover.EstaEnPosicion(1, 2);
        var estaEnOrientacion = rover.EstaEnOrientacion("S");

        estaEnPosicion.Should().BeTrue();
        estaEnOrientacion.Should().BeTrue();
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

    public void EjecutarInstrucciones(string instrucciones)
    {
        foreach (var instruccion in instrucciones.ToList())
        {
            switch (instruccion)
            {
                case 'L':
                    GirarIzquierda();
                    break;
                case 'R':
                    GirarDerecha();
                    break;
                case 'M':
                    Avanzar();
                    break;
            }
        }
    }

    private void GirarDerecha()
    {
        Orientacion = Orientacion switch
        {
            "N" => "E",
            "E" => "S",
            "S" => "O",
            "O" => "N",
        };
    }

    private void GirarIzquierda()
    {
        Orientacion = Orientacion switch
        {
            "N" => "O",
            "O" => "S",
            "S" => "E",
            "E" => "N",
        };
    }

    private void Avanzar()
    {
        switch (Orientacion)
        {
            case "N": CoordenadaY++;
                break;
            case "S": CoordenadaY--;
                break;
            case "E": CoordenadaX++;
                break;
            case "O": CoordenadaX--;
                break;
        }
    }
}

public class Meseta(int coordenadaMaximaX, int coordenadaMaximaY)
{

    public int CoordenadaMaximaX { get; init; } = coordenadaMaximaX;
    public int CoordenadaMaximaY { get; init; } = coordenadaMaximaY;
}