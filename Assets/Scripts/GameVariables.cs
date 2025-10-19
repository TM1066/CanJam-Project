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



    public static List<string> hatNames = new List<string>() {"Big Plant","Black Wig", "Blonde Wig", "Rude", "Plant Pot", "Propellor","Top", "Wally Style", "Witch"};
    public static List<string> maskNames = new List<string>() {"Clown","Corpse","Religious","Pickled Zombie","Plague Doctor","Red Hockey","Vampyre","Werewolf"};
}
