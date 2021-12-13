using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpellSpawner : MonoBehaviour
{

    [SerializeField] private float objectLifetime;
    
    public GameObject spell;
    public int amountToPool;
    private Queue<GameObject> objectPool;
    private float timer;
    
    private void ObjectPoolWarmup()
    {
        objectPool = new Queue<GameObject>();

        for (int i = 0; i < amountToPool; i++)
        {
            var spellCopy = Instantiate(spell,transform.position,quaternion.identity);
            spellCopy.SetActive(false);
            objectPool.Enqueue(spellCopy);
        }
        
    }

    public GameObject ObjectPoolSpawn()
    {
        if (objectPool.Count>0)
        {
            var result = objectPool.Dequeue();
            result.SetActive(true);

            result.GetComponent<SpellTest>().lifeTime = objectLifetime;
            
            return result;
        }
        return Instantiate(spell);
    }

    public void ObjectPoolReturn(GameObject go)
    {
        
        go.SetActive(false);
        
        if (objectPool.Count+1 > amountToPool)
        {
            Destroy(go);
        }
        else
            objectPool.Enqueue(go);
    }


    private void Start()
    {
        ObjectPoolWarmup();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            var go = ObjectPoolSpawn();
            go.GetComponent<SpellTest>().spawnBullet(this);
        }
    }
}
