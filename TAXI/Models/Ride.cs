using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TAXI.General;

namespace TAXI.Models
{
    public class Ride : ObservableObject
    {
		private Guid idRide;
		public Guid IdRide
		{
			get { return idRide; }
			set
			{
				idRide = value;
				OnPropertyChanged(nameof(IdRide));
			}
		}

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

        private float travelDistance;
        public float TravelDistance
        {
            get { return travelDistance; }
            set
            {
                travelDistance = value;
                OnPropertyChanged(nameof(TravelDistance));
            }
        }

        private float travelPrice;
        public float TravelPrice
        {
            get { return travelPrice; }
            set
            {
                travelPrice = value;
                OnPropertyChanged(nameof(TravelPrice));
            }
        }

        public Ride(Guid idClient, Guid idCar, Guid idDriver, Guid idTaxiClass, string departurePoint, string destinationPoint, float travelDistance, float travelPrice)
        {
            IdRide = Guid.NewGuid();
            IdClient = idClient;
            IdCar = idCar;
            IdDriver = idDriver;
            IdTaxiClass = idTaxiClass;
            DeparturePoint = departurePoint;
            DestinationPoint = destinationPoint;
            TravelDistance = travelDistance;
            TravelPrice = travelPrice;
        }

        [JsonConstructor]
        public Ride(Guid idRide, Guid idClient, Guid idCar, Guid idDriver, Guid idTaxiClass, string departurePoint, string destinationPoint, float travelDistance, float travelPrice)
        {
            IdRide = idRide;
            IdClient = idClient;
            IdCar = idCar;
            IdDriver = idDriver;
            IdTaxiClass = idTaxiClass;
            DeparturePoint = departurePoint;
            DestinationPoint = destinationPoint;
            TravelDistance = travelDistance;
            TravelPrice = travelPrice;
        }
    }
}
