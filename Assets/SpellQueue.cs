using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class SpellQueue : MonoBehaviour
{
    LinkedList<string> spellQueue = new LinkedList<string>();
    ElementCombination elementCombination;
    public void Start()
    {
        elementCombination = gameObject.AddComponent<ElementCombination>();
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
    }
   public string  Dequeue() // remove first/head 
    {
        string result = spellQueue.First.Value;
        spellQueue.RemoveFirst();
        return result;
    }
    public string Pop() // remove last/tail  
    {
        string result = spellQueue.Last.Value;
        spellQueue.RemoveLast();
        return result;
    }
}
