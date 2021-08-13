using System;
using RosMessageTypes.Geometry;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using UnityEngine;

namespace Unity.Robotics.MessageVisualizers
{
    public class DefaultVisualizerTransformStamped : StampedDrawingVisualFactory<TransformStampedMsg>
    {
        [SerializeField]
        float m_Size = 0.1f;
        [SerializeField]
        [Tooltip("If ticked, draw the axis lines for Unity coordinates. Otherwise, draw the axis lines for ROS coordinates (FLU).")]
        bool m_DrawUnityAxes;
        [SerializeField]
        Color m_Color;
        [SerializeField]
        string m_Label;
        [SerializeField]
        TFTrackingType m_TFTrackingType;

        public override void Draw(BasicDrawing drawing, TransformStampedMsg message, MessageMetadata meta)
        {
            drawing.SetTFTrackingType(m_TFTrackingType, message.header);
<<<<<<< HEAD
            message.transform.Draw<FLU>(drawing, m_Size, m_DrawUnityAxes);
=======
            DefaultVisualizerTransform.Draw<FLU>(message.transform, drawing, m_Size, m_DrawUnityAxes);
>>>>>>> 8496510bf91e687cdf8b99e236016bd457286055
            drawing.DrawLabel(SelectLabel(m_Label, meta), message.transform.translation.From<FLU>(), SelectColor(m_Color, meta), m_Size);
        }

        public override Action CreateGUI(TransformStampedMsg message, MessageMetadata meta)
        {
            return () =>
            {
                message.header.GUI();
                message.transform.GUI();
            };
        }
    }
}
