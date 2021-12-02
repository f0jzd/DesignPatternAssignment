using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class MerchantStore : MonoBehaviour
{
    public Button healthButton;
    public Button manaButton;
    public Button swordButton;
    
    private Inventory playerInventory;
    private int _observedInventoryCount;
    
    public Item HealthPotion;
    public Item ManaPotion;
    public Item Sword;

    public Transform[] spawnLocations;


    private Item[] merchantPool;
    //private List<Item> merchantPool;


    private void ObjectPoolWarmup()
    {
        merchantPool = new Item[3];
        
        
        var hpPot = Instantiate(HealthPotion, spawnLocations[0]);
        var mpPot = Instantiate(ManaPotion,spawnLocations[1]);
        var sword = Instantiate(Sword,spawnLocations[2]);//Maybe instead of clone, instatiate the prefab to keep it between scenes?

        hpPot.gameObject.SetActive(false);
        mpPot.gameObject.SetActive(false);
        sword.gameObject.SetActive(false);
        
        merchantPool[0] = hpPot;
        merchantPool[1] = mpPot;
        merchantPool[2] = sword;
    }

    public Item ObjectPoolSpawn(int arrayIndex)
    {
        var result = merchantPool[arrayIndex];
        result.gameObject.SetActive(true);
        return result;
    }

    public void ObjectPoolreturn(Item go)
    {
        Debug.Log(go);
        
        go.gameObject.SetActive(false);
    }

    
    private void Start()
    {

        playerInventory = FindObjectOfType<Inventory>();
        playerInventory.OnInventoryChange += (previousValue, newValue) => {
            Debug.Log($"Inventory size change from {previousValue} to {newValue}");
            _observedInventoryCount = newValue;

        };
        
        
        
        
        ObjectPoolWarmup();

        for (int i = 0; i < merchantPool.Length; i++)
        {
            ObjectPoolSpawn(i);
        }
        
        
        
        swordButton.onClick.AddListener(BuySword);
        healthButton.onClick.AddListener(BuyHealthPotion);
        manaButton.onClick.AddListener(BuyManaPotion);
        
    }
    
    private void BuyHealthPotion()
    {

        var item = ObjectPoolSpawn(0);
        
        
        playerInventory.AddToInventory(item,1);
    }
    private void BuyManaPotion()
    {
        playerInventory.AddToInventory(ObjectPoolSpawn(1),1);
    }
    private void BuySword()
    {
        playerInventory.AddToInventory(ObjectPoolSpawn(2),1);
        
        ObjectPoolreturn(ObjectPoolSpawn(2));
        swordButton.gameObject.SetActive(false);
        
        
    }
}

