using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events; 
public class sacPotScript : MonoBehaviour
{

    [SerializeField] GameObject prompt;
    public GameObject shop;
    public GameObject lastHealthPopUp;
    private Boolean speedUsed = false;
    public static int numbSpeedBoost;
    public TextMeshProUGUI speedBoostText;
    
    public GameObject trailSpeed;

    // Start is called before the first frame update
    void Start()
    {
        prompt.SetActive(false);
        shop.SetActive(false);
        trailSpeed.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        // speed boost activation on key press "Q"
        if (Input.GetKeyDown(KeyCode.Q) && numbSpeedBoost > 0)
        {
            numbSpeedBoost -= 1; 
            //speed boost
            StartCoroutine(speedBoost());
            speedUsed = true;
            StartCoroutine(speedDelay());
        }

        speedBoostText.text = numbSpeedBoost.ToString(); 

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            prompt.SetActive(true);

            shop.SetActive(true);
        }


    }

    void OnTriggerExit2D (Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            prompt.SetActive(false);
            shop.SetActive(false);
        }
            
    }

    public void option1()
    {
        if(playerHealthControl.currentHealth > 1)
        {
            playerHealthControl.currentHealth = playerHealthControl.currentHealth - 1;
            PlayerBombController.bombCount += 1; 
        } else 
        {
            Debug.Log("not enough health");
            Instantiate(lastHealthPopUp, new Vector3(transform.position.x,
                transform.position.y + 1.5f, transform.position.z), Quaternion.identity);
            

        }
        
    }


    public void option2()
    {
        if (playerHealthControl.currentHealth > 7 && PlayerBombController.bombCount >= 1)
        {
            playerHealthControl.currentHealth = playerHealthControl.currentHealth - 7;
            PlayerBombController.bombCount = PlayerBombController.bombCount - 1;
            //give player the insta potion
            playerHealthControl.numbBigHealthPotion += 1;

        } else
        {
            Debug.Log("not enough health");
            Instantiate(lastHealthPopUp, new Vector3(transform.position.x,
                transform.position.y + 1.5f, transform.position.z), Quaternion.identity);
        }

    }


    public void option3()
    {
        
        if (playerHealthControl.currentHealth > 3 && speedUsed == false)
        {
            playerHealthControl.currentHealth -= 3;
            numbSpeedBoost += 1;

            
        } else
        {
            Debug.Log("not enough health");
            Instantiate(lastHealthPopUp, new Vector3(transform.position.x,
                transform.position.y + 1.5f, transform.position.z), Quaternion.identity);
        }

    }



    IEnumerator speedBoost()
    {
        PlayerMovement.moveSpeed += 2.5f;
        trailSpeed.SetActive(true); 
        yield return new WaitForSeconds(4);
        PlayerMovement.moveSpeed -= 2.5f;
        trailSpeed.SetActive(false);

    }

    IEnumerator speedDelay()
    {
        
        yield return new WaitForSeconds(1.5f);

        speedUsed = false;
    }




}
