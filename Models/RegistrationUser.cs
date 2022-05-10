using System;

namespace KMA.ProgrammingInCSharp2022.Practice7Serialization.Models
{
    class RegistrationUser
    {
        #region Fields
        private string _name;
        private string _login;
        private int _age;
        private string _password;
        private DateTime dateOfBirth = DateTime.Today;
        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
            }
        }
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = 4;// value;
            }
        }
        public DateTime DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                dateOfBirth = value;
            }
        }
    }
        /*  public string Password
{
get
{
return _password;
}
set
{
_password = value;
}
} */
        #endregion
    }
