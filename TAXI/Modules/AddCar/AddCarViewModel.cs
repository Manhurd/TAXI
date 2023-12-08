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

namespace TAXI.Modules.AddCar
{
    class AddCarViewModel : ObservableObject
    {

        private string driverFullName;
        public string DriverFullName
        {
            get { return driverFullName; }
            set
            {
                driverFullName = value;
                OnPropertyChanged(nameof(DriverFullName));
            }
        }

        private string driverPhone;
        public string DriverPhone
        {
            get { return driverPhone; }
            set
            {
                driverPhone = value;
                OnPropertyChanged(nameof(DriverPhone));
            }
        }

        private string classTitle;
        public string ClassTitle
        {
            get { return classTitle; }
            set
            {
                classTitle = value;
                OnPropertyChanged(nameof(ClassTitle));
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

        private RelayCommand addCar;
        public RelayCommand AddCar
        {
            get
            {
                return addCar ?? (addCar = new RelayCommand(obj =>
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

                    Driver driver = default;

                    bool driverIsFounded = false;

                    foreach (var item in drivers)
                    {
                        var fullname = item.FirstName + " " + item.LastName;

                        if(fullname == DriverFullName && item.Phone == DriverPhone)
                        {
                            driver = item;
                            driverIsFounded = true;
                            break;
                        }
                    }

                    if (!driverIsFounded)
                    {
                        MessageBox.Show("DRIVER NOT FOUND!");
                        return;
                    }

                    TaxiClass taxiClass = default;

                    bool classIsFounded = false;

                    foreach (var item in classes)
                    {
                        if (item.Title == ClassTitle)
                        {
                            taxiClass = item;
                            classIsFounded = true;
                            break;
                        }
                    }

                    if (!classIsFounded)
                    {
                        MessageBox.Show("TAXI CLASS NOT FOUND!");
                        return;
                    }

                    ObservableCollection<Car> cars = new ObservableCollection<Car>();

                    using (FileStream stream = new FileStream(Directory.GetCurrentDirectory() + "/CarCollection.json", FileMode.OpenOrCreate))
                    {
                        if (stream.Length != 0)
                        {
                            cars = JsonSerializer.Deserialize<ObservableCollection<Car>>(stream);
                        }
                    }

                    foreach (var item in cars)
                    {
                        if (item.Number == Number || item.VinCode == VinCode)
                        {
                            MessageBox.Show("CAR WITH THIS INFORMATION ALREADY REGISTERED!");
                            return;
                        }
                    }

                    var newCar = new Car(driver.IdDriver, taxiClass.IdTaxiClass, cars.Count + 1, Brand, Model, Number, VinCode);

                    cars.Add(newCar);

                    var jsonText = JsonSerializer.Serialize(cars);

                    File.WriteAllText(Directory.GetCurrentDirectory() + "/CarCollection.json", jsonText);

                    MessageBox.Show("CAR REGISTERED!");

                }, obj => !string.IsNullOrEmpty(DriverFullName) && DriverPhone != null && DriverPhone.Length == 13 && !string.IsNullOrEmpty(ClassTitle) && !string.IsNullOrEmpty(Brand) && !string.IsNullOrEmpty(Model) && Number != null && Number.Length == 8 && VinCode != null && VinCode.Length == 17));
            }
        }
    }
}
