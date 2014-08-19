namespace Phonebook
{
    using System.Text;

    public class PhonebookSanitizer : IPhoneNumberSanitizer
    {
        private const string CODE = "+359";

        public string Sanitize(string num)
        {
            StringBuilder parsedNumber = new StringBuilder();
            parsedNumber.Clear();
            foreach (char ch in num)
            {
                if (char.IsDigit(ch) || (ch == '+'))
                {
                    parsedNumber.Append(ch);
                }
            }

            if (parsedNumber.Length >= 2 && parsedNumber[0] == '0' && parsedNumber[1] == '0')
            {
                parsedNumber.Remove(0, 1);
                parsedNumber[0] = '+';
            }

            while (parsedNumber.Length > 0 && parsedNumber[0] == '0')
            {
                parsedNumber.Remove(0, 1);
            }

            if (parsedNumber.Length > 0 && parsedNumber[0] != '+')
            {
                parsedNumber.Insert(0, CODE);
            }

            parsedNumber.Clear();

            foreach (char ch in num)
            {
                if (char.IsDigit(ch) || (ch == '+'))
                {
                    parsedNumber.Append(ch);
                }
            }

            if (parsedNumber.Length >= 2 && parsedNumber[0] == '0' && parsedNumber[1] == '0')
            {
                parsedNumber.Remove(0, 1);
                parsedNumber[0] = '+';
            }

            while (parsedNumber.Length > 0 && parsedNumber[0] == '0')
            {
                parsedNumber.Remove(0, 1);
            }

            if (parsedNumber.Length > 0 && parsedNumber[0] != '+')
            {
                parsedNumber.Insert(0, CODE);
            }

            parsedNumber.Clear();

            foreach (char ch in num)
            {
                if (char.IsDigit(ch) || (ch == '+'))
                {
                    parsedNumber.Append(ch);
                }
            }

            if (parsedNumber.Length >= 2 && parsedNumber[0] == '0' && parsedNumber[1] == '0')
            {
                parsedNumber.Remove(0, 1);
                parsedNumber[0] = '+';
            }

            while (parsedNumber.Length > 0 && parsedNumber[0] == '0')
            {
                parsedNumber.Remove(0, 1);
            }

            if (parsedNumber.Length > 0 && parsedNumber[0] != '+')
            {
                parsedNumber.Insert(0, CODE);
            }

            return parsedNumber.ToString();
        }
    }
}