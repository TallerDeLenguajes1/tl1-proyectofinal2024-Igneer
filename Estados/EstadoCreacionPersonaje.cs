using System.Diagnostics.Tracing;
namespace NameSpaceEstadoCreacionPersonaje;

using System.Collections;
using NameSpaceEstados;
using NameSpaceGui;
using NameSpacePersonaje;

class EstadoCreacionPersonaje
    :Estado 
{
    //Variables
    ArrayList ListaDePersonajes;

    //Funciones privadas
    private void CrearPresonaje()
    {
        Gui.ObtenerEntrada("Ingrese el nombre del personaje: ");
        String nombre = Console.ReadLine(); 
        this.ListaDePersonajes.Add(new Personaje(nombre));
        Gui.Anuncio("Personaje Creado");
    }

    public EstadoCreacionPersonaje(Stack<Estado> estados, ArrayList ListaDePersonajes)
        :base(estados)
    {
        this.ListaDePersonajes = ListaDePersonajes;

    }
    public void ProcesarEntrada(int entrada)
    {
        switch(entrada)
        {
            case -1:
                this.finalizar = true;
                break;
            case 1:
                this.CrearPresonaje();
                break;
            default:
                break;
        }

    }


    override public void Update() 
    {
        Gui.Titulo("Creacion de Personaje"); 
        Gui.MenuOpciones(1, "Nuevo Personaje");
        Gui.MenuOpciones(2, "Editar Personaje");
        Gui.MenuOpciones(3, "Eliminar Personaje");
        Gui.MenuOpciones(-1, "Salir"); 

        int opcion = Gui.PedirUnaEntradaEntera("Entrada: ");
        
        this.ProcesarEntrada(opcion); // Probar en probar procesar entrada en GUI
    }
}