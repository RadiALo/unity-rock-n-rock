using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{
    [SerializeField]
    private Sprite hasStarSprite;
    [SerializeField]
    private Sprite hasNotStarSprite;

    [SerializeField]
    private GameObject winMenu;

    [SerializeField]
    private Image enemiesStarImage;

    [SerializeField]
    private Image weaponsStarImage;

    [SerializeField]
    private Image healthsStarImage;


    public void ShowWinWindow(bool HealthsStar, bool WeaponsStar, bool EnemiesStar)
    {
        winMenu.SetActive(true);

        healthsStarImage.sprite = HealthsStar ? hasStarSprite : hasNotStarSprite;
        weaponsStarImage.sprite = WeaponsStar ? hasStarSprite : hasNotStarSprite;
        enemiesStarImage.sprite = EnemiesStar ? hasStarSprite : hasNotStarSprite;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
