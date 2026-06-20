using System;
using System.Collections;
using System.Collections.Generic;
using TriangleNet.Smoothing;
using UnityEngine;

public class Third_person_Camera : MonoBehaviour
{
    public event System.Action<Camera> gameCameraUpdateComplete;
    public float fovslow;
    public float fovfast;
    

    public float cameraorbitSpeed = 3f;
    



    [Header("Alternate View Settings")]
    public viewsettings thirdcameraview;

    public Camera cam;

    public Player_Planet_Controller player;
    Transform target;
    float smoothFovVelocity;
    public float fovsmoothtime;
   
    // Start is called before the first frame update
    void Start()
    {
        target = player.transform;
        cam.fieldOfView = calculatefov();
        updatecameraview(thirdcameraview);
    }

    private void LateUpdate()
    {
        updatecameraview(thirdcameraview);
        cam.fieldOfView   = Mathf.SmoothDamp(cam.fieldOfView , calculatefov(), ref smoothFovVelocity , fovsmoothtime);

    }


    float calculatefov()
    {
       return Mathf.Lerp(fovslow, fovfast, player.speedT);
    }

    void updatecameraview(viewsettings view)
    {
        Vector3 newpos = target.position + target.forward * view.offset.z + player.Gravityup * view.offset.y;
        Vector3 lookTarget = target.position;
        lookTarget += target.right * view.looktargetoffset.x;
        lookTarget += target.up * view.looktargetoffset.y;
        lookTarget += target.forward * view.looktargetoffset.z;
        transform.position = newpos;
        transform.LookAt(lookTarget , player.Gravityup);
        
    }

    [System.Serializable]
    public struct viewsettings
    {
      public Vector3 offset;
      public Vector3 looktargetoffset;

        public viewsettings(Vector3 offset, Vector3 looktargetoffset)
        {
            this.offset = offset;
            this.looktargetoffset = looktargetoffset;
        }
    
        public static viewsettings Lerp(viewsettings a , viewsettings b , float t)
        {
            Vector3 offset = Vector3.Lerp(a.offset, b.offset, t);
            Vector3 looktargetoffset  = Vector3.Lerp(a.looktargetoffset, b.looktargetoffset, t);
            return new viewsettings(offset, looktargetoffset);
        }
    }



    // Update is called once per frame
    void Update()
    {
        
           
        
    }
}
