using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
 public void OnPlayButton()
 {
    SceneManager.LoadScene("GameplayScene");
 }

 public void OnCreditsButton()
 {
    SceneManager.LoadScene("Credits");
 }

 public void OnQuitButton()
 {
    Application.Quit();
 }
}
