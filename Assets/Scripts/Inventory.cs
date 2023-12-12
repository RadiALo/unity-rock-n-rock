using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    [SerializeField]
    private Transform throwTransform;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private List<ProjectileSlot> projectiles = new List<ProjectileSlot>();

    private bool isFliped = true;
    private int choosenProjectile = 0;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Throw();
        }
    }

    public void CollectProjectile(Projectile projectile)
    {
        for (int i = 0; i < projectiles.Count; i++)
        {
            if (projectiles[i].Projectile == projectile)
            {
                projectiles[i].Count++;
                return;
            }
        }

        projectiles.Add(new ProjectileSlot(projectile, 1));

        ShiftChoosen(-(choosenProjectile + 1));
    }

    public void Flip(bool IsFlip)
    {
        if (IsFlip != isFliped)
        {
            throwTransform.localPosition = new Vector3(
                -throwTransform.localPosition.x,
                throwTransform.localPosition.y,
                throwTransform.localPosition.z
            );

            isFliped = IsFlip;
        }
    }

    private void Throw()
    {
        if (projectiles.Count > choosenProjectile)
        {
            GameObject newProjectile = Instantiate(
                projectiles[choosenProjectile].Projectile.gameObject,
                throwTransform.position,
                Quaternion.identity
            );

            if (!isFliped)
            {
                newProjectile.transform.localScale = new Vector3(
                    -1f,
                    1f,
                    1f
                );
            }

            projectiles[choosenProjectile].Count--;

            if (projectiles[choosenProjectile].Count == 0)
            {
                projectiles.RemoveAt(choosenProjectile);

                ShiftChoosen(-1);
            }
        }
    }

    private void ShiftChoosen(int Shift)
    {
        choosenProjectile += Shift;

        if (projectiles.Count == 0)
        {
            choosenProjectile = 0;
            spriteRenderer.sprite = null;
            return;
        }

        while (choosenProjectile < 0)
        {
            choosenProjectile += projectiles.Count;
        }

        while (choosenProjectile >= projectiles.Count)
        {
            choosenProjectile -= projectiles.Count;
        }

        spriteRenderer.sprite = projectiles[choosenProjectile].Projectile
            .GetComponent<SpriteRenderer>().sprite;
    }

    [Serializable]
    private class ProjectileSlot
    {
        public Projectile Projectile;

        public int Count;

        public ProjectileSlot(Projectile Projectile, int Count)
        {
            this.Projectile = Projectile;
            this.Count = Count;
        }
    }
}
