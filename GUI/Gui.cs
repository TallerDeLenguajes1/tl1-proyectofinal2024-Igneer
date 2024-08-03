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

    public static void Anuncio(String cadena)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        cadena = String.Format("\t(~) {0}!\n", cadena);

        System.Console.WriteLine(cadena);
        Console.ResetColor(); 
    }

    public static void ObtenerEntrada(String cadena)
    {
        cadena = String.Format("- {0}: \n", cadena);

        System.Console.WriteLine(cadena); 
    }
     
    public static int PedirUnaEntradaEntera(string mensaje)
    {
        Nullable<int> entrada = null;
        while(entrada == null)
        {
            try
            {
                Gui.ObtenerEntrada(mensaje);
                entrada = Convert.ToInt32(Console.ReadLine());
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        return entrada.Value;
    }
}