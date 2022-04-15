using VinylFlamingo.TrendDotNet;

public class Program 
{
    public static void Main(string[] args)
    {
        var trendService = new Scorer();

        trendService.AddFactor();
        

        foreach (var factor in trendService.Factors)
        {
            Console.WriteLine(factor.Name.ToString());
        }

        
    }
    

}

