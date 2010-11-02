namespace Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PersonService {
        private static readonly List<PersonViewModel> personList = new List<PersonViewModel>();

        public IList<PersonViewModel> GetPeople() {
            return personList;
        }

        public IList<PersonViewModel> GetPeopleByBirthdate(DateTime birthDate) {
            return personList.Where(p => p.Birthdate == birthDate).ToList();
        }

        public void Add(PersonViewModel viewModel) {
            if (viewModel == null)
                return;
            personList.Add(viewModel);
        }
    }
}