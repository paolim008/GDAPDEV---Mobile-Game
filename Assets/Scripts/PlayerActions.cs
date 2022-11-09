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

    private bool Parrying = false;
    private bool Blocking = false;
    private bool Shooting = false;
    private bool Reloading = false;

    public void Parry()
    {
        Parrying = true;
    }

    public void ParryDone()
    {
        Parrying = false;
    }

    public bool IsParrying()
    {
        return Parrying;
    }
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

    public void Shoot()
    {
        Shooting = true;
    }

    public void ShootDone()
    {
        Shooting = false;
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
