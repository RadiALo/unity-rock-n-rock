using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class HealthsUI : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private RectTransform healths;
    [SerializeField]
    private int healthWidth;

    private void Start()
    {
        ReloadHealth(player.Health);

        player.OnHealthChanged.AddListener(ReloadHealth);
    }

    public void ReloadHealth(int HealthLeft)
    {
        healths.sizeDelta= new Vector2(
            healthWidth * HealthLeft,
            healths.sizeDelta.y
        );
    }
}
