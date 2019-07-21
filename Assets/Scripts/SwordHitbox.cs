using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    //private float timer = 0.0f;
    //private float waitTime = 1.5f;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            if (col.gameObject.name.Substring(0, 6) == "RedEye")
            {
                Debug.Log("Atacou o :" + col.gameObject.name);
                //Destroy(col.gameObject);
            } 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;
    }
}
