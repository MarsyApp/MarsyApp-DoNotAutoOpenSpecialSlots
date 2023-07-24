using System.Collections.Generic;
using System.Reflection;
using Aki.Reflection.Patching;
using EFT;
using EFT.InventoryLogic;

namespace DoNotAutoOpenSpecialSlots
{
    class Patcher
    {
        public static void PatchAll()
        {
            new PatchManager().RunPatches();
        }
        
        public static void UnpatchAll()
        {
            new PatchManager().RunUnpatches();
        }
    }

    public class PatchManager
    {
        public PatchManager()
        {
            this._patches = new List<ModulePatch>
            {
                new ItemViewPatches.ApplyDamageInfoPath(),
            };
        }

        public void RunPatches()
        {
            foreach (ModulePatch patch in this._patches)
            {
                patch.Enable();
            }
        }
        
        public void RunUnpatches()
        {
            foreach (ModulePatch patch in this._patches)
            {
                patch.Disable();
            }
        }

        private readonly List<ModulePatch> _patches;
    }

    public static class ItemViewPatches
    {
        public class ApplyDamageInfoPath : ModulePatch
        {
            protected override MethodBase GetTargetMethod()
            {
                return typeof(Player).GetMethod("ApplyDamageInfo", BindingFlags.Instance | BindingFlags.Public);
            }

            [PatchPrefix]
            private static void PatchPrefix(ref DamageInfo damageInfo, EBodyPart bodyPartType, float absorbed, EHeadSegment? headSegment = null)
            {
                if (damageInfo.DamageType == EDamageType.Landmine)
                {
                    int health = DoNotAutoOpenSpecialSlots.dictBodyParts[bodyPartType];

                    if (damageInfo.Damage > health)
                    {
                        float random = UnityEngine.Random.Range(0, 0.8f);
                        damageInfo.Damage = health * random;
                    }
                }
            }
        }
    }
}
