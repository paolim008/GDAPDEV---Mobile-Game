using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{

    private static PlayerActions instance;
    public static PlayerActions Instance
    {
        get { return instance; }
    }

    private bool Blocking = false;
    private bool Reloading = false;

    public void Block()
    {
        Blocking = true;
    }

    public void UnBlock()
    {
        Blocking = false;
    }

    public bool IsBlocking()
    {
        return Blocking;
    }

    public void Reload()
    {
        Reloading = true;
    }

    public void ReloadDone()
    {
        Reloading = false;
    }

    public bool IsReloading()
    {
        return Reloading;
    }
}
