using MarbleGameLib.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace MarbleGameLib.Helpers
{
    public class Helper : IHelper
    {
        public Position GetPosition(int i, int j, int k, int z)
        {
            if (i == k)
            {
                if (j > z)
                    return Position.W;
                else
                    return Position.E;
            }
            else
            {
                if (i > k)
                    return Position.N;
                else
                    return Position.S;
            }
        }
        public object DeepClone(object objSource)
        {
            Type typeSource = objSource.GetType();

            object objTarget = Activator.CreateInstance(typeSource);

            PropertyInfo[] propertyInfo = typeSource.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (PropertyInfo property in propertyInfo)
            {
                if (property.CanWrite)
                {
                    if (property.PropertyType.IsValueType || property.PropertyType.IsEnum || property.PropertyType.Equals(typeof(System.String)))
                    {
                        property.SetValue(objTarget, property.GetValue(objSource, null), null);
                    }
                    else
                    {
                        object objPropertyValue = property.GetValue(objSource, null);

                        if (objPropertyValue == null)

                        {

                            property.SetValue(objTarget, null, null);
                        }
                        else
                        {
                            property.SetValue(objTarget, DeepClone(objPropertyValue), null);
                        }
                    }
                }
            }
            return objTarget;
        }
    }
}

