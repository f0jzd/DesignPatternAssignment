using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]private GameObject item;
    [SerializeField]private String itemName;
    [SerializeField]private bool stackable;
    [SerializeField] private int amount;
    [SerializeField]private float value;
    
    public GameObject Item1 { get; set ; }

    public string ItemName { get; set ; }

    public bool Stackable { get; set ; }
    
    public int Amount { get; set; }

    public float Value{ get; set ; }
}
