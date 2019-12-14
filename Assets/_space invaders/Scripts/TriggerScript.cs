using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
   [SerializeField] private int bulletDamage = 1;
   [SerializeField] private GameObject collisionParticle;
    [SerializeField] private ObjectSpawner playerBulletTriggerSpawner;
    private void Start()
    {
        GameManager.instance.GameStateChangeEvent.AddListener(GameStateChange);
    }
    void GameStateChange(GameStates state)
    {
        switch (state)
        {
            case GameStates.MainMenu:
                gameObject.SetActive(false);
                break;
            case GameStates.GameStart:
                break;
            case GameStates.Pause:
                break;
            case GameStates.Resume:
                break;
            case GameStates.Settings:
                break;
            case GameStates.GameOver:
                gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
    
        if (other.tag == "enemy")
        {
            EnemyHit(other);
        }
        else if(other.tag == "enemybullet")
        {
           // Instantiate(collisionParticle, other.ClosestPoint(transform.position), Quaternion.identity);
            playerBulletTriggerSpawner.Spawn(other.ClosestPoint(transform.position));
            gameObject.SetActive(false);
        }
    }

    private void EnemyHit(Collider2D other)
    {
       // Instantiate(collisionParticle, other.ClosestPoint(transform.position), Quaternion.identity);
        playerBulletTriggerSpawner.Spawn(other.ClosestPoint(transform.position));
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
