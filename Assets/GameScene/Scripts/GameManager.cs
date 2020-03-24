using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public delegate void GameStateChanged(GameState state);
    public static event GameStateChanged OnGameStateChanged;

    public static GameManager instance;

    private GameState curGameState;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }

        Init();
    }

    #region GETSETTERS

    public GameState GetGameState()
    {
        return curGameState;
    }

    #endregion

    private void Init()
    {
        GameObject PrisonerPrefab = (GameObject)Resources.Load("Prisoner");
        for (int i = 0; i < 50; i++)
        {
            GameObject prisoner = Instantiate(PrisonerPrefab);
            prisoner.GetComponent<PrisonerNPC>().SetupAi();
        }
    }

    public void SetGameState(GameState state)
    {

        if (OnGameStateChanged != null) OnGameStateChanged(state);

        if (curGameState != state)
        {
            switch (state)
            {
                case GameState.Init:
                    break;
                case GameState.Pause:
                    break;
                case GameState.Play:
                    break;
            }
        }

        curGameState = state;
    }
}

public enum GameState
{
    Init,
    Pause,
    Play
}
