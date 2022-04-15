using VinylFlamingo.TrendDotNet;

public class Program 
{
    public static void Main(string[] args)
    {
        var trendService = new Scorer();

        trendService.AddFactor("page views", 1700202002, 1);

        foreach(var factor in trendService.Factors)
        {
            Console.WriteLine(factor.Name.ToString());
        }

        Console.WriteLine(trendService.Calculate(45));
    }
    

}

