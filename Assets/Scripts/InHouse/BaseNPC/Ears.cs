using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ears : MonoBehaviour {
    private IABase baseIA;

    private void Start() {
        baseIA = GetComponent<IABase>();
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player")) {
            if(other.GetComponent<CharacterController>().velocity.sqrMagnitude >= 0.1f) {
                Debug.Log("Jugador Escuchado");
                //baseIA.SoundNotificate(other.transform.position);
                baseIA.Audicion(true, other.transform.position);
            } else {
                baseIA.Audicion(false, other.transform.position);
            }

        }

    }

}
