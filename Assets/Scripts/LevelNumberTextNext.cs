using UnityEngine;
using UnityEngine.UI;

public class LevelNumberTextNext : MonoBehaviour
{
    public Text Text;
    public Game Game;

    private void Start()
    {
        Text.text = (Game.LevelIndex + 2).ToString();
    }
}
