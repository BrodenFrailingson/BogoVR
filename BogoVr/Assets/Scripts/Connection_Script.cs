using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using WidgetScript;

public class Connection_Script : MonoBehaviour
{
    private bool _canlink = false;
    private GameObject m_Parent;
    private Widget m_ParentScript;

    public bool canlink{ set{ _canlink = value; } }

    public void Awake()
    {
        m_Parent = transform.root.gameObject;
        m_ParentScript = GetObjectScript(m_Parent);
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

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject == m_Parent)
            return;
        if (!_canlink)
            return;

        if (other.gameObject.tag == "Swap" || 
            other.gameObject.tag == ">" || 
            other.gameObject.tag == "<" || 
            other.gameObject.tag == "For")
        {
            Widget otherScript;
            otherScript = GetObjectScript(other.gameObject);
            if (gameObject.tag == "True")
                m_ParentScript.InLoopCmd = otherScript;
            if (gameObject.tag == "False")
                m_ParentScript.OutLoopCmd = otherScript;
            _canlink = false;
        }
    }

    public void Goto(Transform transform)
    {
        Vector3 newpos = transform.position;
        Quaternion newrot = transform.rotation;
        gameObject.transform.position = newpos;
        gameObject.transform.rotation = newrot;
        gameObject.transform.localScale = new Vector3(0.2f, 0.4f, 0.2f);

    }
}
