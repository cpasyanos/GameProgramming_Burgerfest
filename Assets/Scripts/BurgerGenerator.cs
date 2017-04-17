using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// generates and manages new burger order gameobjects
/// uses an archetype for gameobject pool
/// </summary>
public class BurgerGenerator : MonoBehaviour
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
    void Start()
    {
        myTransform = this.gameObject.transform;
        initGameObjectPool();
    }

    private void initGameObjectPool()
    {
        for (int i = 0; i < maxOrders; i++)
        {
            AddCapacity();
        }
    }

    private void AddCapacity()
    {
        Burger burger = new Burger(pseudoRand);
        GameObject order = Instantiate(OrderPrefab);
        order.transform.SetParent(myTransform, false);
        order.SetActive(false);
        Unused.Add(burger, order);
    }

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

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateNewOrder();
        }
    }
}
