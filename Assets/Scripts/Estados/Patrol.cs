using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour, IHierarchyStatus {
    private enum actionSelection { Observar, Sentarse, Comer, Baño}
    [SerializeField] private actionSelection action;
    public float currentTask = 0f;
    public float TaskMax = 2f;

    public void StartMode() {
        action = GetRandomAction();
        //Debug.Log("Voy hacer... a ya sé..." + action.ToString());
    }

    public void UpdateMode() {
        //en esta linea hara la verificacion de aproximacion, cuando sea 0, iniciara la cuenta
        currentTask += Time.deltaTime;
        currentTask = Mathf.Clamp(currentTask, 0f, TaskMax);
        if(currentTask >= TaskMax) {
            currentTask = 0f;
            //Debug.Log("Ya lo hice");
            ExitMode();
        }

    }

    public void ExitMode() {
        //Debug.Log("Que puedo hacer ahora?");
        StartMode();
    }

    private actionSelection GetRandomAction() {
        // Obtiene todos los valores posibles del enum
        actionSelection[] values = (actionSelection[])System.Enum.GetValues(typeof(actionSelection));

        // Selecciona uno aleatorio
        int index = Random.Range(0, values.Length); // UnityEngine.Random
        return values[index];
    }

}
