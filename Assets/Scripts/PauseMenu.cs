using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
     PauseMenuUI.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
       if(Keyboard.current.escapeKey.wasPressedThisFrame)
       {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
       } 
    }
    public void PauseGame()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
  
    public void ResumeGame()
    {
    PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

}
