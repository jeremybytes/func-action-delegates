namespace delegates;

public static class People
{
    public static List<Person> GetPeople()
    {
        var p = new List<Person>()
        {
            new Person(1, "John", "Koenig", new DateTime(1975, 10, 17), 6, ""),
            new Person(2, "Dylan", "Hunt", new DateTime(2000, 10, 2), 8, ""),
            new Person(3, "Leela", "Turanga", new DateTime(1999, 3, 28), 8, "{1} {0}"),
            new Person(4, "John", "Crichton", new DateTime(1999, 3, 19), 7, ""),
            new Person(5, "Dave", "Lister", new DateTime(1988, 2, 15), 9, ""),
            new Person(6, "Laura", "Roslin", new DateTime(2003, 12, 8), 6, ""),
            new Person(7, "John", "Sheridan", new DateTime(1994, 1, 26), 6, ""),
            new Person(8, "Dante", "Montana", new DateTime(2000, 11, 1), 5, ""),
            new Person(9, "Isaac", "Gampu", new DateTime(1977, 9, 10), 4, ""),
        };
        return p;
    }
}

// public delegate string  PersonFormatter        (Person person);
// public delegate TResult Func<in T, out TResult>(T arg);

public record Person(int Id, string GivenName, string FamilyName,
    DateTime StartDate, int Rating, string FormatString = "")
{
    public string ToString(Func<Person, string>? formatter)
    {
        if (formatter == null)
            return this.ToString();
        return formatter(this);
    }

    public override string ToString()
    {
        if (string.IsNullOrEmpty(FormatString))
            return $"{GivenName} {FamilyName}";
        return string.Format(FormatString, GivenName, FamilyName);
    }
}
