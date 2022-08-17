using UnityEngine;
using UnityEngine.UI;


public class ProgressBarController : MonoBehaviour
{
    [Header("UI Elements")]
    public Image image;

    [Header("Properties")]
    public Player Player;
    private int value;
    private int maxValue;
    public bool isCorrectlyConfigured = false;
    public Text scoreText;
    public LevelGenerator LevelGenerator;
    public int Points;

    private void Start()
    {
        maxValue = LevelGenerator.MaxPlatforms * Points;
    }

    private void Awake()
    {
        if (image.type == Image.Type.Filled & image.fillMethod == Image.FillMethod.Horizontal)
        {
            isCorrectlyConfigured = true;
        }
        else
        {
            Debug.Log(message: "{GameLog} => [ProgressBarController] - (<color=red>Error</color>) -> Components Parameters Are Incorrectly Configured! \n " +
                "Required type: Filled \n" +
                "Required FillMethod: Horizontal");
        }
        
    }

    private void LateUpdate()
    {
        if (!isCorrectlyConfigured) return;
        image.fillAmount = (float)Player.playerScore / (float)maxValue;
        scoreText.text = "Score: " + Player.playerScore.ToString();
    }

    public void SetValue(int value) => this.value = value;
    public void SetMaxValue(int maxValue) => this.maxValue = maxValue;

}
