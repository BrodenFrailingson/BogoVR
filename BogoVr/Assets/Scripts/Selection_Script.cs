using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using WidgetScript;

public class Selection_Script : MonoBehaviour
{
    [SerializeField] private GameObject m_Parent, m_Text;
    private int val;
    private Index_Script indexobj = null;


    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "List_indice")
        {
            indexobj = null;
            m_Text.GetComponent<TextMeshPro>().SetText(other.GetComponent<TextMeshPro>().text);
            val = int.Parse(other.name);
        }
        else if (other.tag == "i")
        {
            indexobj = other.gameObject.GetComponent<Index_Script>();
            m_Text.GetComponent<TextMeshPro>().SetText(indexobj.Symbol);
        }
    }

    public void SetVal1() 
    {
        Widget parent = GetObjectScript(m_Parent);
        if (indexobj == null)
            parent.Val1 = val;
        else
        {
            parent.SetIndexObj(0, indexobj);
            parent.Val1 = -2;
        }
    }

    public void SetVal2()
    {
        Widget parent = GetObjectScript(m_Parent);
        if (indexobj == null)
            parent.Val2 = val;
        else
        {
            parent.SetIndexObj(1, indexobj);
            parent.Val2 = -2;
        }
    }

    public Widget GetObjectScript(GameObject _object)
    {
        Widget script = null;
        switch (_object.tag)
        {
            case "Swap":
                script = _object.GetComponent<Swap>();
                break;
            case ">":
                script = _object.GetComponent<Greater>();
                break;
            case "<":
                script = _object.GetComponent<Less>();
                break;
            case "For":
                script = _object.GetComponent<Iterate_Fowards>();
                break;
        }
        return script;
    }

    public void Goto(Transform transform) 
    {
        Vector3 newpos = transform.position;
        Quaternion newrot = transform.rotation;
        gameObject.transform.position = newpos;
        gameObject.transform.rotation = newrot;
        gameObject.transform.localScale = new Vector3(0.40f, 0.32f, 0.4f);
    }
}
