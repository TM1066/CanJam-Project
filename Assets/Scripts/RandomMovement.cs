using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public int minXIncrement = -2;
    public int maxXIncrement = 2;
    public int minYIncrement = -1;
    public int maxYIncrement = 1;

    public GameObject[] people;
    private Dictionary<Transform, Vector2> personalTargets = new Dictionary<Transform, Vector2>();



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var guy in people)
        {
            //populating targets
            personalTargets.Add(guy.transform, guy.transform.position += new Vector3(Random.Range(minXIncrement, maxXIncrement), Random.Range(minYIncrement, maxYIncrement)));

            guy.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(-5, 5));
            StartCoroutine(RandomMovementTicker(guy.transform));
        }
    }

    public IEnumerator RandomMovementTicker(Transform thingToMove)
    {
        
        while (true)
        {
            if (thingToMove.GetComponent<Renderer>().isVisible && Random.Range(0,3) == 1)
            {
                float timeTaken = 10;

                //should result in grouping behaviour
                //if (Random.Range(0, 5) != 1 && !(Vector2.Distance(thingToMove.position, personalTargets[thingToMove]) <= 1))
                if (Random.Range(0, 5) != 1)
                {
                    personalTargets[thingToMove] -= new Vector2(Random.Range(minXIncrement, maxXIncrement), Random.Range(minYIncrement, maxYIncrement));
                    timeTaken = Random.Range(1f, 10f);
                }

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
