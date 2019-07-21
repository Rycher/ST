using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
    [SerializeField]
    public GameObject enemy;                // The enemy prefab to be spawned.    
    [SerializeField]
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemy, spawnPoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
