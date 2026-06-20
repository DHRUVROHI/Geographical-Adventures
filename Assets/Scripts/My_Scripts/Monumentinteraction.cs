using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monumentinteraction : MonoBehaviour
{

    public static event System.Action<MonumentData> Monumententerregiondata;
    public static event System.Action<MonumentData> Monumentexitrregiondata;
    Monument currentmonument;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collision)
    {
        Monument monument = collision.GetComponent<Monument>();

        if (monument != null)
        {
          //  Debug.Log("Monument reached");
            currentmonument = monument;
            Displayartifactname();
           
            
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Monument monument = other.GetComponent<Monument>();

        if (monument != null)
        {
            monument = null;
            Monumententerregiondata?.Invoke(null);

        }
        //   Monumentexitrregiondata?.Invoke(monument.monumentdata);

    }

    public void Displayartifactname()
    {
        Monumententerregiondata?.Invoke(currentmonument.monumentdata);
    }
}
