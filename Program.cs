using NameSpaceEstadoMenuPrincipal;
using NameSpaceEstados;
using NameSpaceGui;
using NameSpacePersonaje;

Stack<Estado> estados = new Stack<Estado>(); 

List<Personaje> ListaDePersonajes = new List<Personaje>();

estados.Push(new EstadoMenuPrincipal(estados, ListaDePersonajes));

while(estados.Count > 0)
{
    estados.Peek().Update(); // Peek es un metodo que se aplica a Stack, me permite tomar el objeto al princio del stack sin eliminarlo
    
    if(estados.Peek().consultarFinalizar())
    {
        estados.Pop();
    }

}

Gui.Despedida("Juego Finalizado");

