using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMC : MonoBehaviour
{
   /// <summary>
   /// Use this to check of we are at game over
   /// </summary>
   /// <param name="_lives">The players current lives</param>
   /// <returns>True of the players lives are at 0</returns>
   public bool IsGameOver(int _lives)
    {
        
        return _lives == 0;
    }

    /// <summary>
    /// Works out the change in percentage between two scores
    /// </summary>
    /// <param name="_score1">The original score</param>
    /// <param name="_score2">The new score</param>
    /// <returns>The percentage change between _score1 and _score2</returns>
    public float PercentageChange(float _score1, float _score2)
    {
        float change = _score2 - _score2;
        return change / _score1 * 100;
    }

    public Color RandomColor()
    {
        return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f,1f));
    }
}
