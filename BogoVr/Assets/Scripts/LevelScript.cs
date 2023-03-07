using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using WidgetScript;

public class LevelScript : MonoBehaviour
{
    [SerializeField] private GameObject m_ListPrefab;
    [SerializeField] private TextMeshPro m_monitor;
    [SerializeField] private Transform m_List_Spawn;
    private GameObject m_FirstCmd = null;
    private GameObject m_List;
    private readonly string m_cmd1 = "Please Sort this list\nin Ascending order!";
    private readonly string m_cmd2 = "Please Sort this list\nin decending order!";
    private readonly string m_error = "There's something wrong\nwith the list order";
    private readonly string m_success = "The List looks sorted\nSend it out Immediately";
    private bool Accending = true;
    private bool Issorted = false;


    public void Awake()
    {
        Vector3 rot = new Vector3(0.0f, 90.0f, 0.0f);
        m_List = Instantiate(m_ListPrefab, m_List_Spawn.position, Quaternion.Euler(rot));
        m_List.transform.localScale = new Vector3(0.15f, 0.05f, 0.15f);
        m_monitor.SetText(m_cmd1);
    }

    public void Compile() //Testing Case
    {
        if (!m_List)
            return;
        string Message;
        PerformOperation();
        Issorted = IsSorted(Accending);
        Message = (Accending) ? m_cmd1 + '\n' : m_cmd2 + '\n'; 
        Message += (Issorted) ? m_success : m_error;
        m_monitor.SetText(Message);
    }

    public void Commit() //Submission Case
    {
        if (!m_List)
            return;

        PerformOperation();
        Issorted = IsSorted(Accending);      //If list found Sort
        if (Issorted)
        {
            Destroy(m_List);
            Accending = !Accending;
            m_monitor.SetText(m_cmd1);
            int children = gameObject.transform.childCount;
            for (int i = 0; i < children; i++) 
            {
                Destroy(gameObject.transform.GetChild(i).gameObject);
            }
            m_List = Instantiate(m_ListPrefab, m_List_Spawn.position, Quaternion.identity);
            m_List.transform.localScale = new Vector3(0.15f, 0.05f, 0.15f);
            m_FirstCmd = null;
        }
        else if (!Issorted)
        {
            string Message;
            Message = (Accending) ? m_cmd1 + '\n' : m_cmd2 + '\n';
            Message += m_error;
            m_monitor.SetText(Message);
        }
    }

    private bool IsSorted(bool accending) 
    {
        List_Script script = m_List.GetComponent<List_Script>();
        int[] m_Vals = script.ListVals;
        switch (accending) 
        {
            case false:
                
                for (int i =0; i<5; i++) 
                {
                    if (m_Vals[i] < m_Vals[i + 1]) 
                    {
                        return false;
                    }
                }
                break;
            case true:
                for (int i = 0; i < 5; i++)
                {
                    if (m_Vals[i] > m_Vals[i + 1])
                    {
                        return false;
                    }
                }
                break;
        }
        return true;
    }

    private void PerformOperation() 
    {
        if (m_FirstCmd == null)
            return;

        switch (m_FirstCmd.tag)
        {
            case "Swap":
                m_FirstCmd.GetComponent<Swap>().Operation();
                break;
            case ">":
                m_FirstCmd.GetComponent<Greater>().Operation();
                break;
            case "<":
                m_FirstCmd.GetComponent<Less>().Operation();
                break;
            case "For":
                m_FirstCmd.GetComponent<Iterate_Fowards>().Operation();
                break;

        }
    }

    public void SetFirstCmd(GameObject cmd) 
    {
        if (m_FirstCmd != null)
            return;
        m_FirstCmd = cmd;
    }
}
