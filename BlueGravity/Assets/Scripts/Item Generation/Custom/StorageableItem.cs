using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GravityBlue
{
    public class StorageableItem : GameItem
    {
        #region PUBLIC METHODS
        public override void Interact()
        {
            PlayerStorage.Instance.StorageItem(this);
            base.Interact();
        }
        #endregion
    }
}