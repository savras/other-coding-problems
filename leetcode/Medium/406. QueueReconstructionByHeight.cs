public class Solution {
    // Greedy solution - Start filling in result with shortest person first.
    public int[,] ReconstructQueue(int[,] people)
    {
        var len = people.GetLength(0);
        var result = new int[len, 2];

        // Handle people with zero height scenario. 
        for (var i = 0; i < len; i++)
        {
            for (var j = 0; j < 2; j++)
            {
                result[i, j] = -1;
            }
        }
        
        // Dict<height, List of people in front of person of this height>
        var dict = new Dictionary<int, List<int>>();
        for (var i = 0; i < len; i++)
        {
            if (!dict.ContainsKey(people[i, 0]))
            {
                dict.Add(people[i, 0], new List<int> { people[i, 1] });
            }
            else
            {
                dict[people[i, 0]].Add(people[i, 1]);
            }
        }

        // Tallest people first.
        var sortedPeople = dict.OrderByDescending(d => d.Key).ThenBy(d => d.Value).ToList();    
        
        // Process list, starting from shortest person.
        var isTallest = false;
        for(var i = sortedPeople.Count - 1; i >= 0; i--)
        {
            foreach (var heightOfTallerPeople in sortedPeople[i].Value)
            {
                PlacePersonInResult(sortedPeople[i].Key, heightOfTallerPeople, result);
            }
        }

        return result;

    }


    public void PlacePersonInResult(int heightOfPerson, int numberOfPeopleInFront, int[,] result)
    {
        var emptySlots = 0;

        // Skip through number of empty slots as many as the number of people in front.
        // Insert result in the next available slot
        for (var i = 0; i < result.GetLength(0); i++)
        {
            if ((result[i, 0] == -1) || result[i, 0] >= heightOfPerson)
            {
                if (emptySlots == numberOfPeopleInFront && result[i, 0] == -1)
                {
                    result[i, 0] = heightOfPerson;
                    result[i, 1] = numberOfPeopleInFront;
                    break;
                }
                emptySlots++;
            }
        }
    }
}