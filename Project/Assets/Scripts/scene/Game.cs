using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    public OpponentMove oponentPrefab;
    public PlayerMove playerPrefab;

    public Vector3 playerSpawnLocation;
    public Vector3 opponentSpawnLocation;

    public ScoreShot opponentGoal;
    public ScoreShot playerGoal;

    public Text playerScoreText;
    public Text opponentScoreText;

    int playerScore;
    int opponentScore;

    Transform playerTrans;
    Transform opponentTrans;
    Transform ball;
    BallMovement bm;

    void Start()
    {
        var bball = GameObject.FindGameObjectWithTag("Ball");
        ball = bball.transform;
        bm = bball.GetComponent<BallMovement>();

        var opponent = Instantiate(oponentPrefab, opponentSpawnLocation, Quaternion.identity);
        opponent.balltrans = ball;

        Instantiate(playerPrefab, playerSpawnLocation, Quaternion.identity);

        opponentGoal.ShotMade += OnOpponentMakeShot;
        playerGoal.ShotMade += OnPlayerMadeShot;
    }

    private void OnPlayerMadeShot()
    {
        if (bm.player != "Player" && bm.points == 3)
        {
            bm.points = 2;
        }
        playerScore += bm.points;
        playerScoreText.text = playerScore.ToString("00");
        playerScoreText.text = playerScore.ToString();
        SetBack();
    }

    private void OnOpponentMakeShot()
    {
        if (bm.player != "Opponent" && bm.points == 3)
        {
            bm.points = 2;
        }
        opponentScore += bm.points;
        opponentScoreText.text = opponentScore.ToString("00");
        opponentScoreText.text = opponentScore.ToString();
        SetBack();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(playerSpawnLocation, 0.125f);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(opponentSpawnLocation, 0.125f);
    }

    void SetBack()
    {

        bm.points = 2;

        if (playerTrans == null)
            playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        if (opponentTrans == null)
            opponentTrans = GameObject.FindGameObjectWithTag("Opponent").transform;

        float x = Random.Range(-10, 10);
        float y = Random.Range(-5, 5);

        var brb = ball.GetComponent<Rigidbody2D>();
        brb.velocity = new Vector2(x, y);

        playerTrans.position = playerSpawnLocation;
        opponentTrans.position = opponentSpawnLocation;
        ball.position = new Vector2(0, 0);
    }
}
