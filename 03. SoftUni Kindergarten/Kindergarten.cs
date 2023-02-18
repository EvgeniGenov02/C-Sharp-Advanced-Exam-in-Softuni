using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
		//Name - string
		//Capacity - int 
		//Registry - List<Child>

		private string name;
		private int capacity;
        private List<Child> childrens;

		public Kindergarten(string name , int capacity)
		{
			Name= name;
			Capacity = capacity;
            childrens = new List<Child>();

        }

        public string Name
        {
			get { return name; }
			set { name = value; }
		}
		public int Capacity
        {
			get { return capacity; }
			set { capacity = value; }
		}

       public bool AddChild(Child child)
		{
			if (childrens.Count < Capacity)
			{
			childrens.Add(child);
			return true;
			}
			return false;
		}
       public bool RemoveChild(string childFullName)
		{
				string[] nameTokens = childFullName.Split(" ",System.StringSplitOptions.RemoveEmptyEntries);
                string firstName = nameTokens[0];
				string familName = nameTokens[1];
			foreach (var children in childrens)
			{
				if (children.FirstName == firstName && children.LastName == familName)
				{ 
                return true; 
				}
			}
				
			return false;
        }

	  public int ChildrenCount { get { return childrens.Count; } }

       public Child GetChild(string childFullName)
		{
            string[] nameTokens = childFullName.Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
            string firstName = nameTokens[0];
            string familName = nameTokens[1];
            foreach (var children in childrens)
            {
                if (children.FirstName == firstName && children.LastName == familName)
                {
                    return children;
                }
            }
            return null;
		}

        public string RegistryReport()
		{
			if (childrens != null)
			{
				childrens = childrens.OrderByDescending(c => c.Age)
					.ThenBy(c => c.LastName)
					.ThenBy(c => c.FirstName)
					.ToList();
				StringBuilder sb = new StringBuilder();
				sb.AppendLine($"Registered children in {Name}:");

				foreach (var child in childrens)
				{
					sb.AppendLine(child.ToString());
				}
			return sb.ToString().Trim();
			}
			return null;
        }
    }
}
