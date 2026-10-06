using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsumerAdviceApi;

public class Program
{
    private const string Endpoint = "https://api.adviceslip.com/advice";

    public static async Task Main()
    {
        using var httpClient = new HttpClient();

        try
        {
            // A API pode guardar a resposta em cache; o parâmetro "t" garante um conselho novo a cada execução.
            string url = $"{Endpoint}?t={DateTime.Now.Ticks}";
            string json = await httpClient.GetStringAsync(url);

            AdviceResponse? resposta = JsonSerializer.Deserialize<AdviceResponse>(json);

            if (resposta?.Slip is null)
            {
                Console.WriteLine("Não foi possível ler o conselho retornado pela API.");
                return;
            }

            Console.WriteLine("Conselho de Hoje:");
            Console.WriteLine(resposta.Slip.Advice);
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Erro ao acessar a API: {ex.Message}");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Erro ao ler o JSON retornado: {ex.Message}");
        }
    }
}

// Representa o JSON: { "slip": { "id": 1, "advice": "..." } }
public class AdviceResponse
{
    [JsonPropertyName("slip")]
    public Slip? Slip { get; set; }
}

public class Slip
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("advice")]
    public string Advice { get; set; } = string.Empty;
}
