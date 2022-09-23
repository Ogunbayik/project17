using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyList = new List<GameObject>();
    [SerializeField] private GameObject[] enemyPrefabs;
    [Header("Spawn Settings")]
    [SerializeField] private float spawnRate;
    [SerializeField] private int meleeAmount;
    [SerializeField] private int rangeAmount;
    [Header("Spawn Borders")]
    [SerializeField] private int minimumX;
    [SerializeField] private int maximumX;
    [SerializeField] private int minimumZ;
    [SerializeField] private int maximumZ;
    private int listIndex = 0;
    void Start()
    {
        CreateEnemies();
        StartCoroutine(SpawnEnemies());
    }

    void Update()
    {
        if (listIndex >= enemyList.Count)
        {
            StopAllCoroutines();
        }
    }

    private void CreateEnemies()
    {
        for (int i = 0; i < meleeAmount; i++)
        {
            var meleeEnemy = Instantiate(enemyPrefabs[0]);
            meleeEnemy.transform.position = RandomPosition();
            meleeEnemy.SetActive(false);

            enemyList.Add(meleeEnemy);
        }

        for (int i = 0; i < rangeAmount; i++)
        {
            var rangeEnemy = Instantiate(enemyPrefabs[1]);
            rangeEnemy.transform.position = RandomPosition();
            rangeEnemy.SetActive(false);

            enemyList.Add(rangeEnemy);
        }
    }

    private Vector3 RandomPosition()
    {
        var randomX = Random.Range(minimumX, maximumX);
        var posZ = 12f;
        var randomZ = Mathf.Sign(Random.Range(minimumZ, maximumZ)) * posZ;
        var PosY = 0f;
        var spawnPos = new Vector3(randomX, PosY, randomZ);

        return spawnPos;
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            ActivateEnemies();
            listIndex++;
        }
    }

    private void ActivateEnemies()
    {
        enemyList[listIndex].gameObject.SetActive(true);
    }


}
