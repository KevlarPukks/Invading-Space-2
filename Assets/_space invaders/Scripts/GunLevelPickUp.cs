using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLevelPickUp : PickUp
{
    public override void PlayerTouched()
    {
     
        if(PlayerShoot.instance.GunLevel != GunLevel.three)   PlayerShoot.instance.GunLevel++;
    }
}
