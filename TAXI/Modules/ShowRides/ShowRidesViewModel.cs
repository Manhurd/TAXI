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

namespace TAXI.Modules.ShowRides
{
    internal class ShowRidesViewModel : ObservableObject
    {
		public ShowRidesViewModel() 
		{
            RidesCollection = new ObservableCollection<Ride>();
		}

		private string inputText;
		public string InputText
		{
			get { return inputText; }
			set
			{
				inputText = value;
				OnPropertyChanged(nameof(InputText));
			}
		}

		private ObservableCollection<Ride> ridesCollection;
		public ObservableCollection<Ride> RidesCollection
		{
			get { return ridesCollection; }
			set
			{
				ridesCollection = value;
				OnPropertyChanged(nameof(RidesCollection));
			}
		}

		private ObservableCollection<Result> showResults;
		public ObservableCollection<Result> ShowResults
		{
			get { return showResults; }
			set
			{
				showResults = value;
				OnPropertyChanged(nameof(ShowResults));
			}
		}


		private RelayCommand showInfo;
		public RelayCommand ShowInfo
		{
			get
			{
				return showInfo ?? (showInfo = new RelayCommand(obj =>
				{
                    RidesCollection = new ObservableCollection<Ride>();

                    ObservableCollection<Ride> rides = new ObservableCollection<Ride>();

                    using (FileStream stream = new FileStream(Directory.GetCurrentDirectory() + "/RideCollection.json", FileMode.OpenOrCreate))
                    {
                        if (stream.Length != 0)
                        {
                            rides = JsonSerializer.Deserialize<ObservableCollection<Ride>>(stream);
                        }
                        else
                        {
                            MessageBox.Show("RIDES COLLECTION IS EMPTY!");
							return;
                        }
                    }

                    ObservableCollection<Driver> drivers = new ObservableCollection<Driver>();

                    using (FileStream stream = new FileStream(Directory.GetCurrentDirectory() + "/DriverCollection.json", FileMode.OpenOrCreate))
                    {
						drivers = JsonSerializer.Deserialize<ObservableCollection<Driver>>(stream);
                    }

                    ObservableCollection<Client> clients = new ObservableCollection<Client>();

                    using (FileStream stream = new FileStream(Directory.GetCurrentDirectory() + "/ClientCollection.json", FileMode.OpenOrCreate))
                    {
                        clients = JsonSerializer.Deserialize<ObservableCollection<Client>>(stream);
                    }

                    ObservableCollection<Car> cars = new ObservableCollection<Car>();

                    using (FileStream stream = new FileStream(Directory.GetCurrentDirectory() + "/CarCollection.json", FileMode.OpenOrCreate))
                    {
                        cars = JsonSerializer.Deserialize<ObservableCollection<Car>>(stream);
                    }

                    ObservableCollection<TaxiClass> taxiClasses = new ObservableCollection<TaxiClass>();

                    using (FileStream stream = new FileStream(Directory.GetCurrentDirectory() + "/TaxiClassCollection.json", FileMode.OpenOrCreate))
                    {
                        taxiClasses = JsonSerializer.Deserialize<ObservableCollection<TaxiClass>>(stream);
                    }

                    if (InputText[0].Equals('+'))
                    {
						if (InputText.Length != 13)
						{
							MessageBox.Show("INVALID PHONE NUMBER");
							return;
						}

						Driver driver = drivers.FirstOrDefault(obj => obj.Phone == InputText);
						Client client = clients.FirstOrDefault(obj => obj.Phone == InputText);

						if (driver == default(Driver) && client == default(Client))
						{
                            MessageBox.Show("CLIENT AND DRIVER WITH THIS PHONE NUMBER IS NOT FOUND!");
                            return;
						}

						foreach (var item in rides)
						{
							if (client != null && item.IdClient == client.IdClient)
							{
								RidesCollection.Add(item);
							}
                            if (driver != null && item.IdDriver == driver.IdDriver)
                            {
                                RidesCollection.Add(item);
                            }
                        }

                        ShowResults = new ObservableCollection<Result>();

                        foreach (var ride in RidesCollection)
                        {
                            Result result = new Result();
                            result.ClientFirstName = clients.First(obj => obj.IdClient == ride.IdClient).FirstName;
                            result.ClientLastName = clients.First(obj => obj.IdClient == ride.IdClient).LastName;
                            result.DriverFirstName = drivers.First(obj => obj.IdDriver == ride.IdDriver).FirstName;
                            result.DriverLastName = drivers.First(obj => obj.IdDriver == ride.IdDriver).LastName;
                            result.CarBrand = cars.First(obj => obj.IdCar == ride.IdCar).Brand;
                            result.CarModel = cars.First(obj => obj.IdCar == ride.IdCar).Model;
                            result.TaxiClass = taxiClasses.First(obj => obj.IdTaxiClass == ride.IdTaxiClass).Title;
                            result.Departure = ride.DeparturePoint;
                            result.Destination = ride.DestinationPoint;
                            result.TravelDistance = ride.TravelDistance.ToString();
                            result.TravelPrice = ride.TravelPrice.ToString();
                            ShowResults.Add(result);
                        }

                        return;
                    }

                    foreach (var item in rides)
					{
						var client = clients.First(obj => obj.IdClient == item.IdClient);
						var driver = drivers.First(obj => obj.IdDriver == item.IdDriver);

						if ((client.FirstName + "" + client.LastName).Contains(InputText) || (driver.FirstName + "" + driver.LastName).Contains(InputText))
						{
                            RidesCollection.Add(item);
                        }
					}

					if (!RidesCollection.Any())
						MessageBox.Show("CLIENT OR DRIVER WITH THIS FULLNAME IS NOT FOUND!");

					ShowResults = new ObservableCollection<Result>();

					foreach (var ride in RidesCollection)
					{
						Result result = new Result();
						result.ClientFirstName = clients.First(obj => obj.IdClient == ride.IdClient).FirstName;
						result.ClientLastName = clients.First(obj => obj.IdClient == ride.IdClient).LastName;
                        result.DriverFirstName = drivers.First(obj => obj.IdDriver == ride.IdDriver).FirstName;
                        result.DriverLastName = drivers.First(obj => obj.IdDriver == ride.IdDriver).LastName;
                        result.CarBrand = cars.First(obj => obj.IdCar == ride.IdCar).Brand;
                        result.CarModel = cars.First(obj => obj.IdCar == ride.IdCar).Model;
						result.TaxiClass = taxiClasses.First(obj => obj.IdTaxiClass == ride.IdTaxiClass).Title;
						result.Departure = ride.DeparturePoint;
						result.Destination = ride.DestinationPoint;
						result.TravelDistance = ride.TravelDistance.ToString();
						result.TravelPrice = ride.TravelPrice.ToString();
						ShowResults.Add(result);
                    }

                }, obj => !string.IsNullOrEmpty(InputText)));
			}
		}

		internal class Result : ObservableObject
		{

			private string clientFirstName;
			public string ClientFirstName
            {
				get { return clientFirstName; }
				set
				{
					clientFirstName = value;
					OnPropertyChanged(nameof(ClientFirstName));
				}
			}

			private string clientLastName;
			public string ClientLastName
            {
				get { return clientLastName; }
				set
				{
					clientLastName = value;
					OnPropertyChanged(nameof(ClientLastName));
				}
			}

			private string driverFirstName;
			public string DriverFirstName
            {
				get { return driverFirstName; }
				set
				{
					driverFirstName = value;
					OnPropertyChanged(nameof(DriverFirstName));
				}
			}

			private string driverLastName;
			public string DriverLastName
            {
				get { return driverLastName; }
				set
				{
					driverLastName = value;
					OnPropertyChanged(nameof(DriverLastName));
				}
			}

			private string carBrand;
			public string CarBrand
            {
				get { return carBrand; }
				set
				{
					carBrand = value;
					OnPropertyChanged(nameof(CarBrand));
				}
			}

			private string carModel;
			public string CarModel
            {
				get { return carModel; }
				set
				{
					carModel = value;
					OnPropertyChanged(nameof(CarModel));
				}
			}

			private string taxiClass;
			public string TaxiClass
            {
				get { return taxiClass; }
				set
				{
					taxiClass = value;
					OnPropertyChanged(nameof(TaxiClass));
				}
			}

			private string departure;
			public string Departure
            {
				get { return departure; }
				set
				{
					departure = value;
					OnPropertyChanged(nameof(Departure));
				}
			}

			private string destination;
			public string Destination
            {
				get { return destination; }
				set
				{
					destination = value;
					OnPropertyChanged(nameof(Destination));
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

			private string travelPrice;
			public string TravelPrice
            {
				get { return travelPrice; }
				set
				{
					travelPrice = value;
					OnPropertyChanged(nameof(TravelPrice));
				}
			}
		}

	}
}
