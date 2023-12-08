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

namespace TAXI.Modules.ShowClient
{
    internal class ShowClientViewModel : ObservableObject
    {
		public ShowClientViewModel() 
		{
            ShowCollection = new ObservableCollection<Client>();
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

		private ObservableCollection<Client> showCollection;
		public ObservableCollection<Client> ShowCollection
		{
			get { return showCollection; }
			set
			{
				showCollection = value;
				OnPropertyChanged(nameof(ShowCollection));
			}
		}

		private RelayCommand showInfo;
		public RelayCommand ShowInfo
		{
			get
			{
				return showInfo ?? (showInfo = new RelayCommand(obj =>
				{
                    ShowCollection = new ObservableCollection<Client>();

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

                    if (InputText[0].Equals('+') && InputText.Length == 13)
                    {
						foreach (var item in clients)
						{
							if (item.Phone == InputText)
							{
								ShowCollection.Add(item);
								return;
							}
						}
                    }

					foreach (var item in clients)
					{
						var fullname = item.FirstName + " " + item.LastName;
						if (fullname.Contains(InputText))
						{
                            ShowCollection.Add(item);
                        }
					}

					if (!ShowCollection.Any())
						MessageBox.Show("CLIENTS NOT FOUND!");

                }, obj => !string.IsNullOrEmpty(InputText)));
			}
		}

	}
}
