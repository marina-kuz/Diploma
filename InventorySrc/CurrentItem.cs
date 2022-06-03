using UnityEngine;
using UnityEngine.EventSystems;
public class CurrentItem : MonoBehaviour, IPointerClickHandler
{
    [HideInInspector]
    public int index;
    GameObject parent;
    public InventoryManager_ inventory;
    public GameObject inventoryPanel;
    void Start()
    {
        parent=GameObject.Find("House");
        inventory=GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager_>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        //по нажатию левой кнопки мыши
        //Срабатывание кастомного события предмета
        /*if(eventData.button==PointerEventData.InputButton.Left)
        {
            if(inventory.item[index].customEvent!=null)
            {
                inventory.item[index].customEvent.Invoke();
            }
            if(inventory.item[index].isRemovable)
            {
                Remove();
            }
        }*/
        //по нажатию правой кнопки мыши
        //Выбрасывание предмета из инвентаря и удаление этого прдемета из инвентаря
        if(eventData.button==PointerEventData.InputButton.Right)
        {
            if(inventory.item[index].isDropable)
            {
                Drop();
            }            
        }
    }
//Выкинуть предмет на сцену
    void Drop()
    {
        if(inventory.item[index].id!=0)//Не пустая ячейка
        {
            for(int i=0; i<inventoryPanel.transform.childCount;i++)
            {
                if(inventory.item[index].id==inventoryPanel.transform.GetChild(i).GetComponent<Item>().id)
                {
                    if(inventory.item[index].countItem>1)
                    {
                        inventory.item[index].countItem--;
                        inventoryPanel.transform.GetChild(i).GetComponent<Item>().countItem--;
                        TransformItem();
                    }
                    else
                    {
                        TransformItem();
                        inventory.item[index]=new Item();
                    }
                    inventory.DisplayItems();
                }
            }
        }
    }
    void TransformItem()
    {
        for(int i=0; i<inventoryPanel.transform.childCount;i++)
        {
            if(inventory.item[index].id==inventoryPanel.transform.GetChild(i).GetComponent<Item>().id)
            {
                inventoryPanel.transform.GetChild(i).transform.position=new Vector3(0,-150,0);
                inventoryPanel.transform.GetChild(i).transform.SetParent(FindActiveRoom());
                return;
            }
        }
    }
    Transform FindActiveRoom()
    {
        for(int i=0;i<parent.transform.childCount;i++)
        {
            if(parent.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                return parent.transform.GetChild(i).GetComponent<Transform>();
            }
        }
        return null;
    }
}
