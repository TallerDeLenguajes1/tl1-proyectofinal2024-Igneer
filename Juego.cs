namespace NameSpaceJuego;

using NameSpaceEstadoMenuPrincipal;
using NameSpaceEstados;

class Juego
{
//Variables
    private bool finalizar;

    private Stack<Estado> estados; 
    public bool Finalizar{get => finalizar; set => finalizar = value;}

    //Funciones
    private void IniciarVariables()
    {
        this.Finalizar = false;
    }

    private void IniciarEstados()
    {
        this.estados = new Stack<Estado>();

        //Push del primer estado
        this.estados.Push(new EstadoMenuPrincipal(this.estados));
    }



//Constructores y Destructores
    public Juego()
    {
        this.IniciarVariables();
        this.IniciarEstados();
    }

    public void empezar()
    {
        while(this.Finalizar == false)
        {

            int.TryParse(Console.ReadLine(), out int salud);
            if(salud < 0){
                this.Finalizar = true;
            }else
            {
                Console.WriteLine($"Salud actual: {salud}");
            }
        }
        Console.WriteLine("Te moriste");
    }
}