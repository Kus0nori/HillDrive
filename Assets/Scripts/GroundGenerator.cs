using UnityEngine;
using UnityEngine.U2D;

[ExecuteInEditMode]
public class GroundGenerator : MonoBehaviour
{
    [SerializeField] private SpriteShapeController spriteShapeController;

    [SerializeField, Range(1f, 100f)] private int levelLength = 50;
    [SerializeField, Range(1f, 50f)] private float xMultiplier = 2f;
    [SerializeField, Range(1f, 50f)] private float yMultiplier = 2f;
    [SerializeField, Range(0f, 1f)] private float curveSmoothness = 0.5f;
    [SerializeField] private float noiseStep = 0.5f;
    [SerializeField] private float bottom = 10f;

    private Vector3 _lastPos;

    private void OnValidate()
    {
        spriteShapeController.spline.Clear();

        for (var i = 0; i < levelLength; i++)
        {
            _lastPos = transform.position +
                       new Vector3(i * xMultiplier, Mathf.PerlinNoise(0, i * noiseStep) * yMultiplier);
            spriteShapeController.spline.InsertPointAt(i, _lastPos);

            if (i == 0 || i == levelLength - 1) continue;
            spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
            spriteShapeController.spline.SetLeftTangent(i, Vector3.left * xMultiplier * curveSmoothness);
            spriteShapeController.spline.SetRightTangent(i, Vector3.right * xMultiplier * curveSmoothness);
        }

        var position = transform.position;
        spriteShapeController.spline.InsertPointAt(levelLength, new Vector3(_lastPos.x, position.y - bottom));
        spriteShapeController.spline.InsertPointAt(levelLength + 1, new Vector3(position.x, position.y - bottom));
    }
}
