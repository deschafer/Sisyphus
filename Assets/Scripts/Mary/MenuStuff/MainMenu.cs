using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool yesNormal;
    public bool yesBC;
    public bool yesQuit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quitter()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void LoadNormal()
    {
        Debug.Log("Normal mode");
        Application.LoadLevel(1);
       
    }
    public void LoadBC()
    {
        Debug.Log("BC mode");
        Application.LoadLevel(2);
   
    }
}
