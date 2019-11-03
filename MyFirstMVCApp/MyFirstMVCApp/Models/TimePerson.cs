using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyFirstMVCApp.Models
{
    public class TimePerson
    {
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int BirthYear { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }

        public static List<TimePerson> GetPersons(int yearFrom, int yearTo)
        {
            string path = "./wwwroot/personOfTheYear.csv";
            string[] myFile = File.ReadAllLines(path);

            List<TimePerson> people = new List<TimePerson>();

            for (int i = 1; i < myFile.Length; i++)
            {
                string[] column = myFile[i].Split(",");

                TimePerson person = new TimePerson()
                {
                    Year = Convert.ToInt32(column[0]),
                    Honor = column[1],
                    Name = column[2],
                    Country = column[3],
                    BirthYear = (column[4] == "") ? 0 : Convert.ToInt32(column[4]),
                    DeathYear = (column[5] == "") ? 0 : Convert.ToInt32(column[5]),
                    Title = column[6],
                    Category = column[7],
                    Context = column[8]
                };
                people.Add(person);
            }
            people = people.Where(x => (x.Year >= yearFrom) && (x.Year <= yearTo)).ToList();
            return people;
        }
    }
}
