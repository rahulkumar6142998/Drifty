using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    //we makinng instance variable of type GameManger i.e itself to call any function of its class help of this( search singleton pattern).
    public static GameManger instance; //Static can called without making its object

    public bool isGameStarted;
    


    private void Awake()
    {
        // If the instance is null we assiging instance to the attach to the gameObect
        if (instance == null) 
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
       if(!isGameStarted)
        {

            GameStart();
        }
    }

    public void GameStart()
    {
        isGameStarted = true;

    }

   public void GameOver()
    {
        isGameStarted = false;
        Debug.Log("Called");
        SceneManager.LoadScene("Menu");
    }

   
}
