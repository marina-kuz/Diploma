using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Indicator : MonoBehaviour
{
    public float tick=10;
    MoneyScr money;
    TempIndicator tempIndicator;
    [HideInInspector] public int _currHeart;
    [HideInInspector] public int _currHappy;
    [HideInInspector] public int _currFood;
    [HideInInspector] public int _currSleep;
    int min_=0,max_=100;
    public Text money_txt;
    public Text heart_txt;
    public Text happy_txt;
    public Text food_txt;
    public Text sleep_txt;
    
    void Start()
    {
        money = GameObject.FindGameObjectWithTag("Money").GetComponent<MoneyScr>();
        tempIndicator=GameObject.FindGameObjectWithTag("TempIndicator").GetComponent<TempIndicator>();
        money_txt.text=money.get().ToString();
        heart_txt.text=_currHeart.ToString();
        food_txt.text=_currFood.ToString();
        sleep_txt.text=_currSleep.ToString();
        happy_txt.text=_currHappy.ToString();
        StartCoroutine(hungry(1));
        StartCoroutine(dream(1));
        StartCoroutine(happines(1));
        StartCoroutine(health(1));
    }
    private void Update() {
        money_txt.text=money.get().ToString();
        if(tempIndicator.getAnswer())
        {
            setHappy(tempIndicator.getChangedHappiness());
        }
    }
    //Уменьшение сытости на единицу каждые 30 секунд
    IEnumerator hungry(int h)
    {
        while (_currFood>min_)
        {
            food_txt.text=_currFood.ToString();
            yield return new WaitForSeconds(tick);
            _currFood-=h;
        }
    }
    //Уменьшение сна на единицу каждые 30 секунд
    IEnumerator dream(int h)
    {
        while(_currSleep>min_)
        {
            sleep_txt.text =_currSleep.ToString();
            yield return new WaitForSeconds(tick);
            _currSleep-=h;
        }
    }
    //Уменьшение радости на единицу каждые 30 секунд
    IEnumerator happines(int h)
    {
        while (_currHappy>min_)
        {
            happy_txt.text=_currHappy.ToString();
            yield return new WaitForSeconds(tick);
            _currHappy-=h;
        }
    }
    //Уменьшение здоровья
    IEnumerator health(int h)
    {
        while (_currHeart>min_)
        {
            heart_txt.text=_currHeart.ToString();
            yield return new WaitForSeconds(tick);
            if(_currFood<=20 && _currHappy<=20)
            {
                _currHeart-=5;
            }
            else if((_currHeart<max_)&&(_currFood>20)&&(_currHappy>20))
            {
                if(_currHeart+h>=100)
                {
                    _currHeart=100;
                }
                else
                {
                    _currHeart+=h;
                }
            }
        }
    }
    //Сеттер здоровья
    public void setHeart(int x)
    {
        if(x+_currHeart>=100)
        {
            _currHeart=100;
        }
        else{
            _currHeart+=x;
        }
        heart_txt.text=_currHeart.ToString();
    }
    //Сеттер радости
    public void setHappy(int x)
    {
        if(x+_currHappy>=100)
        {
            _currHappy=100;
        }
        else{
            _currHappy+=x;
        }
        happy_txt.text=_currHappy.ToString();
    }
    //Сеттер сна
    public void setSleep(int x)
    {
        if(x+_currSleep>=100)
        {
         _currSleep=100;
        }
        else{
         _currSleep+=x;
        }
        sleep_txt.text=_currSleep.ToString();
    }
    //Сеттер голода
    public void setHungry(int x)
    {
        if(x+_currFood>=100)
        {
            _currFood=100;
        }
        else{
            _currFood+=x;
        }
        food_txt.text=_currFood.ToString();
    }
}
