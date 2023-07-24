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
        public static Dictionary<EBodyPart, int> dictBodyParts = new Dictionary<EBodyPart, int>()
        {
            {EBodyPart.Head, 20},
            {EBodyPart.Chest, 120},
            {EBodyPart.Stomach, 120},
            {EBodyPart.LeftArm, 65},
            {EBodyPart.RightArm, 65},
            {EBodyPart.LeftLeg, 60},
            {EBodyPart.RightLeg, 60},
        };

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
