using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveAndLoad : MonoBehaviour
{
    private static string DataPath = "/PlayerData.dat";
    public static PlayerData pData;

    public static void Save()
    {
        FileStream file = null;

        try
        {
            BinaryFormatter bf = new BinaryFormatter();

            file = File.Create(Application.persistentDataPath + DataPath);

            bf.Serialize(file, pData);
        }

        catch (Exception e)
        {
            if (e != null)
            {

            }
        }

        finally
        {
            if (file != null)
            {
                file.Close();
            }
        }
    }

    public static PlayerData Load()
    {
        FileStream file = null;

        try
        {
            BinaryFormatter bf = new BinaryFormatter();

            file = File.Open(Application.persistentDataPath + DataPath, FileMode.Open);

            pData = bf.Deserialize(file) as PlayerData;


        }

        catch (Exception e)
        {
            if (e != null)
            {

            }
        }

        finally
        {
            if (file != null)
            {
                file.Close();
            }
        }

        if (pData == null)
        {
            pData = new PlayerData(0, 0, 0,
                                   0, 0, 0, 
                                   0, 0, 0,
                                   0, 0, 0, 
                                   0, 1);
            Save();
        }

        return pData;
    }

    public static PlayerData Clear()
    {
        pData = new PlayerData(0, 0, 0, 
                               0, 0, 0, 
                               0, 0, 0,
                               0, 0, 0, 
                               0, 1);
        Save();

        return pData;
    }
}
