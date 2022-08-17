using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
    }
    Text gameText;
    PlayerMove player;

    public enum GameState
    {
        Ready,
        Run,
        GameOver
    }

    public GameState gState;
    public static GameManager gm;
    public GameObject gameLable;

    // Start is called before the first frame update
    void Start()
    {
        gState = GameState.Ready;
        gameText = gameLable.GetComponent<Text>();
        gameText.text = "Ready... ";
        gameText.color = new Color32(255, 185, 0, 255);
        StartCoroutine(ReadyToStart());
        player = GameObject.Find("Player").GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.hp <= 0)
        {
            gameLable.SetActive(true);
            gameText.text = "Game Over";
            gameText.color = new Color32(255, 0, 0, 255);
            gState = GameState.GameOver;
        }
    }

    IEnumerator ReadyToStart()
    {
        yield return new WaitForSeconds(2.0f);
        gameText.text = "Go!";
        yield return new WaitForSeconds(0.5f);
        gameLable.SetActive(false);
        gState = GameState.Run;
    }
}
