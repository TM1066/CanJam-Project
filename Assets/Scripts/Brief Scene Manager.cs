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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hatIndex = Random.Range(0, 8);
        maskIndex = Random.Range(0, 8);
        outfitColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

        introText += $"{hatIndex} hat, a {maskIndex} mask and a {PredictColourName.GetColourName((Color32)outfitColor)} coloured outfit. that's just how stylish the guy is. Good luck! Don't let me down.";

        StartCoroutine(WriteText());

    }

    public IEnumerator WriteText()
    {
        foreach (char c in introText)
        {
            //if (c != '\\');
            introTextMesh.text += c;

            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("Game Scene");
        }
    }
}
