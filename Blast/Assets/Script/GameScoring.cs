using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScoring : MonoBehaviour
{
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
    }
}
