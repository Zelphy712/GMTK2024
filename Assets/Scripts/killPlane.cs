using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class killPlane : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.CompareTag("Player")){
            SceneManager.LoadScene("GameplayScene");
        }
    }
}
