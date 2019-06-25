using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public Transform PlayerT;       
   
    void Start()
    {
        
    }
    
    void Update()
    {
        GameObject Player;
        Player = GameObject.Find("Player");
        if (Player.transform.position.x < -8f)
        {
            Debug.Log("-8");
            //Destroy(Player);
            Player.transform.position = new Vector2(-8f,Player.transform.position.y);
            //Player.transform.position.Set(1f, Player.transform.position.y, Player.transform.position.z);           
        }       
    }
}
