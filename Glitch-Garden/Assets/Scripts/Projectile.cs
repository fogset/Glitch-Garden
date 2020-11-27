using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    //GameSession gameSession;
    int score;
    [SerializeField] float speed = 5f;
    [SerializeField] float damage = 300;

    void Start()
    {
        //gameSession = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();

        if(attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
            //gameSession.AddToScore(1);
           
        }
       
    }
    
    
}
