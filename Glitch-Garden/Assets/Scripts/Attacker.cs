﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)]
    float currentSpeed = 1f;
    [SerializeField] float health = 100;
    GameObject currentTarget;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if(levelController != null)
        {
            levelController.AttackerKilled();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if(currentTarget == false)
        {
            Walking();
        }
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
    public void Walking()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetBool("IsAttacking", false);
    }
    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget)
        { return; }
        Health health = currentTarget.GetComponent<Health>();
        if(health)
        {
            health.DealDamage(damage);
        }
       
    }
}
