class Program
{
    static void Main()
    {
        Soda coke = new Soda("Coca-Cola", "Dark Brown", 5.0, 140, false);
        Coffee espresso = new Coffee("Espresso", "Black", 65.0, 5, "Dark", "Arabic");
        Wine merlot = new Wine("Merlot", "Red", 18.0, 120, "Bordeaux", 2018);

        List<Drink> AllBeverages = new List<Drink>();
        AllBeverages.Add(coke);
        AllBeverages.Add(espresso);
        AllBeverages.Add(merlot);

        foreach (Drink d in AllBeverages)
        {
            d.ShowDrink();
            System.Console.WriteLine("--------------------");
        }


    }
}
