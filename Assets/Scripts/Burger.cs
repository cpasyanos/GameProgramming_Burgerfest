using UnityEngine;

public class Burger
{
    // the number of elements in a burger
    [Range(3, 15)]
    public const int numIngredients = 5;
    public enum fillings { BOTTOM_BUN, TOP_BUN, PATTY, LETTUCE, TOMATO, CHEESE, KETCHUP, MUSTARD, PICKLE };
    public fillings[] ingredients = new fillings[numIngredients];

    public Burger(System.Random pseudoRand)
    {
        InitBurger(pseudoRand);
    }

    public void InitBurger(System.Random pseudoRand)
    {
        ResetBurger();
        GenerateBurger(pseudoRand);
    }
    public void ResetBurger()
    {
        ingredients = new fillings[numIngredients];
    }
    public void GenerateBurger(System.Random pseudoRand)
    {
        ingredients[0] = fillings.BOTTOM_BUN;
        ingredients[numIngredients - 1] = fillings.TOP_BUN;
        for (int i = 1; i < numIngredients - 1; i++)
        {
            // choose fillings randomly
            int nextRand = pseudoRand.Next(0, 100);

            if (nextRand < 40)
            {
                ingredients[i] = fillings.PATTY;
            }
            else if (nextRand < 52)
            {
                ingredients[i] = fillings.LETTUCE;
            }
            else if (nextRand < 64)
            {
                ingredients[i] = fillings.TOMATO;
            }
            else if (nextRand < 76)
            {
                ingredients[i] = fillings.CHEESE;
            }
            else if (nextRand < 88)
            {
                ingredients[i] = fillings.KETCHUP;
            }
            else
            {
                ingredients[i] = fillings.MUSTARD;
            }
        }
    }
    public override string ToString()
    {
        string built = "";

        for (int i = 0; i < numIngredients; i++)
        {
            built += "\n";
            switch (ingredients[i])
            {
                case fillings.BOTTOM_BUN:
                    built += "- Bottom bun";
                    break;
                case fillings.TOP_BUN:
                    built += "- Top bun";
                    break;
                case fillings.PATTY:
                    built += "- Patty";
                    break;
                case fillings.LETTUCE:
                    built += "- Lettuce";
                    break;
                case fillings.TOMATO:
                    built += "- Tomato";
                    break;
                case fillings.CHEESE:
                    built += "- Cheese";
                    break;
                case fillings.KETCHUP:
                    built += "- Ketchup";
                    break;
                case fillings.MUSTARD:
                    built += "- Mustard";
                    break;
            }
        }
        return built;
    }
}