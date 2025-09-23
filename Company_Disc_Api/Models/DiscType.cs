namespace Company_Disc_Api.Models
{
    public class DiscType
    {
        private int _id;
        private string _name;
        private string _color;

        public DiscType(int id, string name, string color)
        {
            _id = id;
            _name = name;
            _color = color;
        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }
    }
}
