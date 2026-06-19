using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "Monument", menuName = "Monument/MonumentData")]
public class MonumentData : ScriptableObject
{
    public string Monumentname;
    public string Monumentcity;
}
