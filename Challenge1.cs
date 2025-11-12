using System.Net.Http.Headers;

namespace Hack_The_Future;

public class Challenge1
{
    public static void Main()
    {
        HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("https://exs-htf-2025.azurewebsites.net")
        };
        
        
    }
}