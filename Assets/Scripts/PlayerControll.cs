using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    float _translateX;
    float _translateY;
    [SerializeField]
    float _jumpForce;
    [SerializeField]
    float _speed;
    GameObject Player;    
    Rigidbody2D Rb;
    Rigidbody2D CJ;
    [SerializeField]
    private GameObject Plataforma;
    bool DJump;
    bool Attack;
    private bool noChao;
    // Start is called before the first frame update
    void Start()
    {
        
        _speed = 5.0f;
        _jumpForce = 320.0f;
        noChao = true;
    }

    // Update is called once per frame
    void Update()
    {
        CJ = GameObject.Find("CJ").GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");       
        Rb = Player.GetComponent<Rigidbody2D>();        
        Controlers();      
    }


    void HitBox()
    {
        GameObject swhitbox = GameObject.Find("SwHitbox");
        swhitbox.GetComponent<CircleCollider2D>().enabled = true;        
    }

    void Controlers()
    {
        float translationY = 0;
        float translationX = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;


        if (Player.GetComponent<Animator>().GetBool("Attack") != true)        
        {
            transform.Translate(translationX, translationY, 0);            
        }
        else
        {
            transform.Translate(0, 0, 0);
        }

        if (translationX != 0)
        {
            Player.GetComponent<Animator>().SetTrigger("Walking");
            //Player.GetComponent<Animator>().SetBool("Walk", true);
            Player.GetComponent<Animator>().SetBool("Idle", false);

            if (Input.GetAxis("Horizontal") < 0)
            {
                //Debug.Log(Input.GetAxis("Horizontal"));
                Player.GetComponent<SpriteRenderer>().flipX = true;
            }

            if (Input.GetAxis("Horizontal") > 0)
            {
                //Debug.Log(Input.GetAxis("Horizontal"));
                Player.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else
        {
            
            //Player.GetComponent<Animator>().SetBool("Walk", false);
            Player.GetComponent<Animator>().SetBool("Idle", true);
        }      

        Player.transform.Translate(_translateX, 0, 0);


        if (CJ.IsTouching(GameObject.Find("Tilemap").GetComponent<Collider2D>()))
        {
            //DJump = false;
            noChao = true;
            //Player.GetComponent<Animator>().SetBool("Jump", false);
            //Debug.Log("Está no Chão");
            Player.GetComponent<Animator>().SetBool("NoChao", true);
        }
        else
        {
            noChao = false;
            //Debug.Log("Está no Ar");
            Player.GetComponent<Animator>().SetBool("NoChao", false);
        }
                     
        //Jump
        if (Input.GetKeyDown(KeyCode.W) || (Input.GetButtonDown("Jump")))
        {
            //Debug.Log("Pulo");
            if (noChao == true)
            {
                //Debug.Log("Jump");
                Rb.AddForce(new Vector2(0f, _jumpForce));
                Player.GetComponent<Animator>().SetTrigger("Jumping");
                DJump = true;
            }
            //Double Jump
            //else
            //{
            //    if (noChao == false && DJump == true) // 
            //    {
            //        Rb.AddForce(new Vector2(0f, 200.0f));
            //        Player.GetComponent<Animator>().SetTrigger("DJump");
            //        DJump = false;
            //    }
            //}


        }

        GameObject swhitbox = GameObject.Find("SwHitbox");
        //swhitbox.GetComponent<CircleCollider2D>().IsTouching(GameObject.Find("RedEye").GetComponent<CircleCollider2D>());
        if (swhitbox.GetComponent<CircleCollider2D>().IsTouching(GameObject.Find("RedEye").GetComponent<CircleCollider2D>()))
        {
            Debug.Log("Acertou o inimigo!");
        }


        if (Input.GetButton("Fire1"))
        {           
            Player.GetComponent<Animator>().SetBool("Attack", true);            
        }
        else
        {
            Attack = false;
            //GameObject swhitbox = GameObject.Find("SwHitbox");
            swhitbox.GetComponent<CircleCollider2D>().enabled = false;
            Player.GetComponent<Animator>().SetBool("Attack", false);            
        }

    }


}
