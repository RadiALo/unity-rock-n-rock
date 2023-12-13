using UnityEngine;

public class AttackZone : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    public int Damage { get => 1; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().TakeDamage(damage);
        }
    }
}
