namespace NameSpaceJuego;
using NameSpacesEstados;

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
        this.estados.Push(new Estado(this.estados));
    }



//Constructores y Destructores
    public Juego()
    {
        this.IniciarVariables();
        this.IniciarEstados();

        Console.WriteLine("Hola Juego class");
    }

    public void empezar()
    {
        Console.WriteLine("Despiertas en un coliseo...\nTe duele mucho la cabeza y no recuerdas nada de lo que te sucedió...\n");
        Console.WriteLine("Pero puedes recordar tu nombre (Introduce tu nombre): ");
        string nombre = Console.ReadLine();
        Console.Clear();
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