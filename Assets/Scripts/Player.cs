using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int health = 10;

    public void TakeDamage(int Damage) {
        health -= Damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
