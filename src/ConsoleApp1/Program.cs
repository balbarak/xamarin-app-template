using ConsoleApp1.Context;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (BlogContext context = new BlogContext())
            {
                var data = context.Countries.ToList();

                var result = new List<XamarinAppTemplate.Models.Country>();

                foreach (var item in data)
                {
                    result.Add(new XamarinAppTemplate.Models.Country()
                    {
                        Name = new XamarinAppTemplate.Models.LocaleString(item.NameArabic, item.NameEnglish),
                        Capital = new XamarinAppTemplate.Models.LocaleString(item.CapitalArabic, item.CapitalEnglish),
                        Area = item.Area,
                        Population = item.Population,
                        CodeTwo = item.CodeTwo,
                        IsActive = item.IsActive,
                        Latitude = item.Latitude,
                        Longtitude = item.Longtitude,
                        PhoneCode = item.PhoneCode,
                        Id = item.Id
                    });
                }

                var text = JsonConvert.SerializeObject(result);

                File.WriteAllText(@"C:\Repos\mobile-template-app\src\ConsoleApp1\Countries.json", text);
            }
        }
    }
}
