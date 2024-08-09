namespace NameSpaceEnemigo;

using NameSpaceGui;
using NameSpacePersonaje;

class Enemigo
{
    string raza                 = "";

    //Estadisticas
    int salud                   = 100;
    int saludMax                = 0;


    int dmg                     = 0; //Daño
    int defensa                 = 0;

    //Atributos
    int vitalidad               = 1;
    int fuerza                  = 1;
    int armadura                = 1;

    public int Dmg {get => dmg;}
    public int Salud { get => salud;}

    public int SaludMax { get => saludMax;}
    public int Defensa { get => defensa;}

    public Enemigo(int nivelDelPersonaje)
    {
        Random random = new Random();
        int atributoMejorado;
        int puntosDeHabilidadDelEnemigo = nivelDelPersonaje * 2;
        while(puntosDeHabilidadDelEnemigo > 0)
        {
            atributoMejorado = random.Next(1,4);
            switch(atributoMejorado)
            {
                case 1:
                    vitalidad++;
                    break;
                case 2:
                    fuerza++;
                    break;
                case 3:
                    armadura++;
                    break;
            }
            puntosDeHabilidadDelEnemigo--;
        }
        GenerarEstadisticasDelEnemigo();
    }

    public void GenerarEstadisticasDelEnemigo()
    {
        saludMax = 50 + vitalidad * 10;
        salud = saludMax;
        dmg = fuerza * 2;
        defensa = armadura * 2;
    }

    public void ActualizarSalud(int dmgRecibido)
    {
        if(dmgRecibido > 0)
        {
            salud -= dmgRecibido; 
        }else
        {
            salud -= 1;
        }
    }

    public int ExperienciaQueGenera(int nivelDelPersonaje)
    {
        return nivelDelPersonaje * 50;
    }

    public bool TomarDecision()
    {
        bool decision; // Ataca - No ataca
        Random random = new Random();
        int opcion = random.Next(1,3);
        switch(opcion)
        {
            case 1:
                //Enemigo ataca
                decision = true;
                Gui.Anuncio("El enemigo ataco");
                break;
            case 2:
                //Enemigo se defiende
                decision = false;
                Gui.Anuncio("El enemigo se defendio");
                break;
            default:
                decision = true;
                break;
        }

        return decision;
    }
}