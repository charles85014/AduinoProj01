using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager master;

    public Texture StartGamePicture;
    public Texture GameOverPicture;

    public enum GameState
    {
        ReadytoStart = 0, StartGame, GameOver
    }
    [HideInInspector]
    public GameState currentGameState = GameState.ReadytoStart;

    [HideInInspector]
    public int CurrentLayerCount = 0;

    public GUIStyle style;

    void Awake()
    {
        master = this;
    }

    // Update is called once per frame
    void Update()
    {
        switch (this.currentGameState)
        {
            case GameState.ReadytoStart:
                if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyDown(KeyCode.Mouse0))
                {
                    this.currentGameState = GameState.StartGame;
                    BoxCreat.master.enabled = true;
                }
                break;

            case GameState.StartGame:

                break;

            case GameState.GameOver:
                if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyDown(KeyCode.Mouse0))
                {
                    iTween.Stop();
                    Application.LoadLevel(Application.loadedLevelName);
                }
                break;
        }
    }

    void OnGUI()
    {
        switch (this.currentGameState)
        {
            case GameState.ReadytoStart:
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), this.StartGamePicture);
                break;

            case GameState.StartGame:
                GUI.Label(new Rect(0, 0, 0, 0), "¥Ø«eÅ|" + CurrentLayerCount.ToString() + "¼h", this.style);
                break;

            case GameState.GameOver:
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), this.GameOverPicture);
                break;
        }
    }
}
