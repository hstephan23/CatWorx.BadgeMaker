namespace CatWorx.BadgeMaker
{
    class Employee(string firstName, string lastName, int id, string photoUrl)
    {
        public string FirstName = firstName;
        public string LastName = lastName;
        public int Id = id;
        public string PhotoUrl = photoUrl;

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }

        public int GetId()
        {
            return Id;
        }

        public string GetPhotoUrl()
        {
            return PhotoUrl;
        }

        public string GetCompanyName()
        {
            return "Cat Worx";
        }
    }
}
