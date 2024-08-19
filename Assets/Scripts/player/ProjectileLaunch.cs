using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileLaunch : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private float shootTime; //time between shots
    
    public InputActionReference throwAction;

    public float shootCounter;

    private void Awake(){
    
    }

    private void OnEnable(){
        print("ProjectileLaunch OnEnable");
        if (throwAction != null && throwAction.action != null){
            throwAction.action.Enable();
            throwAction.action.performed += ctx => LaunchProjectile();
        }
    }

    private void OnDisable(){
        throwAction.action.performed -= ctx => LaunchProjectile();
        throwAction.action.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        shootCounter = shootTime;
    }

    // Update is called once per frame
    void Update()
    {        
        shootCounter -= Time.deltaTime;
    }

    private void LaunchProjectile(){
        if (shootCounter <=0) {
            Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
            shootCounter = shootTime;
        }
    }
}
