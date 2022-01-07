using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    [SerializeField] private GameObject m_ListPrefab;
    [SerializeField] private Transform m_List_Spawn;
    private GameObject m_List;

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
                Destroy(m_List);
                m_List = Instantiate(m_ListPrefab, m_List_Spawn.position, Quaternion.identity);
            }

        }
    }
}