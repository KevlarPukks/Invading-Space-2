using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
    [SerializeField] AudioClip pickUpSound;
    [SerializeField] GameObject pickUpParticle;
    public abstract void PlayerTouched();

    public virtual  void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerTouched();
            SoundManager.PlaySFX(pickUpSound);
            Instantiate(pickUpParticle, collision.ClosestPoint(transform.position),Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
