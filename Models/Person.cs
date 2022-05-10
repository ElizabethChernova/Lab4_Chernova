using System;

namespace KMA.ProgrammingInCSharp2022.Practice7Serialization.Models
{
    class Person
    {
        public Person(string name, string lastName, string email, string login, DateTime dateOfBirth)//, string password)
        {
            Guid = Guid.NewGuid();
            Name = name;
            LastName = lastName;
            Email = email;
            Login = login;
            DateOfBirth = dateOfBirth;

            //   Password = password;
        }



        public Guid Guid { get; }
        public string Name { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Login { get; }
        //     public string Password { get; }

        public DateTime DateOfBirth { get; }

    }
}