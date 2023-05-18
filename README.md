# InsuranceToDbf

## توضیحات
کلاس لایبری برای خروجی لیست بیمه قابل ارایه به سازمان تامین اجتماعی در دات نت 

## نحوه استفاده
``
dotnet add package InsuranceToDbf --version 1.0.3
``

## نمونه استفاده
```C#
InsuranceToDbf.Export.ExportToDbf.Export(workOffice, personnel, out workOfficeStream, out personnelStream);
```
مموری استریم ها می توانند در فایل فایل متنی با فرمت دی بی اف ذخیره شوند و یا به عنوان استریم در پروژه های تحت وب دانلود شوند