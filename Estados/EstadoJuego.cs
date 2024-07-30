namespace NameSpaceEstadoJuego;
using NameSpaceEstados;

class EstadoJuego
    : Estado
{
    public EstadoJuego(Stack<Estado> estados)
        : base(estados)
    {
        System.Console.WriteLine("Hola EstadoJuego");
    }

    override public void Update()
    {
        System.Console.WriteLine("Ingresa un numero (Juego): ");
        int.TryParse(Console.ReadLine(), out int salud);
    
        if(salud < 0)
        {
            this.finalizar = true; 
        }
    }
}