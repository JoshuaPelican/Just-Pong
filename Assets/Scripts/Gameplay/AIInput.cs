using System.Collections;
using UnityEngine;

public class AIInput : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Rigidbody2D ball;

    int aILevel;
    bool isMoving;

    private void FixedUpdate()
    {
        bool doMove = Random.Range(0, 50) < aILevel;

        if (doMove)
        {
            if (isMoving) StopAllCoroutines();
            StartCoroutine(nameof(Move));
        }
    }

    public void SetAILevel(int level)
    {
        aILevel = level;
    }

    IEnumerator Move()
    {
        isMoving = true;

        float targetDistance = Random.Range(0.1f, 0.5f);

        float predictedBallYPosition = ball.position.y + ((ball.velocity.y * Mathf.Abs(ball.position.y - player.Paddle.transform.position.y) / player.Paddle.speed) * 1.5f);
        predictedBallYPosition = Mathf.Clamp(predictedBallYPosition, -4, 4);

        while(Mathf.Abs(predictedBallYPosition - player.Paddle.transform.position.y) > targetDistance)
        {
            float direction = Mathf.Sign(predictedBallYPosition - player.Paddle.transform.position.y);
            player.MovePaddle(direction);
            yield return new WaitForEndOfFrame();
        }

        player.MovePaddle(0);

        isMoving = false;
    }
}
