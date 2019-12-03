  using System.Collections;
  using Sirenix.OdinInspector;
  using UnityEngine;
  using UnityEngine.Events;
 [RequireComponent(typeof(EnemyDamage))]
  public abstract  class Enemy:SerializedScriptableObject
    {
   
   public int health = 3;
    [HideInInspector]
public UnityEvent enemyDeadEvent= new UnityEvent();
    public GameObject deadParticle;
    [Title("Shoot Options")]
    public bool canShoot = false;
    public GameObject bullet;
    public float shootTimeMin = 4, shootTimeMax = 8;
    public float shakeStrength = 0.2f;
    public float shakeDuration = 0.2f;
    public float deathShakeStrength = 50f;

    public float deathShakeDuration = 1f;
    public bool canDropBonus = false;
    [SerializeField] public GameObject[] bonusObjList;

    [SerializeField, Range(1, 100)] public float bonusDropChance = 10;

 /*   public abstract void EnemyDead();
   public abstract void Update();

   public abstract void Init(EnemyBehaviour enemybehaviour);*/
    }
