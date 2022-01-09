using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WidgetScript;

public class LevelScript : MonoBehaviour
{
    [SerializeField] private GameObject m_ListPrefab;
    [SerializeField] private Transform m_List_Spawn;
    private GameObject m_List, m_FirstCmd;


    private void Awake()
    {
        m_List = Instantiate(m_ListPrefab, m_List_Spawn.position, Quaternion.identity);
    }

    public void KeyboardPress() 
    {
        m_List = GameObject.FindGameObjectWithTag("List");
        if (m_List == null)
        {
            m_List = GameObject.FindGameObjectWithTag("List_Out");
            if (m_List == null)
            {
                m_List = Instantiate(m_ListPrefab, m_List_Spawn.position, Quaternion.identity);
            }
            else
            {
                PerformOperation();
                Destroy(m_List);
                m_List = Instantiate(m_ListPrefab, m_List_Spawn.position, Quaternion.identity);
            }

        }
        else
        {
            PerformOperation();
        }
    }

    private void PerformOperation() 
    {
        Debug.Log(m_FirstCmd);
        if (m_FirstCmd != null)
            switch (m_FirstCmd.tag)
            {
                case "Swap":
                    m_FirstCmd.GetComponent<Swap>().Operation();
                    break;
                case ">":
                    m_FirstCmd.GetComponent<Greater>().Operation();
                    break;
                case "<":

                    break;
                case "Iterate_Through":

                    break;

            }
    }


    public void SetFirstCmd(GameObject first) 
    {
        Debug.Log("Setting First Cmd");
        if (m_FirstCmd == null)
            m_FirstCmd = first;
    }
}
