namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    ///Provides public extension methods to convert and process strings.
    ///Methods are ToMd5Hash, ToBoolean, ToShort, ToInteger, ToLong, ToDateTime, CapitalizeFirstLetter,
    ///GetStringBetween, ConvertCyrillicToLatinLetters, ConvertLatinToCyrillicKeyboard, ToValidUsername, 
    ///ToValidLatinFileName, GetFirstCharacters, GetFileExtension,
    ///ToContentType, ToByteArray
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts the string to MD5 hash value.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>The hexadecimal hash value as string.</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// Checks whether the string is positive answer. Positive answers are true, ok, yes, 1, да.
        /// </summary>
        /// <param name="input">The string to be checked</param>
        /// <returns>True if the input is a positive answer, else returns false.</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts the string to short.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>The short value of the converted string.</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts the string to integer.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>The integer value of the  converted string.</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts the string to long.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>The long value of the  converted string.</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts the string to DateTime format.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>The DateTime value of the  converted string.</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Capitalizes the first letter of the string.
        /// </summary>
        /// <param name="input">The string to be capitalized.</param>
        /// <returns>The capitalized string. If string is null, returns null, if string is empty, returns empty.</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Returns the string that is contained between a start string and an end string, starting to search for the start string from a given posititon.
        /// </summary>
        /// <param name="input">The string in which the method searches.</param>
        /// <param name="startString">The starting string, from which to begin the result string.</param>
        /// <param name="endString">The ending string, before which the result string ends. </param>
        /// <param name="startFrom">Optional parameter. The index from which to search for the startString.</param>
        /// <returns>Returns the string between the startString and Endstring.</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Converts the string's Cyrillic letters to their phonetic Latin letters.
        /// </summary>
        /// <param name="input">The string to be converted to Latin letters.</param>
        /// <returns>The converted string with all Cyrillic letters converted to Latin letters.</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converts the string's Latin letters to their phonetic Cyrillic letters.
        /// </summary>
        /// <param name="input">The string to be converted to Cyrillic letters.</param>
        /// <returns>The converted string with all Latin letters converted to Cyrillic letters.</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Converts the string to a valid username, replacing any Cyrillic letters with their phonetic Latin letters.
        /// All characters that are not capital or small Latin or Cyrillic letters, numbers or "." will be removed.
        /// </summary>
        /// <param name="input">The string to be converted to username.</param>
        /// <returns>The string, converted to username.</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Converts the string to a valid latin file name, replacing any Cyrillic letters with their phonetic Latin letters.
        /// All characters that are not capital or small Latin or Cyrillic letters, numbers or "." will be removed.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>The string, converted to valid file name.</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Returns the first charachers of the string, with the specified length.
        /// </summary>
        /// <param name="input">The string to search in for characters.</param>
        /// <param name="charsCount">The number of characters to be extracted.</param>
        /// <returns>The first characters of the string with the specified length. If charsCount is bigger than the length of the string, 
        /// the whole string is returned.</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Returns the file extenstion of a given file name as string.
        /// </summary>
        /// <param name="fileName">The file name to get the file extension of.</param>
        /// <returns>The file extension in lower leters. If the file name is null or whitespaces only, or does not contain
        /// file extension, returns an empty string.</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Returns the content type of given file extension. 
        /// </summary>
        /// <param name="fileExtension">The file extension of which the respective content type is returned.</param>
        /// <returns>Returns the content type. If the input file extension is invalid or not supported, returns "application/octet-stream"</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts the string to an array of bytes.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>The array of bytes the string is converted to.</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
