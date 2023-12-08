using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TAXI.General;

namespace TAXI.Models
{
    public class Car : ObservableObject
    {
		private Guid idCar;
		public Guid IdCar
		{
			get { return idCar; }
			set
			{
				idCar = value;
				OnPropertyChanged(nameof(IdCar));
			}
		}

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

        private Guid idTaxiClass;
		public Guid IdTaxiClass
		{
			get { return idTaxiClass; }
			set
			{
				idTaxiClass = value;
				OnPropertyChanged(nameof(IdTaxiClass));
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

		public Car(Guid idDriver, Guid idTaxiClass, int carIndex, string brand, string model, string number, string vinCode)
		{
			IdCar = Guid.NewGuid();
			IdDriver = idDriver;
			IdTaxiClass = idTaxiClass;
			CarIndex = carIndex;
			Brand = brand;
			Model = model;
			Number = number;
			VinCode = vinCode;
		}

		[JsonConstructor]
        public Car(Guid idCar, Guid idDriver, Guid idTaxiClass, int carIndex, string brand, string model, string number, string vinCode)
        {
            IdCar = idCar;
            IdDriver = idDriver;
            IdTaxiClass = idTaxiClass;
            CarIndex = carIndex;
            Brand = brand;
            Model = model;
            Number = number;
            VinCode = vinCode;
        }
    }
}
