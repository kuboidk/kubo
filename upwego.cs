using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upwego : MonoBehaviour
{
    public float upspeed = 1f;
    public float x = 1f;
    public float y = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(x, Mathf.PingPong(Time.time, upspeed) +y, 0f);
    }
}
