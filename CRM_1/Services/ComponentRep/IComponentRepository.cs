using System;
using CRM_1.Models;

namespace CRM_1.Services.ComponentRep
{
    public interface IComponentRepository
    {
        IEnumerable<Component> GetComponents();

        List<string> GetAllCategories();

        Component GetComponentById(int id);

        int GetLastComponentId();

        void AddComponent(Component component);

        void DeletComponentById(int id);

        void Update(Component component);

        void SetCheck(List<string> categoryCheck);
    }
}

