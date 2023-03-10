using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public class ConvertisseurEuroViewModel: BindViewModel
    {

        public IRelayCommand BtnSetConversion { get; }
        public ConvertisseurEuroViewModel()
        {
            GetDataOnLoadAsync();
            BtnSetConversion = new RelayCommand(ActionSetConversion);
        }
        public void ActionSetConversion()
        {
            if (SelectedDevise != null)
            {
                ConvertedAmount = Montant * SelectedDevise.Taux;
            }
            else
                bvm.DisplayNoDeviseDialog();
        }


    }
}
