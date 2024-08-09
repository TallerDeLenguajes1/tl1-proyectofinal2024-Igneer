using NameSpaceGui;

namespace NameSpacePersonaje;

class Personaje
{
    //Caracteristicas Generales
    private string nombre       = "";
    string raza                 = "";
    int nivel                   = 1;
    int exp                     = 0;
    int expMax                  = 100;

    //Atributos
    int vitalidad               = 1;
    int fuerza                  = 1;
    int armadura                = 1;

    //Estadisticas
    int salud                   = 0;
    int saludMax                = 0;
    int dmg                     = 0; //Daño
    int defensa                 = 0;

    //General
    int enemigosDerrotados = 0;

    public string Nombre { get => nombre;}
    public int Salud { get => salud;}
    public int SaludMax { get => saludMax;}
    public int Dmg { get => dmg;}
    public int Defensa { get => defensa;}
    public int Nivel { get => nivel;}
    public int EnemigosDerrotados { get => enemigosDerrotados;}
    
    public int Exp { get => exp;}
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

    public void RecuperarSalud()
    {
        salud = saludMax;
    }
    public void AumentarEnemigosDerrotados()
    {
        enemigosDerrotados++;
    }

    public void AumentoDeAtributos()
    {
        Random random = new Random();
        int atributoMejorado = random.Next(1,4);
        int puntosDeHabilidad = 3;
        while(puntosDeHabilidad > 0)
        {
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
            puntosDeHabilidad--;
        }
    }
    public void SubidaDeNivel(int expActual, int expObtenida)
    {
        if((expActual+expObtenida) < expMax)
        {
            exp += expObtenida;
        }else
        {
            nivel++;
            exp = 0;
            AumentoDeAtributos();
            CalcularEstadisticas();
        }
    }
    private void CalcularEstadisticas()
    {
        saludMax = 50 + vitalidad * 10;
        salud = saludMax;
        dmg = fuerza * 2;
        defensa = armadura * 2;
        expMax = nivel * 100;
    }
    public Personaje(String nombre)
    {
        AumentoDeAtributos();
        CalcularEstadisticas();

        this.nombre = nombre;
    }

    public string Banner()
    {
        String str = $"\n{nombre}"+$"   Nivel: {nivel}   Salud: {salud}/{saludMax}   Enemigos por derrotar: {enemigosDerrotados}";            
        return str;
    }
    public String DetallesDelPersonaje()
    {
        String str = String.Format(
        "\nNombre:              {0,-20}\n" +
        "Nivel:               {1,-20}\n" +
        "Exp:                 {2}/{3}\n",
        nombre, nivel, exp, expMax);          

        return str;
    }

    public void MostrarEstadisticas() 
    {
        Gui.Titulo("Características Generales:");
        Console.WriteLine(String.Format("Nombre:              {0,-20}\n", Nombre));
        Console.WriteLine(String.Format("Raza:                {0,-20}\n", raza));
        Console.WriteLine(String.Format("Nivel:               {0,-20}\n", Nivel));
        Console.WriteLine(String.Format("Exp:                 {0}/{1}\n", exp, expMax));

        Gui.Titulo("Atributos:");
        Console.WriteLine(String.Format("Vitalidad:           {0,-20}\n", vitalidad));
        Console.WriteLine(String.Format("Fuerza:              {0,-20}\n", fuerza));
        Console.WriteLine(String.Format("Armadura:            {0,-20}\n", armadura));

        Gui.Titulo("Estadísticas:");
        Console.WriteLine(String.Format("Salud:               {0}/{1}\n", Salud, SaludMax));
        Console.WriteLine(String.Format("Daño:                {0,-20}\n", Dmg));
        Console.WriteLine(String.Format("Defensa:             {0,-20}\n", Defensa));

        Gui.Anuncio("Presiona cualquier tecla para volver");
        Console.ReadKey();
        Console.Clear();
    }
}