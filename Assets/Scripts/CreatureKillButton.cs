using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureKillButton : MonoBehaviour
{
    public int m_getExp = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(){
        GameObject.Find("LevelUpManager").GetComponent<LevelUpManager>().OnClickCreatureKill(m_getExp);
    }
}
