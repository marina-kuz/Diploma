using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Helper_ : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject helper;
    void Start()
    {
        helper.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        helper.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        helper.SetActive(false);
    }
}
