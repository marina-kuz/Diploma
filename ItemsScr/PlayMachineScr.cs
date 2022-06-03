using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayMachineScr : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public MessageManager message;
    public GameObject games;
    Button btn;
    //MoneyScr money;

    void Start()
    {
        btn=GetComponent<Button>();
        btn.onClick.AddListener(onClick);
        //money = GameObject.FindGameObjectWithTag("Money").GetComponent<MoneyScr>();
    }

    private void onClick()
    {
        games.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        message.SetMessage(true,"Поиграем?!");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        message.SetMessage(false,"");
    }
}
