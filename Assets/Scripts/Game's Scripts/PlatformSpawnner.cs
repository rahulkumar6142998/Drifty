using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnner : MonoBehaviour
{



    public GameObject platform; // its the prefab that we want to spawn


    public Transform lastPlatform; // its give the last position of the platform from where we start the spawnning 
    public Transform player;


    Vector3 lastPosOfPlatform;
    Vector3 newPosition;

    bool stop; // its usses to run the coroutine infinitly




    void Start()
    {
        lastPosOfPlatform = lastPlatform.position; // its give the last platform posstion

       StartCoroutine("SpawnPlatform"); // Coroutine for Platforn generation

    }

    private void Update()
    {
        if (player.position.y <= -2f)
        {
            stop = true; // this is for stop spawnning the Platform
        }
    }



    public IEnumerator SpawnPlatform() // coroutine run one Buut here we use stop boolean to run it infintly untill player Died
    {

        while (!stop)
        {
            
            
                PlatformGenerator();

                Instantiate(platform, newPosition, Quaternion.identity);

                lastPosOfPlatform = newPosition;

                yield return new WaitForSeconds(0.1f);
            
        }
    }// end of Coroutine

    public void PlatformGenerator() // generating platform using its lenght and random class
    {
        
            newPosition = lastPosOfPlatform;

            int rand = Random.Range(0, 2);  // its create randomness 

            if (rand > 0)
            {
                newPosition.x += 1.5f;
            }
            else
            {
                newPosition.z += 1.5f;
            }
        


    }
}

