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
    List<Personaje> ListaDePersonajes;

    //Funciones privadas
    private void CrearPresonaje()
    {
        if(ListaDePersonajes.Count < 3)
        {
            Gui.PedirEntrada("Ingrese el nombre del personaje: ");
            string nombre = Console.ReadLine(); 
            this.ListaDePersonajes.Add(new Personaje(nombre));
            Console.Clear();
            Gui.Anuncio("Personaje Creado");
        }else{
            Console.Clear();
            Gui.Anuncio("No puedes tener mas de 3 personajes");
        }
    }

    public EstadoCreacionPersonaje(Stack<Estado> estados, List<Personaje> ListaDePersonajes)
        :base(estados)
    {
        this.ListaDePersonajes = ListaDePersonajes;
    }
    public void ProcesarEntrada(int entrada)
    {
        switch(entrada)
        {
            case 1:
                CrearPresonaje();
                break;
            case 2:
                EliminarPersonaje();
                break;
            case 3:
                Console.Clear();
                finalizar = true;
                break;
            default:
                break;
        }

    }
    
    override public void Update() 
    {
        (bool, int) entrada = (false, 0);
        int opcion;
        while(!entrada.Item1)
        {

            Gui.Titulo("Creacion de Personaje"); 
            Gui.MenuOpciones(1, "Nuevo Personaje");
            Gui.MenuOpciones(2, "Eliminar Personaje");
            Gui.MenuOpciones(3, "Salir"); 

            entrada = Gui.ControlarEntradaEntera("Ingresa una opcion: ", 1, 3);
        }
        opcion = entrada.Item2;

        ProcesarEntrada(opcion); // Probar en probar procesar entrada en GUI
    }
    public void EliminarPersonaje()
    {
        if(ListaDePersonajes.Count == 0)
        {
            Console.Clear();
            Gui.Anuncio("No hay personajes por eliminar");
        }else
        {
            (bool, int) entrada = (false, 0);
            while(!entrada.Item1)
            {
                for (int i = 0; i < ListaDePersonajes.Count; i++)
                {
                    System.Console.WriteLine("Personaje N° "+(i+1) + ": " + ListaDePersonajes[i].DetallesDelPersonaje());
                }
                entrada = Gui.ControlarEntradaEntera("Ingresa el numero del personaje a eliminar: ", 1, ListaDePersonajes.Count);
                if(entrada.Item1)
                {
                    entrada.Item2 -= 1;
                    ListaDePersonajes.RemoveAt(entrada.Item2);
                    Console.Clear();
                    Gui.Anuncio("Personaje eliminado correctamente");
                    entrada.Item1 = true;
                }
            }
        }
    }

}