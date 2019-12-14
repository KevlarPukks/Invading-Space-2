using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    [SerializeField] private InvaderWaveList waveList;
    public static Wave wave;
    [SerializeField] private GameObject enemyHolder;
    public static UnityEvent enemyDead = new UnityEvent();
    private int level;
    private bool noEnemiesLeft = false;

    [SerializeField] public Action act;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        enemyDead.AddListener(EnemyDead);
        foreach (var wave in waveList.invaderWaves)
        {
            wave.SpawnInvaders(enemyHolder);

        }
        //   GameManager.instance.GameStateChangeEvent.AddListener(Init);
    }

    public void EnemyDead()
    {

        noEnemiesLeft = true;
        foreach (var enemy in wave.enemies)
        {
            if (enemy.gameObject.activeInHierarchy)
            {
                noEnemiesLeft = false;
                break;
            }
        }


        if (noEnemiesLeft)
        {
            StartCoroutine(wave._Init());
            level++;
            if (level == waveList.invaderWaves.Count + 1)
            {
                level = 1;
            }
            wave = waveList.GetInvaderWave(level);
            foreach (var enemy in wave.enemies)
            {
                enemy.SetActive(true);

            }
        }
        else
        {
            int num = 0;
            foreach (var enemy in wave.enemies)
            {
                if (enemy.gameObject.activeInHierarchy)
                    num++;

            }

        }
    }

    private static IEnumerator _ResetWave()
    {
        wave._Init();
        yield return null;
      }

    // Start is called before the first frame update
    void Start()
    {

        //level = 1;
        //   wave = waveList.GetInvaderWave(level);
        //  wave.Init(enemyHolder);

        GameManager.instance.GameStateChangeEvent.AddListener(GameChange);

    }
    void GameChange(GameStates state)
    {
        switch (state)
        {
            case GameStates.MainMenu:
                if (wave != null)
                {
                    foreach (var wav in waveList.invaderWaves)
                    {
                        StartCoroutine(wave._Init());                 
                    }
                }
                break;
            case GameStates.GameStart:
                level = 1;
                wave = waveList.GetInvaderWave(level);

                //  wave.Init(enemyHolder);
                foreach (var enemy in wave.enemies)
                {
                    enemy.SetActive(true);

                }
                break;
            case GameStates.Pause:
                break;
            case GameStates.Resume:
                break;
            case GameStates.Settings:
                break;
            case GameStates.GameOver:
                foreach (var enemy in wave.enemies)
                {
                    enemy.gameObject.SetActive(false);
                }
                break;
            default:
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.CurrentState == GameStates.GameStart || GameManager.instance.CurrentState == GameStates.Resume)
            wave.Update();
    }
}
