namespace NameSpaceEstadoMenuPrincipal;
using NameSpaceEstados;
using NameSpaceEstadoJuego;

class EstadoMenuPrincipal 
    : Estado
{
    public EstadoMenuPrincipal(Stack<Estado> estados)
        : base(estados)
    {
       
    }

    override public void Update()
    {
        System.Console.WriteLine("Ingresa un numero (MenuPrincipal): ");
        int.TryParse(Console.ReadLine(), out int salud);
    
        if(salud < 0)
        {
            this.finalizar = true; 
        }
    }
}