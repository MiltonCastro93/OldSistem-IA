
using System;

public interface IHierarchyStatus {

    public void StartMode(); //que hacer al momento de arrancar
    public void UpdateMode(); //Hacer esa tarea mientras estoy en este modo
    public void ExitMode(); //Salir de este modo
}
