using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField]
    Player scoringPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Ball"))
            return;

        scoringPlayer.AddScore(1);
        GameManager.Instance.ResetBall();
    }
}
