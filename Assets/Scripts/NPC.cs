using UnityEngine;

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
            this.transform.rotation = new Quaternion(0,-180,0,this.transform.rotation.w);
            if (tempLocation == this.transform.position)
            {
                moving = false;
            }
        }
        tempLocation = this.transform.position;
    }

    void OnMouseEnter()
    {
        Debug.Log($"Hovering Over {this.gameObject.name}");
    }

}
