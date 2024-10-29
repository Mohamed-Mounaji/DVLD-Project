using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data;
namespace DVLD_Business
{
    public class clsPerson
    {
        private enum enMode { AddNew, Update }
        private enMode _Mode;
        private int _PersonID;
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string NationalNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }


        public int PersonID
        {
            get
            {
                return _PersonID;
            }
        }
        public string FullName()
        {
            string FullName = FirstName;
            FullName += (string.IsNullOrEmpty(SecondName) ? "" : " " + SecondName);
            FullName += (string.IsNullOrEmpty(ThirdName) ? "" : " " + ThirdName);
            FullName += " " + LastName;
            return FullName;
        }

        public clsPerson()
        {
            _Mode = enMode.AddNew;
            _PersonID = -1;
        }

        public clsPerson(int PersonID, string firstName, string secondName, string thirdName, string lastName, string nationalNumber, DateTime dateOfBirth,
                                                bool gender, string phone, string email, int nationalityCountryID, string address, string imagePath)
        {
            _Mode = enMode.Update;
            this._PersonID = PersonID;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = lastName;
            this.NationalNumber = nationalNumber;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.Phone = phone;
            this.Email = email;
            this.NationalityCountryID = nationalityCountryID;
            this.Address = address;
            this.ImagePath = imagePath;
        }

        private bool _Update()
        {
            if (this._PersonID == -1) return false;
            if (string.IsNullOrEmpty(this.FirstName)) return false;
            if (string.IsNullOrEmpty(this.LastName)) return false;
            if(string.IsNullOrEmpty(this.Phone)) return false;
            if(string.IsNullOrEmpty(this.NationalNumber)) return false;
            if(string.IsNullOrEmpty(this.Address)) return false;

            return clsPerson_DAL.UpdatePerson(this._PersonID, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.NationalNumber, this.DateOfBirth, this.Gender, this.Phone, this.Email, this.NationalityCountryID, this.Address, this.ImagePath);
        }

        private bool _AddNew()
        {
            if (string.IsNullOrEmpty(this.FirstName)) return false;
            if (string.IsNullOrEmpty(this.LastName)) return false;
            if (string.IsNullOrEmpty(this.Phone)) return false;
            if (string.IsNullOrEmpty(this.NationalNumber)) return false;
            if (string.IsNullOrEmpty(this.Address)) return false;

            _PersonID = clsPerson_DAL.AddNewPerson(this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.NationalNumber, this.DateOfBirth, this.Gender, this.Phone, this.Email, this.NationalityCountryID, this.Address, this.ImagePath);
            if(_PersonID != -1)
            {
                _Mode = enMode.Update;
                return true;
            }
            return false;

         }

        public static clsPerson Find(int PersonID)
        {
            string firstName = "", secondName = "", thirdName = "", lastName = "", nationalNumber = "", phone = "", email = "",address = "", imagePath = "";
            int nationalityCountryID = -1;
            bool gender = false;
            DateTime dateOfBirth = DateTime.Now;

            if (clsPerson_DAL.GetPersonInfoByID(PersonID, ref firstName, ref secondName, ref thirdName, ref lastName, ref nationalNumber, ref dateOfBirth,
                                                ref gender, ref phone, ref email, ref nationalityCountryID, ref address, ref imagePath))
                return new clsPerson(PersonID, firstName, secondName, thirdName, lastName, nationalNumber, dateOfBirth, gender, phone, email, nationalityCountryID, address, imagePath);
            else
                return null;
        }

        public static clsPerson Find(string nationalNumber)
        {
            string firstName = "", secondName = "", thirdName = "", lastName = "", phone = "", email = "", address = "", imagePath = "";
            int nationalityCountryID = -1, PersonID = -1;
            bool gender = false;
            DateTime dateOfBirth = DateTime.Now;

            if (clsPerson_DAL.GetPersonInfoByNationalNumber(nationalNumber , ref PersonID, ref firstName, ref secondName, ref thirdName, ref lastName,  ref dateOfBirth,
                                                ref gender, ref phone, ref email, ref nationalityCountryID, ref address, ref imagePath))
                return new clsPerson(PersonID, firstName, secondName, thirdName, lastName, nationalNumber, dateOfBirth, gender, phone, email, nationalityCountryID, address, imagePath);
            else
                return null;
        }

        public static bool DeletePerson(int PersonID)
        {
            return clsPerson_DAL.DeletePerson(PersonID);
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.Update:
                    return _Update();
                case enMode.AddNew:
                    return _AddNew();
            }
            return false;
        }

        public static DataTable GetAllPeople()
        {
            return clsPerson_DAL.GetAllPeopleInfo();
        }

        public static bool isNationalNumberExist(string NationalNumber)
        {
            return clsPerson_DAL.isNationalNumberExist(NationalNumber);
        }

        public static bool isNationalNumberExist(string nationalNumber, int PersonID)
        {
            return clsPerson_DAL.isNationalNumberExist(nationalNumber, PersonID);
        }

        public static bool isPersonExists(int PersonID)
        {
            return clsPerson_DAL.isPersonExists(PersonID);
        }

        public static bool isAUser(int PersonID )
        {
            return clsPerson_DAL.isAUser(PersonID);
        }

        public static bool HasLicense(int PersonID, int LicenseClassID)
        {
            return clsPerson_DAL.HasLicense(PersonID, LicenseClassID);
        }

        public static string GetFullNameBy(int PersonID)
        {
            return clsPerson_DAL.GetFullNameBy(PersonID);
        }

        public static bool isDriver(int personID)
        {
            return clsPerson_DAL.isDriver(personID);
        }

        public static DataTable GetLicensesHistory(int PersonID)
        {
            return clsPerson_DAL.GetLicensesHistory(PersonID);
        }

        public static int GetPersonIDByDriverID(int driverID)
        {
            return clsPerson_DAL.GetPersonIDByDriverID(driverID);
        }

        public static clsPerson FindByDriverID(int driverID)
        {
            string firstName = "", secondName = "", thirdName = "", lastName = "", nationalNumber = "", phone = "", email = "", address = "", imagePath = "";
            int nationalityCountryID = -1, personID =-1;
            bool gender = false;
            DateTime dateOfBirth = DateTime.Now;

            if (clsPerson_DAL.GetPersonInfoByDriverID(driverID, ref personID, ref firstName, ref secondName, ref thirdName, ref lastName, ref nationalNumber, ref dateOfBirth,
                                                ref gender, ref phone, ref email, ref nationalityCountryID, ref address, ref imagePath))
                return new clsPerson(personID, firstName, secondName, thirdName, lastName, nationalNumber, dateOfBirth, gender, phone, email, nationalityCountryID, address, imagePath);
            else
                return null;
        }

        public static int GetPersonIDByApplicationID(int applicationID)
        {
            return clsPerson_DAL.GetPersonIDByApplicationID(applicationID);
        }

        public static int GetPersonIDByNationalNumber(string nationalNumber)
        {
            return clsPerson_DAL.GetPeresonIDByNationalNumber(nationalNumber);
        }

    }
}
