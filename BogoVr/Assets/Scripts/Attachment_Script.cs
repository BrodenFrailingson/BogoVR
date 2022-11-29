using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

public class Attachment_Script : MonoBehaviour
{
    [SerializeField] private Transform m_Copy_Pos;
    [SerializeField] private GameObject m_Queue;
    private LevelScript m_Levelscript = null;
    private bool candupe = true;
    private bool isActive = false;

    private void Start()
    {
        m_Levelscript = m_Queue.GetComponent<LevelScript>();    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Board")
            return;
        if (!candupe)
            return;
        Instantiate(gameObject, m_Copy_Pos.position, m_Copy_Pos.rotation);
        isActive = true;
        candupe = false;
    }

    public void setparent()
    {
        if (!isActive)
            return;
        m_Levelscript.SetFirstCmd(gameObject);
        this.transform.SetParent(m_Queue.transform, true);
        isActive = false;
    }
}
