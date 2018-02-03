namespace TddBook.Shapes
{
    public class Square : Rectangle
    {
        private double _width;
        private double _height;

        public override double Width
        {
            get { return _width; }
            set { _width = _height = value; }
        }

        public override double Height
        {
            get { return _height; }
            set { _height = _width = value; }
        }
    }
}