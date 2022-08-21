using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    public Text textScore;

	// Update is called once per frame
	void Update ()
    {
        textScore.text = "Score : " + score;
	}
}
