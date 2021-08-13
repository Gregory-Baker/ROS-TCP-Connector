using System;
using RosMessageTypes.Geometry;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using UnityEngine;

namespace Unity.Robotics.MessageVisualizers
{
    public class DefaultVisualizerWrenchStamped : StampedDrawingVisualFactory<WrenchStampedMsg>
    {
        public float thickness = 0.01f;
        public float lengthScale = 1.0f;
        public float sphereRadius = 1.0f;
        public GameObject origin;
        [SerializeField]
        Color m_Color;

        public override void Draw(BasicDrawing drawing, WrenchStampedMsg message, MessageMetadata meta)
        {
<<<<<<< HEAD
            drawing.SetTFTrackingType(m_TFTrackingType, message.header);
            message.wrench.Draw<FLU>(drawing, SelectColor(m_Color, meta), origin.transform.position, lengthScale, sphereRadius, thickness);
=======
            DefaultVisualizerWrench.Draw<FLU>(message.wrench, drawing, SelectColor(m_Color, meta), origin.transform.position, lengthScale, sphereRadius, thickness);
>>>>>>> 8496510bf91e687cdf8b99e236016bd457286055
        }

        public override Action CreateGUI(WrenchStampedMsg message, MessageMetadata meta) => () =>
        {
            message.header.GUI();
            message.wrench.GUI();
        };
    }
}
