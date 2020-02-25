﻿using System.Linq;
using HarmonyLib;
using RimHUD.Data;
using RimHUD.Data.Configuration;
using RimWorld;
using UnityEngine;

namespace RimHUD.Patch
{
    [HarmonyPatch(typeof(InspectPaneUtility), "PaneWidthFor")]
    internal static class RimWorld_InspectPaneUtility_PaneWidthFor
    {
        private static bool Prefix(ref float __result, IInspectPane pane)
        {
            if (!State.AltInspectPane || !State.PawnSelected) { return true; }

            if (pane == null)
            {
                __result = 432f;
                return false;
            }

            var count = pane.CurTabs.Count(tab => tab?.IsVisible ?? false);
            __result = Theme.InspectPaneTabWidth.Value * (float) Mathf.Max(Theme.InspectPaneMinTabs.Value, count);
            return false;
        }
    }
}
