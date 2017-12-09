using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalValues {

    private static int hairType = 2;
    private static int dressType = 2;

    public static int likability = 0;
    public static int response = 0;
    public static int fame = 0;
    public static bool inRelationship = false;
    public static string name = "Deep";
 

    public static void SetHairType(int type)
    {
        hairType = type;
    }

    public static void SetDressType(int type)
    {
        dressType = type;
    }

    public static int GetHairType()
    {
        return hairType;
    }

    public static int GetDressType()
    {
        return dressType;
    }

    public static bool IsInRelationship()
    {
        return inRelationship;
    }

    public static void changeRelationshipStatus()
    {
        inRelationship = !inRelationship;
    }

    static void changeLikability(int value)
    {
        likability += value;
    }

}
