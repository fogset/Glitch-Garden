using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float minSpamnDelay = 1f;
    [SerializeField] float maxSpamnDelay = 5f;
    [SerializeField] Attacker attackerPrefab;

    IEnumerator Start()
    {
        while (spawn){
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpamnDelay, maxSpamnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        Attacker newAttacker = Instantiate
            (attackerPrefab, transform.position, transform.rotation) 
            as Attacker;
        newAttacker.transform.parent = transform;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
