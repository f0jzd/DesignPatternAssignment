using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]private GameObject item;
    [SerializeField]private String itemName;
    [SerializeField]private bool stackable;
    [SerializeField]private float value;


    public GameObject Item1
    {
        get => item;
        set => item = value;
    }

    public string ItemName
    {
        get => itemName;
        set => itemName = value;
    }

    public bool Stackable
    {
        get => stackable;
        set => stackable = value;
    }

    public float Value
    {
        get => value;
        set => this.value = value;
    }
}
