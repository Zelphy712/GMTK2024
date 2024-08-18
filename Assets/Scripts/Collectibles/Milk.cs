using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Milk : MonoBehaviour, ICollectible
{
    public static event Action OnMilkCollected;

    public void Collect(){
        OnMilkCollected?.Invoke();
        gameObject.SetActive(false);
    }
}
