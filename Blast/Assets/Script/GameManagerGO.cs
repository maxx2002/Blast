using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameManagerState
{
    Opening,
    Gameplay,
    GameOver,
}
public class GameManagerGO : MonoBehaviour
{
    public GameObject start;
    public GameObject rocket;
    public GameObject meteorSpawner;
    public GameObject GameOverGO;

    GameManagerState GMstate;

    // Start is called before the first frame update
    void Start()
    {
        GMstate = GameManagerState.Opening;
    }

    // Update is called once per frame
    void UpdateGameManagerState()
    {
        switch (GMstate)
        {
            case GameManagerState.Opening:
                GameOverGO.SetActive(false);

                start.SetActive(true);
                break;
            case GameManagerState.Gameplay:
                start.SetActive(false);

                rocket.GetComponent<RoketControll>().Init();

                meteorSpawner.GetComponent<MeteorSpawn>().ScheduledMeteorSpawner();
                break;
            case GameManagerState.GameOver:
                meteorSpawner.GetComponent<MeteorSpawn>().UnscheduleMeteorSpawner();

                GameOverGO.SetActive(true);

                Invoke("ChangeToOpeningState", 8f);
                // SceneManager.LoadScene("PlayAgain");
                break;
        }
    }

    public void SetGameManagerState(GameManagerState state)
    {
        GMstate = state;
        UpdateGameManagerState();
    }

    public void StartGamePlay()
    {
        GMstate = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }


}
