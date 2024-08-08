using NameSpaceEstados;
using NameSpacePersonaje;
using NameSpaceGui;
using NameSpaceEnemigo;
using System.Security;

namespace NameSpaceEstadoCombate;
class EstadoCombate
    : Estado
{
    protected Personaje personajeActual;
    protected Enemigo enemigo;

    public EstadoCombate(Stack<Estado> estados, Personaje personajeActual, Enemigo enemigo)
        : base(estados)
    {
        this.enemigo = enemigo;
        this.personajeActual = personajeActual;
    }

    public void ProcesarEntrada(int entrada, Enemigo enemigo)
    {
        bool atacaPersonaje;
        bool atacaEnemigo;
        switch(entrada)
        {
            case 1:
                Console.Clear();
                atacaPersonaje = true;
                atacaEnemigo = enemigo.TomarDecision();
                break;
            case 2:
                Console.Clear();
                atacaPersonaje = false;
                atacaEnemigo = enemigo.TomarDecision();
                break;
            default:
                Console.Clear();
                atacaPersonaje = false;
                atacaEnemigo = enemigo.TomarDecision();
                Gui.Anuncio("La opcion ingresada no es valida");
                break;
        }

        ActualizarSaludPersonajeEnemigo(atacaPersonaje, atacaEnemigo);
        
    }

    override public void Update()
    {
        (bool, int) entrada = (false, 0);
        while(!entrada.Item1 && personajeActual.Salud > 0 && enemigo.Salud > 0) // Falta enemigo
        {
            Gui.Titulo("Estado Combate");
            System.Console.WriteLine($"Enemigo\nHP {enemigo.Salud}/{enemigo.SaludMax}:");
            System.Console.WriteLine(Gui.BarraDeProgreso(enemigo.Salud, enemigo.SaludMax, 10)); //Barra de salud del enemigo
            System.Console.WriteLine("\n");
            System.Console.WriteLine($"{personajeActual.Nombre}\nHP {personajeActual.Salud}/{personajeActual.SaludMax}:");
            System.Console.WriteLine(Gui.BarraDeProgreso(personajeActual.Salud, personajeActual.SaludMax, 10));
            System.Console.WriteLine("\n");
            
            Gui.CombateOpciones(1, "Atacar");
            Gui.CombateOpciones(2, "Defender");
            System.Console.WriteLine("\n");
            
            entrada = Gui.ControlarEntradaEntera("Ingresa una opcion: ", 1, 3);

        }
        
        if(enemigo.Salud <= 0)
        {
            personajeActual.AumentarEnemigosDerrotados();
            personajeActual.SubidaDeNivel(personajeActual.Exp, enemigo.ExperienciaQueGenera(personajeActual.Nivel));
            personajeActual.RecuperarSalud();
            Console.Clear();
            Gui.Anuncio("Ganaste el combate");
        }

        if(personajeActual.Salud <= 0 || enemigo.Salud <= 0) // Falta enemigo
        {
            finalizar = true;
        }else
        {
            int opcion = entrada.Item2;

            ProcesarEntrada(opcion, enemigo);
        }
    }

    public void ActualizarSaludPersonajeEnemigo(bool atacaPersonaje, bool atacaEnemigo)
    {
        if(atacaPersonaje)
        {
            if(atacaEnemigo) //Ambos atacan
            {
                personajeActual.ActualizarSalud(enemigo.Dmg);
                enemigo.ActualizarSalud(personajeActual.Dmg);
            }else // personaje ataca - enemigo se defiende
            {
                enemigo.ActualizarSalud(personajeActual.Dmg-enemigo.Defensa);
            }
        }else
        {
            if(atacaEnemigo) // Personaje se defiende - enemigo ataca
            {
                personajeActual.ActualizarSalud(enemigo.Dmg-personajeActual.Defensa);
            }
            //Si ambos se defienden no pasa nada
        }
    }

}