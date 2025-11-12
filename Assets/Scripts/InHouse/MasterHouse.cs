using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterHouse : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_List = new List<GameObject>();

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("NPC")) {
            AddNewEntity(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("NPC")) {
            RemoveNewEntity(other.gameObject);
        }
    }

    private void AddNewEntity(GameObject NPC) {
        if (!m_List.Contains(NPC)) {
            m_List.Add(NPC);
            CounterNPCs();
        }
    }

    private void RemoveNewEntity(GameObject NPC) {
        if (m_List.Contains(NPC)) {
            m_List.Remove(NPC);
            CounterNPCs();
        }    
    }

    private void CounterNPCs() {
        if (m_List.Count > 0) {
            foreach(GameObject npc in m_List) {
                npc.GetComponent<IABase>().CompanyFamily(m_List.Count == 1 ? true : false);
            }
        }
    }

}
