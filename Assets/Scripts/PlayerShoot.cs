using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerShoot : SerializedMonoBehaviour
{
    [SerializeField] private float shootSpeed;
    [Required]
   [SerializeField] private ParticleSystem muzzleflash;
    [SerializeField] private GameObject bulletObj;
    [SerializeField] private Transform gunPos;

    [SerializeField] private int poolAmount;
    [SerializeField] private GameObject gun;
    [SerializeField]
    private Transform poolTransform;
    private float shootTimer;
    private List<GameObject> bulletList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < poolAmount; i++)
        {
            var obj = Instantiate(bulletObj,poolTransform);
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
        if (shootTimer > shootSpeed)
        {
            FireBullet();
           gun.transform.DOPunchPosition(Vector3.down, 0.25f,5);
          muzzleflash.Stop();
          muzzleflash.Play();
           
        }
    }

    private void FireBullet()
    {
        foreach (var bul in bulletList)
        {
            if (!bul.activeInHierarchy)
            {
                bul.SetActive(true);
                bul.transform.position = gunPos.position;
                shootTimer = 0;
                break;
            }
        }
    }
}
