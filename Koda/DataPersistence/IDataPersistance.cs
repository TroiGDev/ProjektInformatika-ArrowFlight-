using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistance
{
    void LoadData(GameData data);
    void SaveData(ref GameData data);
}

//IMPORTANT NOTE: script with high score int variable gets edited (score script)
 //line 6 - IDataPersistance
 //voids for save and load after //DataPersistance