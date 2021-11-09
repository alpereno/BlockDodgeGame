using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility 
{
    //just a static class to get a difficulty percent
    static float secondsToMaxDifficulty = 60;

    public static float getDifficultyPercent() {
        return  Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
    }
}
