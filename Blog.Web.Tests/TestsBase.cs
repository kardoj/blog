using FluentAssertions;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Blog.Web.Tests
{
    public abstract class TestsBase
    {
        public void ShouldHaveCustomAttribute<TAttribute, T>(Expression<Func<T, object>> property)
        {
            var memberExpression = (MemberExpression)property.Body;
            typeof(T).GetProperty(memberExpression.Member.Name).GetCustomAttributes().OfType<TAttribute>().Where(i => true).Should().NotBeEmpty();
        }
    }
}
