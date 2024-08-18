using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerState : MonoBehaviour
{
    [SerializeField]
    private bool hasCollectedPearls = false;
    [SerializeField]
    private int playerHealth = 6;
    [SerializeField]
    private int playerBones = 0;

    [SerializeField] Image[] healthSkulls;
    [SerializeField] Image[] litBones;
    [SerializeField] Image[] unlitBones;
    

    public void FixedUpdate(){
        for (int i = 0; i < healthSkulls.Length; i++)
        {
            if(i >= playerHealth){
                healthSkulls[i].enabled = false;
            }else{
                healthSkulls[i].enabled = true;
            }
        }

        for (int i = 0; i < litBones.Length; i++)
        {
            if(i >= playerBones){
                litBones[i].enabled = false;
                unlitBones[i].enabled = true;
            }else{
                litBones[i].enabled = true;
                unlitBones[i].enabled = false;
            }
        }
    }

    private void OnEnable(){
        Pearls.OnPearlsCollected += CollectPearls;
    }

    private void OnDisable(){
        Pearls.OnPearlsCollected -= CollectPearls;
    }

    public void CollectPearls(){
        hasCollectedPearls = true;
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            print("player died");
        }
    }
}
