using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    private static int[] identity;

    private static int team;

    public static int[] Identity
    {
        get 
        {
            return identity;
        }
        set 
        {
            identity = value;
        }
    }

    public static int Team
    {
        get 
        {
            return team;
        }
        set 
        {
            team = value;
        }
    }
}
