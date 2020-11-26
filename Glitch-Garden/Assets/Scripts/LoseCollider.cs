using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        FindObjectOfType<displayPlayerHealth>().TakeLife(1);
        GameObject otherObject = otherCollider.gameObject;

        if (otherObject.GetComponent<Attacker>() == true)
        {
            Destroy(otherObject);
        }
    }
}
