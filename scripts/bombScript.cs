using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombScript : MonoBehaviour
{

    BoxCollider2D boxcol;
    public GameObject explosion;
    public GameObject bomb; 
    // Start is called before the first frame update
    void Start()
    {
        
        boxcol = gameObject.GetComponent<BoxCollider2D>();
        //disable the collider
        boxcol.enabled = false;
        Debug.Log("false"); 
        StartCoroutine(detonateTime());
        
    }

    

    // Update is called once per frame
    void Update()
    {

        

    }

    IEnumerator detonateTime()
    {
        
        yield return new WaitForSeconds(2);
        //enable the collider
        boxcol.enabled = true;
        Debug.Log(true);
        Instantiate(explosion, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(0.01f);
        Destroy(gameObject);

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        Destroy(col.gameObject);
    }


}
