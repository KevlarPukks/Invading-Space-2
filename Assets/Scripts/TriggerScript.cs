using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
   [SerializeField] private int bulletDamage = 1;
   [SerializeField] private GameObject collisionParticle;
    private void OnTriggerEnter2D(Collider2D other)
    {
    
        if (other.tag == "enemy")
        {
            EnemyHit(other);
        }
    }

    private void EnemyHit(Collider2D other)
    {
        Instantiate(collisionParticle, other.ClosestPoint(transform.position), Quaternion.identity);
        var enemy = other.GetComponent<EnemyBehaviour>();
        if (enemy == null)
        {
            Debug.Log("No script");
            return;
        }

        other.GetComponent<EnemyBehaviour>().takeDamage.Invoke(bulletDamage);
        gameObject.SetActive(false);
    }
}
