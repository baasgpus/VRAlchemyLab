using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace UnityEditor.Rendering.HighDefinition
{
    [VolumeParameterDrawer(typeof(ScalableSettingLevelParameter))]
    sealed class ScalableSettingLevelParameterEditor : VolumeParameterDrawer
    {
        public override bool OnGUI(SerializedDataParameter parameter, GUIContent title)
        {
            var value = parameter.value;

            if (value.propertyType != SerializedPropertyType.Integer)
                return false;

            var o = parameter.GetObjectRef<ScalableSettingLevelParameter>();
            var (level, useOverride) = o.levelAndOverride;

            var rect = GUILayoutUtility.GetRect(0, float.Epsilon, 0, EditorGUIUtility.singleLineHeight);
            // Magic number for padding
            rect.x += 3;
            rect.y += 2;
            rect.width -= 3;
            var contentRect = EditorGUI.PrefixLabel(rect, title);

            o.levelAndOverride = SerializedScalableSettingValueUI.LevelFieldGUI(contentRect, title, level, useOverride);
            return true;
        }
    }
}
