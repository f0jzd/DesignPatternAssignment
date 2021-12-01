using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject item;
    public string itemName;
    public bool stackable;
    public int amount;
    public float value;


    //public virtual bool Stackable { get; set; }
    //public string Amount { get; set; }
}
