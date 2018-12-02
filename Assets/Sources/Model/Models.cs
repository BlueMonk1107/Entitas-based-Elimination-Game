using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Models {

    public static Models Instance { get; private set; } = new Models();

    public DataModel DataModel { get; private set; }

    public void Init()
    {
        DataModel = LoadJsonService.Instance.LoadJson<DataModel>();
        Debug.Log(DataModel.Level.Count);
    }
}
