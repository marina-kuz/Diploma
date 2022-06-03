[System.Serializable]
public class HeroStat
{
    //Состояние показателей питомца
    public int currMoney;
    public int currHeart;
    public int currHappy;
    public int currFood;
    public int currSleep;
    //Игровое время 
    public float seconds;
    public int mins;
    public int hours;
    public int days;
    public int mounts;
    public int years;
    //Данные предметов на поле и в инвентаре
    public string[] itemNames;
    public int[] itemAmount;
    public int[] itemScore;
    public HeroStat(Indicator indicator, MoneyScr money, TimeManager time, InventoryManager_ inventory)
    {
        //Состояние показателей питомца
        currMoney=money.get();
        currHeart=indicator._currHeart;
        currHappy=indicator._currHappy;
        currFood=indicator._currFood;
        currSleep=indicator._currSleep;
        //Игровое время
        seconds=time.seconds;
        mins=time.mins;
        hours=time.hours;
        days=time.days;
        mounts=time.mounts;
        years=time.years;
        //Данные предметов на поле и в инвентаре
        itemNames=new string[inventory.item.Count];
        itemAmount=new int[inventory.item.Count];
        itemScore=new int[inventory.item.Count];
        for (int i = 0; i < inventory.item.Count; i++)
        {
            if(inventory.item[i].id!=0)
            {
                itemNames[i]=inventory.item[i].fileName;
                itemAmount[i]=inventory.item[i].countItem;
                itemScore[i]=inventory.item[i].score;
            }
        }
    }
}