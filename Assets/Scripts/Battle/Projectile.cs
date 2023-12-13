using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private bool stopsByWalls = true;
    [SerializeField]
    private bool isPlayerOwner = true;
    [SerializeField]
    private int damage = 1;


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
        if (stopsByWalls && other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }
        if (!isPlayerOwner && other.CompareTag("Player"))
        {
            other.GetComponent<Player>().TakeDamage(damage);
            Destroy(gameObject);
        } else if (isPlayerOwner && other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
