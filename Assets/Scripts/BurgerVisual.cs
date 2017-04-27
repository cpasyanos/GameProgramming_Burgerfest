using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BurgerVisual : MonoBehaviour
{

    public Sprite[] burgerImageAssets = new Sprite[8];
    public Image[] burgerImageObjects = new Image[Burger.numIngredients];

    public void ResetImages()
    {
        for (int i = 0; i < Burger.numIngredients; i++)
        {
            burgerImageObjects[i].sprite = null;
        }
    }

    public void UpdateBurgerImages(Burger burger)
    {
        for (int i = 0; i < Burger.numIngredients; i++)
        {
            // set the sprites of the gameojbects to the sprites corresponding to the ingredients
            int fillType = (int)burger.ingredients[i];
            burgerImageObjects[i].sprite = burgerImageAssets[fillType];
        }
    }
}
