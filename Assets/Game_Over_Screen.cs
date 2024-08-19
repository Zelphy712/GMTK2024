using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Over_Screen : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("GameplayScene");
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
