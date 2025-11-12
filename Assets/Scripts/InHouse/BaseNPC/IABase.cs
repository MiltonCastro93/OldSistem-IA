using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IABase : MonoBehaviour {
    private Vector3 _posPlayer, _presentPlayer;
    private List<IHierarchyStatus> status = new List<IHierarchyStatus>();
    private IHierarchyStatus currentStatus = null;
    [SerializeField] private bool _soundIntence = false, _visualIntence = false, hiddenPlayer = false, Alerted = false;
    private enum Genero {Hombre, Mujer};
    [SerializeField] private Genero GetGenero;
    [SerializeField] private bool _alone = true;

    private void Start() {
        status.Add(gameObject.AddComponent<Patrol>());                          //[0]
        status.Add(gameObject.AddComponent<Suspicion>());                   //[1]
        status.Add(gameObject.AddComponent<SuspicionVisual>());         //[2]
        status.Add(gameObject.AddComponent<TestingPosition>());            //[3]
        status.Add(gameObject.AddComponent<Alert>());                           //[4]

        ChangeStatus(status[0]);
        currentStatus.StartMode();
    }

    private void Update() {//hacer una manera para volver un estado anterior
        if (_soundIntence) {
            IPassVector vector = (IPassVector)status[1];
            vector.NeedForVector(_posPlayer);

            ITaskComplete task = (ITaskComplete)status[1];
            if (task.TaskComplete()) {
                OldStatus(status[1],0);
                _soundIntence = false;
                return;
            }

            Debug.Log("ESTADO 1");
            ChangeStatus(status[1]);
        }

        if (_visualIntence && !Alerted) {
            IGetDate pass = (IGetDate)status[2];
            pass.PassData(this);

            ITaskComplete task = (ITaskComplete)status[2];
            if (Alerted) {
                if (task.TaskComplete()) {
                    OldStatus(status[2], 4);
                    _visualIntence = false;
                    return;
                }
            }else if (hiddenPlayer) {
                if (task.TaskComplete()) {
                    OldStatus(status[2], 3);
                    _visualIntence = false;
                    return;
                }

            }

            Debug.Log("ESTADO 2");
            ChangeStatus(status[2]);
        }

        if (hiddenPlayer) {
            IPassVector vector = (IPassVector)status[3];
            vector.NeedForVector(_presentPlayer);

            ITaskComplete task = (ITaskComplete)status[3];
            if (task.TaskComplete()) {
                OldStatus(status[3], 0);
                hiddenPlayer = false;
                return;
            }

            Debug.Log("ESTADO 3");
            ChangeStatus(status[3]);
        }

        if (Alerted) {
            ITaskComplete Task = (ITaskComplete)status[4];
            /*
            if (Task.TaskComplete()) {//en desarrollo
                OldStatus(status[4], 5);
                Alerted = false;
            }*/

            Debug.Log("ESTADO 4");
            ChangeStatus(status[4]);
        }

        currentStatus.UpdateMode();
    }

    private void ChangeStatus(IHierarchyStatus newStatus) {
        currentStatus = newStatus;
        currentStatus.StartMode();
    }

    private void OldStatus(IHierarchyStatus oldStatus, int indexTarget) {
        oldStatus.ExitMode();
        currentStatus = status[indexTarget];
        currentStatus.StartMode();
    }

    //TESTEANDO OTRO METODOS
    public void Audicion(bool currentSound, Vector3 noisePoint) { // Oidos a IA BASE
        _soundIntence = currentSound;
        _posPlayer = noisePoint;
    }

    public void PlayerDetected(bool currentVisual, bool PlayerHidden) { // Ojos a IA BASE
        _visualIntence = currentVisual;
        hiddenPlayer = PlayerHidden;
    }

    public bool PlayerVisuality() { // IA BASE a SuspicionVisual.
        return _visualIntence;
    }

    public void InAlert(bool currentAlert) {        //SuspicionVisual a IA BASE
        Alerted = currentAlert;
    }

    public bool StatusAlert() {     //IA BASE a SEGURITYROOM
        return Alerted;
    }

    public void PosHidden(GameObject posPlayer) {   //Ojos a IA BASE
        _presentPlayer = posPlayer.transform.position;
    }

    public void CompanyFamily(bool alone) {
        _alone = alone;
    }

}
