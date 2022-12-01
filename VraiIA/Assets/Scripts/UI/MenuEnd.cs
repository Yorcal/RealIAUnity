using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEnd : MonoBehaviour
{
     public static bool isPaused;
    public GameObject EndMenu;
    // Start is called before the first frame update
    void Start()
    {
        EndMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void EndGame()
    {
        EndMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
}
