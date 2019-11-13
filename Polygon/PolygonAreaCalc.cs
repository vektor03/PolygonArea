using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Polygon
{

    class PointF
    {
        public readonly float x;
        public readonly float y;

        public PointF(string str)
        {
            string[] words = str.Split(new char[] { ' ' });
            x = Convert.ToSingle(words[0]);
            y = Convert.ToSingle(words[1]);
        }
    }
    
    
    /// <summary>
    /// Рассчитывает площадь многоугольника, заданного последовательностью координат вершин
    /// </summary>
    class PolygonArea
    {
        public readonly float Area = 0;

        public PolygonArea(PointF[] dots)
        {
            //http://geomalgorithms.com/a01-_area.html#2D%20Polygons
            //Площадь параллелограмма равна модулю векторного произведения двух векторов в его основании.
            //Площадь треугольника соответственно равна половине от этой площади.
            //Еще векторное произведение несет в себе информацию об ориентации этого треугольника (точки по часовой стр или против).
            //Итоговый вектор перпендикулярен параллелограмму и может быть направлен в одну из двух сторон.
            //В итоге рассчитав векторное произведение мы получаем площадь и ориентацию. Назовем ее площадь*.
            //Вся идея алгортма в том что если многоугольник не имеет пересечений, то сложив по очереди площади всех треугольников  
            //образованных каждой стороной многоугольника и произвольной точкой (0,0), мы получим площадь многоугольника.
            //Однако из-за того что мы не знаем изначальной ориентации точек многоугольника, площадь м. оказаться отрицательной

            if (dots.Length < 3)
            {
                Area = 0;
            }
            else 
            {
                float S = 0;
                int n = dots.Length;

                for (int i = 0; i < n; i++)
                {
                    int j = (i + 1) % n;
                    S += (dots[i].x * dots[j].y) - (dots[j].x * dots[i].y);
                }

                S = Math.Abs(S / 2);
                Area = S;
            }
        }



    }
}
