using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    public GameObject diamond;
   

    private void Start()
    {
        int diamondRange = Random.Range(0, 5);
        Vector3 diamondPos = transform.position; // Assigning the platform position to the Diamond GameObject
        diamondPos.y += 1; // Update the diamond pos up to the platform by 1 other wise it get collide

        if(diamondRange<1)
        {
            Instantiate(diamond, diamondPos, diamond.transform.rotation);
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Invoke("Fall", 0.4f);
        }
        Destroy(gameObject, 2f);
    }

    void Fall()
    {
       

        GetComponent<Rigidbody>().isKinematic = false;
        
    }













}
