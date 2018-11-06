using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 1;
    static float ballImpulseForce = 10;
    static float ballLifetime = 10;
    static float ballStartDuration = 1;
    static int minBallSpawnDuration = 5;
    static int maxBallSpwanDuration = 10;
    static int maxBlockNumber = 30;
    static int stdBlockPoints = 1;
    static int bonusBlockPoints = 2;
    static int freezeBlockPoints = 5;
    static int speedBlockPoints = 5;
    static int stdBlockChance = 70;
    static int bonusBlockChance = 90;
    static int freezeBlockChance = 95;
    static int speedBlockChance = 100;
    static float freezeDuration = 2;
    static float speedDuration = 2;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    /// <summary>
    /// Gets the life time of the ball before it poofs
    /// </summary>
    public float BallLifetime
    {
        get { return ballLifetime; }
    }

    public float BallStartDuration
    {
        get { return ballStartDuration; }
    }

    public int MinBallSpawnDuration
    {
        get { return minBallSpawnDuration; }
    }

    public int MaxBallSpawnDuration
    {
        get { return maxBallSpwanDuration; }
    }

    public int MaxBlockNumber
    {
        get { return maxBlockNumber; }
    }

    public int StdBlockPoints
    {
        get { return stdBlockPoints; }
    }

    public int BonusBlockPoints
    {
        get { return bonusBlockPoints; }
    }

    public int FreezeBlockPoints
    {
        get { return freezeBlockPoints; }
    }

    public int SpeedBlockPoints
    {
        get { return speedBlockPoints; }
    }

    public int StdBlockChance
    {
        get { return stdBlockChance; }
    }

    public int BonusBlockChance
    {
        get { return bonusBlockChance; }
    }

    public int FreezeBlockChance
    {
        get { return freezeBlockChance; }
    }

    public int SpeedBlockChance
    {
        get { return speedBlockChance; }
    }

    public float FreezeDuration
    {
        get { return freezeDuration; }
    }

    public float SpeedDuration
    {
        get { return speedDuration; }
    }
    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        StreamReader input = null;
        try
        {
            input = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));
            string names = input.ReadLine();
            string values = input.ReadLine();
            SetConfigurationDataFields(values);
            // read and save configuration data from file
        }
        catch (Exception e)
        {

        }
        finally
        {
            if (input != null)
                input.Close();
        }
    }
    
    /// <summary>
    /// Used to store the values obtained from the config. file
    /// </summary>
    /// <param name="csvValues"></param>
    static void SetConfigurationDataFields(string csvValues)
    {
        string[] values = csvValues.Split(',');

        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce = float.Parse(values[1]);
        ballLifetime = float.Parse(values[2]);
        ballStartDuration = float.Parse(values[3]);
        minBallSpawnDuration = int.Parse(values[4]);
        maxBallSpwanDuration = int.Parse(values[5]);
        maxBlockNumber = int.Parse(values[6]);
        stdBlockPoints = int.Parse(values[7]);
        bonusBlockPoints = int.Parse(values[8]);
        freezeBlockPoints = int.Parse(values[9]);
        speedBlockPoints = int.Parse(values[10]);
        stdBlockChance = int.Parse(values[11]);
        bonusBlockChance = int.Parse(values[12]);
        freezeBlockChance = int.Parse(values[13]);
        speedBlockChance = int.Parse(values[14]);
        freezeDuration = float.Parse(values[15]);
        speedDuration = float.Parse(values[16]);
    }

    #endregion
}
