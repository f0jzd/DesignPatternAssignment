using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Create the player here!
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Player
{
    public string PlayerName { get; }
    public string Race { get; }
    public string PlayerClass { get; }
    
    public Player(string playerName, string race,string playerClass)
    {
        PlayerName = playerName;
        Race = race;
        PlayerClass = playerClass;
    }
    
}

public class PlayerBuilder
{
    
    public string _playerName;
    public string _race;
    public string _playerClass;
    
    //private int _healthRestored; 
    //private int _manaRestored; 
    public PlayerBuilder PlayerName(string playerName)
    {
        _playerName = playerName;
        return this;
    }
    public PlayerBuilder PlayerRace(string race)
    {
        _race = race;
        return this;
    }
    public PlayerBuilder PlayerClass(string playerClass)
    {
        _playerClass = playerClass;
        return this;
    }
    
    public Player PlayerBuild()
    {
        return new Player(_playerName, _race,_playerClass);
    }
    
}
interface IPlayer
{
    
    public string PlayerName { get; set; }
    public string Race { get; set; }
    public string PlayerClass { get; set; }
    
    
    /*string PotionType();
    string HealthRestored { get; set; }
    int ManaRestored{ get; set; }*/
}
class CreatedPlayerClass : IPlayer
{
    public string PotionType()
    {
        return "This is a Mana Potion";
    }
    
    public string PlayerName { get; set; }
    public string Race { get; set; }
    public string PlayerClass { get; set; }
}

class PlayerCreatorSystem
{
    public Player CreatePlayer(int HealthRestored, int ManaRestored)
    {
        return new PlayerBuilder()
            .PlayerName("Pee")
            .PlayerRace("Poo")
            .PlayerClass("Eee")
            .PlayerBuild();
    }
}
