using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour {

    public int playerCount;

	void Start () {
        DontDestroyOnLoad(this);
	}
	
}
