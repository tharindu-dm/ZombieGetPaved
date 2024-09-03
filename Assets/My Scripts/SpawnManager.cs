using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] TrafficPrefabs;

    private float SpawnXLimit = 20.0f;
    private float SpawnZPosition = 150.0f;

    private float startDelay = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 SpawnPosition = new Vector3(Random.Range(SpawnXLimit, -SpawnXLimit), 0, 50f);

        //instantiating a zombie/boulder at random locations
        Instantiate(TrafficPrefabs[Random.Range(0, TrafficPrefabs.Length - 1)], SpawnPosition, TrafficPrefabs[0].transform.rotation);

        float SpawnInterval = Random.Range(0f, 2f); //interval between spawns
        InvokeRepeating("SpawnRandomCollision", startDelay, SpawnInterval); //repeatedly call the function "" with a delay
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //custom function
    void SpawnRandomCollision() //zombie or boulder
    {
        Vector3 SpawnPosition = new Vector3(Random.Range(SpawnXLimit, -SpawnXLimit), 0, SpawnZPosition);

        //instantiating a zombie/boulder at random locations
        Instantiate(TrafficPrefabs[Random.Range(0, TrafficPrefabs.Length - 1)], SpawnPosition, TrafficPrefabs[0].transform.rotation);
    }
}
