using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void level1()
    {
        GlobalVariable.level = 1;
        SceneManager.LoadScene("Game");
    }

    public void level2()
    {
        GlobalVariable.level = 2;
        SceneManager.LoadScene("Game");
    }

    public void level3()
    {
        GlobalVariable.level = 3;
        SceneManager.LoadScene("Game");
    }
}
