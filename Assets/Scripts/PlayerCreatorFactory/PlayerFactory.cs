using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Debug = UnityEngine.Debug;

public class PlayerFactory : MonoBehaviour
{


    public InputField name;
    public Button submitButton;
    public Button[] choices;

    private string tempName;
    private string tempRace;
    private string tempClass;

    public Player CreatePlayer(string playerName,string playerRace,string playerClass)
    {
        return new PlayerBuilder()
            .PlayerName("Pee")
            .PlayerRace("Poo")
            .PlayerClass("Eee")
            .PlayerBuild();
    }


    public enum State
    {
        ChoosingName,
        SelectingRace,
        SelectingClass,
        EverythingChosen
        
    }

    public enum Event
    {
        ChooseName,
        NameChosen,
        RaceChosen,
        ClassChosen,
        
    }
    
    private State playerState = State.ChoosingName;
    private Event currentEvent = Event.ChooseName;
    
    // Start is called before the first frame update
    
    
    public void Choice1(Event playerEvent)
    {
        switch (playerEvent)
        {
            case Event.ChooseName:
                switch (playerState)
                {
                    case State.ChoosingName:
                    case State.SelectingClass:
                    case State.SelectingRace:
                    case State.EverythingChosen:
                        playerState = State.ChoosingName;
                        break;
                }
                break;
            case Event.NameChosen:
                switch (playerState)
                {
                    case State.ChoosingName:
                        playerState = State.SelectingRace;
                        break;
                }
                break;
            case Event.RaceChosen:
                switch (playerState)
                {
                    case State.SelectingRace: 
                        playerState = State.SelectingClass;
                        break;
                }
                break;
            case Event.ClassChosen:
                switch (playerState)
                {
                    case State.SelectingClass:
                        playerState = State.EverythingChosen;
                        break;
                }
                break;
        }
    }


    private void Start()
    {
        submitButton.onClick.AddListener(SubmitName);

        foreach (var button in choices)
        {
            button.onClick.AddListener(delegate { SubmitChoice(button.GetComponentInChildren<Text>().text); });
        }
        
    }

    public void SubmitChoice(string choice)
    {

        if (playerState == State.SelectingRace)
        {
            tempRace = choice;
            currentEvent = Event.RaceChosen;
            Choice1(currentEvent);
            return;
        }
        if (playerState == State.SelectingClass)
        {
            tempClass = choice;
            currentEvent = Event.ClassChosen;
            Choice1(currentEvent);
            return;
        }
        Debug.Log(choice);
    }

    


    private void SubmitName()
    {
        Debug.Log("Name chosen");
        
        tempName = name.text;
        currentEvent = Event.NameChosen;
        Choice1(currentEvent);
    }

    // Update is called once per frame
    void Update()
    {

        if (currentEvent == Event.ChooseName)
        {
            foreach (var VARIABLE in choices)
            {
                VARIABLE.gameObject.SetActive(false);
            }
        }

        if (currentEvent == Event.NameChosen)
        {
            foreach (var VARIABLE in choices)
            {
                VARIABLE.gameObject.SetActive(true);
            }

            name.gameObject.SetActive(false);
            submitButton.gameObject.SetActive(false);
            
            
            
            choices[0].GetComponentInChildren<Text>().text = "Elf";
            choices[1].GetComponentInChildren<Text>().text = "Dwarf";
            choices[2].GetComponentInChildren<Text>().text = "Human";
            
        }
        if (currentEvent == Event.RaceChosen)
        {
            choices[0].GetComponentInChildren<Text>().text = "Warrior";
            choices[1].GetComponentInChildren<Text>().text = "Mage";
            choices[2].GetComponentInChildren<Text>().text = "Ranger";
        }

        if (currentEvent == Event.ClassChosen)
        {
            Debug.Log($"Your name is {tempName}, your race is {tempRace}, and your class is {tempClass} ");
        }
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
        return "This is your Class";
    }
    
    public string PlayerName { get; set; }
    public string Race { get; set; }
    public string PlayerClass { get; set; }
}

class PlayerCreatorSystem
{
    
}
