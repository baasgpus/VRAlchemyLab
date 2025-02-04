using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEditor.VFX.Block
{
    [VFXInfo(category = "GPUEvent", experimental = true)]
    class GPUEventOnDie : VFXBlock
    {
        public override string name { get { return "Trigger Event On Die"; } }
        public override VFXContextType compatibleContexts { get { return VFXContextType.Update; } }
        public override VFXDataType compatibleData { get { return VFXDataType.Particle; } }

        public override IEnumerable<VFXAttributeInfo> attributes
        {
            get
            {
                yield return new VFXAttributeInfo(VFXAttribute.Lifetime, VFXAttributeMode.Read);
                yield return new VFXAttributeInfo(VFXAttribute.Age, VFXAttributeMode.Read);
                yield return new VFXAttributeInfo(VFXAttribute.Alive, VFXAttributeMode.Read);
                yield return new VFXAttributeInfo(VFXAttribute.EventCount, VFXAttributeMode.Write);
            }
        }
        public override IEnumerable<VFXNamedExpression> parameters
        {
            get
            {
                foreach (var param in base.parameters)
                    yield return param;
                yield return new VFXNamedExpression(VFXBuiltInExpression.DeltaTime, "deltaTime");
            }
        }


        public class InputProperties
        {
            public uint count = 1u;
        }

        public class OutputProperties
        {
            public GPUEvent evt = new GPUEvent();
        }

        public override string source
        {
            get
            {
                return "eventCount = (age + deltaTime > lifetime || !alive) ? count : 0;";
            }
        }
    }
}
