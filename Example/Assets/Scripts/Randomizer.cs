using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    private List<int> _usedValues = new List<int>();
    
    public int UniqueRandomInt(int min, int max, int val)
    {
        val = Random.Range(min, max);
        while(_usedValues.Contains(val))
        {
            val = Random.Range(min, max);
        }
        return val;
    }

}
