using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering; 
public class TimeManager : MonoBehaviour
{
    private Text txt;
    public Volume volume;
    public float tick;
    [HideInInspector] public float seconds;
    [HideInInspector] public int mins;
    [HideInInspector] public int hours;
    [HideInInspector] public int days;
    [HideInInspector] public int mounts;
    [HideInInspector] public int years;

    private string txt_seconds,txt_mins,txt_hours,txt_days,txt_mounts,txt_years;

    void Start()
    {
        this.txt=gameObject.GetComponent<Text>();
    }
    void FixedUpdate()
    {
        CalcTime();
    }
    private void CalcTime()
    {
        this.seconds+=Time.fixedDeltaTime*this.tick;

        if(this.seconds>=60)
        {
            this.seconds=0;
            this.mins+=1;
        }
        if(this.mins>=60)
        {
            this.mins=0;
            this.hours+=1;
        }
        if(this.hours>=24)
        {
            this.hours=0;
            this.days+=1;
        }
        if(this.days>=30)
        {
            this.days=1;
            this.mounts+=1;
        }
        if(this.mounts>=12)
        {
            this.mounts=1;
            this.years+=1;
        }
        this.txt.text=getTimeText();
        SetDayNight();
    }
    private string getTimeText()
    {
        this.txt_hours=setZeroToTxt(this.hours);
        this.txt_mins=setZeroToTxt(this.mins);
        this.txt_days=setZeroToTxt(this.days);
        this.txt_mounts=setZeroToTxt(this.mounts);
        this.txt_years=setZeroToTxt(this.years);
        
        return this.txt_hours+":"+this.txt_mins+", "+this.txt_days+"."+this.txt_mounts+"."+this.txt_years;
    }
    public string setZeroToTxt(int x)
    {
        if((x>=0)&&(x<=9))
        {
            return "0"+x.ToString();
        }
        else
        {
            return x.ToString();
        }
    }
    public int getHours()
    {
        return this.hours;
    }
    public int getMinutes()
    {
        return this.mins;
    }
    private void SetDayNight()
    {
        if(hours>=21 && hours<22)
        {
            volume.weight = (float) mins/60;
        }
        if(hours>=6 && hours<7)
        {
            volume.weight=1- (float) mins/60;
        }
    }
}
