namespace InterviewMatrix.Models
{
    public class Matrix<T>
    {
        public int Width { get; }
        public int Height { get; }
        public T[,] Data { get; private set; }

        private TraverseOrientation _traverseOrientation;

        public Matrix(int width, int height, T[] dictionary, TraverseOrientation traverseOrientation)
        {
            Width = width;
            Height = height;
            Data = new T[Width, Height];
            _traverseOrientation = traverseOrientation;
            Populate(dictionary, _traverseOrientation);
        }

        private void Populate(T[] dictionary, TraverseOrientation traverseOrientation)
        {
            switch(traverseOrientation)
            {
                case TraverseOrientation.TopToBottom:
                    var currentDictionaryIndex = 0;
                    var dictionaryLength = dictionary.Length;
                    for (var i = 0; i < Width; i++)
                    {
                        for (var j = 0; j < Height; j++)
                        {
                            T item = dictionary[currentDictionaryIndex % dictionaryLength];
                            Data[i, j] = item;
                            currentDictionaryIndex++;
                        }
                    }
                    break;
            }
        }

        public string Print()
        {
            T[] linearData = new T[Width * Height];
            switch(_traverseOrientation)
            {
                case TraverseOrientation.TopToBottom:
                    var currentIndex = 0;
                    for (var i = 0; i < Width; i++)
                    {
                        for (var j = 0; j < Height; j++)
                        {
                            linearData[currentIndex] = Data[i, j];
                            currentIndex++;
                        }
                    }
                    break;
            }

            return string.Join(",", linearData);
        }
    }
}
