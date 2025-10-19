using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class BriefSceneManager : MonoBehaviour
{

    [TextArea(0, 30)]
    public string introText;
    public TextMeshProUGUI introTextMesh;

    private int hatIndex;
    private int maskIndex;
    private Color outfitColor;

    public float writeSpeed = 0.05f;

    bool finishedWriting = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hatIndex = Random.Range(0, 8);
        maskIndex = Random.Range(0, 8);
        outfitColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

        GameVariables.attentionHat = hatIndex;
        GameVariables.attentionMask = maskIndex;
        GameVariables.attentionOutfit = outfitColor;

        introText += $"{GameVariables.hatNames[hatIndex]} hat, a {GameVariables.maskNames[maskIndex]} mask and a {PredictColourName.GetColourName((Color32)outfitColor)} coloured outfit. that's just how stylish the guy is. Good luck! Don't let me down.";

        StartCoroutine(WriteText());

    }

    public IEnumerator WriteText()
    {
        foreach (char c in introText)
        {
            //if (c != '\\');
            introTextMesh.text += c;

            yield return new WaitForSeconds(writeSpeed);
        }
        finishedWriting = true;
        yield return null;
    }

    void Update()
    {
        if (Input.anyKeyDown && finishedWriting)
        {
            SceneManager.LoadScene("Game Scene");
        }
        else if (Input.anyKeyDown)
        {
            writeSpeed = 0;
        }
    }
}
