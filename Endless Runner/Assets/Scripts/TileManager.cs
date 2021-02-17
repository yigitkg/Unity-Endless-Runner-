using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] public GameObject[] tilePrefabs;

    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float tileLength = 18f;
    private int amountOfTile = 5;
    private int lastPrefabIndex = 0;
 
    private void Start()
    {
        //activeTiles = new List<GameObject>();
        Random r = new Random();
        
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < amountOfTile; i++)
        {
            SpawnTile();
        }     
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerTransform.position.z > (spawnZ - amountOfTile * tileLength))
        {
            SpawnTile();
        }
    }

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject gameobj = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        gameobj.transform.SetParent(transform);
        gameobj.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;   
    }

    private int RandomPrefabIndex()
    {
        if(tilePrefabs.Length <= 1)
        {
            return 0;
        }
        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return lastPrefabIndex;
    }
}
