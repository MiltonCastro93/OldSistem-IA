using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Alert : MonoBehaviour, IHierarchyStatus, ITaskComplete
{
    private List<GameObject> zones = new List<GameObject>();
    private GameObject zoneProxima;
    private int currentZoneIndex = 0;

    [SerializeField] private float timeHelp = 0f;
    public float HelpMax = 4f;
    private bool StayforHelp = true;
    private bool Danger = false;

    private void Start() {
        zones.AddRange(GameObject.FindGameObjectsWithTag("Zones"));
    }

    public void StartMode() {
        if (zones.Count == 0) return;

        zoneProxima = GetNearestZone();
        currentZoneIndex = zones.IndexOf(zoneProxima);
    }

    public void UpdateMode() {
        if (zoneProxima == null) return;

        float distanceToZone = (zoneProxima.transform.position - transform.position).sqrMagnitude;

        // Si aún no está pidiendo ayuda y llegó a la zona, empieza
        if (!StayforHelp && distanceToZone <= 6f) {
            StayforHelp = true;
            //Debug.Log("Iniciando ayuda en zona: " + zoneProxima.name);
        }

        if (StayforHelp) {
            if (distanceToZone <= 6f) {
                //Debug.Log("Ya estoy seguro, voy a llamar...");
                timeHelp += Time.deltaTime;
                timeHelp = Mathf.Clamp(timeHelp, 0f, HelpMax);

                if (Danger) {//Resetear en algun lado este
                    //Debug.Log("Está conmigo!");

                    // Reset y pasar a la siguiente zona
                    StayforHelp = false;
                    timeHelp = 0f;

                    currentZoneIndex++;
                    if (currentZoneIndex >= zones.Count) {
                        currentZoneIndex = 0; // reiniciar si se pasó del final
                    }

                    zoneProxima = zones[currentZoneIndex];
                } else {
                    //Debug.Log("Estoy seguro solo");
                }

                if (timeHelp >= HelpMax) {
                    //Debug.Log("Ayuda");
                }
            }
        }
    }

    public void ExitMode() {
        Debug.Log("Pasando modo al nonlethal");
    }

    public void presentPlayer() {
        Danger = true;
    }

    public void startHelp(bool status) {
        Danger = status;
    }

    public bool TaskComplete() {
        return timeHelp >= HelpMax;
    }

    private GameObject GetNearestZone() {
        float minDistance = Mathf.Infinity;
        GameObject nearestZone = null;

        foreach (GameObject zone in zones) {
            float distance = Vector3.Distance(transform.position, zone.transform.position);

            if (distance < minDistance) {
                minDistance = distance;
                nearestZone = zone;
            }
        }
        return nearestZone;
    }

}
