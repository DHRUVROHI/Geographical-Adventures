using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

public class PickupArtifact : MonoBehaviour
{
    // Start is called before the first frame update

    public static event System.Action<ArtifactData> Artifact_D;
    public static event System.Action<ArtifactData> Artifact_Dropped;
    private Artifact carriedartifact;
    private Artifact nearbyartifact;

    bool canpickartifact;
    public Transform Handsocket;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyBindings.Interact) && canpickartifact)
        {
            if (carriedartifact != null)
            {
                
                dropartifact();
            }

            else if (canpickartifact)
            {
                pickupartifact();
                
            }
        }
        
       

    }
    private void OnTriggerEnter(Collider collision)
    {
        Artifact artifact = collision.GetComponent<Artifact>();
       if(artifact != null && carriedartifact == null)
        {
           nearbyartifact = artifact;
            canpickartifact = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        Artifact artifact  = other.GetComponent<Artifact>();    
        if(artifact == nearbyartifact)
        {
            nearbyartifact = null;
         //   canpickartifact = false;
       
        }
    }

    public void pickupartifact()
    {

        if(nearbyartifact==null)
        {
            return;
        }
        carriedartifact = nearbyartifact;
        carriedartifact.transform.SetParent(Handsocket);
        //Debug.Log(carriedartifact.name);
        carriedartifact.transform.localPosition = carriedartifact.ArtifactData.holdoffset;
       
        if (carriedartifact != null)
        {
            carriedartifact.iscarried = true;
            Artifact_D?.Invoke(carriedartifact.ArtifactData);
       
        }
    }
    public void dropartifact()
    {
        carriedartifact.iscarried = false;
        Artifact_Dropped?.Invoke(null);
        carriedartifact.transform.SetParent(null);
       // Debug.Log(carriedartifact.name);
        carriedartifact = null;
        nearbyartifact = null;
        canpickartifact = false;


    }

}
