using UnityEngine;
using System.Collections.Generic;

public static class GameVariables
{

    public static int attentionHat = 0;
    public static int attentionMask = 0;
    public static Color attentionOutfit;

    public static GameObject selectedCharacter = null;

    public static bool PlayerCanMove = true;


    //Controls
    public static KeyCode playerChooseButton = KeyCode.E;



    public static List<string> hatNames = new List<string>() {"Hat 1","Hat 2", "Hat 3", "Hat 4", "Hat 5", "Hat 6","Hat 7", "Hat 8"};
    public static List<string> maskNames = new List<string>() {"Clown","Corpse","Religious","Pickled Zombie","Plague Doctor","Red Hockey","Vampyre","Werewolf"};
}
