using KMA.ProgrammingInCSharp2022.Practice7Serialization.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace KMA.ProgrammingInCSharp2022.Practice7Serialization.Repositories
{
    class FileRepository
    {
        private static readonly string BaseFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CSKMAStorage");

        public FileRepository()
        {
            if (!Directory.Exists(BaseFolder))
            {
                Directory.CreateDirectory(BaseFolder);
                Add50InitAsync();
            }
        }

        public async Task AddOrUpdateAsync(Person obj)
        {
            var stringObj = JsonSerializer.Serialize(obj);

            using (StreamWriter sw = new StreamWriter(Path.Combine(BaseFolder, obj.Login), false))
            {
                await sw.WriteAsync(stringObj);
            }
        }

        public async Task<Person> GetAsync(string login)
        {
            string stringObj = null;
            string filePath = Path.Combine(BaseFolder, login);

            if (!File.Exists(filePath))
                return null;

            using (StreamReader sw = new StreamReader(filePath))
            {
                stringObj = await sw.ReadToEndAsync();
            }

            return JsonSerializer.Deserialize<Person>(stringObj);
        }

        public async Task<List<Person>> GetAllAsync()
        {
            var res = new List<Person>();
            foreach (var file in Directory.EnumerateFiles(BaseFolder))
            {
                string stringObj = null;

                using (StreamReader sw = new StreamReader(file))
                {
                    stringObj = await sw.ReadToEndAsync();
                }

                res.Add(JsonSerializer.Deserialize<Person>(stringObj));
            }

            return res;
        }

        public List<Person> GetAll()
        {
            var res = new List<Person>();
            foreach (var file in Directory.EnumerateFiles(BaseFolder))
            {
                string stringObj = null;

                using (StreamReader sw = new StreamReader(file))
                {
                    stringObj = sw.ReadToEnd();
                }

                res.Add(JsonSerializer.Deserialize<Person>(stringObj));
            }

            return res;
        }
        private async Task Add50InitAsync()
        {
            Random r1 = new Random();
            for (int i = 0; i < 50; i++)
            {
                string name = GenerateRandomWorld();
                string login= GenerateRandomWorld(); 
                string email= GenerateRandomWorld();
                int year = r1.Next(DateTime.Today.Year - 130, DateTime.Today.Year);
                int month = r1.Next(1, 12);
                Person dbUser = new Person(name, "Last", email + "@gmail.com", login, new DateTime(year, month, r1.Next(1, DateTime.DaysInMonth(year, month))));//, regUser.Password);
                await AddOrUpdateAsync(dbUser);
            }
        }

        private string GenerateRandomWorld()
        {
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            Random rand = new Random();


            // Сделайте слово.
            string word = "";
            for (int j = 1; j <= 6; j++)
            {
                // Выбор случайного числа от 0 до 25
                // для выбора буквы из массива букв.
                int letter_num = rand.Next(0, letters.Length - 1);

                // Добавить письмо.
                word += letters[letter_num];
            }

            return word;
        }

    }
}