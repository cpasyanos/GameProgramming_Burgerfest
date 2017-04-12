using System.Collections;
using System.Collections.Generic;
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

    private List<GameObject> Used = new List<GameObject>();
    private List<GameObject> Unused = new List<GameObject>();

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
        GameObject order = Instantiate(OrderPrefab);
        order.transform.SetParent(myTransform, false);
        order.SetActive(false);
        Unused.Add(order);
    }

    private void GenerateNewOrder()
    {
        if (Unused.Count == 0)
        {
            return;
        }
        GameObject poppedObject = Unused[0];
        Unused.RemoveAt(0);
        Used.Add(poppedObject);
        poppedObject.SetActive(true);
    }

    public void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateNewOrder();
        }
        */
    }
}
