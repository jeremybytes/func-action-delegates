using System.Windows;

namespace delegates;

public partial class MainWindow : Window
{

    public MainWindow()
    {
        InitializeComponent();
        PersonListBox.ItemsSource = People.GetPeople();
    }

    private void ProcessDataButton_Click(object sender, RoutedEventArgs e)
    {
        OutputList.Items.Clear();
    }

    private void AddToList(string item)
    {
        OutputList.Items.Add(item);
    }
}
