using NameSpaceGui;

namespace NameSpacePersonaje;

class Personaje
{
    //Caracteristicas Generales
    private string nombre       = "";
    string raza                 = "";
    int nivel                   = 0;
    int puntosDeHabilidad       = 3;
    int exp                     = 0;
    int expMax                  = 100;

    //Atributos
    int vitalidad               = 0;
    int fuerza                  = 0;
    int armadura                = 0;

    //Estadisticas
    int salud                   = 100;
    int saludMax                = 0;
    int dmg                     = 0; //Daño
    int defensa                 = 0;

    public String Nombre()
    {
        return this.nombre;
    }

    private void CalcularExperiencia()
    {
        this.expMax = this.nivel * 100;
    }
    private void CalcularEstadisticas()
    {
        this.saludMax = salud + this.vitalidad * 10;
        this.dmg = this.fuerza * 2;
        this.defensa = this.armadura * 2;
    }
    public Personaje(String nombre)
    {
        this.CalcularEstadisticas();

        this.nombre = nombre;
    }

    public string Banner()
    {
        String str = $"\nNombre:{this.nombre}"+$"   Nivel:{this.nivel}\n";            
        return str;
    }
    public String DetallesDelPersonaje()
    {
        String str = String.Format(
        "\nNombre:              {0,-20}\n" +
        "Nivel:               {1,-20}\n" +
        "Puntos de Habilidad: {2,-20}\n" +
        "Exp:                 {3}/{4}\n",
        nombre, nivel, puntosDeHabilidad, exp, expMax);          

        return str;
    }

    public void MostrarEstadisticas() 
    {
        Gui.Titulo("Características Generales:");
        Console.WriteLine(String.Format("Nombre:              {0,-20}\n", nombre));
        Console.WriteLine(String.Format("Raza:                {0,-20}\n", raza));
        Console.WriteLine(String.Format("Nivel:               {0,-20}\n", nivel));
        Console.WriteLine(String.Format("Puntos de Habilidad: {0,-20}\n", puntosDeHabilidad));
        Console.WriteLine(String.Format("Exp:                 {0,-20}/{1}\n", exp, expMax));

        Gui.Titulo("\nAtributos:");
        Console.WriteLine(String.Format("Vitalidad:           {0,-20}\n", vitalidad));
        Console.WriteLine(String.Format("Fuerza:              {0,-20}\n", fuerza));
        Console.WriteLine(String.Format("Armadura:            {0,-20}\n", armadura));

        Gui.Titulo("\nEstadísticas:");
        Console.WriteLine(String.Format("Salud:               {0,-20}/{1}\n", salud, saludMax));
        Console.WriteLine(String.Format("Salud Máxima:        {0,-20}\n", saludMax));
        Console.WriteLine(String.Format("Daño:                {0,-20}\n", dmg));
        Console.WriteLine(String.Format("Defensa:             {0,-20}\n", defensa));
    }
}