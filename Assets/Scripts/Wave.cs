using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave")]
public abstract class Wave : ScriptableObject
{
    [SerializeField] public GameObject enemyholder;

    public abstract void Start();
    public abstract void DrawGrid();
    public abstract void Update();
    public abstract void makeup();
    public abstract void Init(GameObject g);
}
