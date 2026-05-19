namespace CodingExercises;

public class CharFreq
{
    public static Dictionary<char, int> CountCharacterFrequencies(
        string input)
    {
        return (from x in input
            group x by x
            into charGroup
            select new
            {
                Character = charGroup.Key,
                Count = charGroup.Count()
            }).ToDictionary(k => k.Character, v => v.Count);
    }
}