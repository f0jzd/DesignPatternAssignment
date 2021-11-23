using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [Range(0,100)]
    public int playerHealth;
    //public float playerHealth;
    //public static Player Instance { get; set; } = new Player();
    
    private Inventory _inventory = new Inventory();
    
    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject().AddComponent<Player>();
            }

            return instance;
        }
    }

    public int PlayerHealth => playerHealth;

    private static Player instance;

    private void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
}