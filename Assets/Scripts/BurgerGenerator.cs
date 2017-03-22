using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// generates and manages new burger order gameobjects
/// </summary>
public class BurgerGenerator : MonoBehaviour
{

    public enum fillings { BOTTOM_BUN, TOP_BUN, PATTY, LETTUCE, TOMATO, CHEESE, KETCHUP, MUSTARD };
    public Sprite[] burgerImageAssets = new Sprite[8];
    private fillings[] burger = new fillings[numElements];
    public Image[] burgerImageObjects = new Image[numElements];
    public GameObject OrderPrefab;
    private System.Random pseudoRand = new System.Random(seed.GetHashCode());



    private const string seed = "burger up!";

    // the number of elements in a burger
    [Range(3, 15)]
    public const int numElements = 5;

    // These will be used for random filling generation

    // Use this for initialization
    void Start()
    {
        generateBurger();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            generateBurger();
        }
    }


    void generateBurger()
    {

        for (int i = 0; i < numElements; i++)
        {
            // if i is the first element, add a bottom bun
            if (i == 0)
            {
                burger[i] = fillings.BOTTOM_BUN;
            }

            // if it is the last, add the top bun
            else if (i == numElements - 1)
            {
                burger[i] = fillings.TOP_BUN;
            }

            // else choose randomly
            else
            {
                int nextRand = pseudoRand.Next(0, 100);

                if (nextRand < 40)
                {
                    burger[i] = fillings.PATTY;
                }
                else if (nextRand < 52)
                {
                    burger[i] = fillings.LETTUCE;
                }
                else if (nextRand < 64)
                {
                    burger[i] = fillings.TOMATO;
                }
                else if (nextRand < 76)
                {
                    burger[i] = fillings.CHEESE;
                }
                else if (nextRand < 88)
                {
                    burger[i] = fillings.KETCHUP;
                }
                else
                {
                    burger[i] = fillings.MUSTARD;
                }
            }
        }
        GenerateBurgerUi();
        Debug.Log(buildBurgText());
    }

    private void GenerateBurgerUi()
    {
        for(int i = 0; i < numElements;  i++)
        {
            // set the sprites of the gameojbects to the sprites corresponding to the ingredients
            int fillType = (int)burger[i];
            burgerImageObjects[i].sprite = burgerImageAssets[fillType];
        }
    }

    string buildBurgText()
    {
        string built = "";

        for (int i = 0; i < burger.Length; i++)
        {
            built += "\n";
            switch (burger[i])
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
