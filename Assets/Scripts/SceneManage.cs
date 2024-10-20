using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public GameObject GameOverScene;
    
    public void Awake()
    {
        GameOverScene.SetActive(false);

    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Awake();
        
    }

    public void DeathScene()
    {
        GameOverScene.SetActive(true);
    }


}
