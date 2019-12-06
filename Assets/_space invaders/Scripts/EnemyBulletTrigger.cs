using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletTrigger : MonoBehaviour
{
    [SerializeField] private GameObject collisionParticle;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player.PlayerDamagedEvent.Invoke(1);
            Instantiate(collisionParticle, collision.ClosestPoint(transform.position), Quaternion.identity);
            Destroy(gameObject);
        }
        else if (collision.tag == "bullet")
        {
            Instantiate(collisionParticle, collision.ClosestPoint(transform.position), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
