using System.Text;
using System.Text.Json;
using NameSpaceGui;
using NameSpacePersonaje;

class ManejoDeJson
{
    public static bool GuardarListaDePersonajes(Personaje personaje)
    {
        bool guardadoConExito;
        string rutaJson = "personajes.json";

        if(!File.Exists(rutaJson))
        {
            File.WriteAllText(rutaJson, "[]");
        }
        
        string json = File.ReadAllText(rutaJson);

        List<Personaje> ListaGuardada = JsonSerializer.Deserialize<List<Personaje>>(json);
        if(ListaGuardada.Count < 3)
        {
            ListaGuardada.Add(personaje);
            File.WriteAllText(rutaJson, JsonSerializer.Serialize(ListaGuardada));
            guardadoConExito = true;
        }else
        {
            Gui.Anuncio("Existen 3 personajes guardados, no se guardo el personaje");
            guardadoConExito = false;
        }

        return guardadoConExito;
    }

    public static List<Personaje> CargarListaDePersonajes()
    {
        List<Personaje> ListaDePersonajes;

        string rutaJson = "personajes.json";

        if(File.Exists(rutaJson))
        {
            string json = File.ReadAllText(rutaJson);
            ListaDePersonajes = JsonSerializer.Deserialize<List<Personaje>>(json);
        }else
        {
            ListaDePersonajes = new List<Personaje>();
        }

        return ListaDePersonajes;
    }
}