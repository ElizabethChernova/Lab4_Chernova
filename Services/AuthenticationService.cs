using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using KMA.ProgrammingInCSharp2022.Practice7Serialization.Models;
using KMA.ProgrammingInCSharp2022.Practice7Serialization.Repositories;

namespace KMA.ProgrammingInCSharp2022.Practice7Serialization.Services
{
    class AuthenticationService
    {
        private static FileRepository Repository = new FileRepository();

        public async Task<User> Authenticate(UserCandidate userCandidate)
        {
            if (String.IsNullOrWhiteSpace(userCandidate.Name))// || String.IsNullOrWhiteSpace(userCandidate.Password))
                throw new ArgumentException("Login or Password is Empty");
            var dbUser = await Repository.GetAsync(userCandidate.Name);
            if (dbUser == null || userCandidate.Name != dbUser.Name || userCandidate.DateOfBirth != dbUser.DateOfBirth)
                throw new AuthenticationException("Wrong login or password");
            return new User(dbUser.Guid, dbUser.Name, dbUser.LastName, dbUser.Email, dbUser.Login, dbUser.DateOfBirth);
        }

        public async Task<bool> RegisterUser(RegistrationUser regUser)
        {
            var dbUser = await Repository.GetAsync(regUser.Login);
            if (dbUser != null)
                throw new Exception("User already exists");
            if (String.IsNullOrWhiteSpace(regUser.Login)  || String.IsNullOrWhiteSpace(regUser.Name))//|| String.IsNullOrWhiteSpace(regUser.Password)
                throw new ArgumentException("First Name, Login or Password is Empty");
            dbUser = new Person(regUser.Name, "Last", regUser.Login + "@gmail.com", regUser.Login, regUser.DateOfBirth);//, regUser.Password);
            await Repository.AddOrUpdateAsync(dbUser);
            return true;
        }
    }
}
