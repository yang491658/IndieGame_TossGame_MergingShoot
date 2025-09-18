using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event System.Action<int> OnScoreChanged;

    [Header("Game Info.")]
    [SerializeField] private int totalScore = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        SpawnManager.Instance.Spawn(1);
    }

    #region ����
    public void ResetScore()
    {
        Debug.Log("���� �ʱ�ȭ");

        totalScore = 0;
        OnScoreChanged?.Invoke(totalScore);
    }

    public void AddScore(int _score)
    {
        Debug.Log("���� ȹ�� : " + _score);

        totalScore += _score;
        OnScoreChanged?.Invoke(totalScore);
    }
    #endregion

    #region GET
    public int GetTotalScore() => totalScore;
    #endregion
}
