using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveArmadilha : MonoBehaviour
{
    public Transform prefab;
    GameObject Player;
    bool ShurikenGer = false;
    // Start is called before the first frame update
    void Start()
    {
        ;
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.Find("Player");
        Player.GetComponent<Transform>();
        Collider2D PlayerCollider;

        if (Player.transform.position.x > 2f && Player.transform.position.y > 0.4f)
        {            

            if (ShurikenGer == false)
            {
                for (int i = 0; i < 1; i++)
                {
                    Instantiate(prefab, new Vector2(11f, 2.8f), Quaternion.identity);
                    ShurikenGer = true;
                }
            }      
        }

        if (ShurikenGer == true)
        {
            GameObject Shuriken = GameObject.Find("Shuriken_0(Clone)");
            Shuriken.transform.Translate(-0.30f, 0, 0);
            PlayerCollider = Player.GetComponent<BoxCollider2D>();            
            if (Shuriken.GetComponent<BoxCollider2D>().IsTouching(PlayerCollider) == true)
            {
                SceneManager.LoadScene("SampledScene");
            }
        }
       

        
    }
}
