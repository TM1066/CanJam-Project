using UnityEngine;
using System.Collections.Generic;

public class NPCManager : MonoBehaviour
{
    public GameObject personPrefab;

    //lists are important so we can grab IndexOf hats
    public List<Sprite> hats = new List<Sprite>();
    public List<Sprite> masks = new List<Sprite>();

    public RandomMovement NPCMovementManager;

    public int peopleAmount;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        for (int i = 0; i <= peopleAmount; i++)
        {
            var guy = Instantiate(personPrefab);

            //randomising outfits
            guy.GetComponent<NPC>().hatRenderer.sprite = hats[Random.Range(0, hats.Count)];
            guy.GetComponent<NPC>().maskRenderer.sprite = masks[Random.Range(0, hats.Count)];
            guy.GetComponent<NPC>().outfitColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

            NPCMovementManager.people.Add(guy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
