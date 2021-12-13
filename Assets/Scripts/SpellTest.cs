using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpellTest : MonoBehaviour
{
    [HideInInspector]public float lifeTime;
    private float timer;
    private SpellSpawner currentPool;

    public void spawnBullet(SpellSpawner spellSpawner)
    {
        
        currentPool = spellSpawner;
    }

    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0.0)
        {
            currentPool.ObjectPoolReturn(gameObject);
        }
    }
    
}
