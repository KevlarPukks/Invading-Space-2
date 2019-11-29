using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Wave wave;

    [SerializeField] private GameObject enemyHolder;
    // Start is called before the first frame update
    void Start()
    {
        wave.enemyholder = enemyHolder;
     //   wave.Start();
        wave.Init(enemyHolder);
    }

    // Update is called once per frame
    void Update()
    {
        wave.Update();
    }
}
