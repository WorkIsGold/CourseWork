using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Input;

namespace ShestakovCourse2Work
{
    internal class Peaks : Button//Объявляем класс вершин, наследников класса кнопок, со всеми их методами и свойствами
    {//А также некоторыми своими
        List<Lines> incidentLines;//список инцидентных ребёр вершины
        protected int number = -1;//номер вершины для идентификации
        public Peaks() : base()//Создаём новую вершину
        { 
            incidentLines = new List<Lines>();//Инициализируем список инцидентных рёбер вершины
            Panel.SetZIndex(this, 2);//Ставим вершину на верхний слой на экране, над рёбрами и фоном
        }
        public Peaks(string Name) : this()
        { this.Name = Name; }
        public Peaks(int number) : this() { this.number = number; }
        public Peaks(System.Windows.Controls.ControlTemplate templatePeaks, System.Windows.Style stylePeaks) : this()
        {
            this.Style = stylePeaks;
            this.Template = templatePeaks;
        }
        public Peaks(System.Windows.Controls.ControlTemplate templatePeaks, System.Windows.Style stylePeaks, string Name) : this(templatePeaks, stylePeaks)
        { this.Name = Name; }
        public Peaks(System.Windows.Controls.ControlTemplate templatePeaks, System.Windows.Style stylePeaks, int number) : this(templatePeaks, stylePeaks) { this.number = number; }
        public List<Lines> IncidentLines//Доступ к списку инцидентных рёбер вершины
        {
            get { return incidentLines; }
            set { incidentLines = value; }
        }
        public int Number//Доступ к полю номера вершины
        {
            get { return number; }
            set { this.number = value; }
        }
        public double X//Доступ к координате X вершины
        {//Визуальный код
            get { return this.ToButton().X(); }
            set { this.ToButton().X(value); }
        }
        public double Y//Доступ к координате Y вершины
        {//Визуальный код
            get { return this.ToButton().Y(); }
            set { this.ToButton().Y(value); }
        }
        public System.Windows.Controls.Button ToButton()//Преобразование вершины в кнопку для корректной работы некоторых функций
        { return (System.Windows.Controls.Button)this; }//Без их переопределения
    }
}
