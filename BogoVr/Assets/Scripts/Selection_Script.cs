using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Widget;

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
        Debug.Log(val);
        m_Parent.GetComponent<Swap>().SetVal1(val);
    }

    public void SetVal2()
    {
        m_Parent.GetComponent<Swap>().SetVal2(val);
    }

    public void Goto(Transform transform) 
    {
        Vector3 newpos = transform.position;
        Quaternion newrot = transform.rotation;
        gameObject.transform.position = newpos;
        gameObject.transform.rotation = newrot;

        
    }
}
