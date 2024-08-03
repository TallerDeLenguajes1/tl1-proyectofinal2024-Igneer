namespace NameSpaceEstadoJuego;

using System.Collections;
using NameSpaceEstados;
using NameSpaceGui;
using NameSpacePersonaje;


class EstadoJuego
    : Estado
{
    protected Personaje personaje;
    public EstadoJuego(Stack<Estado> estados, Personaje personajeActual)
        : base(estados)
    {
        this.personaje = personajeActual;
    }

    public void ProcesarEntrada(int opcion)
    {
        switch(opcion)
        {
            case -1:
                this.finalizar = true;
                break;
            case 1:
                System.Console.WriteLine(this.personaje.ToString());
                break;
            default:
                break;
        }
    }

    override public void Update()
    {
        Gui.MenuTitulo("Estado Juego"); 
        Gui.MenuOpciones(0, "Estadisticas del Personaje"); 
        Gui.MenuOpciones(-1, "Salir"); 

        int opcion = Gui.PedirUnaEntradaEntera("Entrada");
        this.ProcesarEntrada(opcion);
    }
}