using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class UIManager:MonoBehaviour
{
    public static UIManager instance;
    public Slider shield;

   public Text Score;

    public Text wave;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

}
