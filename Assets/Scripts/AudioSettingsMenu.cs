using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettingsMenu : MonoBehaviour
{
   public void OpenAudioSettingsMenu()
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
    }
   
}
