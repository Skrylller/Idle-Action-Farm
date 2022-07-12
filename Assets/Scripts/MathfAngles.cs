using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MathAnglesU
{
    public static class MathfAngles
    {
        /// <summary>
        /// находит угол на котором находится point1 относительно point2
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static float FindAngle(Vector2 point1, Vector2 point2)
        {
            if (point1 == point2)
                return 0;

            float angle = -Mathf.Atan((point1.x - point2.x) / (point1.y - point2.y)) * Mathf.Rad2Deg;
            if ((point1.y - point2.y) <= 0)
                angle -= 180;

            return angle;
        }

        /// <summary>
        /// находит координаты точки на окружности с радиусом distance по углу angle
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static Vector2 FindDirectional(float angle, float distance)
        {
            float xDir = distance * Mathf.Sin(angle * -1 * Mathf.Deg2Rad);
            float zDir = distance * Mathf.Cos(angle * Mathf.Deg2Rad);

            return new Vector2(xDir, zDir);
        }
    }
}
