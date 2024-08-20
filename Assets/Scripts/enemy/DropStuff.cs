using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropStuff : MonoBehaviour
{

    [SerializeField]
    private GameObject bonePilePrefab;
    [SerializeField]
    private GameObject milkPrefab;


    public void OnKill(){
        float randomValue = Random.Range(0f,1f);
        if(randomValue > 0.5f){
            Instantiate(bonePilePrefab, gameObject.transform.position, Quaternion.identity);
        }else if(randomValue > 0.75f){
            Instantiate(milkPrefab, gameObject.transform.position, Quaternion.identity);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
