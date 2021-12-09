using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class EnemyBehvaiour : MonoBehaviour
{
    enum Roaming
    {
        LookingForPlayer,
        FoundPlayer,
        RandomMovement
    }
    enum Combat
    {
        NonHostile,
        MoveTowardsPlayer,
        AttackPlayer,
    }
    private Roaming _roamingState = Roaming.LookingForPlayer;
    private Combat _combatState = Combat.NonHostile;


    private Rigidbody2D _rigidbody2D;
    public float pushForce;

    public LayerMask LayerMask;

    public float jumpInterval;

    private Transform _playerPosition;

    public float rayDistance;


    // Start is called before the first frame update
    void Start()
    {
        _playerPosition = FindObjectOfType<PlayerMovement>().transform;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        StartCoroutine(RandomMovementCaller(jumpInterval));
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        var position = transform.position;//Rider keeps telling me to do this, but how bad is it to only use it once.
        var targetVector = _playerPosition.position - position;
        RaycastHit2D hit = Physics2D.Raycast(position, targetVector, rayDistance,LayerMask);
        Debug.DrawLine(position, (targetVector.normalized * rayDistance) + position);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,7f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player is in range");
        }
    }


    private void MovementAction()
    {

        if (_roamingState == Roaming.LookingForPlayer)
        {
            if(Random.Range(0,2) == 0)
                _rigidbody2D.AddForce(new Vector2(1,1) * pushForce);
            else
                _rigidbody2D.AddForce(new Vector2(-1,1) * pushForce);
        }

        if (_roamingState == Roaming.FoundPlayer)
        {
            
        }
        
        
    }


    IEnumerator RandomMovementCaller(float time)
    {
        while (true)
        {
            MovementAction();
            yield return new WaitForSeconds(time);
        }
        
    }

    
}