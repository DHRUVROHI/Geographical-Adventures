using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monumentinteraction : MonoBehaviour
{

    public static event System.Action<MonumentData> Monumententerregiondata;
    public static event System.Action<MonumentData> Monumentexitrregiondata;


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
        Monumententerregiondata?.Invoke(monument.monumentdata);
    }

    public void OnTriggerExit(Collider other)
    {
        Monument monument = other.GetComponent<Monument>();
        //   Monumentexitrregiondata?.Invoke(monument.monumentdata);
        Monumententerregiondata?.Invoke(null);

}
}
