using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using WidgetScript;

public class Selection_Script : MonoBehaviour
{
    [SerializeField] private GameObject m_Parent, m_Text;
    private int val;
    private GameObject indexobj = null;
    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "List_Indice")
        {
            indexobj = null;
            m_Text.GetComponent<TextMeshPro>().SetText(other.GetComponent<TextMeshPro>().text);
            val = int.Parse(other.name);
        }
        else if (other.tag == "Index") 
        {
            indexobj = other.gameObject;
            m_Text.GetComponent<TextMeshPro>().SetText("index");
        }
    }

    public void SetVal1() 
    {
        switch (m_Parent.tag)
        {
            case "Swap":
                Swap swapscript = m_Parent.GetComponent<Swap>();
                if (indexobj == null)
                    swapscript.SetVal1(val);
                else
                {
                    swapscript.SetIndexObj1(indexobj);
                    swapscript.SetVal1(-2);
                }
                break;
            case ">":
                Greater Greatscript = m_Parent.GetComponent<Greater>();
                if (indexobj == null)
                    Greatscript.SetVal1(val);
                else
                {
                    Greatscript.SetIndexObj1(indexobj);
                    Greatscript.SetVal1(-2);
                }
                break;
        }
    }

    public void SetVal2()
    {
        switch (m_Parent.tag)
        {
            case "Swap":
                Swap swapscript = m_Parent.GetComponent<Swap>();
                if (indexobj == null)
                    swapscript.SetVal2(val);
                else
                {
                    swapscript.SetIndexObj2(indexobj);
                    swapscript.SetVal2(-2);
                }
                break;
            case ">":
                Greater Greatscript = m_Parent.GetComponent<Greater>();
                if (indexobj == null)
                    Greatscript.SetVal2(val);
                else
                {
                    Greatscript.SetIndexObj2(indexobj);
                    Greatscript.SetVal2(-2);
                }
                break;
        }
    }



    public void Goto(Transform transform) 
    {
        Vector3 newpos = transform.position;
        Quaternion newrot = transform.rotation;
        gameObject.transform.position = newpos;
        gameObject.transform.rotation = newrot;
    }
}
