using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sudoku : MonoBehaviour
{
    MakingMoney money;
    WinPanel winnerPanel;
    TempIndicator indicator;

    public GameObject GamePanel;
    public GameObject SudokuField;
    public GameObject FieldPrefab;
    public GameObject ControllPanel;
    public GameObject ControllPrefab;
    public Button info;
    public Button finish;
    private Dictionary<Tuple<int,int>,FieldPrefabObj> _fieldPrefabObj = 
            new Dictionary<Tuple<int,int>,FieldPrefabObj>();
    private bool IsInfoButtonActive = false;
    private FieldPrefabObj _currCell;
    private SudokuObj _gameObj;
    private SudokuObj _finalObj;

    public void StartGame()
    {
        money=GameObject.Find("Games").GetComponent<MakingMoney>();
        winnerPanel=GameObject.Find("WinPanel").GetComponent<WinPanel>();
        indicator=GameObject.FindGameObjectWithTag("TempIndicator").GetComponent<TempIndicator>();
        CreateField();
        CreateControllField();
        CreateSudokuObj();
    }
    public void OnClick_Finish()
    {
        int count=0;
        for (int row = 0; row < 9; row++)
        {
            for (int column = 0; column < 9; column++)
            {
                FieldPrefabObj fieldObj=
                _fieldPrefabObj[new Tuple<int,int>(row,column)];
                if(fieldObj.IsChangeable)
                {
                    if(_finalObj.Values[row,column]==fieldObj.Number)
                    {
                        fieldObj.ChangeColorToGreen();
                        count++;
                    }
                    else
                    {
                        fieldObj.ChangeColorToRed();
                    }
                }
            }
        }
        if(count==Buttons.cells)
        {
            GamePanel.SetActive(false);
            winnerPanel.SetText("Поздравляю! вы заработали "+Buttons.coins+" монет. Питомец получает 50 очков радости.");
            money.SetMoney(Buttons.coins);
            indicator.setChangedHappiness(50);
        }
    }
    private void CreateSudokuObj()
    {
        SudokuGeneration.CreateSudokuObj(out SudokuObj finalObj, out SudokuObj gameObj);
        _gameObj=gameObj;
        _finalObj=finalObj;
        for (int row = 0; row < 9; row++)
        {
            for (int column = 0; column < 9; column++)
            {
                var currValue=_gameObj.Values[row,column];
                if(currValue!=0)
                {
                    FieldPrefabObj fieldObj=_fieldPrefabObj[new Tuple<int,int>(row,column)];
                    fieldObj.SetNumber(currValue);
                    fieldObj.IsChangeable=false;
                }
            }
        }
    }
    private void CreateField()
    {
        for(int row=0; row<9;row++)
        {
            for(int column=0; column<9;column++)
            {
                GameObject instance=GameObject.Instantiate(FieldPrefab,SudokuField.transform);
                FieldPrefabObj fieldPrefabObj =new FieldPrefabObj(instance, row, column);
                _fieldPrefabObj.Add(new Tuple<int,int>(row, column),fieldPrefabObj);
                instance.GetComponent<Button>().onClick.AddListener(()=>OnClick_FieldPrefab(fieldPrefabObj));
            }
        }
    }
    private void CreateControllField()
    {
        for(int i=1; i<10; i++)
        {
            GameObject instance=GameObject.Instantiate(ControllPrefab,ControllPanel.transform);
            instance.GetComponentInChildren<Text>().text=i.ToString();
            
            ControllPrefabObj controll = new ControllPrefabObj();
            controll.Number=i;
            
            instance.GetComponent<Button>().onClick.AddListener(()=>OnClick_ControllPrefab(controll));
        }
    }
    private void OnClick_FieldPrefab(FieldPrefabObj cell)
    {
        if(cell.IsChangeable)
        {
            if(_currCell!=null)
            {
                _currCell.UnSetHoverMode();
            }
            _currCell=cell;
            cell.SetHoverMode();
        }
    }
    private void OnClick_ControllPrefab(ControllPrefabObj controll)
    {
        if(_currCell!=null)
        {
            if(IsInfoButtonActive)
            {
                _currCell.SetSmallNumber(controll.Number);
            }
            else{
                _currCell.SetNumber(controll.Number);
            }
        }
    }
    public void OnClick_InfoButton()
    {
        if(IsInfoButtonActive)
        {
            IsInfoButtonActive = false;
            info.GetComponent<Image>().color=new Color(1f,1f,1f);
        }
        else
        {
            IsInfoButtonActive = true;
            info.GetComponent<Image>().color=new Color(0.46f,0.85f,0.91f);
        }
    }
}
