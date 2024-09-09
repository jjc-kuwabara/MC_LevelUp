using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpManager : MonoBehaviour
{
    public int m_exp;   // ���݂̌o���l�̒l.
    public int m_level; // ���݂̃��x���̒l.
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
        float expRate = (float)m_exp / expMax; // �o���l�����p�[�Z���g���邩�H.

        GameObject.Find("ExpBar").GetComponent<Image>().fillAmount = expRate;
    }

    private void RefreshLevelText(){
        GameObject.Find("LevelText").GetComponent<Text>().text = m_level.ToString();
    }    

    private int GetNeedExpForNextLevel(){
        // �ۑ�@.
        // ���̃��x���ɂȂ�܂łɕK�v�Ȍo���l�͂����H�H.
        // needExp�̒l���C�����悤�I.

        int needExp = 10;

        return needExp;
    }
}
