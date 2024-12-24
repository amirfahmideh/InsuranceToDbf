# InsuranceToDbf

## توضیحات
کلاس لایبری برای خروجی لیست بیمه قابل ارایه به سازمان تامین اجتماعی در دات نت 

## نحوه استفاده
``
dotnet add package InsuranceToDbf
``

## نمونه استفاده
```C#
InsuranceToDbf.Export.ExportToDbf.Export(workOffice, personnel, out workOfficeStream, out personnelStream);
```
مموری استریم ها می توانند در فایل فایل متنی با فرمت دی بی اف ذخیره شوند و یا به عنوان استریم در پروژه های تحت وب دانلود شوند


## Register Required Encoding
قبل از فراخوانی تابع با دستور زیر انکودینگ های مورد نیاز را به سیستم اضافه کنید

```C#
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
```

---
<a href="https://www.coffeebede.com/amirfahmideh"><img class="img-fluid" src="https://coffeebede.ir/DashboardTemplateV2/app-assets/images/banner/default-yellow.svg" /></a>
