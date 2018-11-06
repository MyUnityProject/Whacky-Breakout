using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager{

    //Different types of Invokers
    static List<FreezeBlock> freezeInvokers = new List<FreezeBlock>();
    static List<SpeedBlock> speedInvokers = new List<SpeedBlock>();
    static List<Block> pointInvokers = new List<Block>();
    static List<Ball> ballInvokers = new List<Ball>();
    static List<Ball> spawnBallInvoker = new List<Ball>(); 

    //Different types of Listeners
    static List<UnityAction<float>> freezeListeners = new List<UnityAction<float>>();
    static List<UnityAction<float>> speedListeners = new List<UnityAction<float>>();
    static List<UnityAction<int>> pointListener = new List<UnityAction<int>>();
    static List<UnityAction<int>> ballListener = new List<UnityAction<int>>();
    static List<UnityAction> spawnBallListener = new List<UnityAction>();

    public static void AddFreezeInvoker(FreezeBlock script)
    {
        freezeInvokers.Add(script);
        
        foreach (UnityAction<float> listener in freezeListeners)
            script.AddFreezeEventListener(listener);

        
    }

    public static void AddFreezeListener(UnityAction<float> listener)
    {
        freezeListeners.Add(listener);
        foreach (FreezeBlock invoker in freezeInvokers)
            invoker.AddFreezeEventListener(listener);
    }

    public static void AddSpeedInvoker(SpeedBlock script)
    {
        speedInvokers.Add(script);

        foreach (UnityAction<float> listener in speedListeners)
            script.AddSpeedEventListener(listener);


    }

    public static void AddSpeedListener(UnityAction<float> listener)
    {
        speedListeners.Add(listener);
        foreach (SpeedBlock invoker in speedInvokers)
            invoker.AddSpeedEventListener(listener);
    }

    public static void AddPointInvoker(Block script)
    {
        pointInvokers.Add(script);

        foreach (UnityAction<int> listener in pointListener)
            script.AddPointEventListener(listener);
    }

    public static void AddPointListener(UnityAction<int> listener)
    {
        pointListener.Add(listener);
        foreach (Block invoker in pointInvokers)
            invoker.AddPointEventListener(listener);
    }

    public static void AddBallInvoker(Ball script)
    {
        ballInvokers.Add(script);

        foreach (UnityAction<int> listener in ballListener)
            script.AddBallEventListener(listener);
    }

    public static void AddBallListener(UnityAction<int> listener)
    {
        ballListener.Add(listener);
        foreach (Ball invoker in ballInvokers)
            invoker.AddBallEventListener(listener);
    }

    public static void AddSpawnBallInvoker(Ball script)
    {
        spawnBallInvoker.Add(script);
        foreach (UnityAction listener in spawnBallListener)
            script.AddSpawnBallEventListener(listener);
    }

    public static void AddSpawnBallListener(UnityAction listener)
    {
        spawnBallListener.Add(listener);
        foreach (Ball invoker in spawnBallInvoker)
            invoker.AddSpawnBallEventListener(listener);
    }
}
