using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class List_Script : MonoBehaviour
{

    [SerializeField] private GameObject[] m_Indices;
    public int[] m_List_Values;
    // Start is called before the first frame update
    void Start()
    {
        RandomiseList();
    }

    private void RandomiseList() 
    {
        
        for (int i = 0; i < 6; i++) 
        {
            m_List_Values[i] = Random.Range(0, 100);   
        }
        NumerateList();
    }

    private void NumerateList() 
    {
        for (int i = 0; i < 6; i++)
        {
            m_Indices[i].GetComponent<TextMeshPro>().SetText(m_List_Values[i].ToString());
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Out_Tray") 
        {
            gameObject.tag = "List_Out";
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Out_Tray")
        {
            gameObject.tag = "List";
        }
    }

    public int GetValueAtIndice(int index) { return m_List_Values[index]; }

    public void Swap(int indice1, int indice2) 
    { 
        int temp = m_List_Values[indice1]; 
        m_List_Values[indice1] = m_List_Values[indice2];
        m_List_Values[indice2] = temp;
        NumerateList();
    }

    public bool Greater(int indice1, int indice2) 
    {
        Debug.Log("in test");
        if (m_List_Values[indice1] > m_List_Values[indice2])
            return true;
        else
            return false;
    }
}
