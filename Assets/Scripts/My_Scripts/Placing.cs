using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Placing : MonoBehaviour
{
    // Start is called before the first frame update

    // public ArtifactData ArtifactData;
    public GameObject IceCream_stand;
    public float offset = 3f;
    public float duration = 0.09f;
    public GameObject PlacementLight;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       Artifact artifactt = other.GetComponent<Artifact>();
        
        if(artifactt != null)
        {

            Debug.Log("Artifact.Captured");
            if(artifactt.ArtifactData.ArtifactName == "Icecream")
            {
                artifactt.transform.DOPunchScale(Vector3.one * 0.2f, 0.4f);
                Debug.Log("animation_starts");
              IceCream_stand.transform.DOMoveY( transform.position.y + offset ,duration);
                PlacementLight.SetActive(true);
            }
        }
    }
}
