public class Solution {
    public int MyAtoi(string s) {
        
        
        string max = "2147483647";

            int index = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ')
                {
                    index = i;
                    break;
                }
            }

            bool positive = true;

            if (s.Length == 0)
                return 0;
            
            if(s[index] != '+' && s[index] != '-' && !Char.IsDigit(s[index]))
                return 0;
            if (s[index] == '-')
            {
                positive = false;
                index += 1;
            }
            else if(s[index] == '+'){
                index++;
            }

            int start = -1;
            int end = -1;

            while (index < s.Length)
            {
                if (Char.IsDigit(s[index]))
                {

                    if (s[index] != '0' && start == -1)
                    {
                        start = index;


                    }

                    index++;



                }
                else
                {
                    end = index - 1;
                    break;
                }

            }
        
            if(start == -1)
                return 0;

            if(end == -1)
            {
                end = s.Length - 1;
            }
            //if it is greater than the max allowed return the max of either negative or positive
            if (end - start + 1 > max.Length)
            {
                if (!positive)
                {
                    return (-1 * int.Parse(max))-1;
                }

                return int.Parse(max);
            }

            string toReturn = "";
            if (end - start + 1 == max.Length)
            {

                bool valid = false;
                for (int x = start; x <= end; x++)
                {
                    if (valid == true)
                    {
                        toReturn += s[x];
                        continue;
                    }

                    if (s[x] > max[x - start])
                    {

                        if (!positive)
                        {
                            return (-1 * int.Parse(max))-1;
                        }

                        return int.Parse(max);
                    }
                    else if (s[x] == max[x - start])
                    {
                        toReturn += s[x];
                    }
                    else
                    {
                        valid = true;
                        toReturn += s[x];

                    }
                }


                return positive? int.Parse(toReturn): -int.Parse(toReturn);
            }
            else
            {
                for (int x = start; x <= end; x++)
                {
                    toReturn += s[x];
                }

                 return positive? int.Parse(toReturn): -int.Parse(toReturn);
            }






        
        
        
    }
}