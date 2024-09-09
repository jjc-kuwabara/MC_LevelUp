using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceManager : MonoBehaviour
{
    public float checkDistance;

    public Vector2 steveMoveVector;
    public Vector2 zombieMoveVector;

    GameObject steveObj;
    GameObject zombieObj;
    GameObject searchObj;

    // Start is called before the first frame update
    void Start()
    {
        steveObj = GameObject.Find("Steve");
        zombieObj = GameObject.Find("Zombie");
        searchObj = GameObject.Find("Search");
    }

    // Update is called once per frame
    void Update()
    {
        ObjMove(steveObj, steveMoveVector);
        ObjMove(zombieObj, zombieMoveVector);
        RefreshSearch();
    }

    void ObjMove(GameObject obj, Vector2 move)
    {
        RectTransform rectTransform = obj.transform as RectTransform;
        rectTransform.Translate( move * Time.deltaTime );

        if (rectTransform.anchoredPosition.x < -10.0f)
        {
            rectTransform.anchoredPosition = new Vector2(10.0f, rectTransform.anchoredPosition.y);
        }
        else if (rectTransform.anchoredPosition.x > 10.0f)
        {
            rectTransform.anchoredPosition = new Vector2(-10.0f, rectTransform.anchoredPosition.y);
        }
        else if (rectTransform.anchoredPosition.y < -10.0f)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, 10.0f);
        }
        else if (rectTransform.anchoredPosition.y > 10.0f)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -10.0f);
        }

        // 小数点以下第二位までは表示.
        float x = rectTransform.anchoredPosition.x;

        float y = rectTransform.anchoredPosition.y;


        obj.transform.Find("text").GetComponent<Text>().text = "(" + x.ToString("N1") + "," + y.ToString("N1") + ")";
    }

    void RefreshSearch()
    {
        RectTransform rectTransformSteve = steveObj.transform as RectTransform;
        RectTransform rectTransformZombie = zombieObj.transform as RectTransform;
        RectTransform rectTransformSearch = searchObj.transform as RectTransform;

        rectTransformSearch.anchoredPosition = rectTransformZombie.anchoredPosition;

        rectTransformSearch.sizeDelta = new Vector2(checkDistance * 2, checkDistance * 2);

        if (IsNear(rectTransformSteve.anchoredPosition, rectTransformZombie.anchoredPosition))
        {
            searchObj.GetComponent<Image>().color = new Color(0.5f, 0.0f, 0.0f, 0.3f);
        }
        else
        {
            searchObj.GetComponent<Image>().color = new Color(0.0f, 0.5f, 0.0f, 0.3f);
        }
    }

    bool IsNear(Vector2 stevePos, Vector2 zombiePos)
    {
        // 近づいているか？の判定.
        float steveX = stevePos.x;
        float steveY = stevePos.y;

        float zombieX = zombiePos.x;
        float zombieY = zombiePos.y;

        float distance = 999.0f;

        // 課題②
        // ２つのオブジェクトの間の距離はいくつ？？.
        // ２つのオブジェクトの座標を使って、distanceの値を修正しよう！.

        distance = 999.9f;





        bool isNear = distance < checkDistance;
        return isNear;
    }

}
