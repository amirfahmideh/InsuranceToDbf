using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceToDbf.Convertor
{
    internal class ConvertWindowsPersianToDos
    {
        public Dictionary<byte, byte> CharachtersMapper_Group1 = new Dictionary<byte, byte>
        {
        {48 , 128}, // 0
        {49 , 129}, // 1
        {50 , 130}, // 2
        {51 , 131}, // 3
        {52 , 132}, // 4
        {53 , 133}, // 5
        {54 , 134}, // 6
        {55 , 135}, // 7
        {56 , 136}, // 8
        {57 , 137}, // 9
        {161, 138}, // ،
        {191, 140}, // ؟
        {193, 143}, //ء 
        {194, 141}, // آ
        {195, 144}, // أ
        {196, 248}, //ؤ  
        {197, 144}, //إ
        {200, 146}, //ب 
        {201, 249}, //ة
        {202, 150}, //ت
        {203, 152}, //ث 
        {204, 154}, //ﺝ
        {205, 158}, //ﺡ
        {206, 160}, //ﺥ
        {207, 162}, //د
        {208, 163}, //ذ
        {209, 164}, //ر
        {210, 165},//ز
        {211, 167},//س
        {212, 169},//ش
        {213, 171}, //ص
        {214, 173}, //ض
        {216, 175}, //ط
        {217, 224}, //ظ
        {218, 225}, //ع
        {219, 229}, //غ
        {220, 139}, //-
        {221, 233},//ف
        {222, 235},//ق
        {223, 237},//ك
        {225, 241},//ل
        {227, 244},//م
        {228, 246},//ن
        {229, 249},//ه
        {230, 248},//و
        {236, 253},//ى
        {237, 253},//ي
        {129, 148},//پ
        {141, 156},//چ
        {142, 166},//ژ
        {152, 237},//ک
        {144, 239},//گ


           };
        public Dictionary<byte, byte> CharachtersMapper_Group2 = new Dictionary<byte, byte>
        {
       {48,128},//
       {49,129},//
       {50,130},
       {51,131},//
       {52,132},//
       {53,133},
       {54,134},//
       {55,135},//
       {56,136},
       {57,137},//
       {161,138},//،
       {191,140},//?
       {193,143},//ء
       {194,141},//آ
       {195,144},//أ
       {196,248},//ؤ
       {197,144},//إ
       {198,254},//ئ
       {199,144},//ا
       {200,147},//ب
       {201,251},//ة
       {202,151},//ت
       {203,153},//ث
       {204,155},//ج
       {205,159},//ح
       {206,161},//خ
       {207,162},//د
       {208,163},//ذ
       {209,164},//ر
       {210,165},//ز
       {211,168},//س
       {212,170},//ش
       {213,172},//ص
       {214,174},//ض
       {216,175},//ط
       {217,224},//ظ
       {218,228},//ع
       {219,232},//غ
       {220,139},//-
       {221,234},//ف
       {222,236},//ق
       {223,238},//ك
       {225,243},//ل
       {227,245},//م
       {228,247},//ن
       {229,251},//ه
       {230,248},//و
       {236,254},//ی
       {237,254},//ي
       {129,149},//پ
       {141 ,157},//چ
       {142,166},//ژ
       {152,238},//ک
       {144,240},//گ
       
       
        };

        public Dictionary<byte, byte> CharachtersMapper_Group3 = new Dictionary<byte, byte>
        {

        {48 , 128}, // 0
        {49 , 129}, // 1
        {50 , 130}, // 2
        {51 , 131}, // 3
        {52 , 132}, // 4
        {53 , 133}, // 5
        {54 , 134}, // 6
        {55 , 135}, // 7
        {56 , 136}, // 8
        {57 , 137}, // 9
        {161, 138}, // ،
        {191, 140}, // ؟
        {193, 143}, //
        {194, 141}, //
        {195, 145}, //
        {196, 248}, //
        {197, 145}, // 
        {198, 252}, //
        {199, 145}, // 
        {200, 146}, // 
        {201, 249}, //
        {202, 150}, //
        {203, 152}, // 
        {204, 154}, //
        {205, 158}, // 
        {206, 160}, //
        {207, 162}, //
        {208, 163}, // 
        {209, 164}, //
        {210, 165}, //
        {211, 167}, // 
        {212, 169}, // 
        {213, 171}, //
        {214, 173}, // 
        {216, 175}, // 
        {217, 224}, //
        {218, 226}, // 
        {219, 230}, // 
        {220, 139}, //
        {221, 233}, // 
        {222, 235}, //
        {223, 237}, //
        {225, 241}, // 
        {227, 244}, //
        {228, 246}, //
        {229, 249}, //   
        {230, 248}, // 
        {236, 252}, //
        {237, 252}, // 
        {129, 148}, // 
        {141, 156}, //
        {142, 166}, // 
        {152, 237}, // 
        {144, 239}//
};
        public Dictionary<byte, byte> CharachtersMapper_Group4 = new Dictionary<byte, byte>
        {
            {48 , 128}, // 0
            {49 , 129}, // 1
            {50 , 130}, // 2
            {51 , 131}, // 3
            {52 , 132}, // 4
            {53 , 133}, // 5
            {54 , 134}, // 6
            {55 , 135}, // 7
            {56 , 136}, // 8
            {57 , 137}, // 9
            {161, 138}, // ،
            {191, 140}, // ؟
            {193,143}, //
            {194,141}, //
            {195,145}, //
            {196,248}, // 
            {197,145}, // 
            //{198,254}, //
            {198,142},
            {199,145}, // 
            {200,147}, // 
            {201,250}, //
            {202,151}, //
            {203,153}, //
            {204,155}, //
            {205,159}, //
            {206,161}, //
            {207,162}, //
            {208,163}, //
            {209,164}, //
            {210,165}, //
            {211,168}, // 
            {212,170}, //
            {213,172}, //
            {214,174}, //
            {216,175}, // 
            {217,224}, //
            {218,227}, //
            {219,231}, //
            {220,139}, //
            {221,234}, //
            {222,236}, //
            {223,238}, //
            {225,243}, //
            {227,245}, // 
            {228,247}, //
            {229,250}, //
            {230,248}, //
            {236,254}, //
            {237,254}, // 
            {129,149}, //
            {141,157}, //
            {142,166}, // 
            {152,238}, // 
            {144,240}, //
};

        public bool is_Lattin_Letter(byte c)
        {
            if (c < 128 && c > 31)
            {
                return true;
            }
            return false;

        }

        public byte get_Lattin_Letter(byte c)
        {
            if ("0123456789".IndexOf((char)c) >= 0)
                return (byte)(c + 80);
            return get_FarsiExceptions(c);
        }

        private byte get_FarsiExceptions(byte c)
        {
            switch (c)
            {
                case (byte)'(': return (byte)')';
                case (byte)'{': return (byte)'}';
                case (byte)'[': return (byte)']';
                case (byte)')': return (byte)'(';
                case (byte)'}': return (byte)'{';
                case (byte)']': return (byte)'[';
                default: return (byte)c;

            }

        }


        public bool is_Final_Letter(byte c)
        {
            string s = "ءآأؤإادذرزژو";

            if (s.ToString().IndexOf((char)c) >= 0)
            {
                return true;

            }
            return false;
        }
        public bool IS_White_Letter(byte c)
        {
            if (c == 8 || c == 09 || c == 10 || c == 13 || c == 27 || c == 32 || c == 0)
            {
                return true;
            }
            return false;
        }
        public bool Char_Cond(byte c)
        {
            return IS_White_Letter(c)
                || is_Lattin_Letter(c)
                || c == 191;
        }

        public string Win2Dos(string str)
        {
            return Encoding.GetEncoding("windows-1256").GetString(get_Unicode_To_IranSystem(str));
        }

        public byte[] get_Unicode_To_IranSystem(string Unicode_Text)
        {

            // " رشته ای که فارسی است را دو کاراکتر فاصله به ابتدا و انتهایآن اضافه می کنیم

            string unicodeString = " " + Unicode_Text + " ";
            //ایجاد دو انکدینگ متفاوت
            Encoding ascii = //Encoding.ASCII;
                Encoding.GetEncoding("windows-1256");

            Encoding unicode = Encoding.Unicode;

            // تبدیل رشته به بایت
            byte[] unicodeBytes = unicode.GetBytes(unicodeString);

            // تبدیل بایتها از یک انکدینگ به دیگری
            byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);

            // Convert the new byte[] into a char[] and then into a string.
            char[] asciiChars = new char[ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
            ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
            string asciiString = new string(asciiChars);
            byte[] b22 = Encoding.GetEncoding("windows-1256").GetBytes(asciiChars);


            int limit = b22.Length;

            byte pre = 0, cur = 0;


            List<byte> IS_Result = new List<byte>();
            for (int i = 0; i < limit; i++)
            {

                if (is_Lattin_Letter(b22[i]))
                {
                    cur = get_Lattin_Letter(b22[i]);

                    IS_Result.Add(cur);


                    pre = cur;
                }
                else if (i != 0 && i != b22.Length - 1)
                {
                    cur = get_Unicode_To_IranSystem_Char(b22[i - 1], b22[i], b22[i + 1]);

                    if (cur == 145) // برای بررسی استثنای لا
                    {
                        if (pre == 243)
                        {
                            IS_Result.RemoveAt(IS_Result.Count - 1);
                            IS_Result.Add(242);
                        }
                        else
                        {
                            IS_Result.Add(cur);
                        }
                    }
                    else
                    {
                        IS_Result.Add(cur);
                    }



                    pre = cur;
                }

            }

            if (IS_Result.Count <= 2)
                return IS_Result.ToArray().Reverse().ToArray();

            IS_Result.RemoveAt(IS_Result.Count - 1);
            IS_Result.RemoveAt(0);
            if (ParseDBF.IsNumber(Unicode_Text))
                return IS_Result.ToArray();

            return IS_Result.ToArray().Reverse().ToArray();
        }

        public byte get_Unicode_To_IranSystem_Char(byte PreviousChar, byte CurrentChar, byte NextChar)
        {

            bool PFlag = Char_Cond(PreviousChar) || is_Final_Letter(PreviousChar);
            bool NFlag = Char_Cond(NextChar);
            if (PFlag && NFlag) return UCTOIS_Group_1(CurrentChar);
            else if (PFlag) return UCTOIS_Group_2(CurrentChar);
            else if (NFlag) return UCTOIS_Group_3(CurrentChar);

            return UCTOIS_Group_4(CurrentChar);

        }

        private byte UCTOIS_Group_4(byte CurrentChar)
        {

            if (CharachtersMapper_Group4.ContainsKey(CurrentChar))
            {
                return (byte)CharachtersMapper_Group4[CurrentChar];
            }
            return (byte)CurrentChar;
        }

        private byte UCTOIS_Group_3(byte CurrentChar)
        {
            if (CharachtersMapper_Group3.ContainsKey(CurrentChar))
            {
                return (byte)CharachtersMapper_Group3[CurrentChar];
            }
            return (byte)CurrentChar;
        }

        private byte UCTOIS_Group_2(byte CurrentChar)
        {
            if (CharachtersMapper_Group2.ContainsKey(CurrentChar))
            {
                return (byte)CharachtersMapper_Group2[CurrentChar];
            }
            return (byte)CurrentChar;
        }
        private byte UCTOIS_Group_1(byte CurrentChar)
        {
            if (CharachtersMapper_Group1.ContainsKey(CurrentChar))
            {
                return (byte)CharachtersMapper_Group1[CurrentChar];
            }
            return (byte)CurrentChar;
        }

    }
}
