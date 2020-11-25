using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        if (otherObject.GetComponent<Gravestone>() == true)
        {
            Animator animator = GetComponent<Animator>();
            animator.SetTrigger("jumpTrigger");
        }

        else if (otherObject.GetComponent<Defender>() == true)
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }


}
