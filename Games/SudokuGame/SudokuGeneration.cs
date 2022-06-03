using System;
using System.Collections.Generic;
public class SudokuGeneration
{
    private static SudokuObj _finalSudokuObj;
    public static void CreateSudokuObj(out SudokuObj finalObj, out SudokuObj gameObj)
    {
        _finalSudokuObj=null;
        SudokuObj sudokuObj=new SudokuObj();
        CreateRandomGroups(sudokuObj);
        if(TryToSolve(sudokuObj))
        {
            sudokuObj=_finalSudokuObj;
        }
        else
        {
            throw new System.Exception("Something wrong!");
        }
        finalObj=sudokuObj;
        gameObj=RemoveSomeRandomNumbers(sudokuObj);
    }
    public static void CreateRandomGroups(SudokuObj sudokuObj)
    {
        List<int> values = new List<int>(){0,1,2};
        int index=UnityEngine.Random.Range(0,values.Count);
        InsertRandomGroup(sudokuObj,1+values[index]);
        values.RemoveAt(index);
        index=UnityEngine.Random.Range(0,values.Count);
        InsertRandomGroup(sudokuObj,4+values[index]);
        values.RemoveAt(index);
        index=UnityEngine.Random.Range(0,values.Count);
        InsertRandomGroup(sudokuObj,7+values[index]);
    }
    public static void InsertRandomGroup(SudokuObj sudokuObj, int group)
    {
        sudokuObj.GetGroupIndex(group,out int startRow, out int startColumn);
        List<int> values= new List<int>(){1,2,3,4,5,6,7,8,9};
        for (int row = startRow; row < startRow+3; row++)
        {
            for (int column = startColumn; column < startColumn+3; column++)
            {
                int index=UnityEngine.Random.Range(0,values.Count);
                sudokuObj.Values[row,column]=values[index];
                values.RemoveAt(index);
            }
        }
    }
    private static bool TryToSolve(SudokuObj sudokuObj, bool OnlyOne=false)
    {
        //найти пустые клетки
        if(HasEmptyFieldToFill(sudokuObj,out int row, out int column,OnlyOne))
        {
            List<int> possibleValues=GetPossibleValues(sudokuObj, row, column);
            foreach (var possibleValue in possibleValues)
            {
                SudokuObj nextSudokuObj=new SudokuObj();
                nextSudokuObj.Values=(int[,])sudokuObj.Values.Clone();
                nextSudokuObj.Values[row,column]=possibleValue;
                if(TryToSolve(nextSudokuObj,OnlyOne)) 
                {
                    return true;
                }
            }
        }
        //есть ли у sudokuObj пустое поле
        if(HasEmptyFields(sudokuObj))
        {
            return false;
        }
        _finalSudokuObj=sudokuObj;
        return true;
    }
    private static bool HasEmptyFieldToFill(SudokuObj sudokuObj, out int row, out int column, bool OnlyOne=false)
    {
        row=0;
        column=0;
        int amountOfPossibleValues=10;
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if(sudokuObj.Values[i,j]==0)
                {
                    int _currAmount=GetPossibleAmountOfValues(sudokuObj,i,j);
                    if(_currAmount!=0)
                    {
                        if(_currAmount<amountOfPossibleValues)
                        {
                            amountOfPossibleValues=_currAmount;
                            row=i;
                            column=j;
                        }
                    }
                }
            }
        }
        if(OnlyOne)
        {
            if(amountOfPossibleValues==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if(amountOfPossibleValues==10)
        {
            return false;
        }
        return true;
    }
    private static int GetPossibleAmountOfValues(SudokuObj sudokuObj, int row, int column)
    {
        int amount=0;
        for (int k = 1; k < 10; k++)
        {
            if(sudokuObj.IsPossibleNumberInPosition(k,row,column))
            {
                amount++;
            }
        }
        return amount;
    }
    private static List<int> GetPossibleValues(SudokuObj sudokuObj, int row, int column)
    {
        List<int> possibleValues = new List<int>();
        for (int value = 1; value < 10; value++)
        {
            if(sudokuObj.IsPossibleNumberInPosition(value, row,column))
            {
                possibleValues.Add(value);
            }
        }
        return possibleValues;
    }
    private static bool HasEmptyFields(SudokuObj sudokuObj)
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if(sudokuObj.Values[i,j]==0)
                {
                    return true;
                }
            }
        }
        return false;
    }
    private static SudokuObj RemoveSomeRandomNumbers(SudokuObj sudokuObj)
    {
        SudokuObj newSudokuObj=new SudokuObj();
        newSudokuObj.Values=(int[,])sudokuObj.Values.Clone();
        List<Tuple<int,int>> values = GetValues();
        int EndValueIndex=41;
        if(Buttons._btn==1){EndValueIndex=71;}
        if(Buttons._btn==2){EndValueIndex=61;}
        bool isFinish=false;
        while (!isFinish)
        {
            int index=UnityEngine.Random.Range(0, values.Count);
            var searchedIndex = values[index];

            SudokuObj nextSudokuObj=new SudokuObj();
            nextSudokuObj.Values=(int[,])newSudokuObj.Values.Clone();
            nextSudokuObj.Values[searchedIndex.Item1,searchedIndex.Item2]=0;
            if(TryToSolve(nextSudokuObj,true))
            {
                newSudokuObj=nextSudokuObj;
            }
            values.RemoveAt(index);
            if(values.Count<EndValueIndex)
            {
                isFinish=true;
            }
        }
        return newSudokuObj;
    }
    private static List<Tuple<int,int>> GetValues()
    {
        List<Tuple<int,int>> values = new List<Tuple<int,int>>();
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                values.Add(new Tuple<int,int>(i,j));
            }
        }
        return values;
    }
}
