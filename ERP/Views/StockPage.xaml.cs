using ERP.Services;
using ERP.ViewModels;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ERP.Views;

public partial class StockPage : ContentPage
{
    
    
    public StockPage( StockViewModel viewModel) // DI ile aldýk nesnesini
    {
        
        InitializeComponent();
        BindingContext = viewModel;



    }

    
}




