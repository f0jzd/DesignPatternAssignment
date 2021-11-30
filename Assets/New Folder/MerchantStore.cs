using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class MerchantStore : MonoBehaviour
{
    public Button healthButton;
    public Button manaButton;
    public Button swordButton;

    public Text amountOfHealthPots;
    public Text amountOfManaPotions;

    private List<Potion> healthPotions = new List<Potion>();
    private List<Potion> manaPotions = new List<Potion>();
    
    StoreManager storeManager = new StoreManager();


    private Inventory playerInventory;
    [SerializeField]private Item HealthPotion;
    [SerializeField]private Item Sword;
    


    public enum PotionType
    {
        Health,
        Mana
    }

    public class Potion
    {
        private PotionType PotionType;
        private int level;

        public int Level
        {
            get => level;
            set => level = value;
        }

        public PotionType PotionType1 => PotionType;

        public Potion Clone()
        {
            return (Potion) MemberwiseClone();
        }

    }

    public class StoreManager
    {
        private Potion HealthPotionStandard;
        private Potion ManaPotionStandard;

        public StoreManager()
        {
            HealthPotionStandard = new Potion();
            ManaPotionStandard = new Potion();
        }


        public Potion BuyPotion(PotionType type, int level)
        {
            switch (type)
            {
                case PotionType.Health:
                    var potion = HealthPotionStandard.Clone();
                    potion.Level = level;
                    return potion;
                case PotionType.Mana:
                    potion = HealthPotionStandard.Clone();
                    potion.Level = level;
                    return potion;
                default:
                    Debug.Log("Something went wrong");
                    return null;
            }
        }

    }


    private void Start()
    {
        playerInventory = FindObjectOfType<Inventory>();
        
        amountOfHealthPots.text = healthPotions.Count.ToString();
        amountOfManaPotions.text = manaPotions.Count.ToString();
        
        swordButton.onClick.AddListener(BuySword);
        healthButton.onClick.AddListener(BuyHealthPotion);
        manaButton.onClick.AddListener(BuyManaPotion);
        
    }

    private void BuyManaPotion()
    {
        
        var manaPot = storeManager.BuyPotion(PotionType.Health, 10);
        manaPotions.Add(manaPot);
        amountOfHealthPots.text = healthPotions.Count.ToString();
        amountOfManaPotions.text = manaPotions.Count.ToString();
    }

    private void BuyHealthPotion()
    {
        
        
        playerInventory.AddToInventory(HealthPotion);
        
        var helfPotion = storeManager.BuyPotion(PotionType.Health, 10);
        healthPotions.Add(helfPotion);
        amountOfHealthPots.text = healthPotions.Count.ToString();
        amountOfManaPotions.text = manaPotions.Count.ToString();
    }

    private void BuySword()
    {
        playerInventory.AddToInventory(Sword);
    }
}

