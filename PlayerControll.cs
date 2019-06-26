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
        Controlers();      
    }

    //Function called from third frame at attack animation
    void HitBox()
    {
        GameObject swhitbox = GameObject.Find("SwHitbox");
        swhitbox.GetComponent<CircleCollider2D>().enabled = true;        
    }
       

    void Controlers()
    {
        GameObject swhitbox = GameObject.Find("SwHitbox");
        CJ = GameObject.Find("CJ").GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        Rb = Player.GetComponent<Rigidbody2D>();

        float translationY = 0;
        float translationX = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;

        //if it's attacking then stop move
        if (Player.GetComponent<Animator>().GetBool("Attack") != true)        
        {
            transform.Translate(translationX, translationY, 0);            
        }
        else
        {
            transform.Translate(0, 0, 0);
        }

        //if it's on movement
        if (translationX != 0)
        {
            Player.GetComponent<Animator>().SetTrigger("Walking");            
            Player.GetComponent<Animator>().SetBool("Idle", false);

            if (Input.GetAxis("Horizontal") < 0)
            {                
                Player.GetComponent<SpriteRenderer>().flipX = true;
            }

            if (Input.GetAxis("Horizontal") > 0)
            {                
                Player.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else
        {   
            Player.GetComponent<Animator>().SetBool("Idle", true);
        }      

        Player.transform.Translate(_translateX, 0, 0);

        //if it's touching on the ground
        if (CJ.IsTouching(GameObject.Find("Tilemap").GetComponent<Collider2D>()))
        {            
            noChao = true;
            Player.GetComponent<Animator>().SetBool("NoChao", true);
        }
        else
        {
            noChao = false;            
            Player.GetComponent<Animator>().SetBool("NoChao", false);
        }
                     
        //Jump
        if (Input.GetKeyDown(KeyCode.W) || (Input.GetButtonDown("Jump")))
        {            
            if (noChao == true)
            {                
                Rb.AddForce(new Vector2(0f, _jumpForce));
                Player.GetComponent<Animator>().SetTrigger("Jumping");
                DJump = true;
            } 
        }

        
        //Hit Enemy
        if (swhitbox.GetComponent<CircleCollider2D>().IsTouching(GameObject.Find("RedEye").GetComponent<CircleCollider2D>()))
        {
            Debug.Log("Acertou o inimigo!");
        }

        //Attack
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
