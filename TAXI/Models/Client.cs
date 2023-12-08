using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TAXI.General;

namespace TAXI.Models
{
    public class Client : ObservableObject
    {

		private Guid idClient;
		public Guid IdClient
		{
			get { return idClient; }
			set
			{
				idClient = value;
				OnPropertyChanged(nameof(IdClient));
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

		public Client(string firstName, string lastName, string phone)
		{
			IdClient = Guid.NewGuid();
			FirstName = firstName;
			LastName = lastName;
			Phone = phone;
		}

		[JsonConstructor]
        public Client(Guid idClient, string firstName, string lastName, string phone)
        {
            IdClient = idClient;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }
    }
}
