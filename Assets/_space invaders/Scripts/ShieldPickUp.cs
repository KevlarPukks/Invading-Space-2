using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickUp : PickUp
{
    public override void PlayerTouched()
    {
        Player.instance.Health++;
    }
}
