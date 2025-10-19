using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject selectConfirmScreen;

    public Transform player; //doing this here is dumb but quick
    //public GameObject interactNotifyTextButtonThing;
    public TextMeshProUGUI interactNotifyTextButtonThing;
    public float interactDistance = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactNotifyTextButtonThing.text = GameVariables.playerChooseButton.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        



        if (GameVariables.selectedCharacter != null)
        {
            selectConfirmScreen.SetActive(true);
        }
        else
        {
            selectConfirmScreen.SetActive(false);
        }


        foreach (var guy in FindObjectsByType<NPC>(FindObjectsSortMode.None))
        {
            if (Vector2.Distance(player.transform.position, guy.transform.position) <= interactDistance)
            {
                interactNotifyTextButtonThing.gameObject.SetActive(true);

                if (Input.GetKeyDown(GameVariables.playerChooseButton))
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
}
