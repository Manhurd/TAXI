using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using TAXI.General;
using TAXI.Models;

namespace TAXI.Modules.AddTaxiClass
{
    public class AddTaxiClassViewModel : ObservableObject
    {
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string pricePerKilometer;
        public string PricePerKilometer
        {
            get { return pricePerKilometer; }
            set
            {
                pricePerKilometer = value;
                OnPropertyChanged(nameof(PricePerKilometer));
            }
        }

        private RelayCommand addTaxiClass;
        public RelayCommand AddTaxiClass
        {
            get
            {
                return addTaxiClass ?? (addTaxiClass = new RelayCommand(obj =>
                {
                    float price = 0;

                    try
                    {
                        price = float.Parse(PricePerKilometer);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("PRICE IS INVALID!");
                        return;
                        throw;
                    }

                    ObservableCollection<TaxiClass> taxiClasses = new ObservableCollection<TaxiClass>();

                    using (FileStream stream = new FileStream(Directory.GetCurrentDirectory() + "/TaxiClassCollection.json", FileMode.OpenOrCreate))
                    {
                        if (stream.Length != 0)
                        {
                            taxiClasses = JsonSerializer.Deserialize<ObservableCollection<TaxiClass>>(stream);
                        }
                    }

                    foreach (var item in taxiClasses)
                    {
                        if (item.Title == Title)
                        {
                            MessageBox.Show("TAXI CLASS WITH THIS TITLE ALREADY REGISTERED!");
                            return;
                        }
                    }

                    var newTaxiClass = new TaxiClass(Title, price);

                    taxiClasses.Add(newTaxiClass);

                    var jsonText = JsonSerializer.Serialize(taxiClasses);

                    File.WriteAllText(Directory.GetCurrentDirectory() + "/TaxiClassCollection.json", jsonText);

                    MessageBox.Show("TAXI CLASS REGISTERED!");

                }, obj => !string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(PricePerKilometer)));
            }
        }
    }
}
