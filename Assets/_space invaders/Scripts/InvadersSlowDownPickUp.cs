using System;
using UnityEngine;

class InvadersSlowDownPickUp : PickUp
{
    [SerializeField] private float moveSpeedDecreasePercentage;
    public override void PlayerTouched()
    {
        var wave = LevelManager.wave;
           var num = moveSpeedDecreasePercentage / 100;
        wave.MoveSpeed -= wave.MoveSpeed * num;
    }
}
