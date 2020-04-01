using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody2D))]
public class kubo : MonoBehaviour
{
    public LayerMask GetLayerMaskdoor;
    public Transform pointdoor;
    public float rangedoor = 0.5f;
    public BoxCollider2D boxCollider2D;
    public healthbarscript healthBar;
    public int maxHealth = 100;
    public int currentHealth;
    public Animator animator;
   
    private int count;
    public Text countText;
  
    public AudioClip audioClip;
    public float jumpboost = 100f;
    public float maxdownpos = -5f;
    public float speed = 5f;
    private bool isJumping = false;
    public Rigidbody2D rb;
    public int give = 10;
    public float range = 0.5f;
    public LayerMask GetLayerMask;
    public Transform point;
    public float attackrate = 2f;
   
    
  float nextattacktime = 0f;
   
    
    public Transform firePoint;
   
   public GameObject bulletPrefab;

    public bool isGrounded;
    private int countweapon;
    public Text weaponcounttext;
   
    
     private bool cool = false;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = audioClip;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();
        count = 0;
        countweapon = 0;
        SetCountText();
        SetCountTextweapon();
    }

    // Update is called once per frame
   
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.E) && count > 3)
        {
            Opendoor();

        }
            boxCollider2D.size = new Vector3(2.03f, 4.46f, 0);
        if (cool == true )
        {
            if (countweapon > 0)
            {
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    // Shoot();
                    animator.SetTrigger("through");
                }
            }
           
        }
       // if (Input.GetKeyUp(KeyCode.Mouse0))
      //  {
     //       animator.SetInteger("through", 0);
      //  }

        // if (cool == true)
        //  {
        //       Debug.Log("is cool");
        //   }
        if (Time.time >= nextattacktime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Hitonu();
                nextattacktime = Time.time + 1f / attackrate;
            }
            
        }

        ifJumping();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
          //  rb.AddForce(new Vector2(0f, jumpboost));
             transform.Translate(0, Time.deltaTime * jumpboost, 0);
            isGrounded = false;
            animator.SetInteger("jumponly", 10);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetInteger("attack", 5);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {

            animator.SetInteger("attack", 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            animator.SetInteger("jumpr", 0);
            animator.SetInteger("jumpl", 0);
            animator.SetInteger("runjumpl", 0);
            animator.SetInteger("runjump", 0);
            animator.SetInteger("jumponly", 0);

            if(Input.GetKey(KeyCode.C))
            {
                boxCollider2D.size = new Vector3 (5f, 3f, 0);
                animator.SetBool("slider", true);
            }
            //  if (Input.GetKeyDown(KeyCode.Space))
            // {
            //     transform.Translate(0, speed * Time.deltaTime * jumpboost, 0);
            //    animator.SetInteger("runjump", 6); isGrounded = true;

            //   }
         //   if (isJumping == false)
          //  {
                animator.SetInteger("run", 1);
            //  }
            // if (isJumping == true)
            if (isGrounded == false)
            {
                animator.SetInteger("jumpr", 3);
               animator.SetInteger("runjump", 6);

            }
        }


        if (Input.GetKeyUp(KeyCode.C))
        {
            animator.SetBool("slidel", false);
            animator.SetBool("slider", false);
        }


        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetInteger("run", 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetInteger("jumponly", 0);
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            animator.SetInteger("jumpl", 0);
            animator.SetInteger("jumpr", 0);
            animator.SetInteger("runjumpl", 0);
            animator.SetInteger("runjump", 0);

            if (Input.GetKey(KeyCode.C))
            {
                boxCollider2D.size = new Vector3(5f, 3f, 0);
                animator.SetBool("slidel", true);
            }
            //  if (Input.GetKeyDown(KeyCode.Space))
            //   {
            //      transform.Translate(0, speed * Time.deltaTime * jumpboost, 0);
            //      animator.SetInteger("runjumpl", 7
            //  }




          //  if (isJumping == false)
          //  {
                animator.SetInteger("runl", 2);
         //   }
            if (isGrounded == false)
            {
                animator.SetInteger("jumpl", 4);

               animator.SetInteger("runjumpl", 7);

            }
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetInteger("runl", 0);
        }

        animator.SetBool("hurt", false);


        if (rb.position.y < maxdownpos)
        {
            // Debug.Log("ded ");
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            // Application.Quit();
        }

    }
    void OnCollisionStay2D()
    {
        isGrounded = true;
    }
    
    void OnTriggerEnter2D(Collider2D mol)
    {
        if (mol.gameObject.name == "Kunai")
        {
            Destroy(mol.gameObject);
             cool = true;
            countweapon = countweapon +3;
            SetCountTextweapon();
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "koin")
        {
            Destroy(col.gameObject);
            GetComponent<AudioSource>().Play();
            count = count + 1;
            SetCountText();
        }
       // if (col.gameObject.name == "Kunai")
       // {
      //      Destroy(col.gameObject);
       //    cool = true;
      //  }
    }
    
    void SetCountText()
    {
        countText.text = "" + count.ToString();

    }
    void SetCountTextweapon()
    {
        // countText.text = "" + count.
        weaponcounttext.text = "" + countweapon.ToString();

    }
    void ifJumping()
    {
        if (rb.velocity.y < 0)
        {
            isJumping = true;
        }
        if (rb.velocity.y == 0)
        {
            isJumping = false;
        }
    }
    
    void OnDrawGizmosSelected()
    {
        if (point == null)
            return;
        Gizmos.DrawWireSphere(point.position, range);
    }
    public void Hitonu()

    {

        //  animator.SetInteger("attack", 5);
        Collider2D[] door = Physics2D.OverlapCircleAll(point.position, range, GetLayerMask);
        foreach (Collider2D creep in door)
        {
            creep.GetComponent<damage>().damagefxn( give);
        }
    }
    public void damagefxn(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        animator.SetBool("hurt",true);
        // if (Mathf.Abs(rb.velocity.x < .1f))
        //   {

        //   }



        if (currentHealth <= 0)
        {
            Debug.Log("ded player ");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            //   animator.SetInteger("ded", 9);
            Destroy(gameObject);

        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        countweapon = countweapon - 1;
        SetCountTextweapon();
       // animator.SetTrigger("through");
    }
    public void Opendoor()

    {
        count = count - 3;
        SetCountText();
        //  animator.SetInteger("attack", 5);
        Collider2D[] oor = Physics2D.OverlapCircleAll(pointdoor.position, rangedoor, GetLayerMaskdoor);
        foreach (Collider2D fordoor in oor)
        {
            fordoor.GetComponent<doorscript>().doorfxn();
        }
    }
}
