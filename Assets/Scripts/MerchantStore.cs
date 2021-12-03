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
    [Header("UI Buttons")]
    public Button healthButton;
    public Button manaButton;
    public Button swordButton;
    
    [Header("Item References")]
    public Item HealthPotion;
    public Item ManaPotion;
    public Item Sword;

    [Header("Item Prices")]
    public int HealthPotionCost;
    public int ManaPotionCost;
    public int SwordCost;

    
    [Header("Display Positions")]
    public Transform[] spawnLocations;


    private Item[] merchantPool;
    private Inventory playerInventory;
    private int _observedPlayerMoney;
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
        playerInventory.onMoneyChange += (previousValue, newValue) =>
        {
            Debug.Log($"Money has changed from {previousValue} to {newValue}");
            _observedPlayerMoney = newValue;
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
        
        if (playerInventory.PlayerMoney-HealthPotionCost < 0)
        {
            Debug.Log("Too expensive");
            return;
        }
        
        playerInventory.AddToInventory(ObjectPoolSpawn(0),1);
        playerInventory.PlayerMoney -= HealthPotionCost;


    }
    private void BuyManaPotion()
    {

        if (playerInventory.PlayerMoney-ManaPotionCost < 0)
        {
            Debug.Log("Too expensive");
            return;
        }
        
        playerInventory.AddToInventory(ObjectPoolSpawn(1),1);
        playerInventory.PlayerMoney -= ManaPotionCost;
        
        
        
        
    }
    private void BuySword()
    {
        
        if (playerInventory.PlayerMoney-SwordCost < 0)
        {
            Debug.Log("Too expensive");
            return;
        }
        
        playerInventory.AddToInventory(ObjectPoolSpawn(2),1);
        ObjectPoolreturn(ObjectPoolSpawn(2));
        swordButton.gameObject.SetActive(false);
        
        playerInventory.PlayerMoney -= SwordCost;
        
        
    }

    
}

