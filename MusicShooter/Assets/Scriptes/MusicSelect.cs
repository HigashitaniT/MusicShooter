using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSelect : MonoBehaviour {

    public GameObject[] musics;
    private List<GameObject> musicNodeList = new List<GameObject>();

    public float scrollLimit = 10; //スクロールが消える位置
    public int preInstantiate = 3; //生成数
    private float nodeYSize; //ノードの高さ
    private RectTransform[] nodeRect;
    //private RectTransform rec; //

    void Start()
    {
        nodeYSize = musics[0].transform.localScale.y;
        preInstantiate = musics.Length;

        for (int i = 0; i < preInstantiate; i++ )
        {
            GameObject clone = (GameObject)Instantiate(musics[i], new Vector3(0,0,0), Quaternion.identity);
            clone.transform.SetParent(this.transform,false);
            musicNodeList.Add(clone);
            PosLoad(clone,i);
            Debug.Log(i);
        }
    }

	// Update is called once per frame
    void Update()
    {
        //int viewNode = (int);
        
        Debug.Log(musicNodeList[1].transform.position);
        //if (rec. > )
        //{

        //}
    }

    void UpdateUI()
    {

    }

    void PosLoad(GameObject clone,int i)
    {
        Debug.Log("in");

        RectTransform cloneRect = clone.GetComponent<RectTransform>();
        Vector2 cloneDelta = cloneRect.sizeDelta;
        float y = 0;

        if (i == 1) return;
        else if (i == 0)
        {
            y = ((clone.transform.position.y + (1 + cloneDelta.y)) - 1) * 3;
        }
        else if (i == 2)
        {
            y = ((clone.transform.position.y + (1 + cloneDelta.y)) - 1) * -1;
        }
        clone.transform.position = new Vector3(clone.transform.position.x, y, 0);
    }

}
