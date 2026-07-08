using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Helpers;
using MegaCrit.Sts2.Core.Nodes.Screens.Map;

namespace MysterySpire;

[HarmonyPatch(typeof(NNormalMapPoint), "UpdateIcon")]
public static class NormalMapIconPatch
{
    // Prefix + skip original: avoids loading the real room icon just to
    // immediately overwrite it (which a Postfix would do on every call).
    static bool Prefix(NNormalMapPoint __instance)
    {
        var icon = __instance.GetNodeOrNull<TextureRect>("%Icon");
        if (icon != null)
        {
            string path = ImageHelper.GetImagePath("atlases/ui_atlas.sprites/map/icons/map_unknown.tres");
            icon.Texture = ResourceLoader.Load<Texture2D>(path, null, ResourceLoader.CacheMode.Reuse);
        }

        var outline = __instance.GetNodeOrNull<TextureRect>("%Outline");
        if (outline != null)
        {
            string path = ImageHelper.GetImagePath("atlases/compressed.sprites/map/map_unknown_outline.tres");
            outline.Texture = ResourceLoader.Load<Texture2D>(path, null, ResourceLoader.CacheMode.Reuse);
        }

        return false;
    }
}

// The quest marker overlay is toggled by a separate method (on _Ready and
// whenever a node's quest state changes), not by UpdateIcon, so it needs
// its own patch to stay hidden — otherwise it leaks "this room has a quest".
[HarmonyPatch(typeof(NNormalMapPoint), "RefreshMarkedIconVisibility")]
public static class QuestIconPatch
{
    static void Postfix(NNormalMapPoint __instance)
    {
        var questIcon = __instance.GetNodeOrNull<TextureRect>("%QuestIcon");
        if (questIcon != null)
        {
            questIcon.Visible = false;
        }
    }
}
