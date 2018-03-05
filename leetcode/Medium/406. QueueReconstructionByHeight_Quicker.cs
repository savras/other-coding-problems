public class Solution {
    // Greedy solution - Start filling in result with shortest person first.
    // Update: Discussions talk about a quicker way to insert based on k from left to right.
    public int[,] ReconstructQueue(int[,] people)
        {
            var length = people.GetLength(0);
            var peopleList = new List<Tuple<int, int>>();
            for (var i = 0; i < length; i++)
            {
                peopleList.Add(Tuple.Create(people[i, 0], people[i, 1]));
            }

            // Tallest people first, then by k ascending
            var sortedPeople = peopleList.OrderByDescending(d => d.Item1).ThenBy(d => d.Item2).ToList();

            // Process sortedPeople, starting from left to right (tallest first)
            var resultList = new List<Tuple<int, int>>(length);
            for (var i = 0; i < sortedPeople.Count; i++)
            {
                resultList.Insert(sortedPeople[i].Item2, Tuple.Create(
                    sortedPeople[i].Item1, sortedPeople[i].Item2));
            }

            var result = new int[length, 2];
            for(var i = 0; i < length; i++)
            {
                result[i,0] = resultList[i].Item1;
                result[i,1] = resultList[i].Item2;
            }
            return result;
        }
}