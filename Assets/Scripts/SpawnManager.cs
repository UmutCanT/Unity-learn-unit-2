using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] animalPrefabs;

    float spawnRangeX = 20f;
    float spawnPosZ = 14f;
    float spawnRangeZ = 10f;
    float spawnStartDelay = 2f;
    float spawnDelay = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RandomAnimalSpawnerTop", spawnStartDelay, spawnDelay);
        InvokeRepeating("RandomAnimalSpawnerSide", spawnStartDelay, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomAnimalSpawnerTop()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

    void RandomAnimalSpawnerSide()
    {
        float direction = SideDecider();
        Vector3 spawnPos = new Vector3(direction, 0, Random.Range(-spawnRangeZ, spawnRangeZ));
        int animalIndex = Random.Range(0, animalPrefabs.Length);       
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.FromToRotation( Vector3.right * direction, Vector3.forward));
        
    }

    float SideDecider()
    {
        int side = Random.Range(0, 2);
        if(side == 0)
        {
            return spawnRangeX;
        }
        return -spawnRangeX;
    }
}
