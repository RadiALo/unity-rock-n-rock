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

    public int WeaponsForStar;

    public int EnemiesCount = 0;

    public int WeaponsUsed = 0;

    private int enemiesKilled = 0;

    public void EnemyDie()
    {
        enemiesKilled++;

        if (enemiesKilled == EnemiesCount)
        {
            Debug.Log("win");
            FinishLevel();
        }
    }

    private void FinishLevel()
    {
        WinMenu winMenu = FindAnyObjectByType<WinMenu>();

        winMenu.ShowWinWindow(
            FindAnyObjectByType<Player>().Health == 3,
            WeaponsUsed <= WeaponsForStar,
            EnemiesCount == enemiesKilled
        );
    }
}
