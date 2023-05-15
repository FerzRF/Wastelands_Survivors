using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntSpawning : MonoBehaviour
{
    public GameObject gruntPrefab;
    public GameObject brutePrefab;
    public Transform playerPosition;
    public Transform spawnPosition;
    public float spawningRadius = 15f;
    float randomRotY;
    float randomX;
    float randomZ;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnGrunt", 0.0f, 3.0f);
        InvokeRepeating("SpawnBrute", 0.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnGrunt()
    {
        randomRotY = Random.Range(-180f, 180f);
        randomX = Random.Range(-spawningRadius, spawningRadius);
        randomZ = Mathf.Sign(randomRotY) * Mathf.Pow((spawningRadius+randomX)*(spawningRadius-randomX), 0.5f);
        Vector3 randomSpawn = new Vector3(randomX,0,randomZ);
        Instantiate(gruntPrefab, playerPosition.position + randomSpawn, Quaternion.Euler(0, randomRotY, 0));
    }

    void SpawnBrute()
    {
        randomRotY = Random.Range(-180f, 180f);
        randomX = Random.Range(-spawningRadius, spawningRadius);
        randomZ = Mathf.Sign(randomRotY) * Mathf.Pow((spawningRadius+randomX)*(spawningRadius-randomX), 0.5f);
        Vector3 randomSpawn = new Vector3(randomX,0,randomZ);
        Instantiate(brutePrefab, playerPosition.position + randomSpawn, Quaternion.Euler(0, randomRotY, 0));
    }
}
