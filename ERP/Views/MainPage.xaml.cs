using ERP.ViewModels;
using System.Xml.Linq;
namespace ERP.Views;

[QueryProperty(nameof(Name), "Name")]
[QueryProperty(nameof(Surname), "Surname")]
public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;



    }

    public string Name
    {
        set
        {
            var viewModel = BindingContext as MainViewModel;
            if (viewModel != null)
            {
                viewModel.Name = value;
            }
        }
    }

    public string Surname
    {
        set
        {
            var viewModel = BindingContext as MainViewModel;
            if (viewModel != null)
            {
                viewModel.Surname = value;
            }
        }

    }
}

