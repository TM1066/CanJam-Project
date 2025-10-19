using UnityEngine;
using System.Collections.Generic;
using System;

public static class GameVariables
{

    public static int attentionHat = 0;
    public static int attentionMask = 0;
    public static int attentionOutfit = 0;

    public static GameObject selectedCharacter = null;

    public static bool PlayerCanMove = true;


    //Controls
    public static KeyCode playerChooseButton = KeyCode.E;

    public static bool wonGame = false;
    public static int gamesWon = 0;
    public static bool lostGame = false;
    public static int gamesLost = 0;

    public static int difficulty = 1; //1 = easy, 2 = medium, 3 = hard



    public static List<string> hatNames = new List<string>() { "Big Plant", "Black Wig", "Blonde Wig", "Rude", "Plant Pot", "Propellor", "Top", "Wally Style", "Witch" };
    public static List<string> maskNames = new List<string>() { "Clown", "Corpse", "Religious", "Pickled Zombie", "Plague Doctor", "Red Hockey", "Vampyre", "Werewolf", "Olivier" };
    public static List<string> colourNames = new List<string>() { "Red", "Orange", "Yellow", "Green", "Blue", "Indigo", "Violet" };
}
