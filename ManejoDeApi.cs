using System.Text.Json.Serialization;
using System.Text.Json;
class ManejoDeApi
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Result
    {
        [JsonPropertyName("index")]
        public string index { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("url")]
        public string url { get; set; }
    }

    public class Razas
    {
        [JsonPropertyName("count")]
        public int count { get; set; }

        [JsonPropertyName("results")]
        public List<Result> results { get; set; }
    }

    public static async Task<Razas> GetRazasAsync(string url)
    {
        url = "https://www.dnd5eapi.co/api/races";
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
            Console.WriteLine($"Error {e.ToString}");
            throw e;
        }
    }

}