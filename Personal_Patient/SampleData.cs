using System;
using System.Collections.Generic;
using System.Linq;
using Personal_Patient.Models;

namespace Personal_Patient
{
    public static class SampleData
    {
        public static void Initialize(PersonalPatientContext context)
        {
            if (!context.patients.Any())
            {
                context.patients.AddRange(
                    new Patient
                    {
                        name = "Петр",
                        surname = "Гуров",
                        patronymic = "Петрович",
                        password = "123",
                        dateofbirth = new DateTime (1993, 03, 05),
                        numberpolicy = "1234567891011121",
                        numberpassport = "1234567891",
                        email = "Example@mail.ru",
                        phone = "81923647581",
                        photourl = "url/"
                    },
                    new Patient
                    {
                        name = "Иван",
                        surname = "Колегов",
                        patronymic = "Иванович",
                        password = "qwerty",
                        dateofbirth = new DateTime(1998, 02, 07),
                        numberpolicy = "1237594857311121",
                        numberpassport = "1237305791",
                        email = "Mail@mail.ru",
                        phone = "81923958581",
                        photourl = "url2/"
                    },
                    new Patient
                    {
                        name = "Андрей",
                        surname = "Андреев",
                        patronymic = "Андреевич",
                        password = "фываавыф",
                        dateofbirth = new DateTime(2001, 02, 02),
                        numberpolicy = "1091647891011121",
                        numberpassport = "1758491891",
                        email = "Qwerty@mail.ru",
                        phone = "81934121581",
                        photourl = "url3/"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
