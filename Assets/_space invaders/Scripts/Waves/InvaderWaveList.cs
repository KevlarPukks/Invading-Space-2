using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class InvaderWaveList : SerializedScriptableObject
{
    public List<InvaderWave> invaderWaves;
    
    public InvaderWave GetInvaderWave(int level =4)
    {
        return invaderWaves[level - 1];
    }

    public void SpawnPool()
    {
     
    }
}
