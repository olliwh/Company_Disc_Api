namespace Company_Disc_Api.Models
{
    public class Employee
    {
        private int _id;
        private string _name;
        private string _email;
        private string _imgUrl;
        private Department _department;
        private DiscType _discType;

        public Employee(int id, string name, string email, Department department, DiscType discType, string imgUrl)
        {
            _id = id;
            _name = name;
            _email = email;
            _imgUrl = imgUrl;
            _department = department;
            _discType = discType;
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
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        public string ImgUrl
        {
            get
            {
                return _imgUrl;
            }
            set
            {
                _imgUrl = value;
            }
        }

        public Department Department
        {
            get
            {
                return _department;
            }
            set
            {
                _department = value;
            }
        }
        public DiscType DiscType
        {
            get
            {
                return _discType;
            }
            set
            {
                _discType = value;
            }
        }
    }
}
