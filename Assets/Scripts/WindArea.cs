using UnityEngine;

public class WindArea : MonoBehaviour
{
    public float windPower;

    public Transform arrows;

    private void Start()
    {
        if (windPower < 0f)
        {
            arrows.rotation = Quaternion.Euler(0f, 0f, 180f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D playerRB = collision.GetComponent<Rigidbody2D>();
            playerRB.velocity = playerRB.velocity + (new Vector2(arrows.position.x - transform.parent.position.x, arrows.position.y - transform.parent.position.y).normalized * windPower * Time.fixedDeltaTime);
        }
    }
}
