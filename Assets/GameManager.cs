using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int _playerScore1 = 0;
    private static int _playerScore2 = 0;

    public GUISkin layout;

    public GameObject _theBall;

    // Start is called before the first frame update
    void Start()
    {
        _theBall = GameObject.FindGameObjectWithTag("Ball");
    }
    
    public static void Score (string wallID) {
        if (wallID == "RightWall")
        {
            _playerScore1++;
        } else
        {
            _playerScore2++;
        }
    }

    void OnGUI () {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + _playerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + _playerScore2);

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            _playerScore1 = 0;
            _playerScore2 = 0;
            _theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        if (_playerScore1 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            _theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        } else if (_playerScore2 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            _theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
