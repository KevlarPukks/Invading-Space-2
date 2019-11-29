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
            Instantiate(collisionParticle, other.ClosestPoint(transform.position), Quaternion.identity);
            var enemy = other.GetComponentInParent<InvaderEnemy>();
            if(enemy==null)
            {
                Debug.Log("No script");
                return;
            }
            other.GetComponentInParent<InvaderEnemy>().TakeDamage.Invoke(bulletDamage);
            gameObject.SetActive(false);
        }
    }
}
