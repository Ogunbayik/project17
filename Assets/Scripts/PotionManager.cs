using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionManager : MonoBehaviour
{
    public static PotionManager Instance;

    [SerializeField] private GameObject potionPrefab;
    [SerializeField] private float spawnRate;
    [SerializeField] private float destroyTime;
    [Header("SpawnBorders")]
    [SerializeField] private float minimumX;
    [SerializeField] private float maximumX;
    [SerializeField] private float minimumZ;
    [SerializeField] private float maximumZ;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    private void OnEnable()
    {
        PlayerCollision.OnCollectPotion += AddPower;
    }
    private void OnDisable()
    {
        PlayerCollision.OnCollectPotion -= AddPower;
    }

    void Start()
    {
        StartCoroutine(nameof(SpawnPotion));
    }
    IEnumerator SpawnPotion()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            CreatePotion();
        }
    }

    private void CreatePotion()
    {
        var potion = Instantiate(potionPrefab);
        potion.transform.position = RandomPosition();
        Destroy(potion, destroyTime);
    }

    private Vector3 RandomPosition()
    {
        var randomX = Random.Range(minimumX, maximumX);
        var randomZ = Random.Range(minimumZ, maximumZ);
        var positionY = 0f;

        var spawnPos = new Vector3(randomX, positionY, randomZ);
        return spawnPos;
    }

    private void AddPower(int power)
    {
        PowerManager.Instance.AddPower(power);
    }
}
