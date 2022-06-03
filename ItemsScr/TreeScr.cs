using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class TreeScr : MonoBehaviour, IPointerEnterHandler
{
    public MessageManager message;
    float m;
    float n=3000.0f;
    Button btn;
    MoneyScr money;

    private void Start() {
        btn=GetComponent<Button>();
        btn.onClick.AddListener(onClick);
        money = GameObject.FindGameObjectWithTag("Money").GetComponent<MoneyScr>();
    }

    private void onClick()
    {
        m=(float)Random.Range(0,3000);
        if(m/n>0 && m/n<=0.1)
        {
            int i=(int)Random.Range(0,1001);
            money.set(i);
            message.SetTempMessage("Вам выпало "+i+" монет! Поздравляю!");
        }
        else
        {
            message.SetTempMessage("Повезет в другой раз!");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        message.SetMessage(true,"Испытай удачу!");
    }
}
