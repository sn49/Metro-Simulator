using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger: MonoBehaviour
{
    //목적지
    public int destline;
    public int destorder;

    //현재위치
    public int curline;
    public int curorder;

    //환승역
    public int transorder;

    private void Start()
    {
        
    }

    public void SetUp()
    {
        

        
    

        while (curline == destline && curorder == destorder)
        {
            curline = Random.Range(0, DataList.dataList.lines.Count);
            curorder = Random.Range(0, DataList.dataList.lines[curline].stationList.Count);
            destline = Random.Range(0, DataList.dataList.lines.Count);
            destorder = Random.Range(0, DataList.dataList.lines[destline].stationList.Count);
        }

        transform.position = DataList.dataList.lines[curline].stationList[curorder].transform.position;

        Debug.Log($"{curline} {curorder} -> {destline} {destorder}");



    }




}
