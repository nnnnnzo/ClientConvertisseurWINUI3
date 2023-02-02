using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientConvertisseurV2.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using WSConvertisseur.Models;

namespace ClientConvertisseurV2.ViewModels
{
    public class BindViewModel: ObservableObject
    {
        public BindViewModel bvm;

       private ObservableCollection<Devise> lesDevises;

        public ObservableCollection<Devise> LesDevises
        {
            get { return lesDevises; }
            set { lesDevises = value; OnPropertyChanged(); }
        }

        private Devise selectedDevise;

        public Devise SelectedDevise
        {
            get { return selectedDevise; }
            set { selectedDevise = value; OnPropertyChanged(); }
        }

        private double montant;

        public double Montant
        {
            get { return montant; }
            set { montant = value; OnPropertyChanged(); }
        }

        private double convertedAmount;

        public double ConvertedAmount
        {
            get { return convertedAmount; }
            set { convertedAmount = value; OnPropertyChanged(); }
        }

        public async void GetDataOnLoadAsync()
        {
            WSService service = new WSService("https://localhost:7063/api/");
            List<Devise> result = await service.GetDevisesAsync("devises");
            if (result == null)
            {
                DisplayNoAPIDialog();
                return;
            }
            else
            {
                LesDevises = new ObservableCollection<Devise>(result);
            }
        }

        public async void DisplayNoAPIDialog()
        {
            ContentDialog noAPIDialog = new ContentDialog
            {
                Title = "Erreur API",
                Content = "API non disponible pour le moment ! Réessayez plus tard.",
                CloseButtonText = "Ok"
            };

            noAPIDialog.XamlRoot = App.MainRoot.XamlRoot;

            ContentDialogResult result = await noAPIDialog.ShowAsync();
        }

        public async void DisplayNoDeviseDialog()
        {
            ContentDialog noDeviseDialog = new ContentDialog
            {
                Title = "Erreur",
                Content = "Vous devez sélectionner une devise.",
                CloseButtonText = "Oui Monsieur"
            };

            noDeviseDialog.XamlRoot = App.MainRoot.XamlRoot;

            ContentDialogResult result = await noDeviseDialog.ShowAsync();
        }
    }
}
