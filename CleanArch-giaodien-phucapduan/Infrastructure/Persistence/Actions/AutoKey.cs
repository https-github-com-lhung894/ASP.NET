namespace Infrastructure.Persistence.Actions
{
    public class AutoKey
    {
        public static string InCreasedByOne(string input)
        {
            string prefix = input.Substring(0, 2);
            string text = input.Substring(2);
            int number = int.Parse(text) + 1;
            int t = number;
            int nod = 0;
            for(int i = 0; t != 0; i++)
            {
                t /= 10;
                nod = i;
            }
            string key = prefix;
            for (int i = 5 - (nod + 1); i > 0; i--)
            {
                key += "0";
            }
            key = key + number;

            return key;
        }

        public static string AutoNumber(string input)
        {
            int number = int.Parse(input);
            number += 1;
            return "" + number;
        }
    }
}
