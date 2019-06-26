using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitControll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        Collider2D rb2 = GameObject.Find("RedEye").GetComponent<Collider2D>();
        if (rb.IsTouching(rb2))
        {
            Life.Health -= 1f;
        }
    }
}
