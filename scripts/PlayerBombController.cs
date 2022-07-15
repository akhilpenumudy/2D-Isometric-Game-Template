using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class PlayerBombController : MonoBehaviour
{
    public GameObject bombPrefab; 
     public Animator anim;
    public static int bombCount;
    public TextMeshProUGUI textMesh;
    private Boolean canDrop = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && bombCount > 0 && canDrop == true)
        {
            print("space key was pressed");
            //anim.Play("throw");
            Instantiate(bombPrefab, transform.position, Quaternion.identity);
            bombCount = bombCount - 1;
            canDrop = false;
            StartCoroutine(dropdelay());
        }
        textMesh.text = bombCount.ToString();
    }



    IEnumerator dropdelay()
    {

        yield return new WaitForSeconds(2);
        canDrop = true;

    }




}
