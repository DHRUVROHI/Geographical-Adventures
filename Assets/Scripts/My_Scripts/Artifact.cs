using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    // Start is called before the first frame update
    public event System.Action<ArtifactData> Artifact_D; 

    public ArtifactData ArtifactData;
    float worldRadius;
 
    public TerrainGeneration.TerrainHeightSettings heightSettings;

    public bool iscarried = false; 
    public void Awake()
    {
        worldRadius = heightSettings.worldRadius;

    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        updaterotation();
        updatepos();
    }
    
    public void updatepos()
    {
        if (!iscarried)
        {

            Vector3 newpos = transform.position.normalized;
            transform.position = newpos * (worldRadius + ArtifactData.groundoffset); //+ArtifactData.holdoffset
        }
    }

    public void updaterotation()
    {
        Vector3 GravityUp = transform.position.normalized;
        transform.rotation = Quaternion.FromToRotation(transform.up , GravityUp) * transform.rotation;
    }
}
