using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Eyes : MonoBehaviour {
    [SerializeField] private GameObject LookAt;             //Punto para comparar si esta en el angulo
    [SerializeField] private GameObject pointEyes;          // Puntos de los Ojos
    private GameObject _player;                                    //GameObject del Player
    private Vector3 endRay;                                              //Posicion normalizada del Player
    private bool _inrange = false;                                    //Activar /DesActivar el cono
    public float AngleMax = 90f;                                   //Configuracion del cono

    private bool _presentPlayer = false, _hiddenPlayer = false;

    private IABase baseIA;

    private void Start() {
        baseIA = GetComponent<IABase>();
    }


    private void FixedUpdate() {
        if (_inrange) {
            float angleCurrent = Quaternion.Angle(LookAt.transform.rotation, pointEyes.transform.rotation);
            if (angleCurrent <= AngleMax) {
                RaycastHit hit;

                if (Physics.Raycast(pointEyes.transform.position, endRay, out hit)) {
                    if(hit.collider.CompareTag("Player")) {
                        _presentPlayer = true;
                        _hiddenPlayer = false;
                    } else if(_presentPlayer) {
                        _presentPlayer = false;
                        _hiddenPlayer = true;
                    }

                    baseIA.PosHidden(_player);
                    baseIA.PlayerDetected(_presentPlayer, _hiddenPlayer);
                    Debug.DrawLine(pointEyes.transform.position, hit.point);
                }
            }            
        }

    }


    private void OnTriggerStay(Collider other) {
        if(_player != null) {
            endRay = (_player.transform.position - pointEyes.transform.position).normalized;
            LookAt.transform.rotation = Quaternion.LookRotation(endRay, transform.up);
        }

    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            _player = other.GetComponent<PlayerMovement>().gameObject;
            _inrange = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            _player = null;
            _inrange = false;
        }
    }

}
