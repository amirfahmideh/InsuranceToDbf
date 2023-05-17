using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceToDbf.Convertor
{
    internal class DOSConvertor
    {
        private static KeyValuePair<byte, string>[] bytes;

        public static string AutoMapping(string input)
        {
            return MappAndReverse(input, true, true, true);
        }

        private static void init()
        {
            int num = 0x80;
            int num2 = 0;
            bytes = new KeyValuePair<byte, string>[80];
            for (int i = 0; i < 10; i++)
            {
                bytes[i] = new KeyValuePair<byte, string>((byte)(num + i), i.ToString());
            }
            num2 = 0x8a;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, ".");
            num2 = 0x8b;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "-");
            num2 = 140;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "؟");
            num2 = 0x8d;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "آ");
            num2 = 0x8e;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ئ");
            num2 = 0x8f;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ء");
            num2 = 0x90;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ا");
            num2 = 0x91;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ا");
            num2 = 0x92;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, " ب");
            num2 = 0x93;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ب");
            num2 = 0x94;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, " پ");
            num2 = 0x95;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "پ");
            num2 = 150;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, " ت");
            num2 = 0x97;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ت");
            num2 = 0x98;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, " ث");
            num2 = 0x99;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ث");
            num2 = 0x9a;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, " ج");
            num2 = 0x9b;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ج");
            num2 = 0x9c;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, " چ");
            num2 = 0x9d;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "چ");
            num2 = 0x9e;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, " ح");
            num2 = 0x9f;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ح");
            num2 = 160;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, " خ");
            num2 = 0xa1;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "خ");
            num2 = 0xa2;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "د");
            num2 = 0xa3;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ذ");
            num2 = 0xa4;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ر");
            num2 = 0xa5;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ز");
            num2 = 0xa6;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ژ");
            num2 = 0xa7;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, " س");
            num2 = 0xa8;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "س");
            num2 = 0xa9;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, " ش");
            num2 = 170;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ش");
            num2 = 0xab;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, " ص");
            num2 = 0xac;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ص");
            num2 = 0xad;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, " ض");
            num2 = 0xae;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ض");
            num2 = 0xaf;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ط");
            num += 0x30;
            num2 = 0xe0;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ظ");
            num2 = 0xe1;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, " ع");
            num2 = 0xe2;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ع");
            num2 = 0xe3;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ع");
            num2 = 0xe4;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ع");
            num2 = 0xe5;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, " غ");
            num2 = 230;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "غ");
            num2 = 0xe7;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "غ");
            num2 = 0xe8;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "غ");
            num2 = 0xe9;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, " ف");
            num2 = 0xea;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ف");
            num2 = 0xeb;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, " ق");
            num2 = 0xec;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ق");
            num2 = 0xed;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, " ک");
            num2 = 0xee;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ک");
            num2 = 0xef;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, " گ");
            num2 = 240;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "گ");
            num2 = 0xf1;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, " ل");
            num2 = 0xf2;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ال");
            num2 = 0xf3;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ل");
            num2 = 0xf4;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, " م");
            num2 = 0xf5;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "م");
            num2 = 0xf6;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, " ن");
            num2 = 0xf7;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ن");
            num2 = 0xf8;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "و");
            num2 = 0xf9;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, " ه");
            num2 = 250;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ه");
            num2 = 0xfb;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ه");
            num2 = 0xfc;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, " ی");
            num2 = 0xfd;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ی");
            num2 = 0xfe;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ی");
            num2 = 0xff;
            bytes[num2 - num] = new KeyValuePair<byte, string>((byte)num2, "ے");
        }

        private static bool IsInRange(byte b)
        {
            return ((b >= 0x80) && ((b <= 0xaf) || (b >= 0xe0)));
        }

        public static string Mapp(string input)
        {
            if (DOSConvertor.bytes == null)
            {
                init();
            }
            string str = "";
            byte[] bytes = Encoding.Default.GetBytes(input);
            foreach (byte num in bytes)
            {
                bool flag = false;
                if (IsInRange(num))
                {
                    foreach (KeyValuePair<byte, string> pair in DOSConvertor.bytes)
                    {
                        if (pair.Key == num)
                        {
                            str = str + pair.Value;
                            flag = true;
                            break;
                        }
                    }
                }
                if (!flag)
                {
                    str = str + ((char)num);
                }
            }
            return str;
        }

        public static string MappAndReverse(string input, bool autoAnalyse, bool doReverse, bool cleanWhiteSpaces)
        {
            if (input == null)
            {
                return "";
            }
            if (cleanWhiteSpaces)
            {
                if ((input == " ") || (input == "\0"))
                {
                    return "";
                }
                input = input.Replace("  ", "").Replace("\0", "");
            }
            if (autoAnalyse && !NeedMapping(input))
            {
                return input;
            }
            input = Mapp(input);
            if (input == null)
            {
                return "";
            }
            if (ParseDBF.IsNumber(input))
                return input;

            if (!doReverse)
            {
                return input;
            }
            string str = "";
            for (int i = input.Length - 1; i >= 0; i--)
            {
                str = str + input[i];
            }
            return str;
        }

        private static bool NeedMapping(string input)
        {
            byte[] bytes = Encoding.Default.GetBytes(input);
            foreach (byte num in bytes)
            {
                if (IsInRange(num))
                {
                    return true;
                }
            }
            return false;
        }
    }
}