namespace Model
{
    using System;

    [Serializable]
    public class PersonViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}