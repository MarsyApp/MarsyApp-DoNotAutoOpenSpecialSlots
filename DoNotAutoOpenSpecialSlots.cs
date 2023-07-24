using System;
using System.Collections.Generic;
using System.IO;
using BepInEx;
using EFT.InventoryLogic;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DoNotAutoOpenSpecialSlots
{
    [BepInPlugin("com.MarsyApp.DoNotAutoOpenSpecialSlots", "MarsyApp-DoNotAutoOpenSpecialSlots", "1.0.0")]
    public class DoNotAutoOpenSpecialSlots : BaseUnityPlugin
    {
        private void Awake()
        {
            Patcher.PatchAll();
            Logger.LogInfo($"Plugin DoNotAutoOpenSpecialSlotsMod is loaded!");
        }
        
        private void OnDestroy()
        {
            Patcher.UnpatchAll();
            Logger.LogInfo($"Plugin DoNotAutoOpenSpecialSlotsMod is unloaded!");
        }
    }
}
