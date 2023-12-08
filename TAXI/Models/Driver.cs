using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TAXI.General;

namespace TAXI.Models
{
    public class Driver : ObservableObject
    {

        private Guid idDriver;
        public Guid IdDriver
        {
            get { return idDriver; }
            set
            {
                idDriver = value;
                OnPropertyChanged(nameof(IdDriver));
            }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        public Driver(string firstName, string lastName, string phone)
        {
            IdDriver = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }

        [JsonConstructor]
        public Driver(Guid idDriver, string firstName, string lastName, string phone)
        {
            IdDriver = idDriver;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }
    }
}
