using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestr1
{
    public class FigureList
    {
        public Figure head;
        public Figure tail;

        private bool IsEmpty { get { return head == null; } }

        //проверяет существование "подобного элемента" удаляет, если находит 
        private bool CheckExistence(Figure elem)
        {
            bool correct = false;
            Figure item = head;
            while (item != null)
            {
                if (elem.Type == item.Type)
                {
                    if (CheckParametrs(elem, item))
                    {
                        Remove(item);
                        break;
                    }
                }
                item = item.Next;
            }
            return correct;
        }
        //вспомогат метод, который проверяет "подобие" элементов
        private bool CheckParametrs(Figure elem, Figure item)
        {
            bool correct = true;
            if ((item.XLU != elem.XLU) || (item.XRD != elem.XRD) ||
                (item.YLU != elem.YLU) || (item.YRD != elem.YRD))
                correct = false;
            return correct;
        }
        //считает кол-во объектов, длину листа
        public int Count()
        {
            Figure item = head;
            var n = 0;
            while (item != null)
            {
                item = item.Next;
                n++;
            }
            return n;
        }
        //добавление по индексу
        public void Add(Figure elem, int index)
        {
            Figure item;
            int length = Count();
            CheckExistence(elem);
            if (IsEmpty)
            {
                tail = head = elem;
            }
            else if (index == 0)
            {
                elem.Next = head;
                head = elem;
            }
            else if (index >= length)
            {
                tail.Next = elem;
                tail = elem;
            }
            else
            {
                int n = 0;
                item = head;
                while (n != index - 1)
                {
                    item = item.Next;
                    n++;
                }
                elem.Next = item.Next;
                item.Next = elem;
            }
        }
        //обычное добавление в конец
        public void AddLast(Figure elem)
        {
            CheckExistence(elem);
            if (IsEmpty)
            {
                tail = head = elem; 
            }
            else
            {
                tail.Next = elem;
                tail = elem;
            }
        }
        //удаление элемента, если он есть, иначе кидает Exception
        public void Remove(Figure elem)
        {
            Figure item = head;
            Figure previous = head;

            int n = -1;
            while (item != null)
            {
                if (item.Equals(elem))
                {
                    if (item == head)
                    {
                        head = item.Next;
                        n = 1;
                        break;
                    }
                    else if (item == tail)
                    {
                        previous.Next = null;
                        tail = previous;
                        n = 1;
                        break;
                    }
                    else
                    {
                        previous = item.Next;
                        n = 1;
                        break;
                    }
                }
                previous = item;
                item = item.Next;
            }
            if (n < 0) throw new InvalidOperationException();
        } 
    }
}
