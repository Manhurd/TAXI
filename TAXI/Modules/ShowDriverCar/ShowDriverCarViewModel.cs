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

namespace TAXI.Modules.ShowDriverCar
{
    internal class ShowDriverCarViewModel : ObservableObject
    {
		public ShowDriverCarViewModel() 
		{
            ShowResults = new ObservableCollection<Result>();
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

                    ObservableCollection<Driver> drivers = new ObservableCollection<Driver>();

                    using (FileStream stream = new FileStream(Directory.GetCurrentDirectory() + "/DriverCollection.json", FileMode.OpenOrCreate))
                    {
                        if (stream.Length != 0)
                        {
                            drivers = JsonSerializer.Deserialize<ObservableCollection<Driver>>(stream);
                        }
                        else
                        {
                            MessageBox.Show("DRIVERS COLLECTION IS EMPTY!");
                            return;
                        }
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

                    ObservableCollection<TaxiClass> classes = new ObservableCollection<TaxiClass>();

                    using (FileStream stream = new FileStream(Directory.GetCurrentDirectory() + "/TaxiClassCollection.json", FileMode.OpenOrCreate))
                    {
                        if (stream.Length != 0)
                        {
                            classes = JsonSerializer.Deserialize<ObservableCollection<TaxiClass>>(stream);
                        }
                        else
                        {
                            MessageBox.Show("TAXI CLASSES COLLECTION IS EMPTY!");
                            return;
                        }
                    }

                    ObservableCollection<Driver> driversResult = new ObservableCollection<Driver>();

                    if (InputText[0].Equals('+'))
                    {
                        if (InputText.Length != 13)
                        {
                            MessageBox.Show("INVALID PHONE NUMBER");
                            return;
                        }

                        foreach (var item in drivers)
                        {
                            if (item.Phone == InputText)
                            {
                                driversResult.Add(item);
                            }
                        }

                        if(!driversResult.Any())
                        {
                            MessageBox.Show("DRIVER WITH THIS PHONE NUMBER IS NOT FOUND!");
                            return;
                        }
                    }

                    foreach (var item in drivers)
                    {
                        if ((item.FirstName + " " + item.LastName).Contains(InputText))
                        {
                            driversResult.Add(item);
                        }
                    }

                    if (!driversResult.Any())
                    {
                        MessageBox.Show("DRIVER WITH THIS INFO IS NOT FOUND!");
                        return;
                    }

                    ShowResults = new ObservableCollection<Result>();

                    foreach (var item in driversResult)
                    {
                        Result result = new Result();
                        result.FirstName = item.FirstName;
                        result.LastName = item.LastName;
                        result.Phone = item.Phone;
                        Car temp = default;
                        try
                        {
                            temp = cars.First(obj => obj.IdDriver == item.IdDriver);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("DRIVER HAS NO CAR!");
                            return;
                            throw;
                        }
                        result.CarIndex = temp.CarIndex;
                        result.Brand = temp.Brand;
                        result.Model = temp.Model;
                        result.Number = temp.Number;
                        result.VinCode = temp.VinCode;
                        result.TaxiClass = classes.First(obj => obj.IdTaxiClass == temp.IdTaxiClass).Title;
                        ShowResults.Add(result);
                    }
                }, obj => !string.IsNullOrEmpty(InputText)));
			}
		}

		internal class Result : ObservableObject
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

            private string brand;
            public string Brand
            {
                get { return brand; }
                set
                {
                    brand = value;
                    OnPropertyChanged(nameof(Brand));
                }
            }

            private string model;
            public string Model
            {
                get { return model; }
                set
                {
                    model = value;
                    OnPropertyChanged(nameof(Model));
                }
            }

            private string number;
            public string Number
            {
                get { return number; }
                set
                {
                    number = value;
                    OnPropertyChanged(nameof(Number));
                }
            }

            private string vinCode;
            public string VinCode
            {
                get { return vinCode; }
                set
                {
                    vinCode = value;
                    OnPropertyChanged(nameof(VinCode));
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

        }
	}
}
