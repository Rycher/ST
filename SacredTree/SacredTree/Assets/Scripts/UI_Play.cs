using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_Play : MonoBehaviour    
{
    public Button Play;
    // Start is called before the first frame update
    void Start()
    {
        Play.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {        
        //Button Play = transform.Find("btnPlay").GetComponent<Button>();
                     
    }

    
    void TaskOnClick()
    {
        Debug.Log("Clicado");
        SceneManager.LoadScene(1);        
    }
}
