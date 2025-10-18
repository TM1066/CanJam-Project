using System.Collections;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public Vector2 targetDestination;

    public int minXIncrement = -2;
    public int maxXIncrement = 2;
    public int minYIncrement = -1;
    public int maxYIncrement = 1;

    public GameObject[] people;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var guy in people)
        {
            guy.transform.position = new Vector3(Random.Range(-10, 10), Random.Range(-5, 5));
            StartCoroutine(RandomMovementTicker(guy.transform));
        }
    }

    public IEnumerator RandomMovementTicker(Transform thingToMove)
    {
        
        while (true)
        {
            if (thingToMove.GetComponent<Renderer>().isVisible)
            {
                float timeTaken = 1;

                //should result in grouping behaviour
                if (Random.Range(0, 5) != 1 && !(Vector2.Distance(thingToMove.position, targetDestination) <= 1))
                //if (Random.Range(0, 5) != 1)
                {
                    targetDestination -= new Vector2(Random.Range(minXIncrement, maxXIncrement), Random.Range(minYIncrement, maxYIncrement));
                    timeTaken = Random.Range(1f, 1f);
                }

                StartCoroutine(PositionLerp(thingToMove, thingToMove.position, targetDestination, timeTaken));

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
                thingToMove.position = Vector3.Slerp(vectorFrom, vectorTo, timeElapsed / duration);
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
