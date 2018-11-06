using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    static ConfigurationData configurationData;
    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force for the ball to move
    /// </summary>
    public static float BallImpulseForce
    {
        get { return configurationData.BallImpulseForce; }
    }

    public static float BallLifetime
    {
        get { return configurationData.BallLifetime; }
    }

    public static float BallStartDuration
    {
        get { return configurationData.BallStartDuration; }
    }

    public static int MinBallSpawnDuration
    {
        get { return configurationData.MinBallSpawnDuration; }
    }

    public static int MaxBallSpawnDuration
    {
        get { return configurationData.MaxBallSpawnDuration; }
    }

    public static int MaxBlockNumber
    {
        get { return configurationData.MaxBlockNumber; }
    }

   

     public static int StdBlockPoints
    {
        get { return configurationData.StdBlockPoints; }
    }

    public static int BonusBlockPoints
    {
        get { return configurationData.BonusBlockPoints; }
    }

    public static int FreezeBlockPoints
    {
        get { return configurationData.FreezeBlockPoints; }
    }

    public static int SpeedBlockPoints
    {
        get { return configurationData.SpeedBlockPoints; }
    }

    public static int StdBlockChance
    {
        get { return configurationData.StdBlockChance; }
    }

    public static int BonusBlockChance
    {
        get { return configurationData.BonusBlockChance; }
    }

    public static int FreezeBlockChance
    {
        get { return configurationData.FreezeBlockChance; }
    }

    public static int SpeedBlockChance
    {
        get { return configurationData.SpeedBlockChance; }
    }

    public static float FreezeDuration
    {
        get { return configurationData.FreezeDuration; }
    }

    public static float SpeedDuration
    {
        get { return configurationData.SpeedDuration; }
    }
    #endregion



    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }
}
