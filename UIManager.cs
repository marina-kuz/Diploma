using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class UIManager : MonoBehaviour
{
    public Dropdown dropDownQuality;
    public Dropdown dropDownResolution;
    Resolution [] res;
    public Toggle toggle;
    void Start()
    {
        if(PlayerPrefs.HasKey("FullScreen"))
        {
            if(PlayerPrefs.GetInt("FullScreen")==0)
            {
                Screen.fullScreen=false;
                toggle.isOn=!Screen.fullScreen;
            }
            else{
                Screen.fullScreen=true;
                toggle.isOn=!Screen.fullScreen;
            }
        }
        else{
        //Полноэкранный режим
        Screen.fullScreen=true;
        toggle.isOn=!Screen.fullScreen;
        }
        //Получение уровней графиков
        dropDownQuality.ClearOptions();
        dropDownQuality.AddOptions(QualitySettings.names.ToList());
         //Загрузка сохранения настроек (если такие есть)
        if(PlayerPrefs.HasKey("Quality")){
            dropDownQuality.value =PlayerPrefs.GetInt("Quality");
             QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality"));
        }
        else{
            dropDownQuality.value = QualitySettings.GetQualityLevel();
        }
        //Получение массива графики
        Resolution [] resolution = Screen.resolutions;
        res= resolution.Distinct().ToArray();
        string[] str=new string[res.Length];
        for(int i=0;i<res.Length;i++)
        {
            str[i]=res[i].width.ToString()+"x"+res[i].height.ToString();
        }
        dropDownResolution.ClearOptions();
        dropDownResolution.AddOptions(str.ToList());
        if(PlayerPrefs.HasKey("Resolution")){
            dropDownResolution.value=PlayerPrefs.GetInt("Resolution");
            Screen.SetResolution(res[PlayerPrefs.GetInt("Resolution")].width,res[PlayerPrefs.GetInt("Resolution")].height,Screen.fullScreen);
        }
        else
        {
        dropDownResolution.value=res.Length-1;
        //Установление максимального разрешение экрана
        Screen.SetResolution(res[res.Length-1].width,res[res.Length-1].height,Screen.fullScreen);
        }
    }
    //Графика
    public void SetQuality()
    {
        QualitySettings.SetQualityLevel(dropDownQuality.value);
        PlayerPrefs.SetInt("Quality",dropDownQuality.value);
    }
    //Разрешение
    public void SetRes()
    {
        Screen.SetResolution(res[dropDownResolution.value].width,res[dropDownResolution.value].height,Screen.fullScreen);
        PlayerPrefs.SetInt("Resolution",dropDownResolution.value);
    }
    public void ScreenMode()
    {
        Screen.fullScreen=!toggle.isOn;
        if(Screen.fullScreen)
        {
            PlayerPrefs.SetInt("FullScreen",1);
        }
        else
        {
            PlayerPrefs.SetInt("FullScreen",0);
        }
    }
    //Выход из игры
    public void Exit()
    {
        Application.Quit();
    }
}
