namespace NameSpaceEstadoJuego;

using System.Collections;
using NameSpaceEstados;
using NameSpaceGui;

class EstadoJuego
    : Estado
{
    ArrayList ListaDePersonajes;
    public EstadoJuego(Stack<Estado> estados, ArrayList ListaDePersonajes)
        : base(estados)
    {
        this.ListaDePersonajes = ListaDePersonajes;
    }

    override public void Update()
    {
        Gui.MenuTitulo("Estado Juego"); 
        Gui.MenuOpciones(0, "Crear Personaje"); 
        Gui.MenuOpciones(-1, "Salir"); 

        Gui.ObtenerEntrada("Entrada:");
        int.TryParse(Console.ReadLine(), out int salud);

        if(salud < 0)
        {
            this.finalizar = true; 
        }
    }
}