
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Invader:Enemy
{/*
    [Title("Shoot Options")] 
  public bool canShoot = false;
    public GameObject bullet;
   public float shootTimeMin=4, shootTimeMax=8;
    public float shakeStrength = 0.2f;
    public float shakeDuration = 0.2f;
    public float deathShakeStrength = 50f;

    public float deathShakeDuration = 1f;
    private EnemyBehaviour enemyBehaviour;
    private float shootTime;
   private float shootTimer = 0;
   

    [Title(("Bonus Options"))] [Space] [SerializeField]
public bool canDropBonus = false;
   [SerializeField]private GameObject[] bonusObjList;
 
   [SerializeField, Range(1, 100)] private float bonusDropChance = 10;
  public override void Init(EnemyBehaviour enemybehaviour)
    {
        shootTimer = 0;
        shootTime = ShootTime();
        enemyBehaviour = enemybehaviour;
        enemyDeadEvent.AddListener(EnemyDead);
       // enemyDeadEvent.Invoke();
    }

 public override void EnemyDead()
   {
              
       if (!canDropBonus) return;
       if (bonusDropChance / 100 >= Random.value)
       {  Debug.Log(Random.value+"and"+bonusDropChance/100);
   
           Instantiate(bonusObjList[Random.Range(0, bonusObjList.Length)], enemyBehaviour.transform.position,
               Quaternion.identity);
       }
   }

    public override void Update()
    {
        Update();
    }

 /*   private void Shoot()
    {
        if (!canShoot) return;
        shootTimer += Time.deltaTime * 1;
        if (shootTimer >= shootTime)
        {
            shootTimer = 0;
            shootTime = ShootTime();
            Instantiate(bullet, enemyBehaviour.gunPosition.position, Quaternion.identity);
        }
    }
    */
    /*
    private float ShootTime()
    {

       var i = Random.Range(shootTimeMin, shootTimeMax);
   
        return i;
    }*/
    
}
