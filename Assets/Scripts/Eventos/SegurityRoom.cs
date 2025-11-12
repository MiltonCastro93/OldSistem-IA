using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegurityRoom : MonoBehaviour
{
    private List<IABase> npcsInRoom = new List<IABase>();

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("NPC")) {
            IABase npc = other.GetComponent<IABase>();
            if (npc != null && npc.StatusAlert()) {
                if (!npcsInRoom.Contains(npc)) {
                    npcsInRoom.Add(npc);
                    Debug.Log("NPC entró a la sala segura y está llamando");
                }
            }
        }

        if (other.CompareTag("Player")) {
            foreach (var npc in npcsInRoom) {
                npc.GetComponent<Alert>().presentPlayer(); // Notificamos al NPC que el jugador entró
                Debug.Log("¡Jugador entró a la sala con el NPC!");
            }

            // También puedes limpiar la lista si todos deben reiniciar
            npcsInRoom.Clear();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("NPC")) {
            IABase npc = other.GetComponent<IABase>();
            npc.GetComponent<Alert>().startHelp(false);
            if (npc != null && npcsInRoom.Contains(npc)) {
                npcsInRoom.Remove(npc);
            }
        }
    }

}
