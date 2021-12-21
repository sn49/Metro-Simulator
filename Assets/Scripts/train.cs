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
        if (isMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, DataList.dataList.lines[line - 1].stationList[order].transform.position, DataList.dataList.lines[line - 1].speed * Time.deltaTime);

        }


        if (transform.position == DataList.dataList.lines[line - 1].stationList[order].transform.position)
        {
            StartCoroutine(Stop(3));
            ChangeDest();
            
        }
    }
    

    public void SetUp()
    {
        line = 1;
        order = 0;
        isPlus = true;
        transform.position = DataList.dataList.lines[line - 1].stationList[order].transform.position;
        isMove = true;



    }

    public IEnumerator Stop(float time)
    {
        isMove = false;
        yield return new WaitForSeconds(time);
        isMove = true;

    }

    private void ChangeDest()
    {
        int currnet = DataList.dataList.lines[line - 1].stationList.Count;
        if (isPlus)
        {
            order++;

        }
        else
        {
            order--;
        }


        if (DataList.dataList.lines[line - 1].repeat)
        {
            if (isPlus)
            {
                if (order == currnet)
                {
                    order = 0;
                }
            }
            else
            {
                if (order == -1)
                {
                    order = currnet - 1;
                }
            }
        }
        else
        {
            if (order == -1 && !isPlus)
            {
                isPlus = !isPlus;
                order = 0;

            }
            else if (order == currnet && isPlus)
            {
                isPlus = !isPlus;
                order = currnet - 1;
            }
        }
    }
}
