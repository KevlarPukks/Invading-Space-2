using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class EnemyBehaviour : MonoBehaviour
{
    [Required]
    public Enemy enemy;

    [SerializeField] private Transform gunPosition;
    private int health = 3;
    [HideInInspector]
    public UnityEvent enemyDeadEvent = new UnityEvent();
    private bool canShoot = false;
    private GameObject bullet;
    private float shootTimeMin = 4, shootTimeMax = 8;
    private float shootTime;
    private float shootTimer = 0;
    private float shakeStrength = 0.2f;
    private float shakeDuration = 0.2f;
    private float deathShakeStrength = 50f;
    private GameObject deadParticle;
    private bool canDropBonus = false;
    private GameObject[] bonusObjList;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color nearlyDeadColor= Color.red;

    private float bonusDropChance = 10;
    private float deathShakeDuration = 1f;
  private Collider2D CapCollider;
    [HideInInspector]public TakeDamageEvent takeDamage = new TakeDamageEvent();
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        health = enemy.health;
        canShoot = enemy.canShoot;
        bullet = enemy.bullet;
        shootTimeMin = enemy.shootTimeMin;
        shootTimeMax = enemy.shootTimeMax;
        shakeStrength = enemy.shakeStrength;
        shakeDuration = enemy.shakeDuration;
        deathShakeStrength = enemy.deathShakeStrength;
        deadParticle = enemy.deadParticle;
        deathShakeDuration = enemy.deathShakeDuration;
        canDropBonus = enemy.canDropBonus;
        bonusObjList = enemy.bonusObjList;
        bonusDropChance = enemy.bonusDropChance;
        shootTimer = 0;
        shootTime = ShootTime();
        CapCollider = GetComponent<Collider2D>();
        enemyDeadEvent.AddListener(EnemyDead);
        takeDamage.AddListener(TakeDamage);
          
    //   enemy.Init(this);
}
   

    private void Update()
    {
        //   enemy.Update();
        Shoot();
    }

 private void Shoot()
    {
        if (!canShoot) return;
        shootTimer += Time.deltaTime * 1;
        if (shootTimer >= shootTime)
        {
            shootTimer = 0;
            shootTime = ShootTime();
            Instantiate(bullet, gunPosition.position, Quaternion.identity);
        }
    }
    private float ShootTime()
    {

        var i = Random.Range(shootTimeMin, shootTimeMax);

        return i;
    }

    public void BonusDrop()
    {

        if (!canDropBonus) return;
        if (bonusDropChance / 100 >= Random.value)
        {
            Debug.Log(Random.value + "and" + bonusDropChance / 100);

            Instantiate(bonusObjList[Random.Range(0, bonusObjList.Length)],transform.position,
                Quaternion.identity);
        }
    }
    public virtual void TakeDamage(int amount)
    {
        health -= amount;
        // transform.DOShakeScale(shakeDuration, shakeStregth, 10);
        if (health == 1)
        {

            if (enemy.health > 1)
            {
  spriteRenderer.color = nearlyDeadColor;
            }
        }
        else if (health < 1)
        {
            EnemyDead();

        }
        if (health>0)

        {
                      transform.DOPunchRotation(Vector3.left * shakeStrength, shakeDuration);
        }
    }
    void EnemyDead()
    {
        StartCoroutine(EnemyDeadCoroutine());
    }
    private IEnumerator EnemyDeadCoroutine()
    {
        transform.DOShakeRotation(deathShakeDuration, Vector3.forward * deathShakeStrength, 20);
        CapCollider.enabled = false;

        yield return new WaitForSeconds(deathShakeDuration);
        Instantiate(deadParticle, transform.position, Quaternion.identity);
        //enemy.EnemyDead();
        BonusDrop();

        gameObject.SetActive(false);
        LevelManager.enemyDead.Invoke();


    }


}