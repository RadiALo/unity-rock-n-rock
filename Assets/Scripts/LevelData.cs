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

    [SerializeField]
    private int level;

    public int WeaponsForStar;

    public int EnemiesCount = 0;

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
        WinMenu winMenu = FindAnyObjectByType<WinMenu>();

        int starsCount = (FindAnyObjectByType<Player>().Health == 3 ? 1 : 0)
            + (WeaponsUsed <= WeaponsForStar ? 1 : 0)
            + (EnemiesCount == enemiesKilled ? 1 : 0);

        winMenu.ShowWinWindow(
            FindAnyObjectByType<Player>().Health == 3,
            WeaponsUsed <= WeaponsForStar,
            EnemiesCount == enemiesKilled
        );

        GameData gameData = GameData.Load();

        for (int i = gameData.StarsCount.Count; i <= level; i++)
        {
            gameData.StarsCount.Add(0);
        }

        if (gameData.StarsCount[level] < starsCount)
        {
            gameData.StarsCount[level] = starsCount;
        }

        gameData.Save();
    }
}
