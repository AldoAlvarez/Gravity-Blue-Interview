using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GravityBlue.Data
{
    [CreateAssetMenu(fileName = "NewGameItem", menuName = "Gravity Blue/Game Item")]
    public class GameItemData : ScriptableObject
    {

        #region VARIABLES
        public uint ID = 100;
        public ushort MaxCapacity = 100;
        public Sprite Visual;
        public ushort Value = 1;
        public uint TradeItem =0;
        //public string Name;
        [TextArea]
        public string Description;
        public AudioClip sound;
        #endregion

    }
}