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
        SceneManager.LoadScene("Game");
    }

    public void level3()
    {
        SceneManager.LoadScene("Game");
    }
}
