using FluentValidation;
using LudFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudFramework.Core.Aspects.Postsharp.ValidationAspects
{
    [Serializable]
    public class FluentValidationAspect : OnMethodBoundaryAspect
    {
        Type _validatorTpye;
        public FluentValidationAspect(Type validatorType)
        {
            _validatorTpye = validatorType;
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorTpye);
            var entityType = _validatorTpye.BaseType.GetGenericArguments()[0];
            var entities = args.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidatorTool.FluentValidate(validator, entity);
            }
        }

    }
}
