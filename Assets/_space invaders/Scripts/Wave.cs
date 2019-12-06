using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Sirenix.Serialization;
using System;

[CreateAssetMenu(menuName = "Wave")]
public abstract class Wave : SerializedScriptableObject
{
    [SerializeField] public GameObject enemyholder;
    public virtual float MoveSpeed { get => throw new NotImplementedException(); set=> throw new NotImplementedException();  }
    public  List<GameObject> enemies = new List<GameObject>();
    public abstract void Start();
    public virtual IEnumerator DrawGrid()
    {
        throw new NotImplementedException();
    }
    public abstract void Update();
    public virtual float StartSpeed { get => throw new NotImplementedException(); set => throw new NotImplementedException();  }
    public abstract void Init(GameObject g);
}
