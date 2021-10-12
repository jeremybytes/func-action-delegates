﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;

namespace delegates
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PersonListBox.ItemsSource = People.GetPeople();
        }

        private Func<Person, string> formatter;
        //private Action<List<Person>> processor;

        private Func<Person, string> GetFormatter()
        {
            if (DefaultStringButton.IsChecked.Value)
                return p => p.ToString();

            if (FamilyNameStringButton.IsChecked.Value)
                return p => p.FamilyName.ToUpper();


            if (GivenNameStringButton.IsChecked.Value)
                return p => p.GivenName.ToLower();

            if (FullNameStringButton.IsChecked.Value)
                return p => $"{p.FamilyName}, {p.GivenName}";

            return null;
        }

        private Action<List<Person>> GetProcessor()
        {
            Action<List<Person>> action = null;

            if (BestCommanderCheckBox.IsChecked.Value)
                action += p => MessageBox.Show(
                    p.OrderByDescending(r => r.Rating).First().ToString());

            if (AverageRatingCheckBox.IsChecked.Value)
                action += p => AddToList(
                    p.Average(r => r.Rating).ToString("#.#"));

            if (EarliestStartDateCheckBox.IsChecked.Value)
                action += p => AddToList(
                    p.Min(s => s.StartDate).ToString("d"));

            if (FirstLettersCheckBox.IsChecked.Value)
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
                {
                    AddToList(person.ToString(formatter));
                }
            }
            if (ActionExpander.IsExpanded)
            {
                // DO NOT DO THIS
                // (unless you hate your co-workers)
                GetProcessor()?.Invoke(people);
            }
        }

        private void AddToList(string item)
        {
            OutputList.Items.Add(item);
        }
    }
}
