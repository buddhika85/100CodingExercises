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
    
}

public class Player
{
    public Statistics? Statistics { get; set; }
}

public class Statistics
{
    public int? HighestScore { get; set; }
}