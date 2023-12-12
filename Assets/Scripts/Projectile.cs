using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Projectile : MonoBehaviour
{
    [SerializeField]
    private bool isPlayerOwner;

    float lifeTime;
        
    private void Start()
    {
        lifeTime = GetComponent<Animator>()
            .GetCurrentAnimatorStateInfo(0).length;
    }

    private void Update()
    {
        if (lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
        } else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player collision
        } else if (other.CompareTag("Enemy"))
        {
            // Enemy collision
        }
    }
}
