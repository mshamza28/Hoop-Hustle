using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private Button button;
    private ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        button.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartGame()
    {
        scoreManager.StartGame();
    }
}
