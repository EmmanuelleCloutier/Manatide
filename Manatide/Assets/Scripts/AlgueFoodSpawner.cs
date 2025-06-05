using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCoinSpawner : MonoBehaviour
{
    public GameObject foodCoinPrefab;
    public float spawnInterval = 5f;
    public PlayerState playerState;

    void Start()
    {
        StartCoroutine(SpawnFoodCoinsRoutine());
    }

    IEnumerator SpawnFoodCoinsRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            TrySpawnCoin();
        }
    }

    void TrySpawnCoin()
    {
        List<Collider2D> activeAlgueColliders = new List<Collider2D>();

        foreach (Transform child in transform)
        {
            if (child.gameObject.activeInHierarchy)
            {
                Collider2D col = child.GetComponent<Collider2D>();
                if (col != null)
                    activeAlgueColliders.Add(col);
            }
        }

        if (activeAlgueColliders.Count == 0) return;

        // Choisir une algue au hasard
        Collider2D targetAlgae = activeAlgueColliders[Random.Range(0, activeAlgueColliders.Count)];

        // Obtenir une position aléatoire dans son collider
        Vector2 spawnPosition = GetRandomPointInCollider(targetAlgae);

        // Spawner le coin
        GameObject coin = Instantiate(foodCoinPrefab, spawnPosition, Quaternion.identity);

        // S'assurer que le coin est devant (sorting layer ou Z)
        SpriteRenderer sr = coin.GetComponent<SpriteRenderer>();
        if (sr != null)
            sr.sortingOrder = 10; // plus grand que celui des algues
    }

    Vector2 GetRandomPointInCircle(Collider2D collider)
    {
        CircleCollider2D circle = collider as CircleCollider2D;
        if (circle == null)
            return collider.bounds.center; // fallback

        Vector2 center = circle.bounds.center;
        float radius = circle.radius * circle.transform.lossyScale.x; // prendre en compte l'échelle globale

        float angle = Random.Range(0f, Mathf.PI * 2f);
        float dist = Mathf.Sqrt(Random.Range(0f, 1f)) * radius;

        Vector2 point = center + new Vector2(
            Mathf.Cos(angle) * dist,
            Mathf.Sin(angle) * dist
        );

        return point;
    }

    Vector2 GetRandomPointInCollider(Collider2D collider)
    {
        if (collider is CircleCollider2D)
            return GetRandomPointInCircle(collider);
        else
        {
            Bounds bounds = collider.bounds;
            Vector2 point;
            int safety = 0;
            do
            {
                point = new Vector2(
                    Random.Range(bounds.min.x, bounds.max.x),
                    Random.Range(bounds.min.y, bounds.max.y)
                );
                safety++;
                if (safety > 30) break;
            } while (!collider.OverlapPoint(point));

            return point;
        }
    }

}
