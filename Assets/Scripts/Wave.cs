using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Sirenix.Serialization;
[CreateAssetMenu(menuName = "Wave")]
public abstract class Wave : SerializedScriptableObject
{
    [SerializeField] public GameObject enemyholder;
    public  List<GameObject> enemies = new List<GameObject>();
    public abstract void Start();
    public abstract void DrawGrid();
    public abstract void Update();
  
    public abstract void Init(GameObject g);
}
