class Soda : Drink
{
    public bool IsDiet;

    public Soda(string name, string color, double temp, int calories, bool isDiet)
        : base(name, color, temp, true, calories) // Sodas are always carbonated
    {
        IsDiet = isDiet;
    }

    public override void ShowDrink()
    {
        base.ShowDrink();
        System.Console.WriteLine("Diet Version: " + IsDiet);
    }
}
