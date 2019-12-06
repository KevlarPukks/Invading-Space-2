using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
public enum GunLevel { one, two, three }
public class PlayerShoot : MonoBehaviour
{
    public static PlayerShoot instance;
    [SerializeField] public float startingShootSpeed;
    private GunLevel gunLevel;

    public GunLevel GunLevel
    {
        get { return gunLevel; }
        set
        {
            gunLevel = value;
            if (gunLevel == GunLevel.one)
            {
                gun.SetActive(true);
                SetGuns(false);
            }
          
            else if (gunLevel == GunLevel.two)
            {
                gun.SetActive(false);
                SetGuns(true);

            }
            else if (gunLevel == GunLevel.three)
            {
                gun.SetActive(true);
                SetGuns(true);
            }
        }
    }

    public static float ShootSpeed { get; set; }
    [Required]
    [SerializeField] private ParticleSystem muzzleflash;
    [SerializeField] private GameObject bulletObj;
    [SerializeField] private Transform gunPos;
    [SerializeField] private Transform gunPos2;
    [SerializeField] private Transform gunPos3;
    [SerializeField] private int poolAmount;
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject gun2;
    [SerializeField] private GameObject gun3;
    [SerializeField]
    private Transform poolTransform;
    private float shootTimer;
    private List<GameObject> bulletList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = this;
        ShootSpeed = startingShootSpeed;
        gunLevel = GunLevel.one;
        for (int i = 0; i < poolAmount; i++)
        {
            var obj = Instantiate(bulletObj, poolTransform);
            obj.SetActive(false);
            bulletList.Add(obj);
        }

        shootTimer = 0;
        FireBullet();
    }

    // Update is called once per frame
    void Update()
    {
        Playershoot();
    }

    private void Playershoot()
    {
        shootTimer += Time.deltaTime * 1;
        if (shootTimer > ShootSpeed)
        {
            FireBullet();

            muzzleflash.Stop();
            muzzleflash.Play();

        }
    }
    void SetGuns(bool active)
    {
        gun2.SetActive(active);
        gun3.SetActive(active);
    }
    private void FireBullet()
    {
        if (GunLevel == GunLevel.one)
        {
            foreach (var bul in bulletList)
            {
                if (!bul.activeInHierarchy)
                {
                    bul.SetActive(true);
                    bul.transform.position = gunPos.position;
                    gun.transform.DOPunchPosition(Vector3.down, 0.25f, 5);
                    shootTimer = 0;
                    break;
                }
            }
        }
        else if (GunLevel == GunLevel.two)
        {
        
                foreach (var bul in bulletList)
                {
                    if (!bul.activeInHierarchy)
                    {
                        bul.SetActive(true);
                        bul.transform.position = gunPos2.position;
                        gun2.transform.DOPunchPosition(Vector3.down, 0.25f, 5);
                        shootTimer = 0;
                        break;
                    }
                }
            foreach (var bul in bulletList)
            {
                if (!bul.activeInHierarchy)
                {
                    bul.SetActive(true);
                    bul.transform.position = gunPos3.position;
                    gun3.transform.DOPunchPosition(Vector3.down, 0.25f, 5);
                    shootTimer = 0;
                    break;
                }
            }

        }

        else if (GunLevel == GunLevel.three)
        {
            foreach (var bul in bulletList)
            {
                if (!bul.activeInHierarchy)
                {
                    bul.SetActive(true);
                    bul.transform.position = gunPos2.position;
                    gun2.transform.DOPunchPosition(Vector3.down, 0.25f, 5);
                    shootTimer = 0;
                    break;
                }
            }
            foreach (var bul in bulletList)
            {
                if (!bul.activeInHierarchy)
                {
                    bul.SetActive(true);
                    bul.transform.position = gunPos3.position;
                    gun3.transform.DOPunchPosition(Vector3.down, 0.25f, 5);
                    shootTimer = 0;
                    break;
                }
            }
            foreach (var bul in bulletList)
            {
                if (!bul.activeInHierarchy)
                {
                    bul.SetActive(true);
                    bul.transform.position = gunPos.position;
                    gun.transform.DOPunchPosition(Vector3.down, 0.25f, 5);
                    shootTimer = 0;
                    break;
                }
            }
        }
        }
     


    }



