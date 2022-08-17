using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Controls Controls;
    public Player Player;
    public AudioSource gameSound;
    public AudioClip VictorySound;
    public AudioClip LoseSound;
    
    public enum State
    {
        Playing,
        Won,
        Loss,
    }

    public void Start()
    {
        gameSound.Play();
    }

    public State CurrentState { get; private set; }

    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Loss;
        Controls.enabled = false;
        Debug.Log("Game Over!" + "\nScore: " + Player.playerScore.ToString());
        Player.SendMessage("PlayLoseSound", LoseSound);
        Invoke("Delay", 2.0f);
        gameSound.Stop();
    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;

        
        CurrentState = State.Won;
        Controls.enabled = false;
        LevelIndex++;
        Debug.Log("You Win!" + " Level: " + LevelIndex.ToString() + " Passed" + "\nScore: " + Player.playerScore.ToString());
        Player.SendMessage("PlayVictorySound", VictorySound);
        Invoke("Delay", 1.0f);
        gameSound.Stop();

        
            
        
    }
    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }

    private const string LevelIndexKey = "LevelIndex";

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Delay()
    {
        ReloadLevel();
    }
}
