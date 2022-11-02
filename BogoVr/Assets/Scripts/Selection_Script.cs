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
                    swapscript.Val1 = val;
                else
                {
                    swapscript.SetIndexObj(0, indexobj.GetComponent<Index_Script>());
                    swapscript.Val1 = -2;
                }
                break;
            case ">":
                Greater Greatscript = m_Parent.GetComponent<Greater>();
                if (indexobj == null)
                    Greatscript.Val1 = val;
                else
                {
                    Greatscript.SetIndexObj(0, indexobj.GetComponent<Index_Script>());
                    Greatscript.Val1 = -2;
                }
                break;
            case "<":
                Less Lessscript = m_Parent.GetComponent<Less>();
                if (indexobj == null)
                    Lessscript.Val1 = val;
                else
                {
                    Lessscript.SetIndexObj(0, indexobj.GetComponent<Index_Script>());
                    Lessscript.Val1 = -2;
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
                    swapscript.Val2 = val;
                else
                {
                    swapscript.SetIndexObj(1, indexobj.GetComponent<Index_Script>());
                    swapscript.Val2 = -2;
                }
                break;
            case ">":
                Greater Greatscript = m_Parent.GetComponent<Greater>();
                if (indexobj == null)
                    Greatscript.Val2 = val;
                else
                {
                    Greatscript.SetIndexObj(1, indexobj.GetComponent<Index_Script>());
                    Greatscript.Val2 = -2;
                }
                break;
            case "<":
                Less Lessscript = m_Parent.GetComponent<Less>();
                if (indexobj == null)
                    Lessscript.Val2 = val;
                else
                {
                    Lessscript.SetIndexObj(1, indexobj.GetComponent<Index_Script>());
                    Lessscript.Val2 = -2;
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
