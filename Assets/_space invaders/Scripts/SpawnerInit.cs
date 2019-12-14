using UnityEngine;

using System.Collections.Generic;
using System.Collections;

namespace _space_invaders.Scripts
{
    public class SpawnerInit : MonoBehaviour
    {
        [SerializeField] List<ObjectSpawner> spawnList = new List<ObjectSpawner>();
        private void Awake()
        {
            StartCoroutine(SpawnInit());
        }
        IEnumerator SpawnInit()
        {
 foreach (var spawn in spawnList)
            {
                spawn.SpawnPool();
            }
            yield return null;
        }
    }
}