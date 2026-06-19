
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UI_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text Artifactname;
    public TMP_Text Artifactweight;
    public TMP_Text Player_corrdinates;
    public Image Artifactimage;

    public TMP_Text Monumentname;
    public TMP_Text Monumentcity;


    public Transform player;
    public float lookaheadDst = 5;
    Vector2 playerTexCoord;
    float latitude;
    float longitude;

    public CanvasGroup Exploration_HUD;

    public float smoothTime;
    float smoothV;

    void Start()
    {
        PickupArtifact.Artifact_D += updateArtifactname;
        PickupArtifact.Artifact_D += updateArtifactweight;
        PickupArtifact.Artifact_D += updateArtifactImage;

        Monumentinteraction.Monumentexitrregiondata += updateMonumentname;
        Monumentinteraction.Monumentexitrregiondata += updateMonumentcity;



    }

// Update is called once per frame
void Update()
    {
        bool uiisactive = GameController.IsState(GameState.Playing);
            {
            Exploration_HUD.alpha = Mathf.SmoothDamp(Exploration_HUD.alpha, uiisactive ? 1 : 0, ref smoothV, smoothTime);

        }
       playerTexCoord = GeoMaths.PointToCoordinate((player.position + player.forward * lookaheadDst).normalized).ToUV();
        longitude = playerTexCoord.x;
        latitude = playerTexCoord.y;
        updatePlayerCorrdinates();
    }

    public void updateArtifactname(ArtifactData artifactData)
    {
        Artifactname.text = artifactData.ArtifactName;
    }
    public void updateArtifactweight(ArtifactData artifactData)
    {
        Artifactweight.text = "" + artifactData.weight;
    }
    public void updateArtifactImage(ArtifactData artifactData)
    {
        Artifactimage  = artifactData.icon;
    }

    public void updatePlayerCorrdinates()
    {
        Player_corrdinates.text = " " + $"Lat: {longitude:F2}" + "," + " " + $"Lat: {latitude:F2}";

    }

    public void updateMonumentname(MonumentData monument)
    {
        Monumentname.text = monument.Monumentname;
    }
    public void updateMonumentcity(MonumentData monument)
    {
        Monumentcity.text = "" + monument.Monumentcity;
    }
   


}
