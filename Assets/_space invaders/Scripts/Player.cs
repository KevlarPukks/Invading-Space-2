using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Events;
using DG.Tweening;

public class Player : SerializedMonoBehaviour
{
   public static Player instance;
    public UnityEvent PlayerDeadEvent;
   [SerializeField] private int startingHealth;
    [SerializeField] GameObject shield;
    public static TakeDamageEvent PlayerDamagedEvent = new TakeDamageEvent();
    private int health;
    public int Health
    {
        get { return health; }
        set { health = value;
            transform.DOPunchRotation(Vector3.left * 0.2f, 0.2f);
            Debug.Log(health);
            if (health > startingHealth)
            {
                health = startingHealth;
            }
            else if(health > 1)
            {
                shield.SetActive(true);
            }else if(health == 1)
            {
                shield.SetActive(false);
            }
            else
            {
                PlayerDeadEvent.Invoke();
            }
        }
    }
    private void Awake()
    {
        PlayerDamagedEvent.AddListener(TakeDamage);
    }
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }  Debug.Log(health);
        Health = startingHealth;
        Debug.Log(health);
    }
    void TakeDamage(int amount)
    {
        Health -= amount;
    }
}
