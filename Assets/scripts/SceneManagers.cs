using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameSceneMove()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LobbySceneMove()
    {
        SceneManager.LoadScene("MainScene");
    }
}
