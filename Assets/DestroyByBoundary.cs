using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This will destroy any gameObject leaving the boundary of the game
// This will stop rendering gameObjects no longer needed and
// Stops the game from using up system resourced
public class DestroyByBoundary : MonoBehaviour {
    private void OnTriggerExit(Collider other) {
        // When the Collider "other" has stopped touching the trigger
        // it will be destroyed
        Destroy(other.gameObject); 
    }
}
