
using System;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))] 
public class circleScript : MonoBehaviour
{
    [SerializeField] int radius =0;
    [SerializeField] int vertices =0;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] float width =0.3f;
    Vector3 pose;
    float theta;
    [SerializeField] int lVertices;
    [SerializeField] Vector2 mousePos;
    bool hold;
      [SerializeField] GameObject enemy;
       [SerializeField]  int generation =1;
  public  int  numberOfEnemies =2 ;
    int devidor;

  
    Vector2 mouse1 ;
    Vector2 mouse2;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
     
        drawingCircle();
    }
    void countFxn()
    {
        numberOfEnemies = 2 * (int)( Math.Pow(2, generation));
        devidor = numberOfEnemies;
        Debug.Log(numberOfEnemies);
    }
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            generation++;
            countFxn();
        }

    
        drawLineWithMouse();
       
    }
    void drawingCircle()
    {
        
        lineRenderer.widthMultiplier = width;
        lineRenderer.positionCount = vertices;
        float dtheta = (2f * Mathf.PI) / vertices;

        for (int i = 0; i < vertices; i++)
        {
            Vector3 pose = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta), 0f);
            lineRenderer.SetPosition(i, pose);
            theta += dtheta ;
        }
    }
    void drawLineWithMouse()
    {
        
        lVertices += 1;
          lineRenderer.positionCount = lVertices ;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lineRenderer.SetPosition(lVertices-1, mousePos);

      
    }



}
