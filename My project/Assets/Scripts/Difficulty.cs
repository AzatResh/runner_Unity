using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Difficulty
{
    [SerializeField] static float secondsToMaxDifficulty = 60;

    public static float GetDifficulty(){
        return Mathf.Clamp01(Time.timeSinceLevelLoad/secondsToMaxDifficulty);
    }
}
