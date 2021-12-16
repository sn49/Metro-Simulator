using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line:MonoBehaviour
{
    public Color color;
    public string name;
    public int index;
    public float speed;
    public int people;
    public bool repeat;
    public List<Station> stationList=new List<Station>();
    public List<Train> trainList=new List<Train>();

}
