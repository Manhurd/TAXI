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

namespace TAXI.Modules.AddRide
{
    class AddRideViewModel : ObservableObject
    {
        private string clientFullName;
        public string ClientFullName
        {
            get { return clientFullName; }
            set
            {
                clientFullName = value;
                OnPropertyChanged(nameof(ClientFullName));
            }
        }

        private int carIndex;
        public int CarIndex
        {
            get { return carIndex; }
            set
            {
                carIndex = value;
                OnPropertyChanged(nameof(CarIndex));
            }
        }

        private string departurePoint;
        public string DeparturePoint
        {
            get { return departurePoint; }
            set
            {
                departurePoint = value;
                OnPropertyChanged(nameof(DeparturePoint));
            }
        }

        private string destinationPoint;
        public string DestinationPoint
        {
            get { return destinationPoint; }
            set
            {
                destinationPoint = value;
                OnPropertyChanged(nameof(DestinationPoint));
            }
        }

        private string travelDistance;
        public string TravelDistance
        {
            get { return travelDistance; }
            set
            {
                travelDistance = value;
                OnPropertyChanged(nameof(TravelDistance));
            }
        }

        private RelayCommand addRide;
        public RelayCommand AddRide
        {
            get
            {
                return addRide ?? (addRide = new RelayCommand(obj =>
                {
                    float travelDistance = 0;

                    try
                    {
                        travelDistance = float.Parse(TravelDistance);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("TRAVEL DISTANCE IS INVALID!");
                        return;
                        throw;
                    }

                    ObservableCollection<Car> cars = new ObservableCollection<Car>();

                    using (FileStream stream = new FileStream(Directory.GetCurrentDirectory() + "/CarCollection.json", FileMode.OpenOrCreate))
                    {
                        if (stream.Length != 0)
                        {
                            cars = JsonSerializer.Deserialize<ObservableCollection<Car>>(stream);
                        }
                        else
                        {
                            MessageBox.Show("CARS COLLECTION IS EMPTY!");
                            return;
                        }
                    }

                    ObservableCollection<Client> clients = new ObservableCollection<Client>();

                    using (FileStream stream = new FileStream(Directory.GetCurrentDirectory() + "/ClientCollection.json", FileMode.OpenOrCreate))
                    {
                        if (stream.Length != 0)
                        {
                            clients = JsonSerializer.Deserialize<ObservableCollection<Client>>(stream);
                        }
                        else
                        {
                            MessageBox.Show("CLIENTS COLLECTION IS EMPTY!");
                            return;
                        }
                    }

                    ObservableCollection<Ride> rides = new ObservableCollection<Ride>();

                    using (FileStream stream = new FileStream(Directory.GetCurrentDirectory() + "/RideCollection.json", FileMode.OpenOrCreate))
                    {
                        if (stream.Length != 0)
                        {
                            rides = JsonSerializer.Deserialize<ObservableCollection<Ride>>(stream);
                        }
                    }

                    Car car = cars.FirstOrDefault(item => item.CarIndex == CarIndex);

                    if (car == default(Car))
                    {
                        MessageBox.Show("CAR NOT FOUND!");
                        return;
                    }

                    Client client = clients.FirstOrDefault(item => (item.FirstName + " " + item.LastName) == ClientFullName);

                    if (client == default(Client))
                    {
                        MessageBox.Show("CLIENT NOT FOUND!");
                        return;
                    }

                    ObservableCollection<TaxiClass> taxiClases = new ObservableCollection<TaxiClass>();

                    using (FileStream stream = new FileStream(Directory.GetCurrentDirectory() + "/TaxiClassCollection.json", FileMode.OpenOrCreate))
                    {
                        if (stream.Length != 0)
                        {
                            taxiClases = JsonSerializer.Deserialize<ObservableCollection<TaxiClass>>(stream);
                        }
                    }

                    TaxiClass taxiClass = taxiClases.First(item => item.IdTaxiClass == car.IdTaxiClass);

                    Ride ride = new Ride(client.IdClient, car.IdCar, car.IdDriver, car.IdTaxiClass, DeparturePoint, DestinationPoint, travelDistance, taxiClass.PricePerKilometer * travelDistance);

                    rides.Add(ride);

                    var jsonText = JsonSerializer.Serialize(rides);

                    File.WriteAllText(Directory.GetCurrentDirectory() + "/RideCollection.json", jsonText);

                    MessageBox.Show("RIDE REGISTERED!");

                }, obj => CarIndex != null && CarIndex > 0 && !string.IsNullOrEmpty(ClientFullName) && !string.IsNullOrEmpty(DeparturePoint) && !string.IsNullOrEmpty(DestinationPoint) && !string.IsNullOrEmpty(TravelDistance)));
            }
        }
    }
}
