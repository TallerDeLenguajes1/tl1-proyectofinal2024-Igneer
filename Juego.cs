namespace Estados;

class Juego
{
//Variables
bool Finalizar; 

//Funciones
private void IniciarVariables()
{
    this.Finalizar = false;
}



//Constructores y Destructores
    public Juego()
    {
        this.IniciarVariables();

        Console.WriteLine("Hola");
    }

    public void Empezar()
    {
        Console.WriteLine("Despiertas en un coliseo...\n Te duele mucho la cabeza y no recuerdas nada de lo que te sucedió...\n");
        Console.WriteLine("Pero puedes recordar tu nombre (Introduce tu nombre): ");
        string nombre = Console.ReadLine();
        Console.Clear();
        while(!this.Finalizar)
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