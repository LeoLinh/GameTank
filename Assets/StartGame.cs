using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public string mainGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void BatDauGame()
    {
        SceneManager.LoadScene("MakeGame");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
