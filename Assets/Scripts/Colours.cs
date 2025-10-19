using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colours : MonoBehaviour
{
    /*
     *  ToDo:
     *  Make a new Colour Class that inherits from the Unity
     *  Color Class but adds a "Name" String Variable that
     *  I can then display as said Colour's Name.
     *  This can then make full use of the RGB Approximation
     *  Script that I'm currently working on.
     *  (Just to write it down, I need to approximate each
     *  Value of the RGB [Red, Green & Blue] to their corresponding
     *  closest matches found in this list and then narrow down
     *  the closest options into how close the resultant values are
     *  to each other and then pick the colour that my script determines
     *  the most confidence in)
     */


    /*  O_O  */
    static public Color32 White = new Color32(255,255,255,255);
    static public Color32 Grey = new Color32(128,128,128,255);
    static public Color32 Black = new Color32(0,0,0,255);

    static public Color32 LightRed = new Color32(255,100,100,255);
    static public Color32 Red = new Color32(255,0,0,255);
    static public Color32 DarkRed = new Color32(150,0,0,255);

    static public Color32 LightOrange = new Color32(255,180,100,255);
    static public Color32 Orange = new Color32(255, 128, 0,255);
    static public Color32 LightBrown = new Color32(200, 100, 0,255);
    static public Color32 Brown = new Color32(150, 75, 0,255);
    static public Color32 DarkBrown = new Color32(100,50,0,255);
    
    static public Color32 LightYellow = new Color32(255,255,200,255);
    static public Color32 Yellow = new Color32(255,255,0,255);
    static public Color32 DarkYellow = new Color32(150,150,0,255);

    static public Color32 LightGreen = new Color32(150,255,150,255);
    static public Color32 Green = new Color32(0,255,0,255);
    static public Color32 DarkGreen = new Color32(0,150,0,255);

    static public Color32 LightBlue = new Color32(120,255,255,255);
    static public Color32 Blue = new Color32(0,0,255,255);
    static public Color32 DarkBlue = new Color32(0,0,150,255);

    static public Color32 LightPurple = new Color32(150,150,255,255);
    static public Color32 Purple = new Color32(125,0,255,255);
    static public Color32 DarkPurple = new Color32(75,0,150,255);

    static public Color32 LightPink = new Color32(255,150,255,255);
    static public Color32 Pink = new Color32(255,0,255,255);
    static public Color32 DarkPink = new Color32(155,0,155,255);



    static public Color32[] colours = 
    {White,Grey,Black,LightRed,Red,DarkRed,LightOrange,Orange,
    LightBrown,Brown,DarkBrown,LightYellow,Yellow,DarkYellow,
    LightGreen,Green,DarkGreen,LightBlue,Blue,DarkBlue,
    LightPurple,Purple,DarkPurple,LightPink,Pink,DarkPink};

    static public Color32[] HColours =
    {Black,Green,White,Orange,LightBrown,Brown,DarkBrown,LightYellow,
    Yellow,DarkYellow};

    static public Color32[] IColours =
    {Black,LightBrown,Brown,DarkBrown,LightGreen,Green,DarkGreen,LightBlue,Blue,DarkBlue,Black};
    
    /*
    static public List<Color32> CreateCompleteListofColours32()
    {
        Color32[] colours = 
        {White,Grey,Black,LightRed,Red,DarkRed,LightOrange,Orange,LightBrown,
        Brown,DarkBrown,LightYellow,Yellow,DarkYellow,LightGreen,Green,DarkGreen,
        LightBlue,Blue,DarkBlue,LightPurple,Purple,DarkPurple,LightPink,Pink,DarkPink};

        List<Color32> ColourList = new List <Color32> (colours);

        return ColourList;
    } 
    */
}
