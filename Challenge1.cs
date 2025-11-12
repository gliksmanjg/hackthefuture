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
        HttpResponseMessage res = client.GetAsync("/api/challenges/signal").Result;
        string json = res.Content.ReadAsStringAsync().Result;
        SignalResponse signalResponse = JsonSerializer.Deserialize<SignalResponse>(json);

        string decrypted = Decrypt(signalResponse.CipherText, signalResponse.Shift);
        
        Console.WriteLine($"Encrypted: {signalResponse.CipherText}");
        Console.WriteLine($"Decrypted: {decrypted}");
    }

    private static string Decrypt(string input, int shift)
    {
        string res = string.Empty;
        foreach (char c in input)
        {
            res += Decrypt(c, shift);
        }
        return res;
    }

    private static char Decrypt(char c, int shift)
    {
        if (!char.IsLetter(c))
        {
            return c;
        }

        bool uppercase = char.IsUpper(c);
        if(uppercase)
        {
            c = char.ToLower(c);
        }
        
        c = (char) (c + shift);

        c -= 'a';
        c = (char) (c % 26);
        c += 'a';

        if (uppercase)
        {
            return char.ToUpper(c);
        }
        else
        {
            return c;
        }
    }
}