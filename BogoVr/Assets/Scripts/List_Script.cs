using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class List_Script : MonoBehaviour
{

    private TextMeshPro[] Texts;
    private int[] m_List_Values;

    [SerializeField] private GameObject m_Indices;

    public int[] ListVals { get { return m_List_Values; } }


    public void Awake()
    {
        Texts = m_Indices.GetComponentsInChildren<TextMeshPro>();
        RandomiseList();
    }

    private void RandomiseList()
    {
        m_List_Values = new int[6];
        for (int i = 0; i < Texts.Length; i++)
        {
            m_List_Values[i] = Random.Range(0, 100);
        }
        NumerateList();
    }

    private void NumerateList()
    {
        for (int i = 0; i < Texts.Length; i++)
        {
            Texts[i].SetText(m_List_Values[i].ToString());
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Outside")
        {
            Instantiate(gameObject, new Vector3(0.0f,0.0f,0.0f), Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public int GetValueAtIndice(int index) => m_List_Values[index];

    public void Swap(int indice1, int indice2)
    {
        Debug.Log("Swap: " + m_List_Values[indice1] + " and " + m_List_Values[indice2]);
        if (indice1 != indice2)
        {
            int temp = m_List_Values[indice1];
            m_List_Values[indice1] = m_List_Values[indice2];
            m_List_Values[indice2] = temp;
            NumerateList();
        }
    }

    public bool Greater(int indice1, int indice2) => (indice1 < indice2 && m_List_Values[indice1] > m_List_Values[indice2]);

    public bool Less(int indice1, int indice2) 
    {
        Debug.Log("Comparing: " + m_List_Values[indice1] + " and " + m_List_Values[indice2] + 
            " result: " + (indice1 < indice2 && m_List_Values[indice1] < m_List_Values[indice2]));
        return (indice1 < indice2 && m_List_Values[indice1] < m_List_Values[indice2]); 
    }

    
}
