using UnityEngine;
using UnityEngine.EventSystems;
public class ItemDescription_ : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    InventoryManager_ inventory;
    void Start()
    {
        inventory=GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager_>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        CurrentItem currItem=GetComponent<CurrentItem>();
        Item item=inventory.item[currItem.index];
        
        if(item.id!=0){
            inventory.itemIcon.sprite=item.icon;
            inventory.itemName.text=item.nameItem;
            inventory.itemDescr.text=item.description;
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        inventory.itemIcon.sprite=Resources.Load<Sprite>("Picture/no_photo");
        inventory.itemName.text="";
        inventory.itemDescr.text="";
    }
}
