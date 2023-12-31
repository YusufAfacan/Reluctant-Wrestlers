using TMPro;
using UnityEngine;
public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance;
    public int currentScore;
    public int healthKitPointValue;
    public int botDefeatBaseValue;
    public TextMeshProUGUI text;
    public Bot[] botsInGame;

    private void Awake()
    {
        Instance = this;
        text.text = currentScore.ToString();
    }
    void Start()
    {
        botsInGame = FindObjectsOfType<Bot>();

        Player player = FindObjectOfType<Player>();

        player.OnHealthKitPicked += Player_OnHealthKitPicked;

        foreach (Bot bot in botsInGame)
        {
            bot.OnDefeatedByPlayer += Bot_OnDefeatedByPlayer;
        }
    }

    private void Bot_OnDefeatedByPlayer(object sender, Bot.OnDefeatedByPlayerEventArgs e)
    {
        currentScore += botDefeatBaseValue + ((int)(e.bodySize * botDefeatBaseValue));
        UpdatePointText();
    }

    private void Player_OnHealthKitPicked(object sender, System.EventArgs e)
    {
        currentScore += healthKitPointValue;
        UpdatePointText();
    }

    private void UpdatePointText()
    {
        text.text = currentScore.ToString();
    }
}
