namespace _02.Defining_Classes___Part_2
{
    using System;

    public class GenericList<T> where T : IComparable
    {
        // Fields
        private T[] elements;
        private int index;
        private int capacity;

        // Constructor
        public GenericList(int capacity)
        {
            this.elements = new T[capacity];
            this.index = 0;
            this.capacity = capacity;
        }

        // Properties
        public T[] Elements
        {
            get
            {
                return this.elements;
            }
        }

        // Methods
        public void Add(T element)
        {
            if (this.index > this.elements.Length - 1)
            {
                this.capacity *= 2;
                T[] newArrayOfElements = new T[this.capacity];
                for (int i = 0; i < elements.Length; i++)
                {
                    newArrayOfElements[i] = elements[i];
                }
                this.elements = newArrayOfElements;
                this.elements[index] = element;
            }
            else
            {
                this.elements[this.index] = element;
                this.index++;
            }
        }

        public T ElementAt(int index)
        {
            if (index < 0 || index > this.elements.Length - 1)
            {
                throw new IndexOutOfRangeException("The index you are trying to access is outside of the boundaries of the array");
            }
            T result = this.elements[index];
            return result;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > this.elements.Length - 1)
            {
                throw new IndexOutOfRangeException("The index you are trying to access is outside of the boundaries of the array");
            }
            T[] newArrayOfElements = new T[this.capacity];
            for (int i = 0, j = 0; i < elements.Length; i++, j++)
            {
                if (i == index)
                {
                    i++;
                    if (i > elements.Length - 1)
                    {
                        break;
                    }
                }
                newArrayOfElements[j] = elements[i];
            }
            this.elements = newArrayOfElements;
        }

        public void InsertAt(int index, T newElement)
        {
            if (index < 0 || index > this.elements.Length - 1)
            {
                throw new IndexOutOfRangeException("The index you are trying to access is outside of the boundaries of the array");
            }
            GenericList<T> temp = new GenericList<T>(this.capacity);
            for (int i = 0; i < elements.Length; i++)
            {
                if (i == index)
                {
                    temp.Add(newElement);
                }
                temp.Add(this.elements[i]);
            }
            this.elements = temp.Elements;
        }

        public void ClearAll()
        {
            for (int i = 0; i < this.elements.Length; i++)
            {
                this.elements[i] = default(T);
            }
        }

        public int GetIndexOf(T element)
        {
            int result = -1;
            for (int i = 0; i < this.elements.Length; i++)
            {
                if (this.elements[i].Equals(element))
                {
                    result = i;
                    break;
                }
            }
            return result;
        }

        public T Min() 
        {
            T min = this.elements[0];

            foreach (T element in this.elements)
            {
                if (element.CompareTo(min) < 0)
                {
                    min = element;
                }
            }
            return min;
        }

        public T Max()
        {
            T max = this.elements[0];

            foreach (T element in this.elements)
            {
                if (element.CompareTo(max) > 0)
                {
                    max = element;
                }
            }
            return max;
        }

        public override string ToString()
        {
            return string.Join(", ", elements);
        }

        public int Length()
        {
            return this.elements.Length;
        }
    }
}
