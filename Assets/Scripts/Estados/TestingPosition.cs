using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingPosition : MonoBehaviour, IHierarchyStatus, IPassVector, ITaskComplete
{
    [SerializeField] private float currentTest = 0f;
    public float TestMax = 2f;
    [SerializeField] private Vector3 _checkpoint;

    public void StartMode() {
        Debug.Log("Quien Habra Sido");
    }

    public void UpdateMode() {
        if (_checkpoint != Vector3.zero) {
            float distance = (_checkpoint - transform.position).sqrMagnitude;
            if (distance < 3f) {
                Debug.Log("Ya estoy en el lugar, voy a chequear...");
                currentTest += Time.deltaTime;
                currentTest = Mathf.Clamp(currentTest, 0f, TestMax);
                if (currentTest >= TestMax) {
                    Debug.Log("No hay nadie");
                }

            }

        }

    }

    public void NeedForVector(Vector3 player) {
        _checkpoint = player;
    }

    public void ExitMode() {
        Debug.Log(" no fue nada");
        currentTest = 0f;
        _checkpoint = Vector3.zero;
    }


    public bool TaskComplete() {
        return currentTest >= TestMax;
    }


}
