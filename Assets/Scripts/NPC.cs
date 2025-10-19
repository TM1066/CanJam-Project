using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    Vector3 tempLocation = new Vector3();

    public bool isAttention = false;

    public bool moving = false;

    //assignment of this stuff will come from the NPCManager
    public SpriteRenderer hatRenderer;
    public Color hatColor;
    public SpriteRenderer maskRenderer;
    public SpriteRenderer outfitRenderer;
    public Color outfitColor;

    public GameObject tennaWin;
    public GameObject tennaLose;


    public Animator animator;


    public Sprite brokenPlagueMask;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        outfitRenderer.color = outfitColor;
    }

    // LateUpdate so movement is done before code checking for it
    void LateUpdate()
    {
        //handle flipping around when moving
        if (this.transform.position.x > tempLocation.x)
        {
            this.transform.rotation = new Quaternion(0, 0, 0, this.transform.rotation.w);
            moving = true;
        }
        else
        {
            this.transform.rotation = new Quaternion(0, -180, 0, this.transform.rotation.w);
            if (tempLocation == this.transform.position)
            {
                moving = false;
            }
            else
            {
                moving = true;
            }
        }
        tempLocation = this.transform.position;
        animator.SetBool("moving", moving);


        //fixing masks
        if (maskRenderer.sprite == brokenPlagueMask)
        {
            maskRenderer.gameObject.transform.localPosition = new Vector2(0.275f, maskRenderer.gameObject.transform.localPosition.y);
        }
        else
        {
            maskRenderer.gameObject.transform.localPosition = new Vector2(0, maskRenderer.gameObject.transform.localPosition.y);
        }

    }

    public void SelectCharacter()
    {
        GameVariables.PlayerCanMove = false;


        if (isAttention)
        {
            hatRenderer.gameObject.SetActive(false);
            maskRenderer.gameObject.SetActive(false);
            outfitRenderer.gameObject.SetActive(false);


            tennaWin.SetActive(true);
            GameVariables.wonGame = true;
            GameVariables.gamesWon += 1;
        }
        else
        {
            hatRenderer.gameObject.SetActive(false);
            maskRenderer.gameObject.SetActive(false);
            outfitRenderer.gameObject.SetActive(false);


            tennaLose.SetActive(true);
            GameVariables.lostGame = true;
            GameVariables.gamesLost -= 1;
        }
        StartCoroutine(WaitForEnd());
    }

    private IEnumerator WaitForEnd()
    {
        yield return new WaitForSecondsRealtime(10);

        GameVariables.PlayerCanMove = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

}
