using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
    public static bool LightSwitch = true;          // Default setting, for it to be day time
    public static int LightIntensity = 1;           // Default intensity
    public static bool MainCameraActive = true;     // Toggle between CameraMain (true) CameraAerial (false)
    public static SkinnedMeshRenderer InvisibilityHolder;   // Sees who has the invisibility spell
    public static PlayerController PolymorphedTarget;    // The person hit by the polymorph spell
    public static bool TurtleActive = true;

}
