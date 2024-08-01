namespace NameSpaceEstadoJuego;
using NameSpaceEstados;
using NameSpaceGui;

class EstadoJuego
    : Estado
{
    public EstadoJuego(Stack<Estado> estados)
        : base(estados)
    {
    }

    override public void Update()
    {
        System.Console.WriteLine(Gui.MenuTitulo("Estado Juego")); 
        System.Console.WriteLine(Gui.MenuOpciones(0, "Crear Personaje")); 
        System.Console.WriteLine(Gui.MenuOpciones(-1, "Salir")); 

        System.Console.WriteLine("Ingresa un numero (Juego): ");
        int.TryParse(Console.ReadLine(), out int salud);

        if(salud < 0)
        {
            this.finalizar = true; 
        }
    }
}