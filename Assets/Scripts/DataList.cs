using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataList : MonoBehaviour
{
    public static DataList dataList = null;
    public List<Line> lines = new List<Line>();

    private void Awake()
    {


        if (dataList == null)
        {
            dataList = this;
        }
        else if (dataList != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    
}
