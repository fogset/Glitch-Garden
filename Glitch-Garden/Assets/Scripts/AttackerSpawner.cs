using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float minSpamnDelay = 1f;
    [SerializeField] float maxSpamnDelay = 5f;
    [SerializeField] Attacker[] attackerPrefabArray;

    IEnumerator Start()
    {
        while (spawn){
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpamnDelay, maxSpamnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        var attackerIndex = UnityEngine.Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[attackerIndex]);
    }

    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate
            (myAttacker, transform.position, transform.rotation)
            as Attacker;
        newAttacker.transform.parent = transform;
    }

}
