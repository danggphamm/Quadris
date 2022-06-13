using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerData 
{

    private int _level1HighScore;
    private int _level2HighScore;
    private int _level3HighScore;

    private int _level4HighScore;
    private int _level5HighScore;
    private int _level6HighScore;

    private int _level7HighScore;
    private int _level8HighScore;
    private int _level9HighScore;

    private int _extra1HighScore;
    private int _extra2HighScore;
    private int _extra3HighScore;

    private int _endlessHighScore;

    private int _currentLevel;

    public PlayerData(int l1HighScore, int l2HighScore, int l3HighScore,
                      int l4HighScore, int l5HighScore, int l6HighScore,
                      int l7HighScore, int l8HighScore, int l9HighScore,
                      int extra1HighScore, int extra2HighScore, int extra3HighScore,
                      int endlessHighScore, int currentL)
    {
        _level1HighScore = l1HighScore;
        _level2HighScore = l2HighScore;
        _level3HighScore = l3HighScore;

        _level4HighScore = l4HighScore;
        _level5HighScore = l5HighScore;
        _level6HighScore = l6HighScore;

        _level7HighScore = l7HighScore;
        _level8HighScore = l8HighScore;
        _level9HighScore = l9HighScore;

        _extra1HighScore = extra1HighScore;
        _extra2HighScore = extra2HighScore;
        _extra3HighScore = extra3HighScore;

        _endlessHighScore = endlessHighScore;

        _currentLevel = currentL;
    }

    public int level1HighScore
    {
        get { return _level1HighScore; }
        set { _level1HighScore = value; }
    }

    public int level2HighScore
    {
        get { return _level2HighScore; }
        set { _level2HighScore = value; }
    }

    public int level3HighScore
    {
        get { return _level3HighScore; }
        set { _level3HighScore = value; }
    }

    public int level4HighScore
    {
        get { return _level4HighScore; }
        set { _level4HighScore = value; }
    }

    public int level5HighScore
    {
        get { return _level5HighScore; }
        set { _level5HighScore = value; }
    }

    public int level6HighScore
    {
        get { return _level6HighScore; }
        set { _level6HighScore = value; }
    }

    public int level7HighScore
    {
        get { return _level7HighScore; }
        set { _level7HighScore = value; }
    }

    public int level8HighScore
    {
        get { return _level8HighScore; }
        set { _level8HighScore = value; }
    }

    public int level9HighScore
    {
        get { return _level9HighScore; }
        set { _level9HighScore = value; }
    }

    public int extra1HighScore
    {
        get { return _extra1HighScore; }
        set { _extra1HighScore = value; }
    }

    public int extra2HighScore
    {
        get { return _extra2HighScore; }
        set { _extra2HighScore = value; }
    }

    public int extra3HighScore
    {
        get { return _extra3HighScore; }
        set { _extra3HighScore = value; }
    }

    public int endlessHighScore
    {
        get { return _endlessHighScore; }
        set { _endlessHighScore = value; }
    }

    public int currentLevel
    {
        get { return _currentLevel; }
        set { _currentLevel = value; }
    }
}
