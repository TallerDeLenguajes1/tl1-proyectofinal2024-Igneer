using System.Reflection.Metadata;

namespace NameSpaceGui;
class Gui
{
    public static String Titulo(String titulo)
    {
        titulo = String.Format("==== {0} ====\n\n", titulo);
        return titulo;
    }

    public static String MenuTitulo(String titulo)
    {
        titulo = String.Format("=== {0}\n", titulo);
        
        return titulo;
    }

    public static String MenuOpciones(int opcion, String titulo)
    {
        titulo = String.Format("- ({0}) : {1} :\n", opcion, titulo);

        return titulo;
    }
}