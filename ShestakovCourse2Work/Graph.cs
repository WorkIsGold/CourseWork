using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShestakovCourse2Work
{
    internal class Graph//Класс графов
    {
        protected List<Peaks> graphPeaks;//Список вершин графа
        protected List<Lines> graphLines;//Список рёбер графа
        protected List<List<Peaks>> incidentPeaks;//Список инцидентных вершин графа
        protected List<List<Lines>> incidentLines;//Список смежных рёбер графа
        protected List<List<Lines>> graphBindComponentsLines;//Список компонент связности графа
        protected List<List<Lines>> graphBasesIndependentCycles;//Список баз независимых циклов графа
        public Graph()
        {
            graphPeaks = new List<Peaks>();//Инициализируем список вершин графа
            graphLines = new List<Lines>();//Инициализируем список рёбер графа
            incidentPeaks = new List<List<Peaks>>();//Инициализируем список инцидинтных вершин графа
            incidentLines = new List<List<Lines>>();//Инициализируем список смежных рёбер графа
            graphBindComponentsLines = new List<List<Lines>>();//Инициализируем список компонент связности графа
            graphBasesIndependentCycles = new List<List<Lines>>();//Инициализируем список баз независимых циклов графа
        }
        public List<Peaks> GraphPeaks { get { return graphPeaks; } }//Доступ к списку вершин графа
        public List<Lines> GraphLines { get { return graphLines; } }//Доступ к списку рёбер графа
        public List<List<Peaks>> IncidentPeaks { get { return incidentPeaks; } }//Доступ к списку инцидентных вершин графа
        public List<List<Lines>> GraphBasesIndependentCycles { get { return graphBasesIndependentCycles; } }//Доступ к базам независимых циклов графа
        public void Clear()//Очищает граф
        {
            graphBindComponentsLines.Clear();//Очищает компоненты связности графа
            graphBasesIndependentCycles.Clear();//Очищает базы независимых циклов графа
        }
        public Peaks LastGraphPeak//Доступ к последней вершине графа
        {
            get { return graphPeaks.LastElement(); }
            set { graphPeaks.LastElement(value); }
        }
        public void AddNewPeak(Peaks peaks)//Добавляем новую вершину в граф
        {
            graphPeaks.Add(peaks);//Добавляем её в список вершин графа
            incidentPeaks.Add(new List<Peaks>());//Добавляем новый список в списке инцидентных вершин графа
        }
        public void AddNewLine(Lines Line)// добавляем в граф новое ребро
        {
            graphLines.Add(Line);// добавляем ребро в список рёбер графа
            incidentLines.Add(new List<Lines>());// добавляем новую строку в список смежных рёбер графа
            foreach (var i in Line.IncidentPeaks[0].IncidentLines)// перебираем рёбра, инцидентные первой вершине нового ребра
                if (i != Line)// если ребро не совпадает с новым ребром
                {
                    incidentLines[i.Number].Add(Line);// добавляем новое ребро в список смежных рёбер ребра
                    incidentLines.LastElement().Add(i);// добавляем ребро в список смежных рёбер нового ребра
                }
            foreach (var i in Line.IncidentPeaks[1].IncidentLines)// перебираем рёбра, инцидентные второй вершине нового ребра
                if (i != Line) // если ребро не совпадает с новым ребром
                {
                    incidentLines[i.Number].Add(Line);// добавляем новое ребро в список смежных рёбер ребра
                    incidentLines.LastElement().Add(i);// добавляем ребро в список смежных рёбер нового ребра
                }
        }
        public void BindTwoPeaks(Peaks peak1, Peaks peak2)//Связываем две вершины друг с другом
        {
            BindTwoPeaksFromTo(peak1, peak2);// Сначала свяжем первую вершину со второй
            BindTwoPeaksFromTo(peak2, peak1);//Затем вторую вершину с первой
        }
        public void BindTwoPeaks(Lines line)//Связываем инцидентные вершины ребра друг с другом
        { BindTwoPeaks(line.IncidentPeaks[0], line.IncidentPeaks[1]); }
        public void BindTwoPeaksFromTo(Peaks peak1, Peaks peak2)//Связываем одну вершину графа с другой
        {
            incidentPeaks[peak1.Number].Add(peak2);
        }
        public void FindBindComponents()// Поиск компонент связности в графе
        {//При помощи обхода графа в ширину
            var queue = new Queue<Lines>();
            foreach (var line in graphLines)//Все рёбра графа
                line.IsVisited = false;//Определяем как непосещённые
            foreach (var line in graphLines)//Перебираем все рёбра графа
                if (!line.IsVisited)//Если ребро ещё не было посещено
                {
                    queue.Enqueue(line);
                    line.IsVisited = true;//Отмечаем ребро как посещённое
                    graphBindComponentsLines.Add(new List<Lines>());//Создаём новую компоненту связности графа
                    graphBindComponentsLines.LastElement().Add(line);//И добавляем в неё ребро
                    while (queue.Count > 0)
                    {
                        var v = queue.Dequeue();
                        foreach (var u in incidentLines[v.Number])//Перебираем смежные ребра
                            if (!u.IsVisited)//Если ребро ранее не было посещено
                            {
                                queue.Enqueue(u);
                                u.IsVisited = true;//Отмечаем ребро как посещённое
                                graphBindComponentsLines.LastElement().Add(u);//И заносим его в компоненту связности графа
                            }
                    }
                }
        }
        public bool CheckCycle(List<Lines> baseIndependentCycles, Lines line)//Проверяем, образует ли ребро цикл с рёбрами базы независимых циклов графа
        {
            if (IsIncidentLine(baseIndependentCycles, line.IncidentPeaks[0]))//Если у ребра есть смежное ребро из базы невисимых циклов с одной стороны
            {
                if (IsIncidentLine(baseIndependentCycles, line.IncidentPeaks[1]))//И если у ребра есть смежное ребро из базы независимых циклов с другой стороны
                    return true;//Значит, оно образует цикл с рёбрами базы независимых циклов графа
                return false;//Во всех остальных случаях оно не образует циклы с рёбрами базы независимых циклов графа
            }
            return false;
        }
        public bool IsIncidentLine(List<Lines> baseIndependentCycles, Peaks peak)//Проверяем, есть ли у ребра смежное ребро из базы независимых циклов с общей вершиной
        {
            foreach (var line in baseIndependentCycles)//Перебираем рёбра базы независимых циклов графа
            {
                if (peak.IncidentLines.Contains(line))//Если ребро инцидентно вершине 
                    return true;//То у ребра есть смежное ребро базы независимых циклов с общей вершиной
            }
            return false;//Иначе нет
        }
        public void FindBaseIdependentCycles()//Поиск баз независимых циклов во всех компонентах связности графа
        {
            Clear();
            FindBindComponents();// Ищем в графе компоненты связности
            foreach (var bindComponentLines in graphBindComponentsLines)//Проходим по всем компонентам связности графа
                FindBaseIndependentCycles(bindComponentLines);//В каждой ищем базу независимых циклов
        }
        public void FindBaseIndependentCycles(List<Lines> bindComponentLines)//Поиск баз независимых циклов в компоненте связности графа
        {
            graphBasesIndependentCycles.Add(new List<Lines>());//Создаём новую базу независимых циклов для рассматриваемой компоненты связности
            graphBasesIndependentCycles.LastElement().Add(bindComponentLines[0]);//Выбрать первое ребро компоненты графа и занести его в список
            foreach (var line in bindComponentLines)// Перебираем рёбра компоненты связности графа
                if (!CheckCycle(graphBasesIndependentCycles.LastElement(), line))//Если выбранное ребро не образует цикл с ранее занесенными в список.
                    graphBasesIndependentCycles.LastElement().Add(line);//Занести его в список
        }
    }
}
