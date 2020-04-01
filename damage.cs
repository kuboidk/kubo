using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class damage : MonoBehaviour
{
    public float eulerAngZ = 0f;
    public int give = 0;
    public float range = 0.5f;
    public float speed = 5f;
    public LayerMask GetLayerMask;
    public Animator animator;
    public Transform point;

    public float attackrate = 2f;
    float nextattacktime = 0f;
    int currenthealth;
    public int maxhealth = 100;
    // Start is called before the first frame update
    void Start()
    {
    // Update is called once per frame
        animator = GetComponent<Animator>();

        currenthealth = maxhealth;
    }
    void Update()
    {
        if (Time.time >= nextattacktime)
        {

            onu();
            nextattacktime = Time.time + 1f / attackrate;

        }
       
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        
    }
    void onu()
    //  void onu(delay : float)
    {


        Collider2D[] hiti = Physics2D.OverlapCircleAll(point.position, range, GetLayerMask);
        foreach (Collider2D kubo in hiti)
        {
            animator.SetTrigger("attackgolem");
            kubo.GetComponent<kubo>().damagefxn(give);
            //yield WaitForSeconds(delay);
        }
    }
    public void damagefxn(int givedamage)
    {
        currenthealth -= givedamage;


        if (currenthealth <= 0)
        {
            Debug.Log("ded ");
            Destroy(gameObject);
        }
    }
}
