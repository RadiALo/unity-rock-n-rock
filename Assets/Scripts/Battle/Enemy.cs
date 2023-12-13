using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Transform rotate;

    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private int health;

    private void Start()
    {
        LevelData.Instance.EnemiesCount++;
    }

    private void Update()
    {
        if (rotate != null && Physics2D.Raycast(rotate.position, Vector2.down, 0.1f, groundLayer))
        {
            transform.localScale = new Vector3(
                -transform.localScale.x,
                transform.localScale.y,
                transform.localScale.z
            );
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            LevelData.Instance.EnemyDie();
            Destroy(gameObject);
        }
    }
}
