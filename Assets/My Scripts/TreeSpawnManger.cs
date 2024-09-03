using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawnManger : MonoBehaviour
{
    public GameObject[] TreePrefabs;

    private float SpawnXLimit = 25.0f;
    private float SpawnZPosition = 150.0f;

    private float startDelay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        float SpawnInterval = Random.Range(0f, 2f); //interval between spawns
         //repeatedly call the function "" with a delay
        InvokeRepeating("SpawnRandomTreesLeft", startDelay, SpawnInterval);
        InvokeRepeating("SpawnRandomTreesRight", startDelay, SpawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //custom function
    void SpawnRandomTreesLeft() //zombie or boulder
    {
        Vector3 SpawnPosition = new Vector3(Random.Range(SpawnXLimit-4, SpawnXLimit), 0, SpawnZPosition);

        //instantiating a zombie/boulder at random locations
        Instantiate(TreePrefabs[Random.Range(0, TreePrefabs.Length - 1)], SpawnPosition, TreePrefabs[0].transform.rotation);
    }
    void SpawnRandomTreesRight() //zombie or boulder
    {
        Vector3 SpawnPosition = new Vector3(Random.Range(-SpawnXLimit, -SpawnXLimit+4), 0, SpawnZPosition);

        //instantiating a zombie/boulder at random locations
        Instantiate(TreePrefabs[Random.Range(0, TreePrefabs.Length - 1)], SpawnPosition, TreePrefabs[0].transform.rotation);
    }
}
