using System;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace Samples.Finder.Components.Common.CommonLibrary.Extensions
{
    public static class BindingExtensions
    {
        public static string GetPropertyName<TEntity, TResult>(this TEntity source, Expression<Func<TEntity, TResult>> expression)
            where TEntity : class 
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return GetPropertyName(expression);
        }

        public static string GetPropertyName<TEntity, TResult>(Expression<Func<TEntity, TResult>> expression)
            where TEntity : class
        {
            if (expression.Body.NodeType == ExpressionType.MemberAccess)
            {
                var memberExpression = expression.Body as MemberExpression;
                if (memberExpression == null)
                {
                    //todo: move HARDCODE into the resources
                    throw new NotSupportedException("Can't get property name. Expression body isn't MemberExpression.");
                }
                return memberExpression.Member.Name;
            }
            //todo: move HARDCODE into the resources
            throw new NotSupportedException(
                string.Format("Can't get property name. Unsupported expression body node type {0}.",
                              expression.Body.NodeType));
        }

        public static void AddBinding<TControl, TResult, TSource>(
            this TControl control,
            Expression<Func<TControl, TResult>> controlPropertyAccessor,
            TSource source,
            Expression<Func<TSource, TResult>> sourcePropertyAccessor)
            where TSource : class
            where TControl : Control
        {
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var controlPropertyName = GetPropertyName(controlPropertyAccessor);
            var sourcePropertyName = GetPropertyName(sourcePropertyAccessor);
            var bindingSource = new BindingSource
                                    {
                                        DataSource = source
                                    };
            control.DataBindings.Add(controlPropertyName, bindingSource, sourcePropertyName);
        }
    }
}