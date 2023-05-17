using System.Text;
using DotNetDBF;
using InsuranceToDbf.Lib;

namespace InsuranceToDbf.Export;
public static class ExportToDbf
{
    /// <summary>
    /// اماده سازی خروجی dbf بصورت MemoryStream برای ذخیره  بر روی کلاینت ها
    /// </summary>
    /// <param name="workOffice">اطلاعات کارگاه</param>
    /// <param name="personnel">اطلاعات کارکنان</param>
    /// <param name="workOfficeStream">خروجی اطلاعات کارگاه بصورت stream</param>
    /// <param name="personnelStream">خروجی اطلاعات کارکنان بصورت stream</param>
    public static void Export(SalaryInsuranceWorkOffice workOffice, List<SalaryInsuranceItem> personnel, out MemoryStream workOfficeStream, out MemoryStream personnelStream)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        workOfficeStream = new MemoryStream();
        ExportDSKKAR(workOfficeStream, workOffice.ToDbfFormat());
        workOfficeStream.Position = 0;

        personnelStream = new MemoryStream();
        ExportDSKWOR(personnelStream, personnel.Select(p => p.ToDbfFormat()).ToList());
        personnelStream.Position = 0;
    }

    /// <summary>
    /// خروجی اطلاعات کارگاه
    /// </summary>
    /// <param name="ms"></param>
    /// <param name="values"></param>
    private static void ExportDSKKAR(MemoryStream ms, object[] values)
    {
        try
        {
            using (var writer = new DBFWriter())
            {
                writer.Fields = new[] { new DBFField("DSK_ID", NativeDbType.Char, 10),
                                            new DBFField("DSK_NAME", NativeDbType.Char, 30),
                                            new DBFField("DSK_FARM", NativeDbType.Char, 30),
                                            new DBFField("DSK_ADRS", NativeDbType.Char, 40),
                                            new DBFField("DSK_KIND", NativeDbType.Numeric, 1),
                                            new DBFField("DSK_YY", NativeDbType.Numeric, 2),
                                            new DBFField("DSK_MM", NativeDbType.Numeric, 2),
                                            new DBFField("DSK_LISTNO", NativeDbType.Char, 12),
                                            new DBFField("DSK_DISC", NativeDbType.Char, 30),
                                            new DBFField("DSK_NUM", NativeDbType.Numeric, 5),
                                            new DBFField("DSK_TDD", NativeDbType.Numeric, 6),
                                            new DBFField("DSK_TROOZ", NativeDbType.Numeric, 12),
                                            new DBFField("DSK_TMAH", NativeDbType.Numeric, 12),
                                            new DBFField("DSK_TMAZ", NativeDbType.Numeric, 12),
                                            new DBFField("DSK_TMASH", NativeDbType.Numeric, 12),
                                            new DBFField("DSK_TTOTL", NativeDbType.Numeric, 12),
                                            new DBFField("DSK_TBIME", NativeDbType.Numeric, 12),
                                            new DBFField("DSK_TKOSO", NativeDbType.Numeric, 12),
                                            new DBFField("DSK_BIC", NativeDbType.Numeric, 12),
                                            new DBFField("DSK_RATE", NativeDbType.Numeric, 5),
                                            new DBFField("DSK_PRATE", NativeDbType.Numeric, 2),
                                            new DBFField("DSK_BIMH", NativeDbType.Numeric, 12),
                                            new DBFField("MON_PYM", NativeDbType.Char, 3),
                    };
                writer.AddRecord(values);
                writer.Write(ms);
            }
        }
        catch (Exception e)
        {
            Console.Write(e.Message);
        }
    }

    /// <summary>
    /// خروجی لیست بیمه شدگان
    /// </summary>
    /// <param name="ms"></param>
    /// <param name="valuesRow"></param>
    private static void ExportDSKWOR(MemoryStream ms, List<object[]> valuesRow)
    {
        try
        {
            using (var writer = new DBFWriter())
            {
                writer.Fields = new[] {new DBFField("DSW_ID", NativeDbType.Char, 10),
                                            new DBFField("DSW_YY", NativeDbType.Numeric, 2),
                                            new DBFField("DSW_MM", NativeDbType.Numeric, 2),
                                            new DBFField("DSW_LISTNO", NativeDbType.Char, 12),
                                            new DBFField("DSW_ID1", NativeDbType.Char, 8),
                                            new DBFField("DSW_FNAME", NativeDbType.Char, 50),
                                            new DBFField("DSW_LNAME", NativeDbType.Char, 50),
                                            new DBFField("DSW_DNAME", NativeDbType.Char, 50),
                                            new DBFField("DSW_IDNO", NativeDbType.Char, 15),
                                            new DBFField("DSW_IDPLC", NativeDbType.Char, 30),
                                            new DBFField("DSW_IDATE", NativeDbType.Char, 8),
                                            new DBFField("DSW_BDATE", NativeDbType.Char, 8),
                                            new DBFField("DSW_SEX", NativeDbType.Char, 3),
                                            new DBFField("DSW_NAT", NativeDbType.Char, 10),
                                            new DBFField("DSW_OCP", NativeDbType.Char, 50),
                                            new DBFField("DSW_SDATE", NativeDbType.Char, 8),
                                            new DBFField("DSW_EDATE", NativeDbType.Char, 8),
                                            new DBFField("DSW_DD", NativeDbType.Numeric, 2),
                                            new DBFField("DSW_ROOZ", NativeDbType.Numeric, 12),
                                            new DBFField("DSW_MAH", NativeDbType.Numeric, 12),
                                            new DBFField("DSW_MAZ", NativeDbType.Numeric, 12),
                                            new DBFField("DSW_MASH", NativeDbType.Numeric, 12),
                                            new DBFField("DSW_TOTL", NativeDbType.Numeric, 12),
                                            new DBFField("DSW_BIME", NativeDbType.Numeric, 12),
                                            new DBFField("DSW_PRATE", NativeDbType.Numeric, 2),
                                            new DBFField("DSW_JOB", NativeDbType.Char, 6),
                                            new DBFField("PER_NATCOD", NativeDbType.Char, 10),
                    };
                foreach (var values in valuesRow)
                {
                    writer.AddRecord(values);
                }
                writer.Write(ms);
            }
        }
        catch (Exception e)
        {
            Console.Write(e.Message);
        }
    }

}