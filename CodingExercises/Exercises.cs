namespace CodingExercises;

public class Exercises
{
    public Dictionary<char, int> CountCharacterFrequencies(
        string input)
    {
        // return (from x in input
        //     group x by x
        //     into charGroup
        //     select new
        //     {
        //         Character = charGroup.Key,
        //         Count = charGroup.Count()
        //     }).ToDictionary(k => k.Character, v => v.Count);
        
        return input.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
    }
    
    public List<string> GetQualifiedPlayers(
        Dictionary<string, int> playerScores)
    {
        // var passedSoFar = new List<string>(playerScores.Keys.Count);
        // foreach (var playerScore in playerScores)
        // {
        //     if (playerScore.Value >= 50)
        //     {
        //         if (playerScore.Value >= 100)
        //         {
        //             Console.WriteLine($"Invalid - {playerScore.Key}: {playerScore.Value}");
        //             break;
        //         }
        //         passedSoFar.Add(playerScore.Key);
        //     }
        // }
        // return passedSoFar;
        
        return playerScores.TakeWhile(x => x.Value < 100)
            .Where(x => x.Value >= 50)
            .Select(x => x.Key)
            .ToList();
    }
    
    public static TimeSpan CalculateTotalBreakTime(
                List<(DateTime Start, DateTime End)> breaks)
    {
        return breaks.Aggregate(TimeSpan.Zero, (current, value) => current + (value.End - value.Start));
    }
    
    public void UpdateHighestScore(
        Player? player, int newScore)
    {
        if (player?.Statistics is null) return;
        // if (player.Statistics.HighestScore == null)
        // {
        //     player.Statistics.HighestScore = newScore;
        //     return;
        // }
        player.Statistics.HighestScore ??= newScore;
        
        player.Statistics.HighestScore = player.Statistics.HighestScore < newScore ? newScore : player.Statistics.HighestScore;
        
    }
    
    
    public decimal CalculateShippingCost(
        decimal orderTotal, 
        bool isPremiumCustomer)
    {
        const decimal premiumLt50CustomerCost = 5;
        const decimal premiumGt50CustomerCost = 0;
        const decimal nonPremiumLt50CustomerCost = 10;
        const decimal nonPremiumGt50CustomerCost = 5;
        // if (isPremiumCustomer)
        // {
        //     return orderTotal < 50 ? premiumLt50CustomerCost : premiumGt50CustomerCost;
        // }
        // return orderTotal < 50 ? nonPremiumLt50CustomerCost : nonPremiumGt50CustomerCost;

        return orderTotal switch
        {
            < 50 when isPremiumCustomer => premiumLt50CustomerCost,
            >= 50 when isPremiumCustomer => premiumGt50CustomerCost,
            < 50 when !isPremiumCustomer => nonPremiumGt50CustomerCost,
            _ => premiumGt50CustomerCost
        };

    }
}

public class Player
{
    public Statistics? Statistics { get; set; }
}

public class Statistics
{
    public int? HighestScore { get; set; }
}