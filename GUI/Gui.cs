using System.Reflection.Metadata;

namespace NameSpaceGui;
class Gui
{
    public static void Titulo(String cadena)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        cadena = String.Format("==== {0} ====", cadena);
        
        System.Console.WriteLine(cadena);
        Console.ResetColor();
    }

    public static void TituloJuego()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        
        String cadena = @"
=================================================================================================
   _____   ______    __        ______        _______.     _______. _______  __    __  .___  ___. 
 /      | /  __  \  |  |      /  __  \      /       |    /       ||   ____||  |  |  | |   \/   | 
|  ,----'|  |  |  | |  |     |  |  |  |    |   (----`   |   (----`|  |__   |  |  |  | |  \  /  | 
|  |     |  |  |  | |  |     |  |  |  |     \   \        \   \    |   __|  |  |  |  | |  |\/|  | 
|  `----.|  `--'  | |  `----.|  `--'  | .----)   |   .----)   |   |  |____ |  `--'  | |  |  |  | 
 \______| \______/  |_______| \______/  |_______/    |_______/    |_______| \______/  |__|  |__| 
 
 ================================================================================================";
        System.Console.WriteLine(cadena+"\n");
        Console.ResetColor();
    }
    public static void Warning(String cadena)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        cadena = String.Format("==== {0} ====", cadena);
        
        System.Console.WriteLine(cadena);
        Console.ResetColor();
    }

    public static void MenuTitulo(String cadena)
    {
        cadena = String.Format("=== {0}\n", cadena);
        
        System.Console.WriteLine(cadena); 
    }

    public static void MenuOpciones(int opcion, String cadena)
    {
        cadena = String.Format("- ({0}) : {1} :\n", opcion, cadena);

        System.Console.WriteLine(cadena); 
    }

    public static void CombateOpciones(int opcion, String cadena)
    {
        cadena = String.Format("- ({0}) | {1} |", opcion, cadena);

        System.Console.WriteLine(cadena); 
    }

    public static void Anuncio(String cadena)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        cadena = String.Format("\t(~) {0}!\n", cadena);

        System.Console.WriteLine(cadena);
        Console.ResetColor(); 
    }

    public static String BarraDeProgreso(int min, int max, int ancho)
    {
        String barra = "[";

        double porcentaje = (double)min / max;
        int completo = Convert.ToInt32(porcentaje * ancho);

        for (int i = 0; i <= completo; i++)
        {
            barra += "=";
        }

        for (int i = completo; i < ancho; i++)
        {
            barra += "-";
        }

        barra += "]"; 

        return barra;
    }
    public static void PedirEntrada(String cadena)
    {
        cadena = String.Format("- {0}: ", cadena);

        System.Console.WriteLine(cadena); 
    }
     
    public static int PedirUnaEntradaEntera(string mensaje)
    {
        Nullable<int> entrada = null;
        while(entrada == null)
        {
            try
            {
                Gui.PedirEntrada(mensaje);
                entrada = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.Clear();
                Gui.Anuncio("Lo que ingresaste no es valido");
            }
        }

        return entrada.Value;
    }

    public static (bool, int) ControlarEntradaEntera(string mensaje, int numeroMinimo, int numeroMaximo)
    {
        bool entradaValida;
        Gui.PedirEntrada(mensaje);
        string entrada = Console.ReadLine();
        if(int.TryParse(entrada, out int numeroEntero) && numeroEntero >= numeroMinimo && numeroEntero <= numeroMaximo)
        {
            entradaValida = true;
        }else
        {
            Console.Clear();
            Gui.Anuncio("Lo que ingresaste no es valido");
            entradaValida = false;
        }

        return (entradaValida, numeroEntero);
    }
}