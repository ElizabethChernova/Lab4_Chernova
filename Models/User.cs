using System;

namespace KMA.ProgrammingInCSharp2022.Practice7Serialization.Models
{
    class User
    {
        public User(Guid guid, string firstName, string lastName, string email, string login, DateTime dateOfBirth)
        {
            Guid = guid;
          Name = firstName;
            LastName = lastName;
            Email = email;
            Login = login;
            DateOfBirth = dateOfBirth;
            Age = CountAge();
            West = CountWestern();
            East = CountChineese();
            Adult = IsAdult();
        }

        public Guid Guid { get; }
        public string Name { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Login { get; }
        public DateTime DateOfBirth { get; }
        public int Age { get; }
        public string West { get; }
        public string East { get; }
        public bool Adult { get; }

        private string CountWestern()
        {


            if ((DateOfBirth.Day >= 21 && DateOfBirth.Month == 3) || (DateOfBirth.Day <= 20 && DateOfBirth.Month == 4)) return "Oven";
            if ((DateOfBirth.Day >= 21 && DateOfBirth.Month == 4) || (DateOfBirth.Day <= 20 && DateOfBirth.Month == 5)) return "Teles ";
            if ((DateOfBirth.Day >= 21 && DateOfBirth.Month == 5) || (DateOfBirth.Day <= 21 && DateOfBirth.Month == 6)) return "Twins ";
            if ((DateOfBirth.Day >= 22 && DateOfBirth.Month == 6) || (DateOfBirth.Day <= 22 && DateOfBirth.Month == 7)) return "Rak";
            if ((DateOfBirth.Day >= 23 && DateOfBirth.Month == 7) || (DateOfBirth.Day <= 23 && DateOfBirth.Month == 8)) return "Lion";
            if ((DateOfBirth.Day >= 24 && DateOfBirth.Month == 8) || (DateOfBirth.Day <= 23 && DateOfBirth.Month == 9)) return "Diva";
            if ((DateOfBirth.Day >= 24 && DateOfBirth.Month == 9) || (DateOfBirth.Day <= 23 && DateOfBirth.Month == 10)) return "Teresy ";
            if ((DateOfBirth.Day >= 24 && DateOfBirth.Month == 10) || (DateOfBirth.Day <= 22 && DateOfBirth.Month == 11)) return "Scorpion ";
            if ((DateOfBirth.Day >= 23 && DateOfBirth.Month == 11) || (DateOfBirth.Day <= 21 && DateOfBirth.Month == 12)) return "Strilets ";
            if ((DateOfBirth.Day >= 22 && DateOfBirth.Month == 12) || (DateOfBirth.Day <= 20 && DateOfBirth.Month == 1)) return "Koserich ";
            if ((DateOfBirth.Day >= 21 && DateOfBirth.Month == 1) || (DateOfBirth.Day <= 18 && DateOfBirth.Month == 2)) return "Vodoliy ";
            else return "Риби ";

        }

        private string CountChineese()
        {
            switch (DateOfBirth.Year % 12.0)
            {

                case 1:
                    return "Piven";

                case 2:
                    return "Dog";
                case 3:
                    return "Pig";
                case 4:
                    return "Mouse";
                case 5:
                    return "Cow ";
                case 6:
                    return "Tiger ";
                case 7:
                    return "Rabit ";
                case 8:

                    return "Dragon ";
                case 9:
                    return "Snake ";
                case 10:
                    return "Horse";
                case 11:
                    return "Goat";
                default:
                    return "Monkey";
            }
        }


        private int CountAge()
        {
            return DateTime.Today.Year - DateOfBirth.Year;
        }
        public bool IsRight()
        {

            if (CountAge() < 0 || (CountAge() == 0 && DateTime.Today.Month < DateOfBirth.Month || DateTime.Today.Month == DateOfBirth.Month && DateTime.Today.Day < DateOfBirth.Day) || CountAge() > 135) return false;
            return true;
        }
        public bool IsAdult()
        {
            return DateTime.Today.Year-DateOfBirth.Year > 18 || DateTime.Today.Year - DateOfBirth.Year == 18 && (DateOfBirth.Month > DateTime.Today.Month || (DateOfBirth.Month == DateTime.Today.Month && DateOfBirth.Day > DateTime.Today.Day));
        }
    }
}