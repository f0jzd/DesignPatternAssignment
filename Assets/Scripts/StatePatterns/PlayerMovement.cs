using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [Range(0,100)]
    public int playerHealth;
    
    private Inventory _inventory;
    
    public static PlayerMovement Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject().AddComponent<PlayerMovement>();
            }
            return instance;
        }
    }
    public int PlayerHealth => playerHealth;
    private static PlayerMovement instance;


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
        StartIdle,
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
        if (Input.GetMouseButton(0))
        {
            Shooting();
        }

        //Movement
        if (Input.GetButton("Horizontal"))
        {
            _pEvent = Event.StartedWalking; 
            MovementEvent(_pEvent);
        }
        if (Input.GetButton("Horizontal") && Input.GetKey(KeyCode.LeftShift))
        {
            _pEvent = Event.StartedRunning; 
            MovementEvent(_pEvent);
        }
        if (!Input.GetButton("Horizontal"))
        {
            _pEvent = Event.StoppedMoving;
            MovementEvent(_pEvent);
        }
    }
    private void Shooting()
    {
        
    }

    private void MovementEvent(Event playerEvent)
    {
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