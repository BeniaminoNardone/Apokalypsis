using UnityEngine;

public class FadeOutWhenBehind : MonoBehaviour
{
public Transform player;
    public float transparency = 0.5f;
    public float distanceThreshold = 1.0f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 playerPositionXZ = new Vector3(player.position.x, 0, player.position.z);
        Vector3 objectPositionXZ = new Vector3(transform.position.x, 0, transform.position.z);

        float distance = Vector3.Distance(playerPositionXZ, objectPositionXZ);

        if (distance < distanceThreshold)
        {
            Color color = spriteRenderer.color;
            color.a = transparency;
            spriteRenderer.color = color;
        }
        else
        {
            Color color = spriteRenderer.color;
            color.a = 1f;
            spriteRenderer.color = color;
        }
    }
}