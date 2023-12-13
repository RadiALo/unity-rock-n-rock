using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Projectile projectile;

    private void Start()
    {
        LevelData.Instance.WeaponsCount++;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Inventory>().CollectProjectile(projectile);
            Destroy(gameObject);
        }
    }
}
