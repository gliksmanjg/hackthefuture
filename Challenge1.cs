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
        string res = client.GetAsync("/api/challenges/signal").Result.Content.ReadAsStringAsync().Result;
        Console.WriteLine(res);
    }
}