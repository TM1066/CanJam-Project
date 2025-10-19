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
    private int outfitIndex;

    public float writeSpeed = 0.05f;

    bool finishedWriting = false;
    public AudioSource talkingAudioSource;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hatIndex = Random.Range(0, 8);
        maskIndex = Random.Range(0, 8);
        outfitIndex = Random.Range(0, 6);

        GameVariables.attentionHat = hatIndex;
        GameVariables.attentionMask = maskIndex;
        GameVariables.attentionOutfit = outfitIndex;

        introText += $"{GameVariables.hatNames[hatIndex]} hat, a {GameVariables.maskNames[maskIndex]} mask and a {GameVariables.colourNames[outfitIndex]}-ish coloured outfit. that's just how stylish the guy is. Good luck! Don't let me down.";

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
        if (Input.anyKeyDown && !talkingAudioSource.isPlaying)
        {
            SceneManager.LoadScene("Game Scene");
        }
        else if (Input.anyKeyDown && talkingAudioSource.isPlaying)
        {
            talkingAudioSource.pitch += 0.1f;
            writeSpeed -= 0.01f;
        }
    }
}
