using ClientConvertisseurV2.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSConvertisseur.Models;

namespace ClientConvertisseurV2.ViewModels
{
    public class ConvertisseurDeviseViewModel: BindViewModel
    {
        public IRelayCommand BtnSetConversion { get; }
        public ConvertisseurDeviseViewModel()
        {
            GetDataOnLoadAsync();
            BtnSetConversion = new RelayCommand(ActionSetConversion);
        }
        public void ActionSetConversion()
        {
            if (SelectedDevise != null)
            {
                ConvertedAmount = Montant / SelectedDevise.Taux;
            }
            else
                bvm.DisplayNoDeviseDialog();
        }

    }
}
