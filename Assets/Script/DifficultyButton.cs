using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    // clickable button and gamemanager
    private Button button;
    private GameManager gameManager;

    // difficulty of button
    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        // get button, get gamemanager from scene, and add function for button
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // method to set difficulty
    void SetDifficulty()
    {
        gameManager.StartGame(difficulty);
        Debug.Log(gameObject.name + " was clicked");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
