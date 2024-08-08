using System.Text;
using System.Text.Json;
using NameSpacePersonaje;

class ManejoDeJson
{
    public void GuardarListaDePersonajes(List<Personaje> ListaDePersonajes)
    {
        string rutaJson = "personajes.json";

        if(!File.Exists(rutaJson))
        {
            File.WriteAllText(rutaJson, "[]");
        }

        string json = JsonSerializer.Serialize(ListaDePersonajes);
    }
}