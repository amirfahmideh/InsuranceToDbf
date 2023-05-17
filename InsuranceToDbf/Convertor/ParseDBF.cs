using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace InsuranceToDbf.Convertor
{
    internal class ParseDBF
    {
        public static bool IsNumber(string numberString)
        {
            char[] chArray = numberString.ToCharArray();
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            foreach (char ch in chArray)
            {
                if ((ch >= '0') && (ch <= '9'))
                {
                    num++;
                }
                else if (ch == '.')
                {
                    num2++;
                }
                else if (ch == ' ')
                {
                    num3++;
                }
                else
                {
                    return false;
                }
            }
            return ((num > 0) && (num2 < 2));
        }

        private static DateTime JulianToDateTime(long lJDN)
        {
            double num2 = Convert.ToDouble(lJDN) + 68569.0;
            double num3 = Math.Floor((double)((4.0 * num2) / 146097.0));
            double num4 = num2 - Math.Floor((double)(((146097.0 * num3) + 3.0) / 4.0));
            double num5 = Math.Floor((double)((4000.0 * (num4 + 1.0)) / 1461001.0));
            double num6 = (num4 - Math.Floor((double)((1461.0 * num5) / 4.0))) + 31.0;
            double num7 = Math.Floor((double)((80.0 * num6) / 2447.0));
            double num8 = num6 - Math.Floor((double)((2447.0 * num7) / 80.0));
            double num9 = Math.Floor((double)(num7 / 11.0));
            double num10 = (num7 + 2.0) - (12.0 * num9);
            double num11 = ((100.0 * (num3 - 49.0)) + num5) + num9;
            return new DateTime(Convert.ToInt32(num11), Convert.ToInt32(num10), Convert.ToInt32(num8));
        }

        public static DataTable ReadDBF(string dbfFile, bool autoAnalyse, bool cleanWhiteSpaces)
        {
            long ticks = DateTime.Now.Ticks;
            DataTable table = new DataTable();
            if (File.Exists(dbfFile))
            {
                BinaryReader reader2 = null;
                try
                {
                    string str;
                    reader2 = new BinaryReader(File.OpenRead(dbfFile));
                    GCHandle handle = GCHandle.Alloc(reader2.ReadBytes(Marshal.SizeOf(typeof(DBFHeader))), GCHandleType.Pinned);
                    DBFHeader header = (DBFHeader)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(DBFHeader));
                    handle.Free();
                    ArrayList list = new ArrayList();
                    while (13 != reader2.PeekChar())
                    {
                        handle = GCHandle.Alloc(reader2.ReadBytes(Marshal.SizeOf(typeof(FieldDescriptor))), GCHandleType.Pinned);
                        list.Add((FieldDescriptor)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(FieldDescriptor)));
                        handle.Free();
                    }
                    ((FileStream)reader2.BaseStream).Seek((long)(header.headerLen + 1), SeekOrigin.Begin);
                    BinaryReader reader = new BinaryReader(new MemoryStream(reader2.ReadBytes(header.recordLen)));
                    DataColumn column = null;
                    foreach (FieldDescriptor descriptor in list)
                    {
                        str = Encoding.ASCII.GetString(reader.ReadBytes(descriptor.fieldLen));
                        switch (descriptor.fieldType)
                        {
                            case 'C':
                                column = new DataColumn(descriptor.fieldName, typeof(string));
                                goto Label_027F;

                            case 'D':
                                column = new DataColumn(descriptor.fieldName, typeof(DateTime));
                                goto Label_027F;

                            case 'F':
                                column = new DataColumn(descriptor.fieldName, typeof(double));
                                goto Label_027F;

                            case 'L':
                                column = new DataColumn(descriptor.fieldName, typeof(bool));
                                goto Label_027F;

                            case 'N':
                                if (str.IndexOf(".") <= -1)
                                {
                                    break;
                                }
                                column = new DataColumn(descriptor.fieldName, typeof(decimal));
                                goto Label_027F;

                            case 'T':
                                column = new DataColumn(descriptor.fieldName, typeof(DateTime));
                                goto Label_027F;

                            default:
                                goto Label_027F;
                        }
                        column = new DataColumn(descriptor.fieldName, typeof(Int64));
                    Label_027F:
                        table.Columns.Add(column);
                    }
                    ((FileStream)reader2.BaseStream).Seek((long)header.headerLen, SeekOrigin.Begin);
                    for (int i = 0; i <= (header.numRecords - 1); i++)
                    {
                        reader = new BinaryReader(new MemoryStream(reader2.ReadBytes(header.recordLen)));
                        if (reader.ReadChar() != '*')
                        {
                            int num4 = 0;
                            DataRow row = table.NewRow();
                            foreach (FieldDescriptor descriptor in list)
                            {
                                switch (descriptor.fieldType)
                                {
                                    case 'C':
                                        {
                                            string str5 = DOSConvertor.MappAndReverse(Encoding.Default.GetString(reader.ReadBytes(descriptor.fieldLen)), autoAnalyse, true, cleanWhiteSpaces);
                                            row[num4] = str5.Trim();
                                            goto Label_05D5;
                                        }
                                    case 'D':
                                        {
                                            string numberString = Encoding.Default.GetString(reader.ReadBytes(4));
                                            string str3 = Encoding.Default.GetString(reader.ReadBytes(2));
                                            string str4 = Encoding.Default.GetString(reader.ReadBytes(2));
                                            row[num4] = DBNull.Value;
                                            try
                                            {
                                                if (((IsNumber(numberString) && IsNumber(str3)) && IsNumber(str4)) && (int.Parse(numberString) > 0x76c))
                                                {
                                                    row[num4] = new DateTime(int.Parse(numberString), int.Parse(str3), int.Parse(str4));
                                                }
                                            }
                                            catch
                                            {
                                            }
                                            goto Label_05D5;
                                        }
                                    case 'F':
                                        str = Encoding.ASCII.GetString(reader.ReadBytes(descriptor.fieldLen));
                                        if (!IsNumber(str))
                                        {
                                            goto Label_05BD;
                                        }
                                        row[num4] = double.Parse(str);
                                        goto Label_05D5;

                                    case 'L':
                                        if (0x59 != reader.ReadByte())
                                        {
                                            goto Label_0569;
                                        }
                                        row[num4] = true;
                                        goto Label_05D5;

                                    case 'N':
                                        str = Encoding.Default.GetString(reader.ReadBytes(descriptor.fieldLen));
                                        if (!IsNumber(str))
                                        {
                                            goto Label_03FA;
                                        }
                                        if (str.IndexOf(".") <= -1)
                                        {
                                            break;
                                        }
                                        row[num4] = decimal.Parse(str);
                                        goto Label_05D5;

                                    case 'T':
                                        {
                                            long lJDN = reader.ReadInt32();
                                            long num3 = reader.ReadInt32() * 0x2710L;
                                            row[num4] = JulianToDateTime(lJDN).AddTicks(num3);
                                            goto Label_05D5;
                                        }
                                    default:
                                        goto Label_05D5;
                                }
                                row[num4] = Int64.Parse(str);// int.Parse
                                goto Label_05D5;
                            Label_03FA:
                                row[num4] = 0;
                                goto Label_05D5;
                            Label_0569:
                                row[num4] = false;
                                goto Label_05D5;
                            Label_05BD:
                                row[num4] = 0f;
                            Label_05D5:
                                num4++;
                            }
                            reader.Close();
                            table.Rows.Add(row);
                        }
                    }
                }
                catch (Exception exception)
                {
                    Console.Write(exception);
                }
                finally
                {
                    if (null != reader2)
                    {
                        reader2.Close();
                    }
                }
                long num6 = DateTime.Now.Ticks - ticks;
            }
            return table;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct DBFHeader
        {
            public byte version;
            public byte updateYear;
            public byte updateMonth;
            public byte updateDay;
            public int numRecords;
            public short headerLen;
            public short recordLen;
            public short reserved1;
            public byte incompleteTrans;
            public byte encryptionFlag;
            public int reserved2;
            public long reserved3;
            public byte MDX;
            public byte language;
            public short reserved4;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct FieldDescriptor
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
            public string fieldName;
            public char fieldType;
            public int address;
            public byte fieldLen;
            public byte count;
            public short reserved1;
            public byte workArea;
            public short reserved2;
            public byte flag;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] reserved3;
            public byte indexFlag;
        }
    }
}

