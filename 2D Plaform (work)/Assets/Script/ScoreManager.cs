using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private static ScoreManager instance;
    [SerializeField] private TextMeshProUGUI text;
    int score;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void ChangeScore(int coinValue)
    {
        score += coinValue;
        text.text = "X" + score.ToString();
    }
}
