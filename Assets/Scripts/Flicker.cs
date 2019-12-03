using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

public class Flicker : SerializedMonoBehaviour {
    public GameObject[] shieldList;

    [SerializeField]private float maxFlickOnTime = 5, maxFlickOffTime = 1, minFlickOnTime = 3, minFlickOffTime = 0.1f;
 
    [ShowInInspector] private float timer;

[ShowInInspector]
    private float flickOnTime;
    [ShowInInspector]
    private float flickOffTime;


    void Start() {
         
          
            timer = 0;
            flickOffTime = FlickOffTime();
             flickOnTime = FlickOnTime();
    }

    void Update() {
       
        timer += Time.deltaTime * 1;
        
        if (shieldList[0].activeInHierarchy)
        {
            if (timer >= flickOffTime)
            {
                foreach (var shield in shieldList)
                {
                     shield.SetActive(false);   
                }
            
                timer = 0;
                flickOnTime = FlickOnTime();
            }
        }
        else
        {
            if (timer >= flickOnTime)
            {
                foreach (var shield in shieldList)
                {
                    shield.SetActive(true);
                }

                timer = 0;
                flickOffTime = FlickOffTime();
            }
        }

    }

    float FlickOnTime()
    {
        return Random.Range(minFlickOnTime, maxFlickOnTime);
    } 
    float FlickOffTime()
    {
        return Random.Range(minFlickOffTime, maxFlickOffTime);
    }
}