using Material_System.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Material_System.Business
{
    public static class Extensions
    {
        private static Regex compiled = new Regex("\\s+", RegexOptions.Compiled);
        private static Regex ConvertToUnsign_rg = (Regex)null;
        public static string RemoveInvalidChars(this string filename)
        {
            return string.Concat(filename.Split(Path.GetInvalidFileNameChars()));
        }
        public static void ReloadEntity<TEntity>(this DAL.BaseContext context, TEntity entity) where TEntity : class
        {
            context.Entry(entity).Reload();
        }
        public static int ToInt(this object data)
        {
            if (data == null)
                return 0;
            int result;
            if (int.TryParse(data.ToString(), out result))
                return result;
            try
            {
                return Convert.ToInt32(data.ToDouble(0));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static int? ToIntOrNull(this object data)
        {
            if (data == null)
                return new int?();
            int result;
            return int.TryParse(data.ToString(), out result) ? new int?(result) : new int?();
        }

        public static double ToDouble(this object data)
        {
            double result;
            return data == null ? 0.0 : (double.TryParse(data.ToString(), out result) ? result : 0.0);
        }

        public static double ToDouble(this object data, int digits) => Math.Round(data.ToDouble(), digits);

        public static double? ToDoubleOrNull(this object data)
        {
            if (data == null)
                return new double?();
            double result;
            return double.TryParse(data.ToString(), out result) ? new double?(result) : new double?();
        }

        public static Decimal ToDecimal(this object data)
        {
            Decimal result;
            return data == null ? 0M : (Decimal.TryParse(data.ToString(), out result) ? result : 0M);
        }

        public static Decimal ToDecimal(this object data, int digits) => Math.Round(data.ToDecimal(), digits);

        public static Decimal? ToDecimalOrNull(this object data)
        {
            if (data == null)
                return new Decimal?();
            Decimal result;
            return Decimal.TryParse(data.ToString(), out result) ? new Decimal?(result) : new Decimal?();
        }

        public static Decimal? ToDecimalOrNull(this object data, int digits)
        {
            Decimal? decimalOrNull = data.ToDecimalOrNull();
            return !decimalOrNull.HasValue ? new Decimal?() : new Decimal?(Math.Round(decimalOrNull.Value, digits));
        }

        public static DateTime ToDate(this object data)
        {
            DateTime result;
            return data == null ? DateTime.MinValue : (DateTime.TryParse(data.ToString(), out result) ? result : DateTime.MinValue);
        }

        public static DateTime? ToDateOrNull(this object data)
        {
            if (data == null)
                return new DateTime?();
            DateTime result;
            return DateTime.TryParse(data.ToString(), out result) ? new DateTime?(result) : new DateTime?();
        }

        public static bool ToBool(this object data)
        {
            if (data == null)
                return false;
            bool? nullable = data.GetBool();
            bool result;
            return nullable.HasValue ? nullable.Value : bool.TryParse(data.ToString(), out result) & result;
        }

        private static bool? GetBool(this object data)
        {
            string lower = data.ToString().Trim().ToLower();
            if (lower == "0")
                return new bool?(false);
            if (lower == "1")
                return new bool?(true);
            if (lower == "Có")
                return new bool?(true);
            if (lower == "Không")
                return new bool?(false);
            if (lower == "yes")
                return new bool?(true);
            return lower == "no" ? new bool?(false) : new bool?();
        }

        public static bool? ToBoolOrNull(this object data)
        {
            if (data == null)
                return new bool?();
            bool? nullable = data.GetBool();
            if (nullable.HasValue)
                return new bool?(nullable.Value);
            bool result;
            return bool.TryParse(data.ToString(), out result) ? new bool?(result) : new bool?();
        }

        public static string ToString(this object data) => data == null ? string.Empty : data.ToString().Trim();

        public static string RemoveStringReader(string input)
        {
            StringBuilder stringBuilder = new StringBuilder(input.Length);
            using (StringReader stringReader = new StringReader(input))
            {
                for (int index = 0; index < input.Length; ++index)
                {
                    char c = (char)stringReader.Read();
                    if (!char.IsWhiteSpace(c))
                        stringBuilder.Append(c);
                }
            }
            return stringBuilder.ToString();
        }

        public static string RemoveLinqNativeCharIsWhitespace(this string input) => new string(((IEnumerable<char>)input.ToCharArray()).Where<char>((Func<char, bool>)(c => !char.IsWhiteSpace(c))).ToArray<char>());

        public static string RemoveLinq(this string input) => new string(((IEnumerable<char>)input.ToCharArray()).Where<char>((Func<char, bool>)(c => !char.IsWhiteSpace(c))).ToArray<char>());

        public static string RemoveRegex(this string input) => Regex.Replace(input, "\\s+", "");

        public static string RemoveRegexCompiled(this string input) => Extensions.compiled.Replace(input, "");

        public static string RemoveForLoop(this string input)
        {
            for (int index = input.Length - 1; index >= 0; --index)
            {
                if (char.IsWhiteSpace(input[index]))
                    input = input.Remove(index, 1);
            }
            return input;
        }

        public static string RemoveInPlaceCharArray(this string input)
        {
            int length1 = input.Length;
            char[] charArray = input.ToCharArray();
            int length2 = 0;
            for (int index = 0; index < length1; ++index)
            {
                char ch = charArray[index];
                switch (ch)
                {
                    case '\t':
                    case '\n':
                    case '\v':
                    case '\f':
                    case '\r':
                    case ' ':
                    case '\u0085':
                    case ' ':
                    case ' ':
                    case ' ':
                    case ' ':
                    case ' ':
                    case ' ':
                    case ' ':
                    case ' ':
                    case ' ':
                    case ' ':
                    case ' ':
                    case ' ':
                    case ' ':
                    case '\u2028':
                    case '\u2029':
                    case ' ':
                    case ' ':
                    case '　':
                        continue;
                    default:
                        charArray[length2++] = ch;
                        continue;
                }
            }
            return new string(charArray, 0, length2);
        }

        public static string RemoveUnicode(this string text)
        {
            string[] strArray1 = new string[67]
            {
        "á",
        "à",
        "ả",
        "ã",
        "ạ",
        "â",
        "ấ",
        "ầ",
        "ẩ",
        "ẫ",
        "ậ",
        "ă",
        "ắ",
        "ằ",
        "ẳ",
        "ẵ",
        "ặ",
        "đ",
        "é",
        "è",
        "ẻ",
        "ẽ",
        "ẹ",
        "ê",
        "ế",
        "ề",
        "ể",
        "ễ",
        "ệ",
        "í",
        "ì",
        "ỉ",
        "ĩ",
        "ị",
        "ó",
        "ò",
        "ỏ",
        "õ",
        "ọ",
        "ô",
        "ố",
        "ồ",
        "ổ",
        "ỗ",
        "ộ",
        "ơ",
        "ớ",
        "ờ",
        "ở",
        "ỡ",
        "ợ",
        "ú",
        "ù",
        "ủ",
        "ũ",
        "ụ",
        "ư",
        "ứ",
        "ừ",
        "ử",
        "ữ",
        "ự",
        "ý",
        "ỳ",
        "ỷ",
        "ỹ",
        "ỵ"
            };
            string[] strArray2 = new string[67]
            {
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "d",
        "e",
        "e",
        "e",
        "e",
        "e",
        "e",
        "e",
        "e",
        "e",
        "e",
        "e",
        "i",
        "i",
        "i",
        "i",
        "i",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "u",
        "u",
        "u",
        "u",
        "u",
        "u",
        "u",
        "u",
        "u",
        "u",
        "u",
        "y",
        "y",
        "y",
        "y",
        "y"
            };
            for (int index = 0; index < strArray1.Length; ++index)
            {
                if (!Extensions.IsEmpty(text))
                {
                    text = text.Replace(strArray1[index], strArray2[index]);
                    text = text.Replace(strArray1[index].ToUpper(), strArray2[index].ToUpper());
                }
            }
            return text;
        }

        public static string NonUnicode(this string text)
        {
            string[] strArray1 = new string[67]
            {
        "á",
        "à",
        "ả",
        "ã",
        "ạ",
        "â",
        "ấ",
        "ầ",
        "ẩ",
        "ẫ",
        "ậ",
        "ă",
        "ắ",
        "ằ",
        "ẳ",
        "ẵ",
        "ặ",
        "đ",
        "é",
        "è",
        "ẻ",
        "ẽ",
        "ẹ",
        "ê",
        "ế",
        "ề",
        "ể",
        "ễ",
        "ệ",
        "í",
        "ì",
        "ỉ",
        "ĩ",
        "ị",
        "ó",
        "ò",
        "ỏ",
        "õ",
        "ọ",
        "ô",
        "ố",
        "ồ",
        "ổ",
        "ỗ",
        "ộ",
        "ơ",
        "ớ",
        "ờ",
        "ở",
        "ỡ",
        "ợ",
        "ú",
        "ù",
        "ủ",
        "ũ",
        "ụ",
        "ư",
        "ứ",
        "ừ",
        "ử",
        "ữ",
        "ự",
        "ý",
        "ỳ",
        "ỷ",
        "ỹ",
        "ỵ"
            };
            string[] strArray2 = new string[67]
            {
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "d",
        "e",
        "e",
        "e",
        "e",
        "e",
        "e",
        "e",
        "e",
        "e",
        "e",
        "e",
        "i",
        "i",
        "i",
        "i",
        "i",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "u",
        "u",
        "u",
        "u",
        "u",
        "u",
        "u",
        "u",
        "u",
        "u",
        "u",
        "y",
        "y",
        "y",
        "y",
        "y"
            };
            for (int index = 0; index < strArray1.Length; ++index)
            {
                if (!Extensions.IsEmpty(text))
                {
                    text = text.Replace(strArray1[index], strArray2[index]);
                    text = text.Replace(strArray1[index].ToUpper(), strArray2[index].ToUpper());
                }
            }
            return text;
        }

        public static string NonUnicodeReplace(this string text)
        {
            string[] strArray1 = new string[67]
            {
        "á",
        "à",
        "ả",
        "ã",
        "ạ",
        "â",
        "ấ",
        "ầ",
        "ẩ",
        "ẫ",
        "ậ",
        "ă",
        "ắ",
        "ằ",
        "ẳ",
        "ẵ",
        "ặ",
        "đ",
        "é",
        "è",
        "ẻ",
        "ẽ",
        "ẹ",
        "ê",
        "ế",
        "ề",
        "ể",
        "ễ",
        "ệ",
        "í",
        "ì",
        "ỉ",
        "ĩ",
        "ị",
        "ó",
        "ò",
        "ỏ",
        "õ",
        "ọ",
        "ô",
        "ố",
        "ồ",
        "ổ",
        "ỗ",
        "ộ",
        "ơ",
        "ớ",
        "ờ",
        "ở",
        "ỡ",
        "ợ",
        "ú",
        "ù",
        "ủ",
        "ũ",
        "ụ",
        "ư",
        "ứ",
        "ừ",
        "ử",
        "ữ",
        "ự",
        "ý",
        "ỳ",
        "ỷ",
        "ỹ",
        "ỵ"
            };
            string[] strArray2 = new string[67]
            {
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "a",
        "d",
        "e",
        "e",
        "e",
        "e",
        "e",
        "e",
        "e",
        "e",
        "e",
        "e",
        "e",
        "i",
        "i",
        "i",
        "i",
        "i",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "o",
        "u",
        "u",
        "u",
        "u",
        "u",
        "u",
        "u",
        "u",
        "u",
        "u",
        "u",
        "y",
        "y",
        "y",
        "y",
        "y"
            };
            for (int index = 0; index < strArray1.Length; ++index)
            {
                if (!Extensions.IsEmpty(text))
                {
                    text = text.Replace(strArray1[index], strArray2[index]);
                    text = text.Replace(strArray1[index].ToUpper(), strArray2[index].ToUpper());
                }
            }
            return text.Replace(" ", "-");
        }

        public static string ConvertToUnsign(this string strInput)
        {
            if (Extensions.ConvertToUnsign_rg == null)
                Extensions.ConvertToUnsign_rg = new Regex("p{IsCombiningDiacriticalMarks}+");
            string input = strInput.Normalize(NormalizationForm.FormD);
            return Extensions.ConvertToUnsign_rg.Replace(input, string.Empty).Replace("đ", "d").Replace("Đ", "D").ToLower();
        }

        public static string ToDateTimeString(this DateTime dateTime, bool isRemoveSecond = false) => isRemoveSecond ? dateTime.ToString("yyyy-MM-dd HH:mm") : dateTime.ToString("yyyy-MM-dd HH:mm:ss");

        public static string ToDateTimeString(this DateTime? dateTime, bool isRemoveSecond = false) => !dateTime.HasValue ? string.Empty : dateTime.Value.ToDateTimeString(isRemoveSecond);

        public static string ToDateString(this DateTime dateTime) => dateTime.ToString("yyyy-MM-dd");

        public static string ToDateString(this DateTime? dateTime) => !dateTime.HasValue ? string.Empty : dateTime.Value.ToDateString();

        public static string ToTimeString(this DateTime dateTime) => dateTime.ToString("HH:mm:ss");

        public static string ToTimeString(this DateTime? dateTime) => !dateTime.HasValue ? string.Empty : dateTime.Value.ToTimeString();

        public static string ToMillisecondString(this DateTime dateTime) => dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

        public static string ToMillisecondString(this DateTime? dateTime) => !dateTime.HasValue ? string.Empty : dateTime.Value.ToMillisecondString();

        public static string Description(this bool value) => value ? "Có" : "Không";

        public static string Description(this bool? value) => !value.HasValue ? "" : value.Value.Description();

        public static string Format(this int number, string defaultValue = "") => number == 0 ? defaultValue : number.ToString();

        public static string Format(this int? number, string defaultValue = "") => number.SafeValue<int>().Format(defaultValue);

        public static string Format(this Decimal number, string defaultValue = "") => number == 0M ? defaultValue : string.Format("{0:0.##}", (object)number);

        public static string Format(this Decimal? number, string defaultValue = "") => number.SafeValue<Decimal>().Format(defaultValue);

        public static string Format(this double number, string defaultValue = "") => number == 0.0 ? defaultValue : string.Format("{0:0.##}", (object)number);

        public static string Format(this double? number, string defaultValue = "") => number.SafeValue<double>().Format(defaultValue);

        public static string FormatRmb(this Decimal number) => number == 0M ? "0 vnđ" : string.Format("{0:0.##} vnđ", (object)number);

        public static string FormatRmb(this Decimal? number) => number.SafeValue<Decimal>().FormatRmb();

        public static string FormatPercent(this Decimal number) => number == 0M ? string.Empty : string.Format("{0:0.##}%", (object)number);

        public static string FormatPercent(this Decimal? number) => number.SafeValue<Decimal>().FormatPercent();

        public static string FormatPercent(this double number) => number == 0.0 ? string.Empty : string.Format("{0:0.##}%", (object)number);

        public static string FormatPercent(this double? number) => number.SafeValue<double>().FormatPercent();

        public static T SafeValue<T>(this T? value) where T : struct => value ?? default(T);

        public static bool ContainsEx(this string obj, string value) => !string.IsNullOrEmpty(obj) && obj.Contains(value);

        public static bool Like(this string obj, string value) => !string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(obj) && value.IndexOf(obj) != -1;

        public static void CheckNull(this object obj, string parameterName)
        {
            if (obj == null)
                throw new ArgumentNullException(parameterName);
        }

        public static bool IsEmpty(this string value) => string.IsNullOrWhiteSpace(value);

        public static bool IsEmpty(this Guid? value) => !value.HasValue || value.Value.IsEmpty();

        public static bool IsEmpty(this Guid value) => value == Guid.Empty;

        public static bool IsEmpty(this object value) => value == null || string.IsNullOrEmpty(value.ToString());
        public static IEnumerable<string> Validate(this QuotaEntity entity)
        {
            if (entity == null) { yield return "Null!!"; }
            if (string.IsNullOrEmpty(entity.Part_No))
            {
                yield return "Vui lòng nhập Part!!";
            }
            if (string.IsNullOrEmpty(entity.Pitch))
            {
                yield return "Vui lòng nhập Pitch!!";
            }
            if (string.IsNullOrEmpty(entity.R_Max))
            {
                yield return "Vui lòng nhập R Max!!";
            }
            if (string.IsNullOrEmpty(entity.R_Min))
            {
                yield return "Vui lòng nhập R Min!!";
            }
            int pitch;
            if (!int.TryParse(entity.Pitch, out pitch))
            {
                yield return "Pitch không hợp lệ!!";
            }
            int r_max;
            if (!int.TryParse(entity.R_Max, out r_max))
            {
                yield return "R Max không hợp lệ!!";
            }
            int r_min;
            if (!int.TryParse(entity.R_Min, out r_min))
            {
                yield return "R Min không hợp lệ!!";
            }
            if (r_max < r_min)
            {
                yield return "R Max phải lớn hơn R Min!!";
            }
        }
        public static string Right(this string s, int length)
        {
            length = Math.Max(length, 0);

            if (s.Length > length)
            {
                return s.Substring(s.Length - length, length);
            }
            else
            {
                return s;
            }
        }
        /// <summary>
        /// Return the remainder of a string s after a separator c.
        /// </summary>
        /// <param name="s">String to search in.</param>
        /// <param name="c">Separator</param>
        /// <returns>The right part of the string after the character c, or the string itself when c isn't found.</returns>
        public static string RightOf(this string s, char c)
        {
            int ndx = s.IndexOf(c);
            if (ndx == -1)
                return s;
            return s.Substring(ndx + 1);
        }
        /// <summary>
        /// Returns the first few characters of the string with a length
        /// specified by the given parameter. If the string's length is less than the 
        /// given length the complete string is returned. If length is zero or 
        /// less an empty string is returned
        /// </summary>
        /// <param name="s">the string to process</param>
        /// <param name="length">Number of characters to return</param>
        /// <returns></returns>
        public static string Left(this string s, int length)
        {
            length = Math.Max(length, 0);

            if (s.Length > length)
            {
                return s.Substring(0, length);
            }
            else
            {
                return s;
            }
        }
        /// <summary>
        /// Returns the first part of the strings, up until the character c. If c is not found in the
        /// string the whole string is returned.
        /// </summary>
        /// <param name="s">String to truncate</param>
        /// <param name="c">Character to stop at.</param>
        /// <returns>Truncated string</returns>
        public static string LeftOf(this string s, char c)
        {
            int ndx = s.IndexOf(c);
            if (ndx >= 0)
            {
                return s.Substring(0, ndx);
            }

            return s;
        }
        public static string Escape(this string str)
        {
            //return str.Replace("\\", "\\\\").Replace(",", "\\,");
            return "\"" + str.Replace("\"", "\"\"") + "\"";
        }
        public static string Unescape(this string str)
        {
            return str.Replace("\\\\", "\\").Replace("\\,", ",");
        }
        public static void ToCSV(this DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);
            //headers    
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }
    }
}
