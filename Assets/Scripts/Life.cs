using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Life : MonoBehaviour
{
    public static float Health;
    float MaxHealth;
    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = 100f;
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Image HealthBar = GameObject.Find("HealthBar").GetComponent<Image>();
        HealthBar.fillAmount = Health / MaxHealth;
    }
}
