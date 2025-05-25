class GameActions
{
    private Random random;

    public GameActions()
    {
        random = new Random();
    }

    // Coin Flip
    public string FlipCoin()
    {
        int result = random.Next(2);
        if (result == 0)
        {
            return "Heads";
        }
        else
        {
            return "Tails";
        }
    }

    // Dice Roll 
    public int RollDice(int sides)
    {
        return random.Next(1, sides + 1);
    }

    // Stat Roll 
    public string StatRoll(int count)
    {
        string result = "Rolled values: ";
        int highest = 0;
        for (int i = 0; i < count; i++)
        {
            int roll = RollDice(6);
            result += roll;
            if (i < count - 1)
            {
                result += ", ";
            }
            if (roll > highest)
            {
                highest = roll;
            }
        }
        result += "\nHighest roll: " + highest;
        return result;
    }

    // Roll Until 
    public string RollUntil(int target)
    {
        if (target < 1 || target > 6)
        {
            return "Invalid target number. Please enter a number between 1 and 6.";
        }

        int tries = 0;
        int rolled = 0;

        while (rolled != target)
        {
            rolled = RollDice(6);
            tries++;
        }

        return "Rolled a " + target + " after " + tries + " tries.";
    }

    //test global
    public void Start()
    {
        System.Console.WriteLine("Flip a coin: " + FlipCoin());

        int dice6 = RollDice(6);
        System.Console.WriteLine("Rolled a 6-sided dice: " + dice6);

        System.Console.WriteLine(StatRoll(4));

        System.Console.WriteLine(RollUntil(2));
    }

}
