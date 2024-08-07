namespace NameSpaceEstadoJuego;

using System.Collections;
using NameSpaceEstados;
using NameSpaceGui;
using NameSpacePersonaje;


class EstadoJuego
    : Estado
{
    int enemigosDerrotados = 0;
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
            case 1:
                this.personaje.MostrarEstadisticas();
                break;
            case 2:
                
                break;
            case 3:
                //Se ejecuta un metodo para guardar partida
                this.finalizar = true;
                break;
            default:
                break;
        }
    }

    override public void Update()
    {
        Gui.MenuTitulo("Estado Juego"); 
        Gui.MenuOpciones(1, "Estadisticas del Personaje");
        Gui.MenuOpciones(2, "Ir al siguiente combate"); 
        Gui.MenuOpciones(3, "Guardar Partida y salir al Menu Principal"); 

        int opcion = Gui.PedirUnaEntradaEntera("Entrada");
        this.ProcesarEntrada(opcion);
    }
}