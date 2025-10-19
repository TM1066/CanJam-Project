using TMPro;
using UnityEngine;

public class MainMenuStuff : MonoBehaviour
{

    public TextMeshProUGUI gamesWonText,gamesLostText;

    public SpriteRenderer BGImage;
    public Sprite WonSprite, LostSprite;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameVariables.wonGame)
        {
            gamesWonText.text = $"Games Won: {GameVariables.gamesWon}";
            BGImage.sprite = WonSprite;
        }
        else
        {
            gamesWonText.text = $"";
        }

        if (GameVariables.lostGame)
        {
            gamesLostText.text = $"Games Lost: {GameVariables.gamesLost}";
            BGImage.sprite = LostSprite;
        }
        else
        {
            gamesLostText.text = $"";
        }
    }
}
