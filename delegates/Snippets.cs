/* Formatters 

        public static string Default(Person person)
        {
            return person.ToString();
        }

        public static string FamilyNameToUpper(Person person)
        {
            return person.FamilyName.ToUpper();
        }

        public static string GivenNameToLower(Person person)
        {
            return person.GivenName.ToLower();
        }

        public static string FullName(Person person)
        {
            return $"{person.FamilyName}, {person.GivenName}";
        }

*/

/* Assign Delegate

            if (DefaultStringButton.IsChecked!.Value)
                return Formatters.Default;

            if (FamilyNameStringButton.IsChecked!.Value)
                return Formatters.FamilyNameToUpper;

            if (GivenNameStringButton.IsChecked!.Value)
                return Formatters.GivenNameToLower;

            if (FullNameStringButton.IsChecked!.Value)
                return Formatters.FullName;

            return null;

*/

/* Assign Action

            if (AverageRatingCheckBox.IsChecked!.Value)
                processor += p => AddToList(
                    p.Average(r => r.Rating).ToString("#.#"));

            if (EarliestStartDateCheckBox.IsChecked!.Value)
                processor += p => AddToList(
                    p.Min(s => s.StartDate).ToString("d"));

            if (BestCommanderCheckBox.IsChecked!.Value)
                processor += p => MessageBox.Show(
                    p.MaxBy(r => r.Rating)!.ToString());

            if (FirstLettersCheckBox.IsChecked!.Value)
                processor += p =>
                {
                    string output = "";
                    p.ForEach(c => output += c.FamilyName[0]);
                    AddToList(output);
                };
*/