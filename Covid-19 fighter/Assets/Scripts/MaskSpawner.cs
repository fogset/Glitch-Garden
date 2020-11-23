using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float minSpamnDelay = 1f;
    [SerializeField] float maxSpamnDelay = 5f;
    [SerializeField] GameObject faceMaskPrefab;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpamnDelay, maxSpamnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        Instantiate(faceMaskPrefab, transform.position, transform.rotation);
    }
}
