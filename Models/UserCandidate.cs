using System;

namespace KMA.ProgrammingInCSharp2022.Practice7Serialization.Models
{
    class UserCandidate
    {
        #region Fields
        private string name;
        private string _password;
        private int age;
        private DateTime _dateOfBirth= DateTime.Today;
        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
       public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                _dateOfBirth = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = 3;// value;
            }
        }
        #endregion
    }
}
