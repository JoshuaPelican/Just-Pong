using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] float startingBallSpeed = 5f;
    [Space]
    [SerializeField] Player player1;
    [SerializeField] Player player2;

    [SerializeField] Rigidbody2D ball;

    [SerializeField] TMP_Dropdown aIDropdown1;
    [SerializeField] TMP_Dropdown aIDropdown2;

    [SerializeField] TMP_Dropdown colorDropdown1;
    [SerializeField] TMP_Dropdown colorDropdown2;

    [SerializeField] TMP_InputField aILevelField1;
    [SerializeField] TMP_InputField aILevelField2;

    private void Awake()
    {
        Instance = this;
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGame()
    {
        // Settings stuff

        ApplySettings();

        ResetBall();
    }

    void ApplySettings()
    {
        player1.GetComponent<Player>().isAI = aIDropdown1.value == 1;
        player1.GetComponent<AIInput>().enabled = aIDropdown1.value == 1;

        player2.GetComponent<Player>().isAI = aIDropdown2.value == 1;
        player2.GetComponent<AIInput>().enabled = aIDropdown2.value == 1;

        player1.SetColor(PlayerColors[colorDropdown1.value]);
        player2.SetColor(PlayerColors[colorDropdown2.value]);

        player1.GetComponent<AIInput>().SetAILevel(int.Parse(aILevelField1.text));
        player2.GetComponent<AIInput>().SetAILevel(int.Parse(aILevelField2.text));
    }

    public void ResetBall()
    {
        ball.position = Vector2.zero;
        ball.velocity = Vector2.zero;

        ball.GetComponent<PlayerColorizer>().SetPlayer(null);

        Invoke(nameof(PushBall), 1.5f);
    }

    public void PushBall()
    {
        int direction = Random.value > 0.5f ? 1 : -1;
        ball.velocity = new Vector2(startingBallSpeed * direction, 0);
    }

    public static Color[] PlayerColors = new Color[]
    {
        Color.red,
        new Color(0.8f, 0.3f, 0),
        Color.yellow,
        Color.green,
        Color.blue,
        new Color(0.6f, 0, 0.8f),
        Color.magenta
    };
}
