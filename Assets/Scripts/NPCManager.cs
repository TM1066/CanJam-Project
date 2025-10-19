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

    private bool attentionSpawned = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        for (int i = 0; i <= peopleAmount; i++)
        {
            var guy = Instantiate(personPrefab,this.transform);

            if (!attentionSpawned)
            {
                guy.GetComponent<NPC>().isAttention = true;
                guy.GetComponent<NPC>().hatRenderer.sprite = hats[GameVariables.attentionHat];
                guy.GetComponent<NPC>().maskRenderer.sprite = masks[GameVariables.attentionMask];
                guy.GetComponent<NPC>().outfitColor = GameVariables.attentionOutfit; // bright colors are easier to recognise

                attentionSpawned = true;
            }
            else
            {
                guy.GetComponent<NPC>().hatRenderer.sprite = hats[Random.Range(0, hats.Count)];
                guy.GetComponent<NPC>().maskRenderer.sprite = masks[Random.Range(0, masks.Count)];
                guy.GetComponent<NPC>().outfitColor = new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f)); // bright colors are easier to recognise


                //randomising outfits
                foreach (var guy2 in FindObjectsByType<NPC>(FindObjectsSortMode.None))
                {
                    while (hats.IndexOf(guy2.hatRenderer.sprite) == GameVariables.attentionHat && (hats.IndexOf(guy2.hatRenderer.sprite) == GameVariables.attentionHat) && !guy2.isAttention)
                    {
                        guy2.GetComponent<NPC>().hatRenderer.sprite = hats[Random.Range(0, hats.Count)];
                        guy2.GetComponent<NPC>().maskRenderer.sprite = masks[Random.Range(0, masks.Count)];
                    }
                }
            }
            NPCMovementManager.people.Add(guy);
        }
    }
}
