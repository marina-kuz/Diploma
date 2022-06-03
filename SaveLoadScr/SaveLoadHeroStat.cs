using System.Collections.Generic;
using UnityEngine;
public class SaveLoadHeroStat : MonoBehaviour
{
    [SerializeField] private Indicator indicator;
    [SerializeField] private MoneyScr money;
    [SerializeField] private TimeManager time;
    [SerializeField] private InventoryManager_ inventory;
    public void SaveData()
    {
        SaveManager.Save(indicator, money, time, inventory);
    }
    public void LoadData()
    {
        HeroStat data = SaveManager.Load();
        if(data!=null)
        {
            //Состояние показателей питомца
            money.set(data.currMoney);
            indicator._currHeart=data.currHeart;
            indicator._currHappy=data.currHappy;
            indicator._currFood=data.currFood;
            indicator._currSleep=data.currSleep;
            //Игровое время
            time.seconds=data.seconds;
            time.mins=data.mins;
            time.hours=data.hours;
            time.days=data.days;
            time.mounts=data.mounts;
            time.years=data.years;
            //Данные предметов на поле и в инвентаре
            inventory.item =new List<Item>();
            for(int i=0; i<inventory.cellContainer.transform.childCount; i++)
            {
                inventory.cellContainer.transform.GetChild(i).GetComponent<CurrentItem>().index=i;
                inventory.item.Add(new Item());
            }
            for (int i = 0; i < data.itemNames.Length; i++)
            {
                if(data.itemNames[i]!=null)
                {
                    Item item=Resources.Load<Item>($"Prefabs/{data.itemNames[i]}");
                    if(data.itemAmount[i]!=1)
                        item.countItem=data.itemAmount[i];
                    inventory.AddItemForLoad(item);
                }
            }
        }
        else{
            //Состояние показателей питомца
            money.set(500);
            indicator._currHeart=100;
            indicator._currHappy=100;
            indicator._currFood=100;
            indicator._currSleep=100;
            //Игровое время
            time.seconds=0.0f;
            time.mins=0;
            time.hours=10;
            time.days=1;
            time.mounts=1;
            time.years=1;
            //Данные предметов на поле и в инвентаре
            inventory.item =new List<Item>();
            for(int i=0; i<inventory.cellContainer.transform.childCount; i++)
            {
                inventory.cellContainer.transform.GetChild(i).GetComponent<CurrentItem>().index=i;
                inventory.item.Add(new Item());
            }
        }
    }
}
