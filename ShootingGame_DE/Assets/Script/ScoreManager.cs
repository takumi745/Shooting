using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    // private int score = 0;

    // 静的変数
    // public staticをつけると、このScoreManagerスクリプトがついている
    // 他のオブジェクトもscoreのデータで共有できる
    public static int score = 0;
    private Text scoreLadel;

    // Start is called before the first frame update
    void Start()
    {
        scoreLadel = this.gameObject.GetComponent <Text> ();
        scoreLadel.text = "Score " + score;
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreLadel.text = "Score " + score;
    }

  
}
