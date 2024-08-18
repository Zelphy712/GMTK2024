using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pearls : MonoBehaviour, ICollectible
{
    public static event Action OnPearlsCollected;

    public void Collect(){
        OnPearlsCollected?.Invoke();
        gameObject.SetActive(false);
    }
}
