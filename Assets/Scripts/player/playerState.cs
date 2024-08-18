using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerState : MonoBehaviour
{
    [SerializeField]
    private bool hasCollectedPearls = false;
    [SerializeField]
    private int playerHealth = 6;
    [SerializeField]
    private int playerBones = 0;

    private void OnEnable(){
        Pearls.OnPearlsCollected += CollectPearls;
    }

    private void OnDisable(){
        Pearls.OnPearlsCollected -= CollectPearls;
    }

    public void CollectPearls(){
        hasCollectedPearls = true;
    }
}
