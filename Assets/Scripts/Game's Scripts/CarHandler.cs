using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarHandler : MonoBehaviour
{
    public GameObject pickEffect;
   
    public Transform playerPos;

    public float speed = 4f;
    private bool isTrue = true;



    int score = 0;
    public Text scoreText;


    private void Start()
    {
        FindObjectOfType<AudioManger>().Play("Engine");
    }


    // Update is called once per frame
    void Update()
    {
        if (GameManger.instance.isGameStarted)   //cheaking that is game is stared is true in GameManger class 
        {
            Move();
            if (!isTrue)
                CheakInput();
        }
        if (playerPos.position.y <= -2f)
        {
            Invoke("GameOverInvoke", 1f);
             
        }
    }

    void Move()
    {   //To move the vehicels on z-Axis direction
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    void CheakInput()
    {
       
        if (Input.GetMouseButton(0))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
           
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            FindObjectOfType<AudioManger>().Play("Skid");
        }
    }
    
   
    private void OnTriggerEnter(Collider other)
    {
        if(GameObject.FindWithTag("tapTrigger"))
        {
            isTrue = false;
        }

        if(GameObject.FindWithTag("Diamond"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("Collect call");

            FindObjectOfType<AudioManger>().Play("Collect");

            Instantiate(pickEffect, other.transform.position, pickEffect.transform.rotation);
            IncrementScore();
        }
    }

    public void IncrementScore()
    {
        Debug.Log("collect");
        score += 1;

        scoreText.text = score.ToString();
    }


    void GameOverInvoke()
    {
        
        GameManger.instance.GameOver();   // calling gameover metheod from GameManger script using static

    }
}
