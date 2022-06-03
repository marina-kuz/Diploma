using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryManager_ : MonoBehaviour
{
    [HideInInspector]
    public List<Item> item;
    public GameObject database;
    public GameObject cellContainer;
    public GameObject inventoryPanel;
    public MessageManager message;
    [Header("ItemDescription")]
    public GameObject description;
    public Image itemIcon;
    public Text itemName;
    public Text itemDescr;
    private void Update() {
       if (Input.GetMouseButtonDown(1))
        {
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit=Physics2D.Raycast(ray,Vector2.zero);
            if(hit)
            {
                //если правая кнопка мыши нажала на объект у которого есть скрипт Item
                if (hit.collider.GetComponent<Item>())
                {
                    //функция добавления предмета
                    AddItem(hit.collider.GetComponent<Item>());
                    message.SetTempMessage(hit.collider.GetComponent<Item>().nameItem+" добавлен(а) в инвентарь!");
                }
            }
        }
    }
    //выводит предметы на отдельное окно инвентаря
    public void DisplayItems()
    {
        for (int i = 0; i < item.Count; i++)
        {
                Transform cell=cellContainer.transform.GetChild(i);
                Transform icon = cell.GetChild(0);
                Transform count = icon.GetChild(0);
                Image  img = icon.GetComponent<Image>();
                Text txt_=count.GetComponent<Text>();

            if (item[i].id!=0)
            {
                txt_.enabled=true;
                img.sprite=item[i].icon;
                txt_.text=item[i].countItem.ToString();
            }
            else
            {
                img.sprite=Resources.Load<Sprite>("Picture/no_photo");;
                txt_.enabled=false;
            }
        }
    }
    //функция добавления предмета в инвентарь
    void AddItem(Item currItem){
        for (int i = 0; i < item.Count; i++)
        {
            //если item больше 1
            if(item[i].id==currItem.id)
            {
                item[i]=currItem;
                item[i].countItem++;
                for(int j=0;j<inventoryPanel.transform.childCount;j++)
                {
                    if(inventoryPanel.transform.GetChild(j).GetComponent<Item>().id==currItem.id)
                    {
                        inventoryPanel.transform.GetChild(j).GetComponent<Item>().countItem++;
                    }
                }
                DisplayItems();
                currItem.gameObject.transform.position=new Vector3(0,5000,0);
                currItem.gameObject.transform.SetParent(inventoryPanel.GetComponent<Transform>());
                return;
            }
            //если это первый item
            else if(item[i].id==0)
            {
                item[i]=currItem;
                item[i].countItem=1;
                currItem.countItem=1;
                DisplayItems();
                currItem.gameObject.transform.position=new Vector3(0,5000,0);
                currItem.gameObject.transform.SetParent(inventoryPanel.GetComponent<Transform>());
                return;
            }
        }
    }
    //функция добавления предмета при загрузке
    public void AddItemForLoad(Item currItem){
        for (int i = 0; i < item.Count; i++)
        {
            if(item[i].id==0)
            {
                item[i]=currItem;
                DisplayItems();
                return;
            }
        }
    }
}