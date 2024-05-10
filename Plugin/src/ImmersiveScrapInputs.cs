using LethalCompanyInputUtils.Api;
using UnityEngine.InputSystem;

namespace ImmersiveScrap.Keybinds;
public class IngameKeybinds : LcInputActions {
    [InputAction("<Keyboard>/q", Name = "ThrowKeybind")]
    public InputAction ThrowKey { get; set; }
}