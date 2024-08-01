using System.Diagnostics.Tracing;
namespace NameSpaceEstadoCreacionPersonaje;

using System.Collections;
using NameSpaceEstados;
using NameSpaceGui;
using NameSpacePersonaje;

class EstadoCreacionPersonaje
    :Estado 
{
    ArrayList ListaDePersonajes;
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
                System.Console.WriteLine(Gui.Anuncio("Personaje Creado"));
                this.ListaDePersonajes.Add(new Personaje("Pepe"));
                this.ListaDePersonajes.Add(new Personaje("Bob"));
                this.ListaDePersonajes.Add(new Personaje("Lila"));
                break;
            default:
                break;
        }

    }

    override public void Update() 
    {
        System.Console.WriteLine(Gui.MenuTitulo("Creacion de Personaje")); 
        System.Console.WriteLine(Gui.MenuOpciones(1, "Nuevo Personaje"));
        System.Console.WriteLine(Gui.MenuOpciones(2, "Editar Personaje"));
        System.Console.WriteLine(Gui.MenuOpciones(3, "Eliminar Personaje"));
        System.Console.WriteLine(Gui.MenuOpciones(-1, "Salir")); 

        System.Console.WriteLine("Entrada: ");
        int.TryParse(Console.ReadLine(), out int opcion);

        this.ProcesarEntrada(opcion); // Probar en probar procesar entrada en GUI
    }
}