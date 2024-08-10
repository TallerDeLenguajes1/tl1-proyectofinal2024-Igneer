namespace NameSpaceManejoApi;
using System.Text.Json.Serialization;
using System.Text.Json;
class ManejoDeApi
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Result
    {
        [JsonPropertyName("name")]
        public string name { get; set; }
    }

    public class Razas
    {
        [JsonPropertyName("count")]
        public int count { get; set; }

        [JsonPropertyName("results")]
        public List<Result> results { get; set; }
    }

    public static async Task<Razas> GetRazasAsync()
    {
        string url = "https://www.dnd5eapi.co/api/races";
        try
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Razas Resultado = JsonSerializer.Deserialize<Razas>(responseBody); 

            return Resultado;
        }
        catch (HttpRequestException e)
        {
            throw e;
        }
    }

}