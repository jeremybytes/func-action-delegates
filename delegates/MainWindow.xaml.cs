using System.Windows;

namespace delegates;

public partial class MainWindow : Window
{
    private Func<Person, string>? formatter;
    //private Action<List<Person>>? processor;

    public MainWindow()
    {
        InitializeComponent();
        PersonListBox.ItemsSource = People.GetPeople();
    }

    private Func<Person, string>? GetFormatter()
    {
        if (DefaultStringButton.IsChecked!.Value)
            return p => p.ToString();

        if (FamilyNameStringButton.IsChecked!.Value)
            return p => p.FamilyName.ToUpper();

        if (GivenNameStringButton.IsChecked!.Value)
            return p => p.GivenName.ToLower();

        if (FullNameStringButton.IsChecked!.Value)
            return p => $"{p.FamilyName}, {p.GivenName}";

        return null;
    }

    private Action<List<Person>> GetAction()
    {
        Action<List<Person>> action = p => { };

        if (BestCommanderCheckBox.IsChecked!.Value)
            action += p => MessageBox.Show(
                p.MaxBy(r => r.Rating)!.ToString());

        if (AverageRatingCheckBox.IsChecked!.Value)
            action += p => AddToList(
                p.Average(r => r.Rating).ToString("#.#"));

        if (EarliestStartDateCheckBox.IsChecked!.Value)
            action += p => AddToList(
                p.Min(s => s.StartDate).ToString("d"));

        if (FirstLettersCheckBox.IsChecked!.Value)
            action += p =>
            {
                string output = "";
                p.ForEach(c => output += c.FamilyName[0]);
                AddToList(output);
            };

        return action;
    }

    private void ProcessDataButton_Click(object sender, RoutedEventArgs e)
    {
        OutputList.Items.Clear();

        var people = People.GetPeople();

        if (StringExpander.IsExpanded)
        {
            formatter = GetFormatter();
            foreach (var person in people)
                AddToList(person.ToString(formatter));
        }
        if (ActionExpander.IsExpanded)
        {
            // DO NOT DO THIS
            // unless you really hate your co-workers
            GetAction()(people);
        }
    }

    private void AddToList(string item)
    {
        OutputList.Items.Add(item);
    }
}
