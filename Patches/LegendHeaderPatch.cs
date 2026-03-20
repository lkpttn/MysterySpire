using HarmonyLib;
using MegaCrit.Sts2.addons.mega_text;
using MegaCrit.Sts2.Core.Nodes.Screens.Map;

namespace MysterySpire;

[HarmonyPatch(typeof(NMapScreen), "_Ready")]
public static class LegendHeaderPatch
{
    static void Postfix(NMapScreen __instance)
    {
        var header = __instance.GetNodeOrNull<MegaLabel>("MapLegend/Header");
        header?.SetTextAutoSize("Cheatsheet");
    }
}
