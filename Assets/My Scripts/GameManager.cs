using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public TextMeshProUGUI endScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver(int value)
    {
        gameOverUI.SetActive(true);
        endScore.text = value.ToString() + " POINTS";
    }
}
