using System.Collections.Generic;
using System.Collections;
using UnityEngine;
//General NPC Movement Manager
public class RandomMovement : MonoBehaviour
{
    public int minXIncrement = -4;
    public int maxXIncrement = 4;
    public int minYIncrement = -1;
    public int maxYIncrement = 1;

    public Vector3 maxPositiveVector;
    public Vector3 maxNegativeVector;

    public List<GameObject> people = new List<GameObject>();
    private Dictionary<Transform, Vector2> personalTargets = new Dictionary<Transform, Vector2>();



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var guy in people)
        {
            //populating targets
            personalTargets.Add(guy.transform, guy.transform.position += new Vector3(Random.Range(minXIncrement, maxXIncrement), Random.Range(minYIncrement, maxYIncrement)));

            //randomise Positions
            guy.transform.position = new Vector3(Random.Range(maxNegativeVector.x, maxPositiveVector.x), Random.Range(maxNegativeVector.y, maxPositiveVector.y));
            StartCoroutine(RandomMovementTicker(guy.transform));
        }
    }

    public IEnumerator RandomMovementTicker(Transform thingToMove)
    {
        
        while (true)
        {
            if (thingToMove.GetComponentInChildren<Renderer>().isVisible && Random.Range(0,3) == 1)
            {
                float timeTaken = 10;

                //should result in grouping behaviour
                //if (Random.Range(0, 5) != 1 && !(Vector2.Distance(thingToMove.position, personalTargets[thingToMove]) <= 1))
                if (Random.Range(0, 5) != 1)
                {
                    personalTargets[thingToMove] -= new Vector2(Random.Range(minXIncrement, maxXIncrement), Random.Range(minYIncrement, maxYIncrement));
                    timeTaken = Random.Range(1f, 10f);
                }

                //clamping Vectors so they stay in rooms - Messy
                if (personalTargets[thingToMove].x > maxPositiveVector.x) { personalTargets[thingToMove] = new Vector2(maxPositiveVector.x, personalTargets[thingToMove].y); }
                if (personalTargets[thingToMove].y > maxPositiveVector.y) { personalTargets[thingToMove] = new Vector2(personalTargets[thingToMove].x, maxPositiveVector.y); }
                if (personalTargets[thingToMove].x < maxNegativeVector.x) { personalTargets[thingToMove] = new Vector2(maxNegativeVector.x, personalTargets[thingToMove].y); }
                if (personalTargets[thingToMove].y < maxNegativeVector.y) { personalTargets[thingToMove] = new Vector2(personalTargets[thingToMove].x, maxNegativeVector.y); }

                StartCoroutine(PositionLerp(thingToMove, thingToMove.position, personalTargets[thingToMove], timeTaken));

                yield return new WaitForSeconds(timeTaken);
            }
            yield return null;
        }
    }

    public static IEnumerator PositionLerp(Transform thingToMove, Vector3 vectorFrom, Vector3 vectorTo, float duration)
    {
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            if (thingToMove != null) // I like to destroy
            {
                thingToMove.position = Vector3.Lerp(vectorFrom, vectorTo, timeElapsed / duration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            else
            {
                break;
            }
        }
        yield return null;
    }
}
