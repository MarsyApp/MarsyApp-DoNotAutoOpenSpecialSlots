using System.Collections.Generic;
using System.Reflection;
using Aki.Reflection.Patching;
using EFT.UI.DragAndDrop;

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
                new ItemViewPatches.SearchableItemViewPatch(),
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
        public class SearchableItemViewPatch : ModulePatch
        {
            protected override MethodBase GetTargetMethod()
            {
                return typeof(SearchableItemView).GetMethod("method_0",
                    BindingFlags.Instance | BindingFlags.NonPublic);
            }

            [PatchPrefix]
            private static bool PatchPrefix(SearchableItemView __instance)
            {
                return !__instance.name.StartsWith("SpecialSlot");
            }
        }
    }
}
