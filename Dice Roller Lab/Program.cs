using System.Reflection.Metadata.Ecma335;
Random random = new Random();
bool runProgram = true;
while (runProgram)
{
    int input = 0;
    int dice1 = 0;
    int dice2 = 0;
    int result = 0;

    Console.WriteLine("How many sides do the dice you want to roll have?");

    if (int.TryParse(Console.ReadLine(), out input) && input > 0)
    {
        DiceRoll(input, out dice1, out dice2, out result);
        if (input == 6)
        {
            Console.WriteLine(ComboRoll6(dice1, dice2));
            Console.WriteLine(SpecialTotal6(dice1, dice2));
        }
        else
        {
            Console.WriteLine(ComboRollAll(dice1, dice2, input));
            Console.WriteLine(SpecialTotalAll(dice1, dice2, input));

        }
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
        continue;
    }

    Console.WriteLine(dice1);
    Console.WriteLine(dice2);
    Console.WriteLine(result);

    while (true)
    {
        Console.WriteLine("Would you like to roll more dice? y/n");
        string answer = Console.ReadLine();
        if (answer == "y")
        {
            break;
        }
        else if (answer == "n")
        {
            runProgram = false;
            break;
        }
        else
        {
            Console.WriteLine("Invalid answer. Please answer y/n.");
        }
    }

}



static void DiceRoll (int range, out int dice1, out int dice2, out int result)
{
    Random random = new Random();
    dice1 = random.Next(1, range + 1);
    dice2 = random.Next(1, range + 1);
    result = dice1 + dice2;
}

static string ComboRoll6 (int dice1, int dice2)
{
    if (dice1 == 1 && dice2 == 1)
    {
        return "Snake Eyes";
    }
    if (dice1 + dice2 == 3)
    {
        return "Ace Deuce";
    }
    if (dice1 == 6 && dice2 == 6)
    {
        return "Box Cars";
    }
    else
    {
        return "";
    }

}

static string SpecialTotal6 (int dice1, int dice2)
{
    int result = dice1 + dice2;
    if (result == 7 || result == 11)
    {
        return "Win";
    }
    if (result == 2 || result == 3 || result == 12)
    {
        return "Craps";
    }
    else
    {
        return "";
    }
}

static string ComboRollAll(int dice1, int dice2, int range)
{
    if (dice1 == dice2)
    {
        return "Duos";
    }
    if (dice1 == 1 && dice2 == range || dice2 == 1 && dice1 == range)
    {
        return "Min Max";
    }
    else
    {
        return "";
    }
}

static string SpecialTotalAll(int dice1, int dice2, int range)
{
    if (dice1 == range && dice2 == range)
    {
        return "Max Roll";
    }
    if (dice1 == 1 && dice2 == 1)
    {
        return "Min Roll";
    }
    else
    {
        return "";
    }
}