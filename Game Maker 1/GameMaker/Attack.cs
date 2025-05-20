class Attack
{
    string name;
    public string _name { get { return name; } }

    int damageAmount;
    public int _damageAmount { get { return damageAmount; } }

    public Attack(string n, int d)
    {
        name = n;
        damageAmount = d;
    }
}
