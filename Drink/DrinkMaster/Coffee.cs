class Coffee : Drink
{
    public string RoastLevel;
    public string BeanType;

    public Coffee(string name, string color, double temp, int calories, string roast, string beans)
        : base(name, color, temp, false, calories)
    {
        RoastLevel = roast;
        BeanType = beans;
    }

    public override void ShowDrink()
    {
        base.ShowDrink();
        System.Console.WriteLine("Roast Level: " + RoastLevel);
        System.Console.WriteLine("Bean Type: " + BeanType);
    }
}
