using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletTrigger : MonoBehaviour
{
    [SerializeField] private GameObject collisionParticle;
    [SerializeField] ObjectSpawner collisionSpawner;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player.PlayerDamagedEvent.Invoke(1);
            collisionSpawner.Spawn(collision.ClosestPoint(transform.position));
          //  Instantiate(collisionParticle, collision.ClosestPoint(transform.position), Quaternion.identity);
            gameObject.SetActive(false);
        }
        else if (collision.tag == "bullet")
        {
            //  Instantiate(collisionParticle, collision.ClosestPoint(transform.position), Quaternion.identity);
            collisionSpawner.Spawn(collision.ClosestPoint(transform.position));
            gameObject.SetActive(false);
        }
    }
}
