using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{


    private Dictionary<Item, int> inventory = new Dictionary<Item, int>();

    //private List<Item> inventory = new List<Item>();
    private Dictionary<Item, int> Inventory1
    {
        get => inventory;
        set => inventory = value;
    }


    public Item AddToInventory(Item item, int amount)
    {
        inventory.Add(item,amount);
        return null;
    }
}
