namespace NameSpaceEstadoMenuPrincipal;
using NameSpaceEstados;
using NameSpaceGui;
using NameSpacePersonaje;


class EstadoMenuPrincipal 
    : Estado
{
    Personaje personaje;

    public EstadoMenuPrincipal(Stack<Estado> estados)
        : base(estados)
    {
        this.personaje = new Personaje("Head");
    }

    override public void Update()
    {
        System.Console.WriteLine(Gui.MenuTitulo("Estado Menu Principal")); 
        System.Console.WriteLine(Gui.MenuOpciones(1, "Nueva Partida"));
        System.Console.WriteLine(Gui.MenuOpciones(2, "Cargar Partida")); 
        System.Console.WriteLine(Gui.MenuOpciones(-1, "Salir")); 

        System.Console.WriteLine(personaje.ToString());

        System.Console.WriteLine("Ingresa un numero (Menu principal): ");
        int.TryParse(Console.ReadLine(), out int salud);

        if(salud < 0)
        {
            this.finalizar = true; 
        }
    }
}