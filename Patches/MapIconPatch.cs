using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Helpers;
using MegaCrit.Sts2.Core.Nodes.Screens.Map;

namespace MysterySpire;

[HarmonyPatch(typeof(NNormalMapPoint), "UpdateIcon")]
public static class NormalMapIconPatch
{
    static void Postfix(NNormalMapPoint __instance)
    {
        var icon = __instance.GetNodeOrNull<TextureRect>("%Icon");
        var outline = __instance.GetNodeOrNull<TextureRect>("%Outline");

        if (icon != null)
        {
            string path = ImageHelper.GetImagePath("atlases/ui_atlas.sprites/map/icons/map_unknown.tres");
            icon.Texture = ResourceLoader.Load<Texture2D>(path, null, ResourceLoader.CacheMode.Reuse);
        }

        if (outline != null)
        {
            string path = ImageHelper.GetImagePath("atlases/compressed.sprites/map/map_unknown_outline.tres");
            outline.Texture = ResourceLoader.Load<Texture2D>(path, null, ResourceLoader.CacheMode.Reuse);
        }
    }
}
