using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

public class InvaderEnemy : MonoBehaviour
{
    [SerializeField] internal int health = 3;
    [SerializeField]private float shakeStrength = 0.5f;
    [SerializeField]private float shakeDuration = 0.5f; 
    [SerializeField]private float deathShakeStrength = 0.5f;

    [SerializeField]private float deathShakeDuration = 0.5f;
    [SerializeField] private GameObject deadParticle;
    public TakeDamageEvent TakeDamage;

    private CapsuleCollider2D collider;
    // Start is called before the first frame update
    void Awake()
    {
        if (TakeDamage== null)
        {
            TakeDamage = new TakeDamageEvent();
        }
        TakeDamage.AddListener(Damage);
        collider = GetComponent<CapsuleCollider2D>();
    }

 public  virtual  void Damage(int amount)
     {
         health -= amount;
        // transform.DOShakeScale(shakeDuration, shakeStregth, 10);
      
         if (health < 1)
         {
             StartCoroutine(EnemyDead());
         }
         else
         {
               transform.DOPunchRotation(Vector3.left*shakeStrength, shakeDuration);
         }
     }

 private IEnumerator EnemyDead()
 {
     transform.DOShakeRotation(deathShakeDuration, Vector3.forward * deathShakeStrength,20);
     collider.enabled = false;
     yield return new WaitForSeconds(deathShakeDuration);
     Instantiate(deadParticle, transform.position, Quaternion.identity);

     gameObject.SetActive(false);
     LevelManager.enemyDead.Invoke();
 }

 // Update is called once per frame
    void Update()
    {
        
    }
}
