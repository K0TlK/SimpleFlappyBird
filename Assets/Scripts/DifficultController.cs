using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultController : Singleton<DifficultController>
{
    [SerializeField] private float[] difficultMultipliers = new float[4] {1.0f, 1.4f, 1.8f, 0.6f};
    private int difficultActive = 0;
    public float DifficultMultiplier => difficultMultipliers[difficultActive];

    public void NextDifficult()
    {
        if (difficultActive + 1 < difficultMultipliers.Length)
        {
            difficultActive++;
        }
        else
        {
            difficultActive = 0;
        }
    }
}
