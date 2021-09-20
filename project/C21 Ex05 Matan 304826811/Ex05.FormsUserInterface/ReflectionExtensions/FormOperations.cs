using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Ex05.FormsUserInterface
{
	public static class FormOperations
	{
		public static bool HasProperty(this object i_Object, string i_PropertyName)
		{
			return i_Object.GetType().GetProperty(i_PropertyName) != null;
		}

		public static void SetProperty<T>(this object i_Object, string i_PropertyName, T i_ValueToSet)
		{
			PropertyInfo propertyToSet = i_Object.GetType().GetProperty(i_PropertyName, BindingFlags.Public | BindingFlags.Instance);

			if ((propertyToSet != null) && propertyToSet.CanWrite)
			{
				propertyToSet.SetValue(i_Object, i_ValueToSet, null);
			}
		}
	}
}
