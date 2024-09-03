using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] PowerupPrefabs;

    private float SpawnXLimit = 20.0f;
    private float SpawnZPosition = 150.0f;

    private float startDelay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        float SpawnInterval = Random.Range(10f, 15f); //interval between spawns
        InvokeRepeating("SpawnRandomCollision", startDelay, SpawnInterval); //repeatedly call the function "" with a delay of 1.0f
    }

    // Update is called once per frame
    void Update()
    {

    }

    //custom function
    void SpawnRandomCollision() //zombie or boulder
    {
        Vector3 SpawnPosition = new Vector3(Random.Range(SpawnXLimit, -SpawnXLimit), 0.5f, SpawnZPosition);

        //instantiating a zombie/boulder at random locations
        Instantiate(PowerupPrefabs[Random.Range(0, PowerupPrefabs.Length)], SpawnPosition, PowerupPrefabs[0].transform.rotation);
    }
}
