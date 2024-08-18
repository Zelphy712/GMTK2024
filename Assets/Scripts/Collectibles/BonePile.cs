using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BonePile : MonoBehaviour, ICollectible
{
    public static event Action OnBonesCollected;

    public void Collect(){
        OnBonesCollected?.Invoke();
        gameObject.SetActive(false);
    }
}
