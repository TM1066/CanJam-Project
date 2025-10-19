using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject selectConfirmScreen;
    public Transform selectedGuyParent;
    public GameObject guyPrefab;
    private GameObject guyPicture;

    public Transform player; //doing this here is dumb but quick
    //public GameObject interactNotifyTextButtonThing;
    public TextMeshProUGUI interactNotifyTextButtonThing;
    public TextMeshProUGUI winLoseTextMesh;
    public float interactDistance = 0.5f;



    public AudioSource bgmPlayer;
    public AudioClip winAudio;
    public AudioClip loseAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactNotifyTextButtonThing.text = "E";
    }

    // Update is called once per frame
    void Update()
    {
        if (GameVariables.selectedCharacter != null && !selectConfirmScreen.activeSelf)
        {
            selectConfirmScreen.SetActive(true);
            guyPicture = Instantiate(guyPrefab, selectedGuyParent);
            guyPicture.GetComponent<NPC>().hatRenderer.sprite = GameVariables.selectedCharacter.GetComponent<NPC>().hatRenderer.sprite;
            guyPicture.GetComponent<NPC>().maskRenderer.sprite = GameVariables.selectedCharacter.GetComponent<NPC>().maskRenderer.sprite;
            guyPicture.GetComponent<NPC>().outfitColor = GameVariables.selectedCharacter.GetComponent<NPC>().outfitColor;
            guyPicture.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            foreach (var renderer in guyPicture.GetComponentsInChildren<SpriteRenderer>())
            {
                renderer.sortingOrder = 1000;
            }
            guyPicture.transform.localScale = new Vector3(50, 50);
        }
        else if (GameVariables.selectedCharacter == null && selectConfirmScreen.activeSelf)
        {
            if (guyPicture)
            {
                Destroy(guyPicture);
            }

            selectConfirmScreen.SetActive(false);
        }


        foreach (var guy in FindObjectsByType<NPC>(FindObjectsSortMode.None))
        {
            if (Vector2.Distance(player.transform.position, guy.transform.position) <= interactDistance)
            {
                interactNotifyTextButtonThing.gameObject.SetActive(true);

                if (Input.GetKeyDown(GameVariables.playerChooseButton) && GameVariables.PlayerCanMove)
                {
                    GameVariables.selectedCharacter = guy.gameObject;
                }
            }
            else
            {
                interactNotifyTextButtonThing.gameObject.SetActive(false);
            }
        }
    }

    public void DeselectCharacter()
    {
        GameVariables.selectedCharacter = null;
    }

    public void ConfirmCharacter()
    {
        Time.timeScale = 0.75f;
        winLoseTextMesh.gameObject.SetActive(true);
        if (GameVariables.selectedCharacter.GetComponent<NPC>().isAttention)
        {
            winLoseTextMesh.text = "You Ween!";
            bgmPlayer.clip = winAudio;
            bgmPlayer.Play();
        }
        else
        {
            winLoseTextMesh.text = "You Fail!";
            bgmPlayer.clip = loseAudio;
            bgmPlayer.Play();
        }


        GameVariables.selectedCharacter.GetComponent<NPC>().SelectCharacter();
        GameVariables.selectedCharacter = null;
    }
}
