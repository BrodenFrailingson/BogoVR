using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using WidgetScript;

public class Connection_Script : MonoBehaviour
{
    private bool canlink = false;
    [SerializeField] private GameObject m_Parent;
    public void OnTriggerEnter(Collider other)
    {

        GetOtherType(other.gameObject);
        canlink = false;
    }

    private void GetOtherType(GameObject other) 
    {
        if (canlink)
        {
            switch (other.tag)
            {
                case "Swap":
                    GetParentType(other);
                    break;
                case ">":
                    GetParentType(other);
                    break;
                case "<":
                    GetParentType(other);
                    break;
                case "For":
                    GetParentType(other);
                    break;
            }
        }
    }


    private void GetParentType(GameObject other) 
    {
        switch (m_Parent.tag)
        {
            case "Swap":
                m_Parent.GetComponent<Swap>().SetNextCmd(other);
                break;
            case ">":
                if (gameObject.tag == "True")
                {
                    Debug.Log(other);
                    m_Parent.GetComponent<Greater>().SetNextCmd(other);
                }
                else
                    m_Parent.GetComponent<Greater>().SetFalseCmd(other);
                break;
            case "<":
                if (gameObject.tag == "True")
                {
                    Debug.Log(other);
                    m_Parent.GetComponent<Less>().SetNextCmd(other);
                }
                else
                    m_Parent.GetComponent<Less>().SetFalseCmd(other);
                break;
            case "For":
                if (gameObject.tag == "True")
                {
                    Debug.Log(other);
                    m_Parent.GetComponent<Iterate_Fowards>().SetNextCmd(other);
                }
                else
                {
                    m_Parent.GetComponent<Iterate_Fowards>().SetFalseCmd(other);
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

    public void SetLink() { canlink = true; }
}
