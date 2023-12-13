using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public static LevelData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LevelData>();
            }

            return instance;
        }
    }

    private static LevelData instance;

    public List<int> WeaponsForStar;

    public int EnemiesCount = 0;

    public int WeaponsCount = 0;

    public int WeaponsUsed = 0;

    private int enemiesKilled = 0;

    public void EnemyDie()
    {
        enemiesKilled++;

        if (enemiesKilled == EnemiesCount)
        {
            FinishLevel();
        }
    }

    private void FinishLevel()
    {

    }
}
