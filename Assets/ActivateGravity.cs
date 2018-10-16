using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// The game will have an internal timer counting down the destruction of the arena
// The matches are 3 minutes long.
// Every 36 seconds, a ring of the arena will fall
public class ActivateGravity : MonoBehaviour {

    private float startTime;

    private void Start() {
        startTime = Time.time;
    }

    private void Update() {
        float t = Time.time - startTime; // The vriable t will hold the time in seconds starting at 0
        int seconds = (int)t;            // the variable "seconds holds the seconds as an (int)

        // gameObject.tag will locate each of the rings by matching the game object's tags
        // then after every 36 seconds, the gravity applied to the onjects will be manually turned on
        // causing the game objects to fall off and be destroyed once the exit the boudary
        if (gameObject.tag == "FinalRing") {
            if (seconds == 36) {
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
            }
        } else if (gameObject.tag == "QuaternaryRing") {
            if (seconds == 72) {
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
            }
        } else if (gameObject.tag == "TertiaryRing") {
            if (seconds == 108) {
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
            }
        } else if (gameObject.tag == "SecondRing") {
            if (seconds == 144) {
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
            }
        } else if (gameObject.tag == "CenterRing") {
            if (seconds == 180) {
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
