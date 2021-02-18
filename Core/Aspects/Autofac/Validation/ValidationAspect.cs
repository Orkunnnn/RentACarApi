using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Linq;
using System.Reflection;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private readonly Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("Bu bir doğrulama sınıfı değil.");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            IValidator validator;

            if (_validatorType.GetConstructors()[0].GetParameters().Length == 0)
            {
                validator = (IValidator)Activator.CreateInstance(_validatorType);
            }
            else
            {
                var parameterType = _validatorType.GetConstructors()[0].GetParameters()[0].ParameterType;
                var implementedClass = AppDomain.CurrentDomain.GetAssemblies().SelectMany(c => c.GetTypes())
                    .First(p => parameterType.IsAssignableFrom(p));
                var concreteClass = Activator.CreateInstance(implementedClass);
                validator = (IValidator)Activator.CreateInstance(_validatorType, concreteClass);
            }

            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
