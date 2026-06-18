using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ CreateAssetMenuAttribute(fileName = "Artifact" , menuName ="Artifacts/Artifactsobject")]
public class ArtifactData : ScriptableObject
{
    public string ArtifactName;
    public string Description;
    public float weight;
    public Image icon;
    public Vector3 holdoffset;
    public float groundoffset;


}
