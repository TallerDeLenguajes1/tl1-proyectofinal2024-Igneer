using NameSpaceGui;

namespace NameSpacePersonaje;

class Personaje
{
    // //Datos
    // string nombre;
    // string raza;
    // string edad;

    // //Caracteristicas
    // int velocidad;
    // int destreza;
    // int fuerza;
    // int nivel;
    // int armadura;
    // int salud;

    // private void Stats()
    // {
    //     Random random = new Random();
    //     this.velocidad = random.Next(1, 11);
    //     this.destreza = random.Next(1, 5);
    //     this.fuerza = random.Next(1, 11);
    //     this.nivel = 1;
    //     this.armadura = random.Next(1, 11);
    //     this.salud = 100;
    // }

    // private void Datos()
    // {
    //     System.Console.WriteLine("Ingresa el nombre del personaje: ");
    //     this.nombre = Console.ReadLine();
    //     int opcion = -1;
    //     while(opcion < 1 || opcion > 9)
    //     {
    //         int.TryParse(Console.ReadLine(), out opcion);
    //         System.Console.WriteLine("Elije la raza: ");
    //         switch(opcion)
    //         {
    //             case 1:
    //                 System.Console.WriteLine(Gui.MenuOpciones(1, "Dragonborn"));
    //                 this.raza = "Dragonborn";
    //                 break;
    //             case 2:
    //                 System.Console.WriteLine(Gui.MenuOpciones(2, "Dwarf"));
    //                 this.raza = "Dwarf";
    //                 break;
    //             case 3:
    //                 System.Console.WriteLine(Gui.MenuOpciones(3, "Elf"));
    //                 this.raza = "Elf";
    //                 break;
    //             case 4:
    //                 System.Console.WriteLine(Gui.MenuOpciones(4, "Gnome"));
    //                 this.raza = "Gnome";
    //                 break;
    //             case 5:
    //                 System.Console.WriteLine(Gui.MenuOpciones(5, "Half-elf"));
    //                 this.raza = "Half-elf";
    //                 break;
    //             case 6:
    //                 System.Console.WriteLine(Gui.MenuOpciones(6, "Half-orc"));
    //                 this.raza = "Half-orc";
    //                 break;
    //             case 7:
    //                 System.Console.WriteLine(Gui.MenuOpciones(7, "Halfling"));
    //                 this.raza = "Halfling";
    //                 break;
    //             case 8:
    //                 System.Console.WriteLine(Gui.MenuOpciones(8, "Human"));
    //                 this.raza = "Human";
    //                 break;
    //             case 9:
    //                 System.Console.WriteLine(Gui.MenuOpciones(9, "Tiefling"));
    //                 this.raza = "Tiefling";
    //                 break;
    //             default:
    //                 System.Console.WriteLine("No se ingreso una opcion valida");
    //                 break;
    //         }
    //     }
    // }

    //Caracteristicas Generales
    private String nombre       = "";
    int nivel                   = 0;
    int puntosDeHabilidad       = 3;
    int exp                     = 0;
    int expMax                  = 100;

    //Atributos
    int vitalidad               = 1;
    int fuerza                  = 1;
    int destreza                = 1;
    int agilidad                = 1;
    int inteligencia            = 1;

    //Estadisticas
    int salud                   = 0;
    int saludMax                = 10;
    int dmg                     = 0; //Daño
    int dmgMax                  = 0; //DañoMaximo
    int precision               = 0;
    int defensa                 = 0;

    //General
    int oro                     = 100;

    private void CalcularExperiencia()
    {
        this.expMax = this.nivel * 100;
    }
    private void CalcularEstadisticas()
    {
        this.salud = this.vitalidad * 10;
        this.dmgMax = this.fuerza * 2;
        this.dmg = this.dmgMax / 2;
        this.precision = this.destreza * 2;
        this.defensa = this.agilidad * 2;
    }
    public Personaje(String nombre)
    {
        this.CalcularEstadisticas();

        this.nombre = nombre;
    }

    public override String ToString()
    {
        return this.nombre;
    }
}