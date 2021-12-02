using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Inventory : MonoBehaviour
{

    private List<OnInventoryChangeDelegate> _inventorySubscriber = new List<OnInventoryChangeDelegate>();
    
    
    
    
    
    public delegate void OnInventoryChangeDelegate(int previousValue, int newValue);
    
    public int maxInventorySize;

    [HideInInspector]public int currentInventorySize;

    private int inventoryCount;
    
    
    public int money;
    
    
    private bool itemExists = false;
    
    private List<Item> Inventory1;

    public Inventory(List<Item> inventory1)
    {
        Inventory1 = inventory1;
    }


    public int CurrentInventorySize
    {
        set
        {
            var previousValue = currentInventorySize;
            currentInventorySize = value;
            
            foreach (var subscriber in _inventorySubscriber)
            {
                subscriber(previousValue, value);
            }
        }
        get => currentInventorySize;
    }


    public event OnInventoryChangeDelegate OnInventoryChange
    {
        add => _inventorySubscriber.Add(value);
        remove => _inventorySubscriber.Remove(value);
    }


    private void Start()
    {
        _inventorySubscriber = new List<OnInventoryChangeDelegate>();
    }


    public void AddToInventory(Item item, int amount)
    {
        foreach (var itemInInventory in Inventory1)
        {
            if (item.itemName == itemInInventory.itemName)
            {
                Debug.Log("found duplicate");
                itemExists = true;
                if (item.stackable)
                {
                    var founditem = itemInInventory;
                    founditem.amount += amount;
                    Debug.Log($"Item : {item} , Amount: {founditem.amount}");
                }
                
            }
        }
        
        if (!itemExists && Inventory1.Count<maxInventorySize)
        {
            Inventory1.Add(item);
            currentInventorySize++;
            Debug.Log($"Adding {item} to inventory");
        }

        if (itemExists && !item.stackable)
        {
            if (Inventory1.Count < maxInventorySize)
            {
                Inventory1.Add(item);
                currentInventorySize++;
            }

            if (Inventory1.Count > maxInventorySize)
            {
                Debug.Log("inventory is full");
            }
        }

        itemExists = false;
        Debug.Log($"Inventory Size: {Inventory1.Count}");
    }
}
