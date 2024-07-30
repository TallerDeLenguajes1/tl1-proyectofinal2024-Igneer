namespace NameSpaceEstadoMenuPrincipal;
using NameSpaceEstados;
using NameSpaceEstadoJuego;

class EstadoMenuPrincipal 
    : Estado
{
    public EstadoMenuPrincipal(Stack<Estado> estados)
        : base(estados)
    {
        System.Console.WriteLine("Bienvenido al menu principal");

        this.estados.Push(new EstadoJuego(this.estados));
    }
}