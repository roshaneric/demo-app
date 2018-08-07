using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NewsCore.Tests.Common
{
    public static class ObjectExtensions
    {
        private static readonly Dictionary<Type, IEnumerable<Tuple<string, Type>>> PropertiesAndFieldsByType = new Dictionary<Type, IEnumerable<Tuple<string, Type>>>();

        private static IEnumerable<Tuple<string, Type>> PropertiesAndFieldsOf<TObject>() where TObject : class
        {
            IEnumerable<Tuple<string, Type>> propertiesAndFields;

            var t = typeof(TObject);
            if (PropertiesAndFieldsByType.TryGetValue(t, out propertiesAndFields))
            {
                return propertiesAndFields;
            }

            var properties = t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Select(_ => new Tuple<string, Type>(_.Name, _.DeclaringType));
            var fields = t.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Select(_ => new Tuple<string, Type>(_.Name, _.DeclaringType));
            PropertiesAndFieldsByType[t] = propertiesAndFields = properties.Concat(fields).Distinct();
            return propertiesAndFields;
        }

        public static TObject Set<TObject>(this TObject o, string property, object value) where TObject : class
        {
            if (o != null)
            {
                var prop = PropertiesAndFieldsOf<TObject>().FirstOrDefault(_ => _.Item1 == property);
                if (prop != null)
                {
                    var accessor = new PrivateObject(o, new PrivateType(prop.Item2));
                    accessor.SetFieldOrProperty(property, value);
                }
            }
            return o;
        }

        public static TSource Set<TSource, TProperty>(this TSource obj, Expression<Func<TSource, TProperty>> propertyExpression, TProperty value) where TSource : class
        {
            if (!(propertyExpression.Body is MemberExpression member))
                throw new ArgumentException($"Expression {propertyExpression} refers to a method, not a property.");

            var propInfo = member.Member;
            return obj.Set(propInfo.Name, value);
        }
    }
}
