using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
public class TakeDamageEvent:UnityEvent<int>{}
public class InvaderEnemy : MonoBehaviour
{
    [SerializeField] private int health = 3;
    [SerializeField]private float shakeStregth = 0.5f;
    [SerializeField]private float shakeDuration = 0.5f;
    
    public TakeDamageEvent TakeDamage;
    // Start is called before the first frame update
    void Start()
    {
        if (TakeDamage== null)
        {
            TakeDamage = new TakeDamageEvent();
        }
        TakeDamage.AddListener(Damage);
    }

     void Damage(int amount)
     {
         health -= amount;
        // transform.DOShakeScale(shakeDuration, shakeStregth, 10);
        transform.DOPunchRotation(Vector3.left*shakeStregth, shakeDuration);
         if (health < 0)
         {
             gameObject.SetActive(false);
         }
     }
    // Update is called once per frame
    void Update()
    {
        
    }
}
