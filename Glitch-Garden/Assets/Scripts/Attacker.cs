using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)]
    float currentSpeed = 1f;
    [SerializeField] float health = 100;
    GameObject currentTarget;
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

    public void SetMovementSpeed(float Speed)
    {
        currentSpeed = Speed;
    }

    public void Attack(GameObject target)
    {
        Animator animator = GetComponent<Animator>();
        animator.SetBool("IsAttacking", true);
        currentTarget = target;
    }
}
