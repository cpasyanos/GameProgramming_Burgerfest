using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// generates and manages new burger order gameobjects
/// uses an archetype for gameobject pool
/// </summary>
public class BurgerGenerator : UnitySingleton<BurgerGenerator>
{
    public GameObject OrderPrefab;
    public int maxOrders = 5;
    private Transform myTransform;

    private Dictionary<Burger, GameObject> Used = new Dictionary<Burger, GameObject>();
    private Dictionary<Burger, GameObject> Unused = new Dictionary<Burger, GameObject>();

    private System.Random pseudoRand = new System.Random();

    // foreach burger in burgers
    // foreach ingredient in burger
    // if count is at least that much
    // break
    // else keep looping


    // Use this for initialization
    private void Start()
    {
        myTransform = this.gameObject.transform;
        initGameObjectPool();
        StartCoroutine(burgerGeneratorTimer());
    }


    /// <summary>
    /// checks if there's an order that matches what was served on the plate. if so, remove it from the list of active orders.
    /// </summary>
    public bool TryRemoveMatchingBurger(Dictionary<Burger.fillings, int> ingredientHistogram)
    {
        bool ret = false;
        Burger match = null;
        for (int i = 0; i < Used.Keys.Count(); i++)
        {
            if (Used.Keys.ElementAt(i).HistogramEquals(ingredientHistogram))
            {
                ret = true;
                match = Used.Keys.ElementAt(i);
                break;
            }
        }
        if (match != null)
        {
            ReturnOrderToUnused(match);
        }
        return ret;
    }


    private void initGameObjectPool()
    {
        for (int i = 0; i < maxOrders; i++)
        {
            AddCapacity();
        }
    }

    /// <summary>
    /// generates new burgers if needed
    /// </summary>
    private void AddCapacity()
    {
        Burger burger = new Burger(pseudoRand);
        GameObject order = Instantiate(OrderPrefab);
        order.transform.SetParent(myTransform, false);
        order.SetActive(false);
        Unused.Add(burger, order);
    }

    /// <summary>
    /// grabs the next object from the unused collection and generates a new order from it
    /// </summary>
    private void GenerateNewOrder()
    {
        if (Unused.Count == 0)
        {
            return;
        }
        var poppedObject = Unused.First();
        Burger burger = poppedObject.Key;
        BurgerVisual burgerVis = poppedObject.Value.GetComponentInChildren<BurgerVisual>();
        Unused.Remove(burger);
        burger.InitBurger(pseudoRand);
        burgerVis.UpdateBurgerImages(burger);
        Used.Add(poppedObject.Key, poppedObject.Value);
        poppedObject.Value.SetActive(true);
    }

    /// <summary>
    /// resets the order and puts it back to the unused collection
    /// </summary>
    private void ReturnOrderToUnused(Burger usedOrder)
    {
        GameObject returnedObject;
        if (!Used.TryGetValue(usedOrder, out returnedObject))
        {
            Debug.LogError("removing order that wasn't in the used pool!");
            return;
        }
        Used.Remove(usedOrder);
        returnedObject.SetActive(false);
        Unused.Add(usedOrder, returnedObject);
    }

    private IEnumerator burgerGeneratorTimer()
    {
        while(true)
        {
            GenerateNewOrder();
            yield return new WaitForSeconds(10);
        }
    }
}
