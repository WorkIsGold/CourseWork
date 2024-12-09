using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace ShestakovCourse2Work
{
    internal static class ListExtension//Дополнительные методы для списка
    {
        public static T LastElement<T>(this List<T> list)//Получить последний элемент списка
        { return list[list.Count - 1]; }
        public static void LastElement<T>(this List<T> list, T value)//Изменить последний элемент списка
        { list[list.Count - 1] = value; }
    }
    /*internal static class CanvasExtention
    {
        public static Point GetPosition(this System.Windows.Controls.Canvas canvas, System.Windows.UIElement sender)
        {
            Point point = new Point();
            point.X = Canvas.GetLeft(sender);
            point.Y = Canvas.GetTop(sender);
            return point;
        }
    }*/
    internal static class ButtonExtension//Расширения для кнопок
    {
        public static double X(this System.Windows.Controls.Button button)//Возвращает координату X кнопки
        { return Canvas.GetLeft(button); }
        public static double Y(this System.Windows.Controls.Button button)//Возвращает координату Y кнопки
        { return Canvas.GetTop(button); }
        public static void X(this System.Windows.Controls.Button button, double x)//Изменяет координату X кнопки
        { Canvas.SetLeft(button, x); }
        public static void Y(this System.Windows.Controls.Button button, double y)//Изменяет координату Y кнопки
        { Canvas.SetTop(button, y); }
    }
    /*internal static class ObjectExtension
    {
        public static System.Windows.Controls.Button ToButton(this object Object)
        { return (System.Windows.Controls.Button)Object; }
    }*/
}
