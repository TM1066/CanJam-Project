using UnityEngine;
using System.Collections.Generic;

public class NPCManager : MonoBehaviour
{
    public GameObject personPrefab;

    //lists are important so we can grab IndexOf hats
    public List<Sprite> hats = new List<Sprite>();
    public List<Sprite> masks = new List<Sprite>();
    public List<Color> colours = new List<Color>() { Color.red, Color.orange, Color.yellow, Color.green, Color.blue, Color.indigo, Color.violet };

    public RandomMovement NPCMovementManager;

    public int peopleAmount;

    private bool attentionSpawned = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (GameVariables.difficulty == 1)
        {
            peopleAmount = 5;
        }
        if (GameVariables.difficulty == 2)
        {
            peopleAmount = 15;
        }
        if (GameVariables.difficulty == 3)
        {
            peopleAmount = 30;
        }

        for (int i = 0; i <= peopleAmount; i++)
        {
            var guy = Instantiate(personPrefab, this.transform);

            if (!attentionSpawned)
            {
                guy.GetComponent<NPC>().isAttention = true;
                guy.GetComponent<NPC>().hatRenderer.sprite = hats[GameVariables.attentionHat];
                guy.GetComponent<NPC>().maskRenderer.sprite = masks[GameVariables.attentionMask];
                guy.GetComponent<NPC>().outfitColor = colours[GameVariables.attentionOutfit]; // bright colors are easier to recognise

                attentionSpawned = true;
            }
            else
            {
                guy.GetComponent<NPC>().hatRenderer.sprite = hats[Random.Range(0, hats.Count)];
                guy.GetComponent<NPC>().maskRenderer.sprite = masks[Random.Range(0, masks.Count)];
                guy.GetComponent<NPC>().outfitColor = colours[Random.Range(0, 6)];


                //randomising outfits
                foreach (var guy2 in FindObjectsByType<NPC>(FindObjectsSortMode.None))
                {
                    if (GameVariables.difficulty != 3)
                    {
                        while (hats.IndexOf(guy2.hatRenderer.sprite) == GameVariables.attentionHat && (hats.IndexOf(guy2.hatRenderer.sprite) == GameVariables.attentionHat) && !guy2.isAttention)
                        {
                            guy2.GetComponent<NPC>().hatRenderer.sprite = hats[Random.Range(0, hats.Count)];
                            guy2.GetComponent<NPC>().maskRenderer.sprite = masks[Random.Range(0, masks.Count)];
                        }
                    }
                    
                }
            }
            NPCMovementManager.people.Add(guy);
        }
    }
}
