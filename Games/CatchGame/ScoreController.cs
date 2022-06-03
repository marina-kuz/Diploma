using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    MakingMoney money;
    WinPanel winnerPanel;
    TempIndicator indicator;
    public Text score_txt;
    private int score;
    public GameObject GamePanel;
    void Start()
    {
        money=GameObject.Find("Games").GetComponent<MakingMoney>();
        winnerPanel=GameObject.Find("WinPanel").GetComponent<WinPanel>();
        indicator=GameObject.FindGameObjectWithTag("TempIndicator").GetComponent<TempIndicator>();
    }

    public void StartGame()
    {
        score=0;
    }

    void Update()
    {
        score_txt.text=score.ToString();
        if(score>=900)
        {
            GamePanel.SetActive(false);
            winnerPanel.SetText("Поздравляю! вы заработали 45 монеток! Питомец получает 35 очков радости.");
            money.SetMoney(45);
            indicator.setChangedHappiness(35);
        }
        else if(score<=-200)
        {
            GamePanel.SetActive(false);
            winnerPanel.SetText("Вы проиграли :( Питомец получает -20 очков радости.");
            indicator.setChangedHappiness(-20);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="BadFish")
        {
            Destroy(other.gameObject);
            score-=100;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag=="GoodFish")
        {
            Destroy(other.gameObject);
            score+=100;
        }
    }
}
