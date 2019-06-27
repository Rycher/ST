using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitControll : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D rb2;
    private float timer = 0.0f;
    private float waitTime = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        rb2 = GameObject.Find("RedEye").GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if (rb.IsTouching(rb2))
        {
            if (timer > waitTime)
            {
                //Debug.Log(timer);

                // Remove the recorded 2 seconds.
                timer = timer - waitTime;
                //Debug.Log("Tempo esperado :" + timer);
                Life.Health -= 10f;
            }
            
        }
    }
}
