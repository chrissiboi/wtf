using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WTF
{
    class CreateMap
    {

        public static void Print(Canvas CanvasMap, FieldObject[,] map)
        {

            int left = 1;
            int top = 1;
               
            for (int i = 0; i < map.GetLength(0); i++)
            {

                for (int j = 0; j < map.GetLength(1); j++)
                {

                    Rectangle rectangle = new Rectangle();

                    switch (map[i, j].getObjectType())
                    {

                        case ("street"):
                            rectangle.Fill = new SolidColorBrush(Colors.Gray);
                            break;
                        case ("house"):
                            rectangle.Fill = new SolidColorBrush(Colors.White);
                            break;
                        case ("tree"):
                            rectangle.Fill = new SolidColorBrush(Colors.Green);
                            break;
                        case ("firestation"):
                            rectangle.Fill = new SolidColorBrush(Colors.IndianRed);
                            break;
                        case ("river"):
                            rectangle.Fill = new SolidColorBrush(Colors.Blue);
                            break;

                    }

                    rectangle.Stroke = new SolidColorBrush(Colors.Black);
                    rectangle.Width = 50;
                    rectangle.Height = 50;
                    rectangle.SetValue(Canvas.LeftProperty, (double)left);
                    rectangle.SetValue(Canvas.TopProperty, (double)top);
                     
                    CanvasMap.Children.Add(rectangle);

                    left = left + 50;

                }

                top = top + 50;
                left = 1;

            }

        }

    }

}

