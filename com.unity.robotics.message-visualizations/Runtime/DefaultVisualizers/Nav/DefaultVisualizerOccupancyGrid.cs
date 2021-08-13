using System;
using RosMessageTypes.Nav;
using Unity.Robotics.MessageVisualizers;
using Unity.Robotics.ROSTCPConnector;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using UnityEngine;

public class DefaultVisualizerOccupancyGrid : TexturedDrawingVisualFactory<OccupancyGridMsg>
{
    public float mapVerticalOffset = 0f;
    int m_Height;
    int m_Width;

    public override void Draw(BasicDrawing drawing, OccupancyGridMsg message, MessageMetadata meta)
    {
<<<<<<< HEAD
        var state = ROSConnection.GetOrCreateInstance().GetTopic(m_Topic);

        if (state != null)
        {
            var visual = state.Visual as IDrawingTextureVisual;
            if (visual.mesh == null)
            {
                visual.mesh = new Mesh();
                visual.mesh.vertices = new[]
                    { Vector3.zero, new Vector3(0, 0, 1), new Vector3(1, 0, 1), new Vector3(1, 0, 0) };
                visual.mesh.uv = new[] { Vector2.zero, Vector2.up, Vector2.one, Vector2.right };
                visual.mesh.triangles = new[] { 0, 1, 2, 2, 3, 0 };
                visual.shaderMaterial = new Material(Shader.Find("Unlit/OccupancyGrid"));
            }

            visual.material = new Material(visual.shaderMaterial);
            visual.material.mainTexture = visual.texture2D;

            var origin = message.info.origin.position.From<FLU>();
            var rotation = message.info.origin.orientation.From<FLU>();
            rotation.eulerAngles += new Vector3(0, -90, 0); // TODO: Account for differing texture origin
            var scale = message.info.resolution;

            drawing.SetTFTrackingType(m_TFTrackingType, message.header);
            visual.drawingObject = drawing.DrawMesh(visual.mesh,
                origin - rotation * new Vector3(scale * 0.5f, -mapVerticalOffset, scale * 0.5f), rotation,
                new Vector3(m_Width * scale, 1, m_Height * scale), visual.material);
        }
=======
        Draw<FLU>(message, drawing);
    }

    static Mesh s_OccupancyGridMesh;
    static Material s_OccupancyGridMaterial;

    public static void Draw<C>(OccupancyGridMsg message, BasicDrawing drawing) where C : ICoordinateSpace, new()
    {
        Vector3 origin = message.info.origin.position.From<C>();
        Quaternion rotation = message.info.origin.orientation.From<C>();
        int width = (int)message.info.width;
        int height = (int)message.info.height;
        float scale = message.info.resolution;

        if (s_OccupancyGridMesh == null)
        {
            s_OccupancyGridMesh = new Mesh();
            s_OccupancyGridMesh.vertices = new Vector3[] { Vector3.zero, new Vector3(0, 0, 1), new Vector3(1, 0, 1), new Vector3(1, 0, 0) };
            s_OccupancyGridMesh.uv = new Vector2[] { Vector2.zero, Vector2.up, Vector2.one, Vector2.right };
            s_OccupancyGridMesh.triangles = new int[] { 0, 1, 2, 2, 3, 0, };
            s_OccupancyGridMaterial = new Material(Shader.Find("Unlit/OccupancyGrid"));
        }

        if (s_OccupancyGridMaterial == null)
            s_OccupancyGridMaterial = new Material(Shader.Find("Unlit/Color"));

        Texture2D gridTexture = new Texture2D(width, height, TextureFormat.R8, true);
        gridTexture.wrapMode = TextureWrapMode.Clamp;
        gridTexture.filterMode = FilterMode.Point;
        gridTexture.SetPixelData(message.data, 0);
        gridTexture.Apply();

        Material gridMaterial = new Material(s_OccupancyGridMaterial);
        gridMaterial.mainTexture = gridTexture;

        drawing.DrawMesh(s_OccupancyGridMesh, origin - rotation * new Vector3(scale * 0.5f, 0, scale * 0.5f), rotation, new Vector3(width * scale, 1, height * scale), gridMaterial);
>>>>>>> 8496510bf91e687cdf8b99e236016bd457286055
    }

    public override Action CreateGUI(OccupancyGridMsg message, MessageMetadata meta)
    {
        return () =>
        {
            message.header.GUI();
            message.info.GUI();
        };
    }

    public override Texture2D CreateTexture(OccupancyGridMsg message)
    {
        var rotation = message.info.origin.orientation.From<FLU>();
        rotation.eulerAngles += new Vector3(0, -90, 0); // TODO: Account for differing texture origin
        m_Width = (int)message.info.width;
        m_Height = (int)message.info.height;

        var tex = new Texture2D(m_Width, m_Height, TextureFormat.R8, true);
        tex.wrapMode = TextureWrapMode.Clamp;
        tex.filterMode = FilterMode.Point;
        tex.SetPixelData(message.data, 0);
        tex.Apply();

        return tex;
    }
}
