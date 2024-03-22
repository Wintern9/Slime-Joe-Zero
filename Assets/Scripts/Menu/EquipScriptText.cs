using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipScriptText : Settings
{
    [SerializeField] private GameObject[] EuipeObj;

    private int EupNum;

    private List<int> _OPENSKINS;

    private void Start()
    {
         Settings.ScinNum = Settings.ScinNumEquipped;
        EupNum = Settings.ScinNum;
        EuipeObj[Settings.ScinNum].SetActive(true);
        _OPENSKINS = SkinOpensGet();
    }

    void Update()
    {
        if(EupNum != Settings.ScinNum && _OPENSKINS.Contains(Settings.ScinNum))
        {
            EuipeObj[EupNum].SetActive(false);
            EuipeObj[Settings.ScinNum].SetActive(true);
            EupNum = Settings.ScinNum;
            Settings.ScinNumEquipped = Settings.ScinNum;
        }
    }
}
