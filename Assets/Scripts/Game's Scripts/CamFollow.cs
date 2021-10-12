using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform player;
    

    Vector3 distanceFromPlayer;


    public float smoothcam;
   
    void Start()
    {
        distanceFromPlayer = player.position - transform.position; 
    }


    void Update()
    {
        if (player.position.y > -2f)
        {
            FollowPlayer();
        }
    }

    void FollowPlayer()
    {
        Vector3 currentPos = transform.position; //this give the current postion of main camera

        Vector3 targetPos = player.position - distanceFromPlayer; //this give the postion of player and camera follow it using Vector3.lerp

        transform.position = Vector3.Lerp(currentPos, targetPos, smoothcam * Time.deltaTime);
    }
}
