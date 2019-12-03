
    using System;
    using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
    using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyDamage:MonoBehaviour
    {
        [SerializeField]internal Enemy enemy;
        public TakeDamageEvent takeDamage;
  public float shakeStrength = 0.2f;
        public float shakeDuration = 0.2f; 
        public float deathShakeStrength = 50f;

        public float deathShakeDuration = 1f;
      public GameObject deadParticle;
        private CapsuleCollider2D capCollider;

    private void Start()
        {
            
            if (takeDamage== null)
            {
                takeDamage = new TakeDamageEvent();
            }
            takeDamage.AddListener(TakeDamage);
            capCollider = GetComponent<CapsuleCollider2D>();
           
       // BonusDrop();
        }

        public virtual void TakeDamage(int amount)
             {
                 enemy.health -= amount;
                // transform.DOShakeScale(shakeDuration, shakeStregth, 10);
              
                 if ( enemy.health < 1)
                 {
                     StartCoroutine(EnemyDead());
     
                 }
                 else
                 
                 {
                       transform.DOPunchRotation(Vector3.left* shakeStrength, shakeDuration);
                 }
             }
        
         private IEnumerator EnemyDead()
         {
             transform.DOShakeRotation( deathShakeDuration, Vector3.forward *  deathShakeStrength,20);
             capCollider.enabled = false;
      
             yield return new WaitForSeconds(deathShakeDuration);
             Instantiate(deadParticle, transform.position, Quaternion.identity);
      //  enemy.EnemyDead();
   

        gameObject.SetActive(false);
             LevelManager.enemyDead.Invoke();

        
         }

   
    }
