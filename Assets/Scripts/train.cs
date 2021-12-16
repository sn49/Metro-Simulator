using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    public int people;
    public int maxpeople;
    public bool isMove;
    public bool isPlus;
    public int line;
    public int order;



    void Start()
    {
        SetUp();
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, DataList.dataList.lines[line - 1].stationList[order].transform.position, DataList.dataList.lines[line - 1].speed * Time.deltaTime);

        print(transform.position - DataList.dataList.lines[line - 1].stationList[order].transform.position);

        if (transform.position == DataList.dataList.lines[line - 1].stationList[order].transform.position)
        {
            if (order+1==DataList.dataList.lines[line-1].stationList.Count||(order==0&&!isPlus))
            {
                isPlus = !isPlus;
            }

            if (isPlus)
            {
                order++;

            }
            else
            {
                order--;
            }
        }
    }
    

    public void SetUp()
    {
        line = 1;
        order = 0;
        isPlus = true;
        transform.position = DataList.dataList.lines[line - 1].stationList[order].transform.position;


    }
}
