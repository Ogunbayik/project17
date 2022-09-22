using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyList = new List<GameObject>();

    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Vector3[] spawnPoints;

    [SerializeField] private int meleeAmount;
    [SerializeField] private int rangeAmount;
    void Start()
    {
        SpawnEnemies();
    }

    void Update()
    {
        
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < meleeAmount; i++)
        {
            var meleeEnemy = Instantiate(enemyPrefabs[0]);
            meleeEnemy.transform.position = spawnPoints[0];
            meleeEnemy.SetActive(false);

            enemyList.Add(meleeEnemy);
        }

        for (int i = 0; i < rangeAmount; i++)
        {
            var rangeEnemy = Instantiate(enemyPrefabs[1]);
            rangeEnemy.transform.position = spawnPoints[1];
            rangeEnemy.SetActive(false);

            enemyList.Add(rangeEnemy);
        }
    }
}
