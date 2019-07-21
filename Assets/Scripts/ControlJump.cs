using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJump : MonoBehaviour
{
    [SerializeField]
    Collider2D Chao;
    public bool IsGrounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Player = GameObject.Find("Player");

        if (Player.GetComponent<Rigidbody2D>().IsTouching(Chao))
        {
            IsGrounded = true;
            //Debug.Log("IsGrounded");
        }
        {
            IsGrounded = false;
        }
    }
}
