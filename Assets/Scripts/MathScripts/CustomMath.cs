using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMath : MonoBehaviour {
    public static float[] weightArray(float[] array)
    {
        if (array == null) return null;
        float total = 0;
        foreach (float i in array)
        {
            total += i;
        }
        if (total == 0f) return array;

        float[] weighted = new float[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            weighted[i] = array[i] / total;
            if (i > 0)
            {
                weighted[i] += weighted[i - 1];
            }
        }
        return weighted;
    }
}
