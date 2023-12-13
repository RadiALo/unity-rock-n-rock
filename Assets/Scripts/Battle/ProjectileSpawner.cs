using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField]
    private Projectile projectile;

    [SerializeField]
    private bool spawn;

    private bool isSpawned;

    void Update()
    {
        if (spawn && !isSpawned)
        {
            GameObject newProjectile = Instantiate(
               projectile.gameObject,
               transform.position,
               Quaternion.identity
           );

           newProjectile.transform.localScale = transform.localScale;
        }

        isSpawned = spawn;
    }
}
