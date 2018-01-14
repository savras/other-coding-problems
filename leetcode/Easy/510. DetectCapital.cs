public class Solution {
    public bool CheckIfCharIsCapital(char c)
    {
        return c < 'a' || c > 'z';
    }

    public bool CheckIfCharIsSmall(char c)
    {
        return c >= 'a' && c <= 'z';
    }

    public bool DetectCapitalUse(string word)
    {
        if (word.Length <= 1)
        {
            return true;
        }

        var result = true;
        if (CheckIfCharIsSmall(word[0]))
        {
            for (var i = 1; i < word.Length; i++)
            {
                if (CheckIfCharIsCapital(word[i]))
                {
                    result = false;
                    break;
                }
            }
        }
        else
        {
            if (CheckIfCharIsCapital(word[1]))
            {
                for (var i = 1; i < word.Length; i++)
                {
                    if (CheckIfCharIsSmall(word[i]))
                    {
                        result = false;
                        break;
                    }
                }
            }
            else
            {
                for (var i = 2; i < word.Length; i++)
                {
                    if (CheckIfCharIsCapital(word[i]))
                    {
                        result = false;
                        break;
                    }
                }
            }

        }

        return result;
    }
}