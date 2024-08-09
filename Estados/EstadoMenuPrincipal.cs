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
    protected List<Personaje> ListaDePersonajes;
    protected Personaje personajeActual;
    public EstadoMenuPrincipal(Stack<Estado> estados, List<Personaje> ListaDePersonajes)
        : base(estados)
    {
        this.ListaDePersonajes = ListaDePersonajes;
        personajeActual = null;
    }


    public void ProcesarEntrada(int entrada)
    {
        switch(entrada)
        {
            case 1:
                Console.Clear();
                EmpezarNuevoJuego();
                break;
            case 2:
                Console.Clear();
                personajeActual = null;
                estados.Push(new EstadoCreacionPersonaje(estados, ListaDePersonajes));
                break;
            case 3:
                Console.Clear();
                SeleccionarPersonaje();
                break;
            case 4:
                Console.Clear();
                HallDeLaFama();
                Gui.Anuncio("Presiona cualquier tecla para volver");
                Console.ReadKey();
                Console.Clear();
                break;
            case 5:
                finalizar = true;
                break;
            default:
                Console.Clear();
                Gui.Anuncio("La opcion ingresada no es valida");
                break;
        }

    }

    override public void Update()
    {
        (bool, int) entrada = (false, 0);
        while(!entrada.Item1)
        {
            if(personajeActual != null)
            {
                System.Console.WriteLine("Personaje Selecionado: "+ personajeActual.Nombre + "\n");
            }
            Gui.TituloJuego();
            Gui.MenuOpciones(1, "Nueva Partida");
            Gui.MenuOpciones(2, "Creacion de Personajes");
            Gui.MenuOpciones(3, "Seleccion de personajes");
            Gui.MenuOpciones(4, "Hall de la fama");
            Gui.MenuOpciones(5, "Salir"); 

            entrada = Gui.ControlarEntradaEntera("Ingresa una opcion: ", 1, 5);
        }

        int opcion = entrada.Item2;

        ProcesarEntrada(opcion);
    }

    public void EmpezarNuevoJuego()
    {
        //mientras el personaje actual sea nulo, no se puede comenzar el juego
        if(personajeActual == null) //error
        {
            Gui.Anuncio("No seleccionaste un personaje para empezar, selecciona uno para comenzar");
        }else//Empezar el juego
        {
            estados.Push(new EstadoJuego(estados, personajeActual, ListaDePersonajes));
        }
    }

    public void SeleccionarPersonaje()
    {
        if(ListaDePersonajes.Count == 0)
        {
            Gui.Anuncio("No hay personajes creados");
        }else
        {
            //Mostrar los personajes para elegir
            (bool, int) entrada = (false, 0);
            while(!entrada.Item1)
            {
                for (int i = 0; i < ListaDePersonajes.Count; i++)
                {
                    System.Console.WriteLine("Personaje N° "+(i+1) + ": " + ListaDePersonajes[i].DetallesDelPersonaje());
                }
                entrada = Gui.ControlarEntradaEntera("Ingresa el numero del personaje a seleccionar", 1, ListaDePersonajes.Count);
                if(entrada.Item1)
                {
                    entrada.Item2 -= 1;
                    personajeActual = ListaDePersonajes[entrada.Item2];
                    Console.Clear();
                    Gui.Anuncio($"El personaje {personajeActual.Nombre} fue seleccionado");
                }
            }
        }
    }

    public void HallDeLaFama()
    {
        string rutaJson = "HallDeLaFama.json";

        List<Personaje> personajesGanadores = ManejoDeJson.CargarListaDePersonajes(rutaJson);

        if(personajesGanadores.Count() == 0)
        {
            Gui.Anuncio("No hay personajes ganadores");
        }else
        {
            for (int i = 0; i < personajesGanadores.Count; i++)
            {
                System.Console.WriteLine("Ganador N° "+(i+1) + ": " + personajesGanadores[i].DetallesDelPersonaje());
            }
        }
    }
}