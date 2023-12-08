using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TAXI.General;
using TAXI.Modules.AddCar;
using TAXI.Modules.AddClient;
using TAXI.Modules.AddDriver;
using TAXI.Modules.AddRide;
using TAXI.Modules.AddTaxiClass;
using TAXI.Modules.ShowClient;
using TAXI.Modules.ShowDriverCar;
using TAXI.Modules.ShowRides;

namespace TAXI.Modules.MainWindow
{
    public class MainWindowViewModel : ObservableObject
    {
        private readonly ContentControl contentControl;
		private readonly Window mainWindow;

        private readonly StartPageView startPageView;

		private readonly AddTaxiClassView addTaxiClassView;
		private readonly AddDriverView addDriverView;
		private readonly AddClientView addClientView;
		private readonly AddRideView addRideView;
		private readonly AddCarView addCarView;

        private readonly ShowClientView showClientView;
        private readonly ShowRidesView showRidesView;
        private readonly ShowDriverCarView showDriverCarView;

        public MainWindowViewModel(Window mainWindow, ContentControl contentControl)
        {
            this.contentControl = contentControl;
            this.mainWindow = mainWindow;

            startPageView = new StartPageView();
            this.contentControl.Content = startPageView;

			addTaxiClassView = new AddTaxiClassView();
			addDriverView = new AddDriverView();
			addClientView = new AddClientView();
			addRideView = new AddRideView();
			addCarView = new AddCarView();

            showClientView = new ShowClientView();
            showRidesView = new ShowRidesView();
            showDriverCarView = new ShowDriverCarView();
        }

		private RelayCommand navigateToAddTaxiClass;
		public RelayCommand NavigateToAddTaxiClass
		{
			get
			{
				return navigateToAddTaxiClass ?? (navigateToAddTaxiClass = new RelayCommand(obj =>
				{

					contentControl.Content = addTaxiClassView;

				}, obj => true));
			}
		}

        private RelayCommand navigateToAddDriver;
        public RelayCommand NavigateToAddDriver
        {
            get
            {
                return navigateToAddDriver ?? (navigateToAddDriver = new RelayCommand(obj =>
                {

                    contentControl.Content = addDriverView;

                }, obj => true));
            }
        }

        private RelayCommand navigateToAddClient;
        public RelayCommand NavigateToAddClient
        {
            get
            {
                return navigateToAddClient ?? (navigateToAddClient = new RelayCommand(obj =>
                {

                    contentControl.Content = addClientView;

                }, obj => true));
            }
        }

        private RelayCommand navigateToAddCar;
        public RelayCommand NavigateToAddCar
        {
            get
            {
                return navigateToAddCar ?? (navigateToAddCar = new RelayCommand(obj =>
                {

                    contentControl.Content = addCarView;

                }, obj => true));
            }
        }

        private RelayCommand navigateToAddRide;
        public RelayCommand NavigateToAddRide
        {
            get
            {
                return navigateToAddRide ?? (navigateToAddRide = new RelayCommand(obj =>
                {

                    contentControl.Content = addRideView;

                }, obj => true));
            }
        }

        private RelayCommand navigateToShowClient;
        public RelayCommand NavigateToShowClient
        {
            get
            {
                return navigateToShowClient ?? (navigateToShowClient = new RelayCommand(obj =>
                {

                    contentControl.Content = showClientView;

                }, obj => true));
            }
        }

        private RelayCommand navigateToShowRides;
        public RelayCommand NavigateToShowRides
        {
            get
            {
                return navigateToShowRides ?? (navigateToShowRides = new RelayCommand(obj =>
                {

                    contentControl.Content = showRidesView;

                }, obj => true));
            }
        }

        private RelayCommand navigateToShowDriverCar;
        public RelayCommand NavigateToShowDriverCar
        {
            get
            {
                return navigateToShowDriverCar ?? (navigateToShowDriverCar = new RelayCommand(obj =>
                {

                    contentControl.Content = showDriverCarView;

                }, obj => true));
            }
        }

        private RelayCommand close;
		public RelayCommand Close
		{
			get
			{
				return close ?? (close = new RelayCommand(obj =>
				{

					mainWindow.Close();

				}, obj => true));
			}
		}

		private RelayCommand minimize;
		public RelayCommand Minimize
		{
			get
			{
				return minimize ?? (minimize = new RelayCommand(obj =>
				{

					mainWindow.WindowState = WindowState.Minimized;

				}, obj => true));
			}
		}
	}
}
