using System;
using CRM_1.Models;

namespace CRM_1.Services.ComponentRep
{
    public class MocComponentRepository : IComponentRepository
    {
        private List<Component> componentList;

        public MocComponentRepository()
        {
            componentList = new List<Component>()
            {
                new Component
                {
                    Id = 0, Name = "Табак", Category = "Для Кальяна", Amount = 1000
                },
                new Component
                {
                    Id = 1, Name = "Уголь", Category = "Для Кальяна", Amount = 40
                },
                new Component
                {
                    Id = 2, Name = "Кола", Category = "Напитки", Amount = 6
                },
                new Component
                {
                    Id = 3, Name = "Пиво Bud", Category = "Напитки", Amount = 2
                },
                new Component
                {
                    Id = 4, Name = "Имбирь", Category = "Для Чая", Amount = 4
                },
                new Component
                {
                    Id = 5, Name = "Мундштук", Category = "Для Кальяна", Amount = 150
                },
                new Component
                {
                    Id = 6, Name = "Сироп Вишневый", Category = "Для Чая", Amount = 150
                },
            };
        }

        public IEnumerable<Component> GetComponents()
        {
            return componentList.Where(x => x.IsChecked == true);
        }

        public Component GetComponentById(int id)
        {
            var itemToGet = componentList.FirstOrDefault(x => x.Id.Equals(id));
            return itemToGet;
        }

        public int GetLastComponentId()
        {
            return componentList.Last().Id;
        }

        public List<string> GetAllCategories()
        {
            List<string> categories = new List<string>();

            foreach (var item in componentList)
            {
                if (!categories.Any(x => x.Equals(item.Category)))
                {
                    categories.Add(item.Category);
                }
            }

            return categories;
        }

        public void AddComponent(Component component)
        {
            if (!componentList.Any(x => x.Name.Equals(component.Name)))
                componentList.Add(component);
        }

        public void DeletComponentById(int id)
        {
            var itemToRemove = componentList.FirstOrDefault(x => x.Id.Equals(id));
            if (itemToRemove != null)
                componentList.Remove(itemToRemove);
        }

        public void Update(Component component)
        {
            componentList
                .FindAll(x => x.Id == component.Id)
                .ForEach(x => {
                    x.Name = component.Name;
                    x.Amount = component.Amount;
                    x.Category = component.Category; });
        }

        public void SetCheck(List<string> categoryCheck)
        {
            if (categoryCheck.Count() == 0)
            {
                foreach (var component in componentList)
                    component.IsChecked = true;
            }
            else
            {
                foreach (var component in componentList)
                    component.IsChecked = false;

                foreach(var category in categoryCheck)
                {
                    foreach (var component in componentList)
                    {
                        if (component.Category.Equals(category))
                            component.IsChecked = true;
                    }
                }
            }
        }
    }
}

