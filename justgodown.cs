using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class justgodown : MonoBehaviour
{
   // public float maxdownpos = 6.439946f;
    public Rigidbody2D rb;
    public float peed = 9.8f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      //  fxn();
    }
    public void fxn(float peed)
    {

        rb.velocity = transform.up * -peed * Time.deltaTime;
        if (rb.position.y < 6f)
       {

            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
        //transform.Translate(0, -Time.deltaTime * peed, 0);
        // Physics2D.gravity = new Vector2(0, -peed);
    }
}

//   Physics2D.gravity = new Vector2(0, 9.8f);
//6.37
 
           
            // Application.Quit();
        