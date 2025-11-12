using System.Text.Json;

namespace Hack_The_Future;

public class Challenge1
{
    public static void Main()
    {
        string apiKey = File.ReadAllText("key.txt");
        
        HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("https://exs-htf-2025.azurewebsites.net")
        };

        client.DefaultRequestHeaders.Add("Authorization", "team " + apiKey);
        HttpResponseMessage res = client.GetAsync("/api/challenges/signal?isTest=true").Result;
        string json = res.Content.ReadAsStringAsync().Result;
        SignalResponse signalResponse = JsonSerializer.Deserialize<SignalResponse>(json);

        Console.WriteLine($"Encrypted: {signalResponse.CipherText}");
        string deciphered = decipher(signalResponse.CipherText, signalResponse.Shift);
        Console.WriteLine($"Decrypted: {deciphered}");
    }

    private static string decipher(string input, int shift)
    {
        string res = string.Empty;
        foreach (char c in input)
        {
            if (char.IsLetter(c))
            {
                res += (char) (c + shift);
            }
            else
            {
                res += c;
            }
        }
        return res;
    }
}