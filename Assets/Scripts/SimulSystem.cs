using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimulSystem : MonoBehaviour
{
    public GameObject station;
    Vector3 mouseposition;
    Vector3 startposition;
    Camera camera;
    int selLine;
    int mode;
    public GameObject createLineUI;

    public GameObject train;

    public Text noticeText;
    public GameObject NoticeImage;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        mode = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            mode = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            mode = 2;
        }


        if (mode == 1)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                //카메라 사이즈 -
                camera.orthographicSize -= 1;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                //카메라 사이즈 +
                camera.orthographicSize += 1;

            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                camera.transform.position = new Vector3(camera.transform.position.x,camera.transform.position.y+1,camera.transform.position.z);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y - 1, camera.transform.position.z);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                camera.transform.position = new Vector3(camera.transform.position.x-1, camera.transform.position.y, camera.transform.position.z);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                camera.transform.position = new Vector3(camera.transform.position.x+1, camera.transform.position.y, camera.transform.position.z);
            }

        }

        
        if (Input.GetMouseButtonDown(0))
        {
            

            startposition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            startposition = Camera.main.ScreenToWorldPoint(startposition);

            if (mode == 2)
            {
                if (DataList.dataList.lines.Count == 0)
                {
                    StartCoroutine(NoticeMessage("노선을 만들어주세요."));
                    return;
                }

                if (GameObject.FindGameObjectsWithTag("window").Length != 0)
                {
                    return;
                }
                mouseposition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
                mouseposition = camera.ScreenToWorldPoint(mouseposition);

                var fposition = new Vector3(mouseposition.x, mouseposition.y,0);

                Collider2D[] colls = Physics2D.OverlapCircleAll(fposition, 3);

                int count = 0;

                foreach (var i in colls)
                {
                    if (i.CompareTag("button"))
                    {
                        continue;
                    }
                    count++;
                }

                if (count == 0)
                {

                    GameObject temps = Instantiate(station, fposition, Quaternion.identity);
                    


                    if (DataList.dataList.lines.Count == 1)
                    {
                        Station st = temps.GetComponent<Station>();
                        st.lines.Add(DataList.dataList.lines[0].index);
                        temps.GetComponent<SpriteRenderer>().color = DataList.dataList.lines[0].color;
                        DataList.dataList.lines[0].stationList.Add(st);
                        

                        if (DataList.dataList.lines[0].stationList.Count > 1)
                        {
                            LineRenderer lineRenderer = DataList.dataList.lines[0].gameObject.GetComponent<LineRenderer>();

                            if (lineRenderer)
                            {

                            }
                            else
                            {
                                lineRenderer = DataList.dataList.lines[0].gameObject.AddComponent<LineRenderer>();
                            }
                            lineRenderer.positionCount = DataList.dataList.lines[0].stationList.Count;
                            lineRenderer.startWidth = 0.1f;
                            lineRenderer.endWidth = 0.1f;

                            for (int i=0; i< lineRenderer.positionCount; i++)
                            {
                                lineRenderer.SetPosition(i, DataList.dataList.lines[0].stationList[i].transform.position);
                            }

                            
                            
                            
                        }
                        

                        
                    }
                    else
                    {
                        
                    }
                }

                
            }
            
        }

    }


    public void OpenUI(int uinum)
    {
        if (uinum == 1)
        {
            if (DataList.dataList.lines.Count!=1)
            {
                GameObject ui = Instantiate(createLineUI);
                ui.transform.SetParent(GameObject.Find("Canvas").transform);
                ui.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            }
            else
            {
                StartCoroutine(NoticeMessage("현재 노선 1개만 지원합니다."));
            }
            
            
        }
    }

    public IEnumerator NoticeMessage(string message)
    {
        NoticeImage.SetActive(true);
        noticeText.text = message;
        yield return new WaitForSeconds(3);
        NoticeImage.SetActive(false);
    }

    public void MakeTrain()
    {
        GameObject tempTrain=Instantiate(train,transform.position,Quaternion.identity);
        tempTrain.GetComponent<Train>().SetUp();
        


    }

}
