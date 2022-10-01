using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionApp.Utilities.Mapper
{
    public abstract class ModelDtoMapperBase<TModelIn, TDtoOut> where TModelIn : class where TDtoOut : new()
    {
        public abstract TDtoOut MapToDto(TModelIn model);
   

        public IEnumerable<TDtoOut> MapToDto(IEnumerable<TModelIn> modelList)
        {
            foreach(var model in modelList)
            {
                yield return this.MapToDto(model);
            }
        }
    }
}
