namespace NameSpaceJuego;

using NameSpaceEstadoMenuPrincipal;
using NameSpaceEstados;
using NameSpaceEstadoJuego;
using System.Collections;

class Juego
{
    //Variables
    private Stack<Estado> estados; 
    private ArrayList ListaDePersonajes;

    //Funciones
    private void IniciarListaDePersonajes()
    {
        this.ListaDePersonajes = new ArrayList();
    }
    private void IniciarEstados()
    {
        this.estados = new Stack<Estado>();

        //Push del primer estado
        this.estados.Push(new EstadoMenuPrincipal(this.estados, this.ListaDePersonajes));
        //this.estados.Push(new EstadoJuego(this.estados));

    }

//Cambiar juego en program

//Constructores y Destructores
    public Juego()
    {
        this.IniciarListaDePersonajes();
        this.IniciarEstados();
    }

    public void empezar()
    {
        while(this.estados.Count > 0)
        {
            this.estados.Peek().Update(); // Peek es un metodo que se aplica a Stack, me permite tomar el objeto al princio del stack sin eliminarlo
            
            if(this.estados.Peek().consultarFinalizar())
            {
                this.estados.Pop();
            }
            
        }

        Console.WriteLine("Juego Finalizado");
    }
}