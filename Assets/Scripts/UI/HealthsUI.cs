using UnityEngine;

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
