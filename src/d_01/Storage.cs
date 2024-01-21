namespace s21
{
    public class Storage
    {
        private int capacity;
        private int numberOfGoods;

        public Storage(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("Capacity must be a positive integer.");
            }

            this.capacity = capacity;
            this.numberOfGoods = capacity;
        }
        
        public void TakeGoods(int quantity)
        {
            if (quantity <= 0 || quantity > numberOfGoods)
            {
                throw new ArgumentException("Invalid quantity of goods to take.");
            }
            numberOfGoods -= quantity;
        }
        
        public int GetNumberOfGoods => numberOfGoods;
        public int GetCapacity => capacity;

        public bool IsEmpty() => numberOfGoods == 0;
    }
}