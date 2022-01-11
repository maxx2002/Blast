using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScoring : MonoBehaviour
{
    public GameObject GameManagerGO;

    Text TextScoreUI;

    int score;

    public int Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            UpdateScoreTextUI();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //ambil component gameobject text score ui
        TextScoreUI = GetComponent<Text>();
    }

    // Update is called once per frame
    void UpdateScoreTextUI()
    {
        string StrScore = string.Format("{0:0000000}", score);
        TextScoreUI.text = StrScore;

        if (GlobalVariable.level == 1)
        {
            if (this.score >= 100)
            {
                GameManagerGO.GetComponent<GameManagerGO>().SetGameManagerState(GameManagerState.GameOver);
            }
        }
        else if (GlobalVariable.level == 2)
        {
            if (this.score >= 200)
            {
                GameManagerGO.GetComponent<GameManagerGO>().SetGameManagerState(GameManagerState.GameOver);
            }
        }
        else if (GlobalVariable.level == 3)
                {
            if (this.score >= 300)
            {
                GameManagerGO.GetComponent<GameManagerGO>().SetGameManagerState(GameManagerState.GameOver);
            }
        }
    }
}
            
     
