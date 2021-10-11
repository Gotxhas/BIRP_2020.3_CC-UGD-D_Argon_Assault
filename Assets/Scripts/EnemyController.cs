using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private Transform spawnerParent;
    [SerializeField] private int scorePoint;
    [SerializeField] private int healthPoints;
    
    
    private void OnParticleCollision(GameObject other)
    {
        healthPoints--;
        
        if (healthPoints <= 0)
        {
            EnemyHit();
        }
    }

    private void EnemyHit()
    {
        GameObject explosionPref = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        explosionPref.transform.SetParent(spawnerParent);
        EventBroker.CallEnemyHit(scorePoint);
        Destroy(explosionPref, 1);
        Destroy(gameObject);
    }
}
