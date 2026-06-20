
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UI_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text Artifactname;
    public TMP_Text Artifactweight;
    public TMP_Text Player_corrdinates;
    public Image Artifactimage;

    public TMP_Text Monumentname;
    public TMP_Text Monumentcity;
    
    public TMP_Text DiscoveryQuest_tajmahal;
    public TMP_Text DiscoveryQuest_QutubMinar;
    public TMP_Text DiscoveryQuest_IndiaGate;
    public TMP_Text DiscoveryQuest_Jamamasjid;


    public Transform player;
    public float lookaheadDst = 5;
    Vector2 playerTexCoord;
    float latitude;
    float longitude;



    public float UIFade_time = 0.5f;
    

    public CanvasGroup Exploration_HUD;

    public float smoothTime;
    float smoothV;

    void Start()
    {
        PickupArtifact.Artifact_D += updateArtifactname;
        PickupArtifact.Artifact_D += updateArtifactweight;
        PickupArtifact.Artifact_D += updateArtifactImage;

        Monumentinteraction.Monumententerregiondata += updateMonumentname;
        Monumentinteraction.Monumententerregiondata += updateMonumentcity;
        Monumentinteraction.Monumententerregiondata += Questui;
        Monumentname.text = "";
        Monumentcity.text = "";
        //Artifactimage.sprite = null;
       // DiscoveryQuest_IndiaGate.text = "<color=red>TEST</color>";


    }

// Update is called once per frame
void Update()

    {

        if (player == null) return;
        if (Exploration_HUD == null) return;
        if (Player_corrdinates == null) return;

        bool uiisactive = GameController.IsState(GameState.Playing);
            {
            Exploration_HUD.alpha = Mathf.SmoothDamp(Exploration_HUD.alpha, uiisactive ? 1 : 0, ref smoothV, smoothTime);

        }
       playerTexCoord = GeoMaths.PointToCoordinate((player.position + player.forward * lookaheadDst).normalized).ToUV();
        longitude = playerTexCoord.x;
        latitude = playerTexCoord.y;
        updatePlayerCorrdinates();

    }

    private void OnDestroy()
    {
        PickupArtifact.Artifact_D -= updateArtifactname;
        PickupArtifact.Artifact_D -= updateArtifactweight;
        PickupArtifact.Artifact_D -= updateArtifactImage;

        Monumentinteraction.Monumententerregiondata -= updateMonumentname;
        Monumentinteraction.Monumententerregiondata -= updateMonumentcity;
        Monumentinteraction.Monumententerregiondata -= Questui;
    }

    public void updateArtifactname(ArtifactData artifactData)
    {

        if (Artifactweight == null)
            return;

        Artifactname.DOKill();
        Sequence seq = DOTween.Sequence();
       // Artifactname.transform.localPosition = Vector3.zero;
        if (artifactData == null)
        {
            seq.Join(Artifactname.DOFade(0, UIFade_time));
           
          //  seq.Join(Artifactname.transform.DOScale(0.8f, UIFade_time));
            return;
        }

        Artifactname.text = " Artifact name "  +  artifactData.ArtifactName;
        seq.Join(Artifactname.DOFade(1, UIFade_time));
        // seq.Join(Artifactname.transform.DOScale(1f, UIFade_time));
       
    }
    public void updateArtifactweight(ArtifactData artifactData)
    {
        if (Artifactname == null)
            return;


        Artifactweight.DOKill();
        Sequence seq = DOTween.Sequence();
      //  Artifactweight.transform.localPosition = Vector3.zero;
        if (artifactData == null)
        {
            seq.Join(Artifactweight.DOFade(0, UIFade_time));
         //   seq.Join(Artifactweight.transform.DOScale(0.8f, UIFade_time));
            return;
        }

        Artifactweight.text = " Artifact Weight "  +  + artifactData.weight;
        seq.Join(Artifactweight.DOFade(1, UIFade_time));
       // seq.Join(Artifactweight.transform.DOScale(1f, UIFade_time));
    }
    public void updateArtifactImage(ArtifactData artifactData)
    {
        if (Artifactimage == null)
        {
           // Debug.LogError("Artifactimage reference lost!");
            return;
        }

        // Artifactimage.DOKill();
        //Sequence seq = DOTween.Sequence();
        //  Artifactimage.transform.localPosition = Vector3.zero;
        // Debug.Log("Updating image: " + artifactData.icon.name);
        if (artifactData == null)
        {
            //seq.Join(Artifactimage.DOFade(0, UIFade_time));
            //seq.Join(Artifactimage.transform.DOScale(0.8f, UIFade_time));
            Artifactimage.sprite = null;
            return;
        }

        Artifactimage.sprite = artifactData.icon;
       // seq.Join(Artifactimage.DOFade(1, UIFade_time));
        // seq.Join(Artifactimage.transform.DOScale(1f, UIFade_time));
    }

    public void updatePlayerCorrdinates()
    {
        Player_corrdinates.text = " " + $"Long: {longitude:F2}" + "," + " " + $"Lat: {latitude:F2}";

    }

    public void updateMonumentname(MonumentData monument)
    {
        if (Monumentname == null)
            return;

        Monumentname.DOKill();
        Sequence seq = DOTween.Sequence();
        // Debug.Log("updatemonumetname : " + monument.name);
        if (monument == null)
        {

            seq.Join(Monumentname.DOFade(0, UIFade_time));
            seq.Join(Monumentname.transform.DOScale(0.8f, UIFade_time));
            return;
        }

        Monumentname.transform.localScale = Vector3.zero;
        Monumentname.text = monument.Monumentname;
      
        seq.Join(Monumentname.DOFade(1, UIFade_time));
        seq.Join(Monumentname.transform.DOScale(1f, UIFade_time));
        

    }
    public void updateMonumentcity(MonumentData monument)
    {

        if (Monumentcity == null)
            return;
        Monumentcity.DOKill();
        Sequence seq = DOTween.Sequence();
        if (monument == null)
        {
           
            seq.Join(Monumentcity.DOFade(0, UIFade_time));
            seq.Join(Monumentcity.transform.DOScale(0.8f, UIFade_time));
            return;

        }
        Monumentcity.transform.localScale = Vector3.zero;
        Monumentcity.text = "" + monument.Monumentcity;

        seq.Join(Monumentcity.DOFade(1, UIFade_time));
        seq.Join(Monumentcity.transform.DOScale(1f, UIFade_time));
        

    }
    public void Questui(MonumentData monument)
    {
       // Debug.Log("QuestUI Called");
        if (monument == null)
        {
            return;
        }

        if (DiscoveryQuest_IndiaGate == null ||
      DiscoveryQuest_tajmahal == null ||
      DiscoveryQuest_Jamamasjid == null ||
      DiscoveryQuest_QutubMinar == null)
            return;

        //  Debug.Log("Monument Name: " + monument.Monumentname);

        if (monument.Monumentname == "India Gate")
            {
                DiscoveryQuest_IndiaGate.text =$"<s>{DiscoveryQuest_IndiaGate.text}</s>";
            }
            if (monument.Monumentname == "Taj mahal")
            {
                DiscoveryQuest_tajmahal.text = $"<s>{DiscoveryQuest_tajmahal.text}</s>";
            }
            if (monument.Monumentname == "Jama masjid")
            {
                DiscoveryQuest_Jamamasjid.text = $"<s>{DiscoveryQuest_Jamamasjid.text}</s>";
            }
            if (monument.Monumentname == "Qutub minar")
            {
                DiscoveryQuest_QutubMinar.text = $"<s>{DiscoveryQuest_QutubMinar.text}</s>";
            }
        }
    }


