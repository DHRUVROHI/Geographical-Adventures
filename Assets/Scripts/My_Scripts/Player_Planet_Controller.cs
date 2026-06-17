using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player_Planet_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isspherical = true;
    public float min_speed;
    public float max_speed;
  //  public float rotation_speed;
    public float acceleration;
    
    float horizontal;
    float vertical;

    Vector3 movepos;
    Vector3 movedir;


    float currentspeed;
    float basetargetspeed;
    float desiredspeed;
    public float speedsmooting = 0.1f;

    public float turnspeed;
    public float smoothturntime;
    float smoothedturnspeed;
    float refsmoothturn;

    
 

    float worldRadius;
    public TerrainGeneration.TerrainHeightSettings heightSettings;




    private void Awake()
    {
        worldRadius = heightSettings.worldRadius;
        basetargetspeed = Mathf.Lerp(min_speed, max_speed, 0.35f);
        currentspeed = basetargetspeed;
        desiredspeed = 15f;
       
 
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
        HandleMovement();
    }

    public void updatemovementInput(Vector2 move)

    {
        horizontal = move.x;
        vertical = move.y;
        desiredspeed = move.magnitude > 0 ? max_speed : 0f;
        movepos =  transform.forward * vertical + transform.right * horizontal;
        movedir = movepos.normalized;
        basetargetspeed = Mathf.MoveTowards(basetargetspeed, desiredspeed, acceleration * Time.deltaTime);
        basetargetspeed = Mathf.Clamp(basetargetspeed, min_speed, max_speed);
        
     
    }
    public void HandleMovement()
    {
        currentspeed = Mathf.Lerp(currentspeed, basetargetspeed, 1 - Mathf.Pow(speedsmooting, Time.deltaTime));
        smoothedturnspeed = Mathf.SmoothDamp(smoothedturnspeed, horizontal * turnspeed, ref refsmoothturn, smoothturntime);
        float turnAmount = smoothedturnspeed * Time.deltaTime;
        updateposition();
        updaterotation(turnAmount);

    }
    

    public void updateposition()
    {
        Vector3 newpos = transform.position + movepos * currentspeed * Time.deltaTime;
        if(isspherical)
        {
            newpos = newpos.normalized * worldRadius;
        }
        transform.position = newpos ;

    }

    public void updaterotation(float turnamount)
    {
        if (isspherical)
        {
            Vector3 gravityup = transform.position.normalized;
          //  Quaternion TargetRotaton =  Quaternion.LookRotation(movedir, gravityup);

            //transform.rotation = Quaternion.Slerp(transform.rotation, TargetRotaton, turnspeed * Time.deltaTime);
            transform.RotateAround(transform.position, gravityup, turnamount);
           // transform.LookAt((transform.position + transform.forward * 10).normalized * worldRadius , gravityup);
            transform.rotation = Quaternion.FromToRotation(transform.up, gravityup) * transform.rotation;

        }


    }

    public float speedT
    {
         get
            {
            return Mathf.InverseLerp(min_speed, max_speed, currentspeed);
        }

      
    }

    public Vector3 Gravityup
    {
        get
        {
           return (isspherical)?transform.position.normalized : Vector3.up  ;
        }
    }

}
