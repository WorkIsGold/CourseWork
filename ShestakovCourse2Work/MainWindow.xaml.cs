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

namespace ShestakovCourse2Work
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Controls.Control draggedPeak;//Ссылка на перетаскиваемую вершину
        Lines draggedLine;//Ссылка на перетаскиваемое ребро
        Graph graph;//Граф
        Point peakRelativePosition;//Для корректного вычисления новых коодинат перетаскиваемой вершины
        bool IsDraggingPeak = false;//Для запоминания, перетаскиваем ли мы вершину
        bool IsDraggingLine = false;//Для запоминания, перетаскиваем ли мы ребро
        System.Windows.Controls.ControlTemplate templateTogglePeaks;//для управления внешним видом
        System.Windows.Style stylePeaks;//для подключения элементов управления
        System.Windows.Style styleLines;//для внешнего вида рёбер
        System.Windows.Media.SolidColorBrush EmeraldBrush;//Цвет для выделения рёбер
        public MainWindow()//Конструктор главного окна приложения
        {
            InitializeComponent();//Инициализация окна приложения
            templateTogglePeaks = (System.Windows.Controls.ControlTemplate)FindResource("templatePeaks");//инициализация шаблона вершин из xaml
            stylePeaks = (System.Windows.Style)FindResource("stylePeaks");//Инициализация стиля вершин из xaml
            styleLines = (System.Windows.Style)FindResource("styleLines");//Инициализация стиля рёбер из xaml
            graph = new Graph();// Создаём новый граф
            graph.AddNewPeak(roundButton1);
            graph.AddNewPeak(testclass1);
            EmeraldBrush = (System.Windows.Media.SolidColorBrush)FindResource("Emerald");//Инициализация цвета для выделения рёбер
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)//При нажатии на клавишу клавиатуры
        {
            textblock1.Text = e.Key.ToString();
            if (e.Key == System.Windows.Input.Key.Enter)//Если нажата клавиша Enter
            {
                Calculation();//Вычисляем базы независимых циклов графа
            }
            else if (e.Key == Key.Escape)//Иначе, если нажата клавиша Escape
            {
                Close();//Закрываем окно программы
            }
        }
        private void btn_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)//При нажатии левой кнопки мыши на вершину графа
        {
            IsDraggingPeak = true;//Запоминаем, что мы теперь перетаскиваем вершину
            draggedPeak = (Peaks)sender;//Запоминаем, какую вершину мы перетаскиваем
            peakRelativePosition = e.GetPosition(draggedPeak);//Запоминаем её изначальное расположение для корректного вычисления координат в дальнейшем
        }
        private void btn_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)//При нажатии правой кнопки мыши на вершину
        {
            if (!IsDraggingLine)//Если ребро не перетаскивается
            {
                IsDraggingLine = true;// Запоминаем, что ребро теперь перетаскивается
                draggedLine = CreateNewLine((Peaks)sender);//И создаём новое ребро, которое перетаскивается
            }
            else//Если ребро перетаскивается
            {
                IsDraggingLine = false;//Запоминаем, что ребро теперь не перетаскивается
                if ((Peaks)sender != draggedLine.IncidentPeaks[0])//Если нажимаемая вершина не инцидентна перетаскиваемому ребру
                {
                    BindDraggedLineToPeak(sender, e);//Привязываем перетаскиваемое ребро к этой вершине
                }
                else//Иначе, если нажимаемая вершина не инцидентна перетаскиваемому ребру
                {
                    CreateNewPeakWithIncidentLine(sender, e);//Создаём новую вершину, инцидентную перетаскиваемому ребру
                }
            }
        }
        private void btn_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)//При отпускании левой кнопки мыши
        {
            if (!IsDraggingPeak)//Если вершина не перетаскивалась
                return;//Ничего не делаем
            IsDraggingPeak = false;//Иначе отменяем перетаскивание вершины
        }
        private void canvas_PreviewMouseMove(object sender, MouseEventArgs e)//При движении мыши по фону
        {
            textblock2.Text = e.GetPosition(canvas1).X.ToString();
            textblock3.Text = e.GetPosition(canvas1).Y.ToString();
            if (IsDraggingLine)//И перетаскивании ребра
                draggedLine.XY2 = e.GetPosition(canvas1);//Устанавлиавем координаты конца ребра равными координатам курсора
        }
        private void btn_PreviewMouseMove(object sender, MouseEventArgs e)// двигаем ребра либо вершины
        {
            textblock2.Text = e.GetPosition(canvas1).X.ToString();
            textblock3.Text = e.GetPosition(canvas1).Y.ToString();
            if (IsDraggingLine)//Если двигается ребро
                MoveDraggedLine(e);//Сдвигаем ребро
            else if (IsDraggingPeak)//В противном случае если двигается вершину
                MoveDraggedPeak(sender, e);//Сдвигаем вершину
        }
        private void MoveDraggedLine(MouseEventArgs e)//Двигаем ребро
        {
            draggedLine.XY2 = e.GetPosition(canvas1);//Перемещаем второй конец ребра на координаты курсора
            if (e.GetPosition(canvas1).X > draggedLine.Line.X1)//Чтобы ребро не закрывало вершину, смещаем его конец слегка в сторону
            {//Если курсор правее начала перетаскиваемого ребра
                draggedLine.X2 -= 1;//По координате X влево
                draggedLine.Y2 -= 1;//По координате Y вверх
            }
            else//Если курсор левее навала перетаскиваемого ребра
            {
                draggedLine.X2 += 1;//По координате X вправо
                draggedLine.Y2 += 1;//По координате Y вниз
            }
        }
        private void MoveDraggedPeak(object sender, MouseEventArgs e)//Двигаем вершину
        {
            ((Peaks)draggedPeak).X = e.GetPosition(canvas1).X - peakRelativePosition.X;//Устаначливаем координату X перетаскиваемой вершины равной координате X курсора
            ((Peaks)draggedPeak).Y = e.GetPosition(canvas1).Y - peakRelativePosition.Y;//Устаначливаем координату Y перетаскиваемой вершины равной координате Y курсора
            foreach (var line in ((Peaks)sender).IncidentLines)//Перебираем инцидентые вершине рёбра
                line.SetLine((Peaks)sender);//Передвигаем их соответствующий конец на координаты вершины
        }
        private void CreateNewPeak(object sender, MouseButtonEventArgs e)//Создаём новую вершину
        {
            Peaks peak = new Peaks(templateTogglePeaks, stylePeaks, graph.IncidentPeaks.Count);//Создаём новую вершину
            graph.AddNewPeak(peak);//Добавляем новую вершину в граф
            canvas1.Children.Add(peak);//Добавляем новую вершину на экран
            graph.LastGraphPeak.X = e.GetPosition(canvas1).X - peakRelativePosition.X;//Устанавливаем координаты новой вершины на координаты курсора мыши
            graph.LastGraphPeak.Y = e.GetPosition(canvas1).Y - peakRelativePosition.Y;
        }
        private void BindDraggedLineToPeak(object sender, MouseButtonEventArgs e)//Привязываем перетаскиваемое ребро к вершине
        {
            draggedLine.IncidentPeaks[1] = (Peaks)sender;//Делаем перетаскиваемое ребро и вершину инцидентными
            ((Peaks)sender).IncidentLines.Add(draggedLine);
            graph.AddNewLine(draggedLine);//Добавляем перетаскиваемое ребро в граф
            graph.BindTwoPeaks(draggedLine.IncidentPeaks[0], (Peaks)sender);//Связываем в графе две вершины
            draggedLine.X2 = ((Peaks)sender).X + draggedLine.Correction;//Устанавливаем координаты перетаскиваемого ребра равными координатам вершины
            draggedLine.Y2 = ((Peaks)sender).Y + draggedLine.Correction;
        }
        private void CreateNewPeakWithIncidentLine(object sender, MouseButtonEventArgs e)//Создание новой вершины, инцидентной перетаскиваемому ребру
        {
            CreateNewPeak((Peaks)sender, e);//Создаём новую вершину
            draggedLine.IncidentPeaks[1] = graph.LastGraphPeak;//Делаем её инцидентной перетаскиваемому ребру
            graph.LastGraphPeak.IncidentLines.Add(draggedLine);
            graph.AddNewLine(draggedLine);//Добавляем в граф новое ребро
            //Console.WriteLine(draggedLine.IncidentPeaks[0].Number + " " + draggedLine.IncidentPeaks[1].Number);
            graph.BindTwoPeaks((Peaks)sender, graph.LastGraphPeak);//Связываем инцидентные перетаскиваемому ребру вершины 
            draggedLine.Line.X2 = graph.LastGraphPeak.X + draggedLine.Correction;//Устанавливаем координаты перетаскиваемого ребра равными координатам новой вершины
            draggedLine.Line.Y2 = graph.LastGraphPeak.Y + draggedLine.Correction;
        }
        private Lines CreateNewLine(object sender)//Создаём новое ребро
        {
            Lines line = new Lines((Peaks)sender, graph.GraphLines.Count);//Создаём новое ребро
            line.Style = styleLines;//Задаём стиль отбражения ребра
            ((Peaks)sender).IncidentLines.Add(line);//Делаем ребро инцидентным вершине
            line.SetLine((Peaks)sender, (Peaks)sender);
            canvas1.Children.Add(line.Line);//Добавляем ребро на экран
            //Panel.SetZIndex(line.Line, 1);
            return line;//Возвращаем ссылкку на новое ребро
        }
        private void canvasButton_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)//При нажатии правой кнопкой мыши на экран
        {
            CreateNewPeak(sender, e);//Создаём новую вершину на месте нажатия
        }
        private void Calculation() // делаем вычисления баз независимых циклов 
        {
            graph.FindBaseIdependentCycles();// ищем базы независимых циклов в графе
            foreach (var i in graph.GraphBasesIndependentCycles)// перебираем базы независимых циклов в графе
            {
                foreach (var j in i)// перебираем ребра в базах независимых циклов
                {
                    j.Line.Stroke = EmeraldBrush; //окрашиваем каждое ребро каждой базы независимых циклов
                }
            }
        }
    }
}
