using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_Quit : MonoBehaviour
{
    public Button Quit;
    // Start is called before the first frame update
    void Start()
    {
        Quit.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClick()
    {
        //Debug.Log("Quit");
        Application.Quit();
    }

}
