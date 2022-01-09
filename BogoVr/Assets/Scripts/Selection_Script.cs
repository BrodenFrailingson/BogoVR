using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using WidgetScript;

public class Selection_Script : MonoBehaviour
{
    [SerializeField] private GameObject m_Parent, m_Text;
    private int val;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "List_Indice") 
        {
            m_Text.GetComponent<TextMeshPro>().SetText(other.GetComponent<TextMeshPro>().text);
            val = int.Parse(other.name);
            Debug.Log(val);
        }
    }

    public void SetVal1() 
    {
        switch (m_Parent.tag)
        {
            case "Swap":
                m_Parent.GetComponent<Swap>().SetVal1(val);
                break;
            case ">":
                m_Parent.GetComponent<Greater>().SetVal1(val);
                break;
        }
    }

    public void SetVal2()
    {
        switch (m_Parent.tag)
        {
            case "Swap":
                m_Parent.GetComponent<Swap>().SetVal2(val);
                break;
            case ">":
                m_Parent.GetComponent<Greater>().SetVal2(val);
                break;
        }
    }



    public void Goto(Transform transform) 
    {
        Debug.Log("Here");
        Vector3 newpos = transform.position;
        Quaternion newrot = transform.rotation;
        gameObject.transform.position = newpos;
        gameObject.transform.rotation = newrot;

        
    }
}
