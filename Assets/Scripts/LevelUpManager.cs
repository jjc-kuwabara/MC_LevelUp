using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpManager : MonoBehaviour
{
    public int m_exp;
    public int m_level;
    // Start is called before the first frame update
    void Start()
    {
        RefreshExpBar();
        RefreshLevelText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickCreatureKill(int addExp){
        m_exp += addExp;

        int expMax = GetNeedExpForNextLevel();
        if(m_exp >= expMax){
            m_exp -= expMax;
            m_level ++;
            RefreshLevelText();
        }

        RefreshExpBar();
    }

    public void OnClickExpReset(){
        m_exp = 0;
        m_level = 0;

        RefreshExpBar();
        RefreshLevelText();
    }

    private void RefreshExpBar(){
        int expMax = GetNeedExpForNextLevel();
        float expRate = (float)m_exp / expMax;

        GameObject.Find("ExpBar").GetComponent<Image>().fillAmount = expRate;
    }

    private void RefreshLevelText(){
        GameObject.Find("LevelText").GetComponent<Text>().text = m_level.ToString();
    }    

    private int GetNeedExpForNextLevel(){
        return 10;
    }
}
