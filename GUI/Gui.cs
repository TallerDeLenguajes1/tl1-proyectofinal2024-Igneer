using System.Reflection.Metadata;

namespace NameSpaceGui;
class Gui
{
    public static String Titulo(String cadena)
    {
        cadena = String.Format("==== {0} ====\n\n", cadena);
        return cadena;
    }

    public static String MenuTitulo(String cadena)
    {
        cadena = String.Format("=== {0}\n", cadena);
        
        return cadena;
    }

    public static String MenuOpciones(int opcion, String cadena)
    {
        cadena = String.Format("- ({0}) : {1} :\n", opcion, cadena);

        return cadena;
    }

    public static String Anuncio(String cadena)
    {
        cadena = String.Format("(~) ({0})!\n", cadena);

        return cadena;
    }

    public static String ObtenerEntrada(String cadena)
    {
        cadena = String.Format("- {0}: \n", cadena);

        return cadena;
    }
     
}