using UnityEngine;

public class ManateeRoaming2D : MonoBehaviour
{
    [Header("Roaming Settings")]
    public float roamRadius = 5f;
    public float roamDelay = 3f;
    public float moveSpeed = 1f; 

    private Vector2 targetPosition;
    private float timer;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        timer = roamDelay;
        PickNewDestination();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        
        Vector2 currentPosition = transform.position;
        transform.position = Vector2.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);
        
        Vector2 direction = targetPosition - currentPosition;
        if (direction.x != 0)
        {
            transform.localScale = new Vector3(
                direction.x < 0 ? -1f : 1f,
                transform.localScale.y,
                transform.localScale.z
            );
        }
        
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f || timer >= roamDelay)
        {
            PickNewDestination();
            timer = 0f;
        }
    }

    void PickNewDestination()
    {
        Camera cam = Camera.main;
        Vector2 min = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector2 max = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));

        Vector2 newTarget;
        int attempts = 10;

        do
        {
            Vector2 randomDirection = Random.insideUnitCircle * roamRadius;
            newTarget = (Vector2)transform.position + randomDirection;
            attempts--;
        } while ((newTarget.x < min.x || newTarget.x > max.x || newTarget.y < min.y || newTarget.y > max.y) && attempts > 0);

        targetPosition = (attempts > 0) ? newTarget : transform.position;
    }
}