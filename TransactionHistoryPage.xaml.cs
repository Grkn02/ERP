using ERP.ViewModels;

namespace ERP.Views;

public partial class TransactionHistoryPage : ContentPage
{
	public TransactionHistoryPage(TransactionHistoryViewModel viewModel )
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}