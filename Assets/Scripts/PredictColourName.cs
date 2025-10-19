using System; //for Math Class
using System.Collections;
using System.Collections.Generic;
using System.Linq; //for list Aggregate Method
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Whelp. Good enough.


public class PredictColourName : MonoBehaviour
{

    public Image colourToPredict;

    private Color32 currentColour;

    public TMP_Text colourNameText;

    [HideInInspector]
    public Color32[] colours; //List<Color32> colours;

    List<string> colourNames = new List<string>() {"White","Grey","Black","Light Red","Red","Dark Red","Light Orange","Orange","Light Brown",
    "Brown","Dark Brown","Light Yellow","Yellow","Dark Yellow","Light Green","Green","Dark Green",
    "Light Blue","Blue","Dark Blue","Light Purple","Purple","Dark Purple","Light Pink","Pink","Dark Pink"};


    [HideInInspector]
    public List<Color32> predictions;

    int currentR;
    int currentG;
    int currentB;

    [HideInInspector]
    public List<int> rValues;
    [HideInInspector]
    public List<int> gValues;
    [HideInInspector]
    public List<int> bValues;


    void Start()
    {
        colours =  Colours.colours;   //new List<Color32> (Colours.CreateCompleteListofColours32());

        for (int x = 0; x < colours.Length; x++)
        {   //Populating individual RGB value lists
            rValues.Add(colours[x].r);
            gValues.Add(colours[x].g);
            bValues.Add(colours[x].b);
        }
    }

    // Update is called once per frame
    void Update()
    {

        try //haha, you thought I stopped doing this, sike
        {
            //clearing predictions so it doesn't add infinitely

            predictions.Clear();


            //setting current prediction target variables
            currentColour = colourToPredict.color;
            currentR = currentColour.r;
            currentG = currentColour.g;
            currentB = currentColour.b;

            int closestR = rValues.Aggregate((x,y) => Math.Abs(x-currentR) < Math.Abs(y-currentR) ? x : y);
            int closestG = gValues.Aggregate((x,y) => Math.Abs(x-currentG) < Math.Abs(y-currentG) ? x : y);
            int closestB = bValues.Aggregate((x,y) => Math.Abs(x-currentB) < Math.Abs(y-currentB) ? x : y);


            //Debug.Log("(" + closestR.ToString() + ", " + closestG.ToString() + ", " + closestB.ToString() + ")");

            //now onto actually predicting colours


            //possible colours
            for (int i = 0; i < colours.Length;i++)
            {
                Color32 currentColourToCheck = colours[i];
                if (currentColourToCheck.r == closestR && currentColourToCheck.g == closestG && currentColourToCheck.b == closestB)
                {
                    predictions.Add(currentColourToCheck);
                } 
            }   

            //Narrowing down predictions 
            while (predictions[0].r != closestR || predictions[0].g != closestG || predictions[0].b != closestB)
            {
                predictions.Remove(predictions[0]);
            }
            

            IEnumerable<Color32> possibleColours = colours.Except(predictions);


            colourNameText.text = colourNames[Array.IndexOf(colours,predictions[0])] + "~";

            //Debug.Log(string.Join(",", predictions));

        }

        catch
        {
          
        }
    }
}