using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 5;
    [Space]
    [SerializeField] Player player;

    Rigidbody2D rig;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.transform.CompareTag("Ball"))
            return;

        collision.transform.GetComponent<PlayerColorizer>().SetPlayer(player);

        // calculate the pong-style hit velocity
        Vector2 hitNormal = (collision.GetContact(0).point - ((Vector2)transform.position * new Vector2(1.3f, 1))).normalized;
        collision.rigidbody.velocity = hitNormal * collision.rigidbody.velocity.magnitude;
    }

    public void Move(float yAmount)
    {
        Vector2 movement = new Vector2(0, yAmount * speed * Time.deltaTime);
        rig.MovePosition(rig.position + movement);
    }
}
