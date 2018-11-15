﻿using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class SpellQueue : MonoBehaviour
{
    LinkedList<string> spellQueue = new LinkedList<string>();
    ElementCombination elementCombination;
    public TMP_Text spellQueueUI;
    public TMP_SpriteAsset spellIcon;
    StringBuilder build;

    public void Start()
    {
        elementCombination = gameObject.AddComponent<ElementCombination>();
        spellQueueUI = GetComponent<PlayerController>().spellQueueUI;
        spellIcon = GetComponent<PlayerController>().spellIcon;
    }
    public void Enqueue(string element) // add last 
    {
        string result = null;
        if (spellQueue.Count > 0 )
        {
            result = elementCombination.GetElement(element,spellQueue.Last.Value);
        }
        if (result != null )
        {
            Pop();
        }
        if (result == null)
        {
            result = element;
            if (spellQueue.Count >= 5)
            {
                return; 
            }
        }
        spellQueue.AddLast(result);
        UpdateUI();
    }
   public string  Dequeue() // remove first/head 
    {
        string result = spellQueue.First.Value;
        spellQueue.RemoveFirst();
        UpdateUI();
        return result;
    }
    public string Pop() // remove last/tail  
    {
        string result = spellQueue.Last.Value;
        spellQueue.RemoveLast();
        UpdateUI();
        return result;
    }
    private void UpdateUI()
    {
        build = new StringBuilder();

        if (spellQueueUI)
        {
            spellQueueUI.text = "";
            foreach(string element in spellQueue)
            {
                String newElement = element.Replace(" ", String.Empty); // Removes whitespace from element
                build.Append("<sprite=\"" + newElement + "\" name=\"" + newElement + "\">");
                spellQueueUI.SetText(build);

            }
            spellQueueUI.text = spellQueueUI.text.TrimEnd(' ', '|');
        }
    }
}