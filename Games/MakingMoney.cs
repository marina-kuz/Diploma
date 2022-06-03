using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakingMoney : MonoBehaviour
{
    public Text money_txt;
    MoneyScr money;

    void Start()
    {
        money = GameObject.FindGameObjectWithTag("Money").GetComponent<MoneyScr>();
        money_txt.text=money.get().ToString();
    }

    public void SetMoney(int x)
    {
        money.set(x);
        money_txt.text=money.get().ToString();
    }
}
