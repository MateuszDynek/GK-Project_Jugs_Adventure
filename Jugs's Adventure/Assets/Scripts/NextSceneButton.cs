using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextSceneButton : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("SampleScene2");
    }
    public void FirstScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void HowToPlay()
    {
        SceneManager.LoadScene("StartScene2");
    }
    public void HowToPlay2()
    {
        SceneManager.LoadScene("StartScene3");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
