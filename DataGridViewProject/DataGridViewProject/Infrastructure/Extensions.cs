using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace DataGridViewProject.Infrastructure
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
                // Получаем данные валидации свойства из атрибутов
                var sourcePropertyInfo = source.GetType().GetProperty(sourcePropName);
                var validationAttributes = sourcePropertyInfo?.GetCustomAttributes<ValidationAttribute>();

                if (validationAttributes?.Any() == true)
                {
                    // Подписываемся на событие Validating, чтобы выполнять валидацию по необходимости
                    control.Validating += (sender, e) =>
                    {
                        var context = new ValidationContext(source) { MemberName = sourcePropName };
                        var results = new List<ValidationResult>();

                        // Очищаем предыдущие ошибки
                        errorProvider.SetError(control, string.Empty);

                        // Проверяем валидность конкретного свойства
                        var propertyValue = sourcePropertyInfo?.GetValue(source);
                        bool isValid = Validator.TryValidateProperty(propertyValue, context, results);

                        // Если не валидно, проходимся по всем ошибкам и показываем их
                        if (!isValid)
                        {
                            // Выводим только ошибки для этого свойства
                            errorProvider.SetError(control, string.Join("; ", results.Select(r => r.ErrorMessage)));
                        }
                    };
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
