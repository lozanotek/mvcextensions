namespace Model
{
    using System.Collections.Generic;

    public class PersonService
    {
        private static readonly List<PersonViewModel> personList = new List<PersonViewModel>();

        public IList<PersonViewModel> GetPeople()
        {
            return personList;
        }

        public void Add(PersonViewModel viewModel)
        {
            if (viewModel == null) return;
            personList.Add(viewModel);
        }
    }
}