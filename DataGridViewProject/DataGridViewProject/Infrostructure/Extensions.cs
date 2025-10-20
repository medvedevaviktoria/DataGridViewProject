using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace DataGridViewProject.Infrostructure
{
    public static class Extensions
    {

        public static void AddBinding<TControl, TSource>(
            this TControl control, // тип элемента управления
            Expression<Func<TControl,object>> destinationProperty, // свойство контрола, которое будет связано
            TSource source, // тип модели данных
            Expression<Func<TSource, object>> sourceProperty, // свойство модели, которое будет связано
            ErrorProvider? errorProvider = null)
            where TControl : Control
            where TSource : class
        {
            var destPropName = GetPropertyName(destinationProperty);
            var sourcePropName = GetPropertyName(sourceProperty);


            var existing = control.DataBindings[destPropName];
            if (existing != null)
                control.DataBindings.Remove(existing);

            var binding = new Binding(destPropName, source, sourcePropName)
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            };

            control.DataBindings.Add(binding);

            if (errorProvider != null)
            {
                var context = new ValidationContext(source); // создаём объект ValidationContext для передачи дополнительной информации о проверяемом объекте source
                var results = new List<ValidationResult>(); // список со всеми найденными ошибками валидации
                if (!Validator.TryValidateObject(source, context, results, true))
                {
                    var propError = results.FirstOrDefault(x => x.MemberNames.Contains(sourcePropName));
                    if (propError != null)
                    {
                        errorProvider.SetError(control, propError.ErrorMessage);
                    }
                }
                else
                {
                    errorProvider.SetError(control, string.Empty);
                }
            }
        }

        /// <summary>
        /// Метод извлечения имени свойства из лямбда-выражения
        /// </summary>
        static string GetPropertyName<TType>(Expression<Func<TType, object>> expression)
        {
            Expression body = expression.Body;
            if (body.NodeType == ExpressionType.Convert)
            {
                body = ((UnaryExpression)body).Operand;
            }

            if (body is MemberExpression memberExpression)
            {
                return memberExpression.Member.Name;
            }

            throw new ArgumentException("Espression must be a property access", nameof(expression));
        }

    }
}
