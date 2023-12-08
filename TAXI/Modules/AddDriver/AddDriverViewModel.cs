using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using TAXI.General;
using TAXI.Models;

namespace TAXI.Modules.AddDriver
{
    class AddDriverViewModel : ObservableObject
    {
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

        private RelayCommand addDriver;
        public RelayCommand AddDriver
        {
            get
            {
                return addDriver ?? (addDriver = new RelayCommand(obj =>
                {

                    ObservableCollection<Driver> drivers = new ObservableCollection<Driver>();

                    using (FileStream stream = new FileStream(Directory.GetCurrentDirectory() + "/DriverCollection.json", FileMode.OpenOrCreate))
                    {
                        if (stream.Length != 0)
                        {
                            drivers = JsonSerializer.Deserialize<ObservableCollection<Driver>>(stream);
                        }
                    }

                    foreach (var item in drivers)
                    {
                        if (item.FirstName == FirstName && item.LastName == LastName && item.Phone == Phone)
                        {
                            MessageBox.Show("DRIVER WITH THIS INFORMATION ALREADY REGISTERED!");
                            return;
                        }
                    }

                    var newDriver = new Driver(FirstName, LastName, Phone);

                    drivers.Add(newDriver);

                    var jsonText = JsonSerializer.Serialize(drivers);

                    File.WriteAllText(Directory.GetCurrentDirectory() + "/DriverCollection.json", jsonText);

                    MessageBox.Show("DRIVER REGISTERED!");

                }, obj => !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) && Phone != null && Phone.Length == 13));
            }
        }
    }
}
