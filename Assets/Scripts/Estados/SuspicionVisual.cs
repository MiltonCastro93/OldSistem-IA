using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SuspicionVisual : MonoBehaviour, IHierarchyStatus, IGetDate, ITaskComplete
{
    [SerializeField] private float currentTime = 0f;
    public float DetectionTime = 4f;
    private IABase _base;

    public void StartMode() {
        Debug.Log("QUIEN ES?");
    }

    public void UpdateMode() {
        if (_base.PlayerVisuality()) {
            currentTime += Time.deltaTime;
            currentTime = Mathf.Clamp(currentTime, 0f, DetectionTime);
            if (currentTime >= DetectionTime) {
                _base.InAlert(true);
                Debug.Log("Alertado");
            }
        }
    }

    public void ExitMode() {
        Debug.Log("Ire a ver");
        currentTime = 0f;
    }

    public void PassData(IABase Entity) {
        _base = Entity;
    }

    public bool TaskComplete() {
        return currentTime >= DetectionTime;
    }

}
