using System;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Inventory : MonoBehaviour
{
    

    public int maxInventorySize;

    [HideInInspector]public int currentInventorySize;

    private int inventoryCount;

    public delegate void OnMoneyChangeDelegate(int previousValue, int newValue);
    
    public event OnMoneyChangeDelegate onMoneyChange
    {
        add => _moneySubscribers.Add(value);
        remove => _moneySubscribers.Remove(value);
    }

    private List<OnMoneyChangeDelegate> _moneySubscribers = new List<OnMoneyChangeDelegate>();
    public int _playerMoney;

    public int PlayerMoney
    {
        set
        {
            var previousValue = _playerMoney;
            _playerMoney = value;

            foreach (var subscriber in _moneySubscribers)
                subscriber(previousValue, value);
            
        }
        get => _playerMoney;
    }
    
    
    private bool itemExists = false;

    private List<Item> Inventory1 = new List<Item>();


    


    public void AddToInventory(Item item, int amount)
    {
        foreach (var itemInInventory in Inventory1)
        {
            if (item.itemName == itemInInventory.itemName)
            {
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
