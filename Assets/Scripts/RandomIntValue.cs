using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

[Serializable]
public class RandomIntValue
{
    public int Min;
    public int Max;

    public int RandomValue
    {
        get
        {
            return Random.Range(Min, Max);
        }
    }
}
