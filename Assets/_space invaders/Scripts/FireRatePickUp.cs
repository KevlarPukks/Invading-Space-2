using System;
using UnityEngine;

public class FireRatePickUp : PickUp
{
    public override void PlayerTouched()
    {
        if(PlayerShoot.ShootSpeed <= 0.4f)
        {
            PlayerShoot.ShootSpeed = 0.4f;
        }
        else
        {
   PlayerShoot.ShootSpeed -= 0.2f;
        }
     
    }
}

