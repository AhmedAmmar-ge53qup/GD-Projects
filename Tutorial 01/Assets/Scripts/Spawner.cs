using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float repeatInterval;
    //private float interval = 0.0f;


    void Start()
    {
       InvokeRepeating("spawnPrefab", 1.0f, repeatInterval);
    }

    
    void Update()
    {
        //interval += Time.deltaTime;
        //if(interval >= 0.25f)
        //{
        //    Instantiate(prefab);
        //    interval = 0.0f;
        //}
    }

    void spawnPrefab()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }
}
