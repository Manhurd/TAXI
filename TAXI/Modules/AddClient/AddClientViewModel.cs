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

namespace TAXI.Modules.AddClient
{
    class AddClientViewModel : ObservableObject
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

        private RelayCommand addClient;
        public RelayCommand AddClient
        {
            get
            {
                return addClient ?? (addClient = new RelayCommand(obj =>
                {

                    ObservableCollection<Client> clients = new ObservableCollection<Client>();

                    using (FileStream stream = new FileStream(Directory.GetCurrentDirectory() + "/ClientCollection.json", FileMode.OpenOrCreate))
                    {
                        if (stream.Length != 0)
                        {
                            clients = JsonSerializer.Deserialize<ObservableCollection<Client>>(stream);
                        }
                    }

                    foreach (var item in clients)
                    {
                        if (item.Phone == Phone)
                        {
                            MessageBox.Show("CLIENT WITH THIS INFORMATION ALREADY REGISTERED!");
                            return;
                        }
                    }

                    var newClient = new Client(FirstName, LastName, Phone);

                    clients.Add(newClient);

                    var jsonText = JsonSerializer.Serialize(clients);

                    File.WriteAllText(Directory.GetCurrentDirectory() + "/ClientCollection.json", jsonText);

                    MessageBox.Show("CLIENT REGISTERED!");

                }, obj => !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) && Phone != null && Phone.Length == 13));
            }
        }
    }
}
