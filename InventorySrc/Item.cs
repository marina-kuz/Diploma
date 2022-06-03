using UnityEngine;
using UnityEngine.Events;
public class Item : MonoBehaviour
{
    public string fileName;
    public string nameItem;
    public int id;
    public int price; //Стоимость 1 предмета
    public int countItem; //Количество предметов
    //значение предмета
    public int score;
    [Multiline(5)]
    public string description; //Описание предмета
    public Sprite icon; //Изображение предмета
    //Может ли предмет быть удален из инвентаря после кастомного события
    public bool isRemovable;
    //Может ли предмет быть выкинут из инвентаря
    public bool isDropable;
    //Особенные события предмета
    public UnityEvent customEvent;
}
