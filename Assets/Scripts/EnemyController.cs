using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private Transform spawnerParent;
    [SerializeField] private int scorePoint;
    
    private void OnParticleCollision(GameObject other)
    {
        EnemyHit();
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
