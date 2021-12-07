using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateLineUI : MonoBehaviour
{
    public Slider[] colorSlider=new Slider[3];

    Image showColorImage;

    // Start is called before the first frame update
    void Start()
    {
        showColorImage = GameObject.Find("NewLineColor").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        showColorImage.color = new Color(colorSlider[0].value, colorSlider[1].value, colorSlider[2].value);
    }

    public void CreateLine()
    {
        int index= DataList.dataList.lines.Count + 1;
        Line newL=new GameObject($"Line{index} manager").AddComponent<Line>();
        newL.color = new Color(colorSlider[0].value, colorSlider[1].value, colorSlider[2].value);
        newL.speed = GameObject.Find("Slider_speed").GetComponent<Slider>().value;
        newL.name = $"{newL.index}È£¼±";
        DataList.dataList.lines.Add(newL);

        print("complete add line");
        Destroy(gameObject);
    }
}
