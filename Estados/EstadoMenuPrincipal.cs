namespace NameSpaceEstadoMenuPrincipal;

using System.Collections;
using NameSpaceEstadoCreacionPersonaje;
using NameSpaceEstadoJuego;
using NameSpaceEstados;
using NameSpaceGui;
using NameSpacePersonaje;


class EstadoMenuPrincipal 
    : Estado
{
    protected ArrayList ListaDePersonajes;
    protected Personaje personajeActual;
    public EstadoMenuPrincipal(Stack<Estado> estados, ArrayList ListaDePersonajes)
        : base(estados)
    {
        this.ListaDePersonajes = ListaDePersonajes;
        this.personajeActual = null;
    }


    public void ProcesarEntrada(int entrada)
    {
        switch(entrada)
        {
            case -1:
                this.finalizar = true;
                break;
            case 1:
                this.EmpezarNuevoJuego();
                break;
            case 2:
                this.estados.Push(new EstadoCreacionPersonaje(this.estados, this.ListaDePersonajes));
                break;
            case 3:
                this.SeleccionarPersonaje();
                break;
            default:
                break;
        }

    }

    override public void Update()
    {
        if(this.personajeActual != null)
        {
            System.Console.WriteLine("Personaje Actual: "+this.personajeActual.Nombre()+"\n");
        }
        Gui.MenuOpciones(1, "Nueva Partida");
        Gui.MenuOpciones(2, "Crear Personaje");
        Gui.MenuOpciones(3, "Seleccionar de personajes");
        Gui.MenuOpciones(-1, "Salir"); 

        int opcion = Gui.PedirUnaEntradaEntera("Entrada");

        this.ProcesarEntrada(opcion);
    }

    public void EmpezarNuevoJuego()
    {
        //mientras el personajeactual sea nulo, no se puede comenzar el juego
        if(this.personajeActual == null) //error
        {
            Gui.Anuncio("No seleccionaste un personaje para empezar, selecciona uno para comenzar");
        }else//Empezar el juego
        {
            this.estados.Push(new EstadoJuego(this.estados, this.personajeActual));
        }
    }

    public void SeleccionarPersonaje()
    {
        //Mostrar los personajes para elegir
        for (int i = 0; i < this.ListaDePersonajes.Count; i++)
        {
            System.Console.WriteLine(i + ": " + ListaDePersonajes[i].ToString());
        }
        int opcion = Gui.PedirUnaEntradaEntera("Seleccion de Personajes");

        try
        {
            this.personajeActual = (Personaje)this.ListaDePersonajes[opcion];
        }catch(Exception e)
        {
            System.Console.WriteLine(e.Message);
        }

        if(this.personajeActual != null)
        {
            Gui.Anuncio($"El personaje {this.personajeActual.ToString()}fue seleccionado");
        }

    }
}