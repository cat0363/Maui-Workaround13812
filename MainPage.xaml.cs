using System.Collections.ObjectModel;

namespace Maui_Workaround13812;

public partial class MainPage : ContentPage
{
    public class ListItem {
        public string ItemName { get; set; }
    }

    private ObservableCollection<ListItem> ListItems = new ObservableCollection<ListItem>();

    public MainPage()
	{
		InitializeComponent();

        ListItems.Add(new ListItem() { ItemName = "Item 1" });
        ListItems.Add(new ListItem() { ItemName = "Item 2" });
        ListItems.Add(new ListItem() { ItemName = "Item 3" });
        ListItems.Add(new ListItem() { ItemName = "Item 4" });
        ListItems.Add(new ListItem() { ItemName = "Item 5" });
        lvTest.ItemsSource = ListItems;
    }
}

