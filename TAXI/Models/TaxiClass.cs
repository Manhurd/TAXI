using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TAXI.General;

namespace TAXI.Models
{
    public class TaxiClass : ObservableObject
    {

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

		private float pricePerKilometer;
		public float PricePerKilometer
		{
			get { return pricePerKilometer; }
			set
			{
				pricePerKilometer = value;
				OnPropertyChanged(nameof(PricePerKilometer));
			}
		}

		public TaxiClass(string title, float pricePerKilometer)
		{
            IdTaxiClass = Guid.NewGuid();
            Title = title;
            PricePerKilometer = pricePerKilometer;
		}

		[JsonConstructor]
        public TaxiClass(Guid idTaxiClass, string title, float pricePerKilometer)
        {
            IdTaxiClass = idTaxiClass;
            Title = title;
            PricePerKilometer = pricePerKilometer;
        }
    }
}
