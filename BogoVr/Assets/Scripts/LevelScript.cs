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
    [SerializeField] private GameObject m_CmdQueue;
    private GameObject m_List;
    private readonly string m_cmd1 = "Please Sort this list\nin Ascending order!";
    private readonly string m_cmd2 = "Please Sort this list\nin decending order!";
    private readonly string m_error = "There's something wrong\nwith the list order";
    private readonly string m_success = "The List looks sorted\nSend it out Immediately";
    private bool Accending = true;
    private bool Issorted = false;


    public void Awake()
    {
        m_List = Instantiate(m_ListPrefab, m_List_Spawn.position, Quaternion.identity);
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
            int children = m_CmdQueue.transform.childCount;
            for (int i = 0; i < children; i++) 
            {
                Destroy(m_CmdQueue.transform.GetChild(i).gameObject);
            }
            m_List = Instantiate(m_ListPrefab, m_List_Spawn.position, Quaternion.identity);
        }
        else if (!Issorted)
        {
            string Message;
            Message = (Accending) ? m_cmd1 + '\n' : m_cmd2 + '\n';
            Message += m_error;
            m_monitor.SetText(Message);
        }
    }

    public void KeyboardPress() 
    {
        if (m_List)
            return;
        m_List = Instantiate(m_ListPrefab, m_List_Spawn.position, Quaternion.identity);
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
                    if (m_Vals[i] > m_Vals[i + 1]) 
                    {
                        return false;
                    }
                    return true;
                }
                break;
            case true:
                
                for (int i = 0; i < 5; i++)
                {
                    if (m_Vals[i] < m_Vals[i + 1])
                    {
                        return false;
                    }
                    return true;
                }
                break;
        }
        return true;
    }

    private void PerformOperation() 
    {
        if (m_CmdQueue.transform.childCount == 0)
            return;

        GameObject child = m_CmdQueue.transform.GetChild(0).gameObject;

        switch (child.tag)
        {
            case "Swap":
                child.GetComponent<Swap>().Operation();
                break;
            case ">":
                child.GetComponent<Greater>().Operation();
                break;
            case "<":
                child.GetComponent<Less>().Operation();
                break;
            case "For":
                child.GetComponent<Iterate_Fowards>().Operation();
                break;

        }
    }
}
