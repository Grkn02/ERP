using ERP.ViewModels;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace ERP.Views;

public partial class StockEntryPage : ContentPage
{
	public StockEntryPage(StockEntryViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
   
}

