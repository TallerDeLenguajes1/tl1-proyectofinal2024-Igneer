namespace NameSpaceEstadoMenuPrincipal;

using System.Collections;
using NameSpaceEstadoCreacionPersonaje;
using NameSpaceEstados;
using NameSpaceGui;
using NameSpacePersonaje;


class EstadoMenuPrincipal 
    : Estado
{
    protected ArrayList ListaDePersonajes;
    public EstadoMenuPrincipal(Stack<Estado> estados, ArrayList ListaDePersonajes)
        : base(estados)
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
                break;
            case 2:
                this.estados.Push(new EstadoCreacionPersonaje(this.estados, this.ListaDePersonajes));
                break;
            case 3:
                System.Console.WriteLine(this.ListaDePersonajes.Count);
                break;
            default:
                break;
        }

    }

    override public void Update()
    {
        System.Console.WriteLine(Gui.MenuTitulo("Estado Menu Principal")); 
        System.Console.WriteLine(Gui.MenuOpciones(1, "Nueva Partida"));
        System.Console.WriteLine(Gui.MenuOpciones(2, "Crear Personaje"));
        System.Console.WriteLine(Gui.MenuOpciones(3, "Lista de personajes"));
        System.Console.WriteLine(Gui.MenuOpciones(-1, "Salir")); 

        Gui.ObtenerEntrada("Entrada: ");
        int.TryParse(Console.ReadLine(), out int opcion);

        this.ProcesarEntrada(opcion);
    }
}