namespace SoftUniKindergarten
{
    public class Child
    {

        
        private string firstName;
        private string contactNumber;
        private int age;
        private string lastName;
        private string parentName;
        //firstName, lastName, age, parentName, contactNumber.
        public Child(string firstName,string lastName, int age, string parentName, string contactNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
            Age = age;
            ParentName = parentName;
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string ParentName
        {
            get { return parentName; }
            set { parentName = value; }
        }
        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }

        public override string ToString() 
        {
      return $"Child: {FirstName} {LastName}, Age: {Age}, Contact info: {ParentName} - {ContactNumber}";
        }
    }
}
