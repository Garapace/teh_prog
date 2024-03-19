using System;

namespace laba2
{
    abstract class BaseList
    {
        protected int quantity;
        public int Count { get { return quantity; } }
        public abstract void Add(int digit);
        public abstract void Insert(int digit, int index);
        public abstract void Delete(int index);
        public abstract void Clear();
        public abstract int this[int i] { set; get; }
        public abstract void Print();

        public void Assign(BaseList source)
        {
            Clear();
            for (int i = 0; i < source.Count; i++)
            {
                Add(source[i]);
            }
        }
        public void AssignTo(BaseList dest)
        {
            dest.Assign(this);
        }
        public BaseList Clone()
        {
            BaseList clone = EmptyClone();
            clone.Assign(this);
            return clone;
        }
        protected abstract BaseList EmptyClone();
        public virtual void Sort()
        {
            int left = 0;
            int right = quantity - 1;
            while (left < right)
            {
                for (int i = left; i < right; i++)
                {
                    if (this[i] > this[i + 1])
                    {
                        int temp = this[i];
                        this[i] = this[i + 1];
                        this[i + 1] = temp;
                    }
                }
                right--;

                for (int i = right; i > left; i--)
                {
                    if (this[i - 1] > this[i])
                    {
                        int temp = this[i - 1];
                        this[i - 1] = this[i];
                        this[i] = temp;
                    }
                }
                left++;
            }
        }

        public bool IsEqual(BaseList list)
        {
            if (list.Count != quantity)
            {
                return false;
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != this[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}