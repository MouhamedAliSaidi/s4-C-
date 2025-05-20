class Wine : Drink
{
    public string Region;
    public int BottledYear;

    public Wine(string name, string color, double temp, int calories, string region, int year)
        : base(name, color, temp, false, calories)
    {
        Region = region;
        BottledYear = year;
    }

    public override void ShowDrink()
    {
        base.ShowDrink();
        System.Console.WriteLine("Region: " + Region);
        System.Console.WriteLine("Bottled Year: " + BottledYear);
    }
}
