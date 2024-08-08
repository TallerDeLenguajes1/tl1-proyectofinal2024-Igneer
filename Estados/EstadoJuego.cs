namespace NameSpaceEstadoJuego;

using System.Collections;
using NameSpaceEstados;
using NameSpaceGui;
using NameSpacePersonaje;
using NameSpaceEstadoCombate;
using System.Transactions;
using NameSpaceEnemigo;


class EstadoJuego
    : Estado
{
    protected Personaje personajeActual;
    protected List<Personaje> ListaDePersonajes;


    public EstadoJuego(Stack<Estado> estados, Personaje personajeActual, List<Personaje> ListaDePersonajes)
        : base(estados)
    {
        this.personajeActual = personajeActual;
        this.ListaDePersonajes = ListaDePersonajes;
    }

    public void ProcesarEntrada(int opcion)
    {
        switch(opcion)
        {
            case 1:
                Console.Clear();
                personajeActual.MostrarEstadisticas();
                break;
            case 2:
                Console.Clear();
                Enemigo enemigo = new Enemigo(personajeActual.Nivel);
                estados.Push(new EstadoCombate(estados, personajeActual, enemigo));
                break;
            case 3:
                //Se ejecuta un metodo para guardar partida
                Console.Clear();
                Gui.Anuncio("Se guardo la partida con exito");
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
        (bool,int) entrada = (false, 0);
        int enemigosNecesariosAderrotar = 4;
        while(!entrada.Item1 && personajeActual.Salud>0 && personajeActual.EnemigosDerrotados < enemigosNecesariosAderrotar)
        {
            
            Gui.Titulo("Zona de descanso");
            System.Console.WriteLine(personajeActual.Banner());
            System.Console.WriteLine("\n");
            Gui.MenuOpciones(1, "Estadisticas del Personaje");
            Gui.MenuOpciones(2, "Ir al combate"); 
            Gui.MenuOpciones(3, "Guardar Partida y salir al Menu Principal"); 
        
            entrada = Gui.ControlarEntradaEntera("Ingresa una opcion: ", 1, 3);
        }

        if(personajeActual.Salud <= 0 || personajeActual.EnemigosDerrotados >= enemigosNecesariosAderrotar)
        {
            finalizar = true;
            if(personajeActual.Salud <= 0)
            {
                Gui.Anuncio($"El personaje {personajeActual.Nombre} se murio");
                Gui.Anuncio($"Elimina el personaje y crea uno nuevo");
            }
            if(personajeActual.EnemigosDerrotados >= enemigosNecesariosAderrotar)
            {
                Gui.Anuncio("Lograste Sobrevivir");
                Gui.Anuncio($"El personaje {personajeActual.Nombre} pasara al Hall de la fama");
                Gui.Anuncio($"Elimina el personaje y crea uno nuevo");
                //Guardar Record
            }
        }else
        {
            int opcion = entrada.Item2;

            this.ProcesarEntrada(opcion);
        }
    }
}