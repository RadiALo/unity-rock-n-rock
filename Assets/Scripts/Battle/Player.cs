using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int health = 3;

    public int Health { get => health; }

    public UnityEvent<int> OnHealthChanged = new();

    public void TakeDamage(int Damage) {
        health -= Damage;

        OnHealthChanged.Invoke(health);

        if (health <= 0)
        {
            LevelData.Instance.LoseLevel();
        }
    }
}
