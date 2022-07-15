using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class playerHealthControl : MonoBehaviour
{
    
    public int startingHealth;
    public static int currentHealth; 
    public TextMeshProUGUI textMesh;
    public static int numbBigHealthPotion;
    public TextMeshProUGUI bigHealthText;
    public GameObject powerUpHealth;
   

    // Start is called before the first frame update
    void Start()
    {
        //textMesh = FindObjectOfType<TextMeshProUGUI>();
        currentHealth = startingHealth; 
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = currentHealth.ToString();
        bigHealthText.text = numbBigHealthPotion.ToString();

        // big health activation on key press "R" 
        if (Input.GetKeyDown(KeyCode.R) && numbBigHealthPotion > 0)
        {
            currentHealth = currentHealth + 7;
            numbBigHealthPotion -= 1;
            Instantiate(powerUpHealth, transform.position, Quaternion.identity);
        }
        

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "heart_item")
        {
            playerHealthControl.currentHealth = playerHealthControl.currentHealth + 1;
            Destroy(collision.gameObject);
          
        }

        


    }




}
