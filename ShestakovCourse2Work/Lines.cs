using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace ShestakovCourse2Work
{
    internal class Lines
    {
        protected System.Windows.Shapes.Line line;//линия для отображения ребра
        protected Peaks[] incidentPeaks;//список инцидентных вершин ребра
        protected bool IsTwoPeaks = false;
        protected double correction = 0;//Поправка на визуальный размер вершины
        //protected Arrow arrow;
        protected int number = -1;//номер ребра для идентификации
        protected bool isVisited = false;//было посещено ребро ранее или нет
        public Lines()//Создание нового ребра
        {
            incidentPeaks = new Peaks[2];//Создаём список для двух инцидентных вершин ребра
            line = new System.Windows.Shapes.Line();//Создаём линию для визуального отображения ребра
            Panel.SetZIndex(line, 1);//Устанавливаем линию на первый слой на экране, под вершины, но над фоном
        }
        public Lines(Peaks incidentPeak) : this() { incidentPeaks[0] = incidentPeak; SetCorrection(incidentPeak); }
        public Lines(Peaks incidentPeak, int count) : this(incidentPeak) { number = count; }
        public Lines(Peaks incidentPeak1, Peaks incidentPeak2) : this(incidentPeak1)
        { incidentPeaks[1] = incidentPeak2; }
        public Lines(Peaks incidentPeak1, Peaks incidentPeak2, int count) : this(incidentPeak1, incidentPeak2) { number = count; }
        public void SetLine(Peaks incidentPeak1, Peaks incidentPeak2)//Проводит ребро от одной вершины к другой
        {//Визуальный код
            line.X1 = incidentPeak1.X() + correction;//Устанавливаем координату X начала ребра равной координате X первой вершины
            line.Y1 = incidentPeak1.Y() + correction;//Устанавливаем координату Y начала ребра равной координате Y первой вершины
            line.X2 = incidentPeak2.X() + correction;//Устанавливаем координату X конца ребра равной координате X второй вершины
            line.Y2 = incidentPeak2.Y() + correction;//Устанавливаем координату Y конца ребра равной координате Y второй вершины
        }
        public void SetLine(Peaks incidentPeak)//Обновление визуального состояния ребра из-за перемещения инцидентной ему вершины
        {//Визуальный код
            if (incidentPeak == incidentPeaks[0])//Если инцидентная вершина - начало ребра
            {
                line.X1 = incidentPeak.X() + correction;//Устанавливаем координату X начала ребра равной координате X центра инцидентной вершины 
                line.Y1 = incidentPeak.Y() + correction;//Устаначливаем координату Y начала ребра равной координате Y центра инцидентной вершины
            }
            else//Иначе инцидентная вершина - конец ребра
            {
                line.X2 = incidentPeak.X() + correction;//Устанавливаем координату X конца ребра равной координате X центра инцидентной вершины
                line.Y2 = incidentPeak.Y() + correction;//Устанавливаем координату Y конца ребра равной координате Y центра инцидентной вершины
            }
            //arrow.RecreateArrow(this);
        }
        public void setLine(Peaks incidentPeak, Point e)//Обновление визуального состояния ребра из-за перетаскивания ребра
        { XY2 = e; }//Устанавливаем координаты конца ребра равными координатам курсора мыши

        public bool IsVisited//Доступ к посещённости ребра
        {
            get { return isVisited; }
            set { isVisited = value; }
        }
        public Point XY1//Доступ к координатам начала ребра
        {//Визуальный код
            get { return new Point(line.X1, line.Y1); }
            set { line.X1 = value.X; line.Y1 = value.Y; }
        }
        public Point XY2//Доступ к координатам конца ребра
        {//Визуальный код
            get { return new Point(line.X2, line.Y2); }
            set { X2 = value.X; Y2 = value.Y; }
        }
        public double X2//Доступ к координате X конца ребра
        {//Визуальный код
            get { return line.X2; }
            set
            { 
                line.X2 = value;
                //arrow.RecreateArrow(this);
            }
        }
        public double Y2//Доступ к координате Y конца ребра
        {//Визуальный код
            get { return line.Y2; }
            set
            {
                line.Y2 = value;
                //arrow.RecreateArrow(this);
            }
        }
        public int Number//Доступ к номеру ребра
        {
            get { return number; }
            set { number = value; }
        }
        public System.Windows.Shapes.Line Line//Доступ к линии ребра
        {//Визуальный код
            get { return line; }
        }
        /*public Arrow Arrow
        {
            get { return arrow; }
        }*/
        public double Correction//Доступ к параметру коррекции ребра
        {//Визуальный код, для корректного вычисления координат конца ребра
            get { return correction; }
            set { correction = value; }
        }
        public Peaks[] IncidentPeaks//Доступ к списку инцидентных вершин ребра
        {
            get { return incidentPeaks; }
            set { incidentPeaks = value; }
        }
        public void SetCorrection(Peaks peak)//Установка параметра коррекции по визуальному размеру вершин
        {//Визуальный код
            correction = peak.ActualWidth / 2;
        }
        public System.Windows.Style Style//Установка стиля ребра
        {//Визуальный код
            set { line.Style = value; /*arrow.Style = value;*/ }
        }
    }
}
