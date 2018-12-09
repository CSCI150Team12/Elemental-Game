using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementCombination : MonoBehaviour
{
    Hashtable elements = new Hashtable();
    Hashtable currentElements;
    // Use this for initialization
    void Start()
    {
        //Complexity 2
        elements.Add("Air + Fire", "Fireball");
        elements.Add("Air + Water", "Ice");
        elements.Add("Air + Earth", "Sand");
        elements.Add("Fire + Water", "Steam");
        elements.Add("Fire + Earth", "Magma");
        elements.Add("Water + Earth", "Mud");
        //Complexity 3
        elements.Add("Air + Fireball", "Two Fireballs");
        elements.Add("Air + Ice", "Snow");
        elements.Add("Air + Sand", "Tornado");
        //elements.Add("Air + Steam", "Fog");
        elements.Add("Air + Magma", "Stone");
        elements.Add("Air + Mud", "Mudball");
        elements.Add("Fire + Fireball", "Bigger Fireball");
        elements.Add("Fire + Ice", "Water");
        elements.Add("Fire + Sand", "Glass");
        elements.Add("Fire + Steam", "Air");
        elements.Add("Fire + Magma", "Plasma");
        
        elements.Add("Fire + Mud", "Dirt");
        elements.Add("Water + Fireball", "Steam Ball");
        //elements.Add("Water + Ice", "Glacier");
        elements.Add("Water + Sand", "Quicksand");
        //elements.Add("Water + Steam", "Cloud");
        //elements.Add("Water + Magma", "Obsidian");
        elements.Add("Water + Mud", "Mud");
        elements.Add("Earth + Fireball", "Magmaball");
        //elements.Add("Earth + Ice", "Tundra");
        //elements.Add("Earth + Sand", "Desert");
        //elements.Add("Earth + Steam", "Geyser");
        //elements.Add("Earth + Magma", "Volcano");
        //elements.Add("Earth + Mud", "Swamp");
        //Complexity 4
        elements.Add("Air + Plasma", "Lightning");
        //Complexity 5
        elements.Add("Air + Lightning", "Lightning Storm");
        //Collectible items/Extra
        elements.Add("Black Hole + Fire", "Star");
        elements.Add("Life + Water", "Frog");
    }

    public string GetElement(string element1, string element2)
    {
        string result = (string)elements[element1 + " + " + element2];
        if (result == null)
        {
            result = (string)elements[element2 + " + " + element1];
        }
        return result;
    }
}
