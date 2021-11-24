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


    private enum State {
        Walking,
        Running,
        Idle,
    }
    //Edges, what does the player do basically
    private enum Event {
        StoppedMoving,
        StartedWalking,
        StartedRunning,
        StartIdle
    }
    
    private State _pState = State.Idle;
    private Event _pEvent = Event.StartIdle;
    

    private void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            _pEvent = Event.StartedWalking; 
            OnEvent(_pEvent);
        }
        if (Input.GetButton("Horizontal") && Input.GetKey(KeyCode.LeftShift))
        {
            _pEvent = Event.StartedRunning; 
            OnEvent(_pEvent);
        }
        if (!Input.GetButton("Horizontal"))
        {
            _pEvent = Event.StoppedMoving;
            OnEvent(_pEvent);
        }
        if (_pState == State.Idle)
        {
            Debug.Log("Idle");
        }
        if (_pState == State.Walking)
        {
            Debug.Log("Walking");
        }
        if (_pState == State.Running)
        {
            Debug.Log("Running");
        }
    }

    private void OnEvent(Event playerEvent)
    {
        ///This is literally a switch statement
        /* if (playerEvent == Event.StartedWalking)
         {
             pState = State.Walking;
         }
         else if (playerEvent == Event.StartedRunning)
         {
                 
         }*/
        
        switch (playerEvent)
        { 
            case Event.StartedWalking:
                switch (_pState)
                {
                    case State.Idle:
                    case State.Running:
                        _pState = State.Walking;
                        break;
                    case State.Walking:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                break;
            case Event.StartedRunning:
                _pState = _pState switch
                {
                    State.Walking => State.Running,
                    _ => _pState
                };
                break;
            case Event.StoppedMoving:
                switch (_pState)
                {
                    case State.Walking:
                    case State.Running: 
                        _pState = State.Idle;
                        break;
                    case State.Idle:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                break;
        }
    }
    
}