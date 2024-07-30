namespace NameSpaceEstadoJuego;
using NameSpaceEstados;

class EstadoJuego
    : Estado
{
    public EstadoJuego(Stack<Estado> estados)
        : base(estados)
    {
        System.Console.WriteLine("Hola EstadoJuego");
    }
}